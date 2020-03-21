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
        private string GetLocationId(GeneratorContext context, string objectiveType)
        {
            Random random = new Random();
            string objectiveId;
            Location[] objective = context.Locations.Where(g => g.type == objectiveType).ToArray();
            if (objective == null)
            {
                objective = context.Locations.ToArray();
            }
            int index = random.Next(objective.Length-1);
            string o = objectiveType;
            objective[index].visitCount++;
            objectiveId = objective[index].LocationId;
            context.Locations.AddOrUpdate(objective[index]);
            context.SaveChanges();
            return objectiveId;
        }
        public string generateRandomObjective(GeneratorContext context, HumanTypeLiking[] likings)
        {
            string objectiveId = "";
            int probability = 0;
            Random random = new Random();
            int randomUpodobanie = random.Next(1, 100);
            for (int i = 0; i <= likings.Length - 1; i++)
            {
                probability += likings[i].probability;
                if (probability >= randomUpodobanie)
                {
                    objectiveId = GetLocationId(context, likings[i].humanTypeLikingName);
                    i = likings.Length;
                }
            }
            return objectiveId;
        }
    }
}