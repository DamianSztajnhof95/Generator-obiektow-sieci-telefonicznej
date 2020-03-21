using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generator.Models
{
    public class HumanTypeLiking
    {
        
        public int humanTypeLikingId { get; set; }
        public string humanTypeLikingName { get; set; }
        public int probability { get; set; }
        public int humanTypeId { get; set; }
    }
}