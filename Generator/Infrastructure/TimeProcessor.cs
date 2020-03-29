using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generator.Infrastructure
{
    public class TimeProcessor
    {
        public static int calculateTime(int actualTime,int duration)
        {
            actualTime += duration;
            if (actualTime > 86400)
            {
                actualTime = actualTime - 86400;
            }

            return actualTime;
        }
    }
}