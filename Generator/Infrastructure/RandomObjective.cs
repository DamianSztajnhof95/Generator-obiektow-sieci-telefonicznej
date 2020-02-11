using Generator.DAL;
using Generator.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Generator.Infrastructure
{
    public class RandomObjective
    {
        public string[] UpodobaniaStudenta = new string[]
        {
            "police",
            "university",
            "bar",
            "restaurant",
            "shopping_mall",
            "movie_theater"           
        };
        public string[] Upodobaniaturysty = new string[]{
            "police",
            "tourist_attraction",
            "restaurant",
            "church",
           "art_gallery",
            "park"           
        };
        public string[] UpodobaniaKulinarnegoTurysty = new string[]
        {
            "police",
            "restaurant",
            "bar",
            "shopping_mall",
            "cafe"
        };
        public string[] UpodobaniaReligijnegoTurysty = new string[]
        {
            "police",
            "cemetery",
            "church",
            "restaurant"
        };
        public string generateRandomObjective(GeneratorContext context, string type)
        {
            string objectiveType;
            Random random = new Random();
            string objectiveId;
            if (type == "student")
            {
                int randomUpodobanie = random.Next(1, 100);
                if (randomUpodobanie <= 2)
                {
                    objectiveType = UpodobaniaStudenta[0];
                }
                else if (randomUpodobanie <= 52)
                {
                    objectiveType = UpodobaniaStudenta[1];
                }
                else if (randomUpodobanie <= 62)
                {
                    objectiveType = UpodobaniaStudenta[2];
                }
                else if (randomUpodobanie <= 72)
                {
                    objectiveType = UpodobaniaStudenta[3];
                }
                else if(randomUpodobanie<=95)
                {
                    objectiveType = UpodobaniaStudenta[4];
                }
                else
                {
                    objectiveType = UpodobaniaStudenta[5];
                }
                List<Miejsce> objective = context.Locations.Where(g => g.type == objectiveType).ToList();  
                int index = random.Next(objective.Count);
                objective[index].visitCount++;
                objectiveId = objective[index].MiejsceId;
                context.Locations.AddOrUpdate(objective[index]);
                context.SaveChanges();
            }
            else if(type == "zwykłyturysta")
            { 
                int randomUpodobanie = random.Next(1, 100);
                if (randomUpodobanie <= 2)
                {
                    objectiveType = Upodobaniaturysty[0];
                }
                else if (randomUpodobanie <= 30)
                {
                    objectiveType = Upodobaniaturysty[1];
                }
                else if (randomUpodobanie <= 40)
                {
                    objectiveType = Upodobaniaturysty[2];
                }
                else if (randomUpodobanie <= 60)
                {
                    objectiveType = Upodobaniaturysty[3];
                }
                else if (randomUpodobanie <= 80)
                {
                    objectiveType = Upodobaniaturysty[4];
                }
                else 
                {
                    objectiveType = Upodobaniaturysty[5];
                }              
                List<Miejsce> objective = context.Locations.Where(g => g.type == objectiveType).ToList();
                int index = random.Next(objective.Count);
                objective[index].visitCount++;
                objectiveId = objective[index].MiejsceId;
                context.Locations.AddOrUpdate(objective[index]);
                context.SaveChanges();
            }
            else if(type== "kulinarnyturysta")
            {              
                int randomUpodobanie = random.Next(1, 100);
                if (randomUpodobanie <= 2)
                {
                    objectiveType = UpodobaniaKulinarnegoTurysty[0];
                }
                else if (randomUpodobanie <= 40)
                {
                    objectiveType = UpodobaniaKulinarnegoTurysty[1];
                }
                else if (randomUpodobanie <= 70)
                {
                    objectiveType = UpodobaniaKulinarnegoTurysty[2];
                }
                else if (randomUpodobanie <= 85)
                {
                    objectiveType = UpodobaniaKulinarnegoTurysty[3];
                }
                else 
                {
                    objectiveType = UpodobaniaKulinarnegoTurysty[4];
                }              
                List<Miejsce> objective = context.Locations.Where(g => g.type == objectiveType).ToList();
                int index = random.Next(objective.Count);
                objective[index].visitCount++;
                objectiveId = objective[index].MiejsceId;
                context.Locations.AddOrUpdate(objective[index]);
                context.SaveChanges();
            }
            else 
            {                
                int randomUpodobanie = random.Next(1, 100);
                if (randomUpodobanie <= 2)
                {
                    objectiveType = UpodobaniaReligijnegoTurysty[0];
                }
                else if (randomUpodobanie <= 40)
                {
                    objectiveType = UpodobaniaReligijnegoTurysty[1];
                }
                else if (randomUpodobanie <= 80)
                {
                    objectiveType = UpodobaniaReligijnegoTurysty[2];
                }
                else 
                {
                    objectiveType = UpodobaniaReligijnegoTurysty[3];
                }              
                List<Miejsce> objective = context.Locations.Where(g => g.type == objectiveType).ToList();
                int index = random.Next(objective.Count);
                objective[index].visitCount++;
                objectiveId = objective[index].MiejsceId;
                context.Locations.AddOrUpdate(objective[index]);
                context.SaveChanges();
            }
            return objectiveId;
        }
    }
}