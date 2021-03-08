
using System.Collections.Generic;


namespace Generator.Models
{

    public class Root
    {        
        public virtual List<Route> routes { get; set; }
        public virtual List<SnappedPoint> snappedPoints { get; set; }       
    }
}