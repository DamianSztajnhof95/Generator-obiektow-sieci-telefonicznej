using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generator.Models
{
    public class Pozycja
    {
        public int PozycjaId { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public TimeSpan actualTime { get; set; }
        public int HumanId { get; set; }

    }
}