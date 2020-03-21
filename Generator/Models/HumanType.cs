﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generator.Models
{
    public class HumanType
    {
        

        public int HumanTypeId { get; set; }
        public string HumanTypeName { get; set; }
        public ICollection<Human> humans { get; set; }
        public ICollection<HumanTypeLiking> humanLikings { get; set; }
        public string color { get; set; }
        public int numberOfLocations { get; set; }
        
    }
}