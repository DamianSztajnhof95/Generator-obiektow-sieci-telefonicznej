using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generator.Models
{

    public class AllHumansPositions
    {
        public AllHumansPositions()
        {
            this.fullTable = new List<HumanPositions>();
        }
        public List<HumanPositions> fullTable { get; set; }
    }
}