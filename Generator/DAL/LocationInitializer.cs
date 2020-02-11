using Generator.Infrastructure;
using Generator.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Generator.DAL
{
    public class LocationInitializer
    {      
        public  void LoadRoot(GeneratorContext context,string query)
        {            
            var locations = new List<Miejsce>();
                LocationRootObject root = LocationProcessor.LoadLocation(query);
                foreach (var i in root.results)
                {
                    locations.Add(new Miejsce() { MiejsceId = i.place_id, Lat = i.geometry.location.lat, Lng = i.geometry.location.lng, Name = i.name, visitCount = 0, type = query });
                }
                locations.ForEach(g => context.Locations.AddOrUpdate(g));
                context.SaveChanges();
        }
    }
}