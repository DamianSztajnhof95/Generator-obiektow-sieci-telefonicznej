

namespace Generator.Models
{
    public class Location
    {       
        public string LocationId { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Name { get; set; }
        public int visitCount { get; set; }
        public string type { get; set; }
    } 
}