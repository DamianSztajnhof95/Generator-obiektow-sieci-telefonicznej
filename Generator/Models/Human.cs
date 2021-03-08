
using System.Collections.Generic;


namespace Generator.Models
{
    public class Human
    {       
        public int HumanId { get; set; }              
        public string LocomotionType { get; set; }
        public HumanType humanType { get; set; }
        public virtual List<Leg> HumanRoutes { get; set; } 
    }
}