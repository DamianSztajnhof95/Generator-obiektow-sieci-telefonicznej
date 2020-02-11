using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Generator.DAL
{
    public class LocationSeeder
    {
        public LocationInitializer initializer = new LocationInitializer();
        public void SeedDatabaseWithLocations(GeneratorContext context)
        {
            initializer.LoadRoot(context, "church");
            initializer.LoadRoot(context, "hospital");            
            initializer.LoadRoot(context, "restaurant");           
            initializer.LoadRoot(context, "university");
            initializer.LoadRoot(context, "art_gallery");        
            initializer.LoadRoot(context, "tourist_attraction");        
            initializer.LoadRoot(context, "shopping_mall");        
            initializer.LoadRoot(context, "park");        
            initializer.LoadRoot(context, "movie_theater");            
            initializer.LoadRoot(context, "bar");           
            initializer.LoadRoot(context, "night_club");         
            initializer.LoadRoot(context, "police");
            initializer.LoadRoot(context, "cemetery");
            initializer.LoadRoot(context, "amusement_park");
            initializer.LoadRoot(context, "train_station");
            initializer.LoadRoot(context, "cafe");
        }
    }
}