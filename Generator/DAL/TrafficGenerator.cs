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
        public List<string> generateTrafficUrls(GeneratorContext context)
        {                
            List<string> allTraffic = new List<string>();
            //Ile obiektów do wygenerowania
            for(int i = 0; i < 1000; i++)
            { 
                RandomObjective randomObjective = new RandomObjective();
                string url = "";
                string type;
                string locomitionType;              
                List<Miejsce> noclegi = context.Locations.Where(g => g.type == "lodging").ToList();
                var random = new Random();
                int index = random.Next(noclegi.Count);
                Miejsce nocleg = noclegi[index];
                int typ = random.Next(0, 4);                
                int it;
                int randomlocomotionType = random.Next(0, 2);
                if (randomlocomotionType == 1)
                {
                    locomitionType = "&mode=Walking";                 
                }
                else
                {
                    locomitionType = "";                  
                }
               
                if (typ == 1)
                {
                    type = "student";
                    it = random.Next(2, 4);
                    url = $"shttps://maps.googleapis.com/maps/api/directions/json?{locomitionType}&origin=place_id:{nocleg.MiejsceId}&destination=place_id:{nocleg.MiejsceId}&waypoints=";
                }
                else if(typ==2)
                {
                    type = "religijnyturysta";
                    it = random.Next(3, 7);
                    url = $"rhttps://maps.googleapis.com/maps/api/directions/json?{locomitionType}&origin=place_id:{nocleg.MiejsceId}&destination=place_id:{nocleg.MiejsceId}&waypoints=";
                }
                else if (typ == 3)
                {
                    it = random.Next(3, 7);
                    type = "kulinarnyturysta";
                    url = $"khttps://maps.googleapis.com/maps/api/directions/json?{locomitionType}&origin=place_id:{nocleg.MiejsceId}&destination=place_id:{nocleg.MiejsceId}&waypoints=";
                }
                else
                {
                    it = random.Next(3, 7);
                    type = "zwykłyturysta";
                    url = $"zhttps://maps.googleapis.com/maps/api/directions/json?{locomitionType}&origin=place_id:{nocleg.MiejsceId}&destination=place_id:{nocleg.MiejsceId}&waypoints=";
                }                
                for (int j = 0; j < it; j++)
                {
                    if (j != 0)
                    {
                        url = url + "|place_id:" + randomObjective.generateRandomObjective(context, type);
                    }
                    else
                    {
                        url = url +"place_id:"+ randomObjective.generateRandomObjective(context, type);
                    }
                }
                url = url + "&key=AIzaSyA5jOPVeNOqU6lLscGSE3t665ejKNjrGQI";
                allTraffic.Add(url);
            }
            return allTraffic;
        }
    }
}