using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generator.Models
{

    public class Root
    {        
        public virtual List<Route> routes { get; set; }
        public virtual List<SnappedPoint> snappedPoints { get; set; }       
    }
}