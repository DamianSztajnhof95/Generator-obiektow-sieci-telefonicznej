using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generator.Models
{
    public class Human
    {
       
        public int HumanId { get; set; }
              
        public string LocomotionType { get; set; }
        public int HumanTypeId { get; set; }

        public List<Route> HumanRoutes { get; set; } 
    }
}