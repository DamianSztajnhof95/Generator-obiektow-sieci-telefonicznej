using System;
using System.Collections.Generic;


namespace Generator.Models
{
    public class Duration2
    {
        public int Duration2Id { get; set; }
        public int value { get; set; }
        public int StepId { get; set; }       
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
        public virtual Duration2 duration { get; set; }
        public virtual EndLocation2 end_location { get; set; }
        public virtual StartLocation2 start_location { get; set; }
        public int LegId { get; set; }    
        public TimeSpan actualTime { get; set; }
    }
    public class Leg
    {
        public int LegId { get; set; }
        public virtual List<Step> steps { get; set; }
        public int HumanId { get; set; }
    }
    public class Route
    {   
        public int RouteId { get; set; }
        public virtual List<Leg> legs { get; set; }
        
    }
}