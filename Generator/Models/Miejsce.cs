using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Generator.Models
{
    public class Miejsce
    {
       
        public string MiejsceId { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Name { get; set; }
        public int visitCount { get; set; }
        public string type { get; set; }

    }
  
}