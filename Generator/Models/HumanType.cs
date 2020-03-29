
using System.Collections.Generic;


namespace Generator.Models
{
    public class HumanType
    {        
        public int HumanTypeId { get; set; }
        public string HumanTypeName { get; set; }
        public virtual ICollection<Human> humans { get; set; }
        public virtual ICollection<HumanTypeLiking> humanLikings { get; set; }
        public string color { get; set; }
        public int numberOfLocations { get; set; }        
    }
}