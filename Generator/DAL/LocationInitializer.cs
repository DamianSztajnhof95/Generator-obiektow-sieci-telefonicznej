using Generator.Models;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace Generator.DAL
{
    public class LocationInitializer
    {       
        public  void LoadRoot(GeneratorContext context,string query,string town,int radius)
        {                    
            string nextPageToken = null;
            var locations = new List<Location>();
            do
            {
                LocationRootObject root = LocationProcessor.LoadLocation(query,nextPageToken,town,radius);
                foreach (var i in root.results)
                {
                    locations.Add(new Location() { LocationId = i.place_id, Lat = i.geometry.location.lat,
                        Lng = i.geometry.location.lng, Name = i.name, visitCount = 0, type = query });
                }
                nextPageToken = root.next_page_token;
            }
            while (nextPageToken != null);           
                locations.ForEach(g => context.Locations.AddOrUpdate(g));
                context.SaveChanges();
        }
    }
}