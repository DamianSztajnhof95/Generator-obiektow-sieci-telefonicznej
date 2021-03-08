using Generator.Infrastructure;
using Generator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Generator.DAL
{
    public class TrafficGenerator
    {
        public Human generateTraffic(GeneratorContext context, Human human)
        {            
            RandomObjective randomObjective = new RandomObjective();                       
            List<Location> noclegi = context.Locations.Where(g => g.type == "lodging").ToList();
            var random = new Random();//zainicjowanie generatora liczb losowych    
            int actualTime = random.Next(21600, 43200);
            Location nocleg;
            Leg leg = null;
            string objective;
            do
            {
                nocleg = noclegi[random.Next(noclegi.Count)];//wybranie noclegu o losowym indeksie                       
                objective = randomObjective.generateRandomObjective
                    (context, human.humanType.humanLikings.ToArray());
                leg = HttpSinglePathGenerator.GetSinglePath(nocleg.LocationId, objective);
               
            } while (leg==null);
            foreach (var i in leg.steps )
            {
                i.actualTime = TimeSpan.FromSeconds(
                    TimeProcessor.calculateTime(actualTime, i.duration.value));                
            }
            actualTime += random.Next(1800, 7200);
            human.HumanRoutes = new List<Leg>();
            human.HumanRoutes.Add(leg);
            int howManyLocation = random.Next(1,human.humanType.numberOfLocations);
            for (int j = 0; j <= howManyLocation-1; j++)
            {
                string newObjective = randomObjective.generateRandomObjective
                    (context, human.humanType.humanLikings.ToArray());
                leg = HttpSinglePathGenerator.GetSinglePath(objective,newObjective);
                 if (leg == null)
                {
                    howManyLocation--;
                }
                else
                {
                    foreach (var i in leg.steps)
                    {
                        i.actualTime = TimeSpan.FromSeconds(
                            TimeProcessor.calculateTime(actualTime, i.duration.value));
                    }
                    human.HumanRoutes.Add(leg);
                    objective = newObjective;
                    actualTime += random.Next(1800, 7200);
                }             
            }
            leg = HttpSinglePathGenerator.GetSinglePath(objective, nocleg.LocationId);
            if (leg == null)
            {
                return null;
            }
            foreach (var i in leg.steps)
            {
                i.actualTime = TimeSpan.FromSeconds(
                    TimeProcessor.calculateTime(actualTime, i.duration.value));
            }
            human.HumanRoutes.Add(leg);           
            return human;
        }
    }
}