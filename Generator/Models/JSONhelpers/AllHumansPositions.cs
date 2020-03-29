using System.Collections.Generic;

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