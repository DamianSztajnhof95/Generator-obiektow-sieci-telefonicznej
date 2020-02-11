using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generator.Models
{
    
    public class HumanPositions
    {
        public HumanPositions()
        {
            this.pozycje = new List<SingleHumanPosition>();
        }
        public string humantype { get; set; }
        public List<SingleHumanPosition> pozycje { get; set; }
        
    }
}