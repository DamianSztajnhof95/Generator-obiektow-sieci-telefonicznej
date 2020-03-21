using Generator.Infrastructure;
using Generator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Generator.DAL
{
    public class TrafficGenerator
    {
        public Human generateTraffic(GeneratorContext context, Human human)
        {            
            RandomObjective randomObjective = new RandomObjective();                       
            string url = "";
            List<Location> noclegi = context.Locations.Where(g => g.type == "lodging").ToList();
            var random = new Random();//zainicjowanie generatora liczb losowych    
            int actualTime = random.Next(25200, 32000);
            Location nocleg = noclegi[random.Next(noclegi.Count)];//wybranie noclegu o losowym indeksie
            var humanTypes = context.humanTypes;
            var humanType = humanTypes.Where(g => human.HumanTypeId == g.HumanTypeId).FirstOrDefault();
            humanType.humanLikings = context.humanTypeLikings.Where(g => g.humanTypeId == human.HumanTypeId).ToArray();
            string Objective = randomObjective.generateRandomObjective(context, humanType.humanLikings.ToArray());
            url = $"https://maps.googleapis.com/maps/api/directions/json?origin=place_id:" +
                $"{nocleg.LocationId}&destination=place_id:{Objective}&key=AIzaSyA5jOPVeNOqU6lLscGSE3t665ejKNjrGQI";
            Route route = HttpSinglePathGenerator.GetSinglePath(url);
            foreach(var i in route.legs.First().steps)
            {
                actualTime += i.duration.value;
                if (actualTime > 86400)
                {
                    actualTime = actualTime - 86400;
                    }
                i.actualTime = TimeSpan.FromSeconds(actualTime) ;
                actualTime += random.Next(1800, 7200);                
            }
            human.HumanRoutes = new List<Route>();
            human.HumanRoutes.Add(route);
            for (int j = 0; j < humanType.numberOfLocations-1; j++)
            {
                string newObjective = randomObjective.generateRandomObjective(context, humanType.humanLikings.ToArray());
                url = $"https://maps.googleapis.com/maps/api/directions/json?origin=place_id:" +
                    $"{Objective}&destination=place_id:{newObjective}&key=AIzaSyA5jOPVeNOqU6lLscGSE3t665ejKNjrGQI";
                route = HttpSinglePathGenerator.GetSinglePath(url);
                foreach(var i in route.legs.First().steps)
                {
                    actualTime += i.duration.value;
                    if(actualTime> 86400)
                    {
                        actualTime = actualTime - 86400;
                    }
                    i.actualTime = TimeSpan.FromSeconds(actualTime);
                }
                human.HumanRoutes.Add(route);
                Objective = newObjective;
                actualTime += random.Next(1800, 7200);
            }
            url = $"https://maps.googleapis.com/maps/api/directions/json?origin=place_id:" +
                $"{Objective}&destination=place_id:{nocleg.LocationId}&key=AIzaSyA5jOPVeNOqU6lLscGSE3t665ejKNjrGQI";
            route = HttpSinglePathGenerator.GetSinglePath(url);
            foreach (var i in route.legs.First().steps)
            {               
                actualTime += i.duration.value;
                if (actualTime > 86400)
                {
                    actualTime = actualTime - 86400;
                    }
                i.actualTime = TimeSpan.FromSeconds(actualTime);
            }
            human.HumanRoutes.Add(route);           
            return human;
        }
    }
}