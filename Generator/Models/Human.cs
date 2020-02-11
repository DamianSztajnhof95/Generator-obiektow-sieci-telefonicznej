using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generator.Models
{
    public class Human
    {
        public int HumanId { get; set; }
        public string HumanType { get; set; }       
        
        
        public ICollection<Pozycja> Pozycje { get; set; }
        
    }
}