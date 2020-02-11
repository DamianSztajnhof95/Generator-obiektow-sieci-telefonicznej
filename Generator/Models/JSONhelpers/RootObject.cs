using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generator.Models
{
    public class Distance
    {
        
        public int value { get; set; }
    }
    public class Duration
    {
        
        public int value { get; set; }
    }

    public class EndLocation
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class StartLocation
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Distance2
    {
       
        public int value { get; set; }
    }

    public class Duration2
    {
        
        public int value { get; set; }
    }

    public class EndLocation2
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Polyline
    {
        public string points { get; set; }
    }

    public class StartLocation2
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Step
    {
        public Distance2 distance { get; set; }
        public Duration2 duration { get; set; }
        public EndLocation2 end_location { get; set; }
        
        
        public StartLocation2 start_location { get; set; }
       
        
    }

    public class Leg
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        
        public EndLocation end_location { get; set; }
        
        public StartLocation start_location { get; set; }
        public List<Step> steps { get; set; }
       
    }

    public class OverviewPolyline
    {
        public string points { get; set; }
    }

    public class Route
    {
        public List<Leg> legs { get; set; }
        public OverviewPolyline overview_polyline { get; set; }
      
       
        
    }

    public class RootObject
    {
        
        public List<Route> routes { get; set; }
        public List<SnappedPoint> snappedPoints { get; set; }

       
    }
}