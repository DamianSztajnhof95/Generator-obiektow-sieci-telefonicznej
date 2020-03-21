using Generator.Infrastructure;
using Generator.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

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
            HumanType[] humanTypes = context.humanTypes.ToArray();
            for (int humanNumber =0; humanNumber <= numberOfObjects-1; humanNumber++) 
            {
                Human human = new Human();
                human.LocomotionType = locomotionTypes[random.Next(locomotionTypes.Length)];
                human.HumanTypeId = humanTypes[random.Next(humanTypes.Length)].HumanTypeId;                               
                human= traffic.generateTraffic(context, human);                               
                context.People.AddOrUpdate(human);
                context.SaveChanges();
                               
            }           
        }     
    }
}