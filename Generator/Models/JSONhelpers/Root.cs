using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generator.Models
{

    public class Root
    {        
        public List<Route> routes { get; set; }
        public List<SnappedPoint> snappedPoints { get; set; }       
    }
}