using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generator.Models
{
    public class Duration2
    {
        public int Duration2Id { get; set; }
        public string text { get; set; }
        public int value { get; set; }
       
    }
    public class EndLocation2
    {
        public int EndLocation2Id { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }


    }
    public class StartLocation2
    {
        public int StartLocation2Id { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }

        
    }
    public class Step
    {
        public int StepId { get; set; }
        public Duration2 duration { get; set; }
        public EndLocation2 end_location { get; set; }
        public StartLocation2 start_location { get; set; }
        public int LegId { get; set; }
    
        public TimeSpan actualTime { get; set; }
    }
    public class Leg
    {
        public int LegId { get; set; }
        public List<Step> steps { get; set; }
        public int RouteId { get; set; }
    }
    public class Route
    {   
        public int RouteId { get; set; }
        public List<Leg> legs { get; set; }
        public int HumanId { get; set; }
    }
}