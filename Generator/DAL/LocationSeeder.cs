
namespace Generator.DAL
{
    public class LocationSeeder
    {
        public LocationInitializer initializer = new LocationInitializer();
        public string[] locationTypes = new string[]
        {
            "train_station",
            "tourist_attraction",
            "church" ,
            "hospital" ,
            "restaurant" ,
            "university" ,
            "art_gallery",
            "shopping_mall",
            "park",
            "movie_theater",
            "bar",
            "night_club",
            "police",
            "cemetery",
            "amusement_park",
            "cafe",
            "lodging",
        };
        public void SeedDatabaseWithLocations(GeneratorContext context,string town,int radius)
        {
            for(int i = 0; i <= locationTypes.Length-1; i++)
            {
                initializer.LoadRoot(context, locationTypes[i], town, radius);
            }            
        }
    }
}