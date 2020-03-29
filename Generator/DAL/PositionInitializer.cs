using Generator.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Generator.DAL
{
    public class PositionInitializer
    {       
        public Random random = new Random();        
        TrafficGenerator traffic = new TrafficGenerator();
        public string[] locomotionTypes = new string[]
        {
            "&mode=walking",
            ""
        };       
        public void SaveRouteInDb(GeneratorContext context,int numberOfObjects)
        {
            HumanType[] humanTypes = context.humanTypes.Include(x=>x.humanLikings).ToArray();
            for (int humanNumber =0; humanNumber <= numberOfObjects-1; humanNumber++) 
            {
                Human human = new Human();
                human.humanType = humanTypes[random.Next(humanTypes.Length)];
                human.LocomotionType = locomotionTypes[random.Next(locomotionTypes.Length)];                             
                human= traffic.generateTraffic(context, human);
                if (human.HumanRoutes == null)
                {
                    numberOfObjects--;
                }
                context.People.AddOrUpdate(human);
                context.SaveChanges();                               
            }           
        }     
    }
}