﻿using System.Collections.Generic;

namespace Generator.Models
{    
    public class HumanPositions
    {
        public HumanPositions()
        {
            this.pozycje = new List<SingleHumanPosition>();
        }
        public string humantype { get; set; }
        public string color { get; set; }
        public List<SingleHumanPosition> pozycje { get; set; }        
    }
}