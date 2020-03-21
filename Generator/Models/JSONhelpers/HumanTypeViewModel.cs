using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generator.Models
{
    public class HumanTypeViewModel
    {
        public string HumanTypeName { get; set; }
        public string HumanLikings { get; set; }
        public string probabilities { get; set; }
        public string color { get; set; }
        public int NumberOfLocations { get; set; }
    }
}