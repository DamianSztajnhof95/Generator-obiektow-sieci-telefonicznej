using Generator.Infrastructure;
using Generator.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Generator.DAL
{
    public class PositionInitializer
    {
        public Random random = new Random();
        int actualTime;
        int legCount;
        int stepsCount;
        public void SaveRouteInDb(GeneratorContext context, string query)
        {
            char typeId = query[0];            
            query=query.Substring(1);
            RootObject root = new RootObject();
              actualTime = random.Next(21600, 43200);
            var positions = new List<Pozycja>();
            RootObject rootChecked = HttpSinglePathGenerator.GetSinglePath(query);
            if(rootChecked.routes == null)
            {
                return;
            }
            root = rootChecked;
            int rootCount = root.routes.Count;       
            foreach (var i in root.routes)
            {
                legCount = i.legs.Count;
                foreach(var j in i.legs)
                {
                    stepsCount = j.steps.Count;                    
                    actualTime = actualTime + random.Next(1200, 7200);
                    foreach(var k in j.steps)
                    {
                        actualTime = actualTime + k.duration.value;
                        positions.Add(new Pozycja { Lat = k.start_location.lat, Lng = k.start_location.lng, actualTime = TimeSpan.FromSeconds(actualTime) });
                    }
                }               
            }
            var lastRoute = root.routes[rootCount-1].legs[legCount-1].steps[stepsCount-1];
            positions.Add(new Pozycja { Lat = lastRoute.end_location.lat, Lng = lastRoute.end_location.lng, actualTime = TimeSpan.FromSeconds(actualTime + lastRoute.duration.value) });
            Human human = new Human();
            if (typeId=='s')
            {
                human.HumanType = "student";
            }
            else if(typeId=='z')
            {
                human.HumanType = "zwykłyturysta";
            }
            else if (typeId == 'r')
            {
                human.HumanType = "religijnyturysta";
            }
            else
            {
                human.HumanType = "kulinarnyturysta";
            }
            human.Pozycje = positions;
            context.People.AddOrUpdate(human);
            context.SaveChanges();
        }
    }
}