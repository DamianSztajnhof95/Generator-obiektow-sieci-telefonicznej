using Generator.Infrastructure;
using Generator.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            List<Location> noclegi = context.Locations.Where(g => g.type == "lodging").ToList();
            var random = new Random();//zainicjowanie generatora liczb losowych    
            int actualTime = random.Next(25200, 32000);
            Location nocleg = noclegi[random.Next(noclegi.Count)];//wybranie noclegu o losowym indeksie
            var humanTypes = context.humanTypes.Include(g => g.humanLikings).ToArray();
            var humanType = humanTypes[random.Next(humanTypes.Count()- 1)];
            human.HumanTypeId = humanType.HumanTypeId;
            humanType.humanLikings = context.humanTypeLikings.Where(g => g.humanTypeId == human.HumanTypeId).ToArray();
            string objective = randomObjective.generateRandomObjective(context, humanType.humanLikings.ToArray());            
            Route route = HttpSinglePathGenerator.GetSinglePath(nocleg.LocationId,objective);
            foreach (var i in route.legs.First().steps)
            {
                actualTime += i.duration.value;
                if (actualTime > 86400)
                {
                    actualTime = actualTime - 86400;
                }
                i.actualTime = TimeSpan.FromSeconds(actualTime);
                actualTime += random.Next(1800, 7200);
            }
            human.HumanRoutes = new List<Route>();
            human.HumanRoutes.Add(route);
            for (int j = 0; j < humanType.numberOfLocations-1; j++)
            {
                string newObjective = randomObjective.generateRandomObjective(context, humanType.humanLikings.ToArray());

                route = HttpSinglePathGenerator.GetSinglePath(objective,newObjective);

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
                objective = newObjective;
                actualTime += random.Next(1800, 7200);
            }

            route = HttpSinglePathGenerator.GetSinglePath(objective, nocleg.LocationId);
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