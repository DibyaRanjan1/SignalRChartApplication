using SignalRChartApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChartApplication.Storage
{
    public class DataManager
    {
        public static List<Chart> GetData()
        {
            var r = new Random();
            return new List<Chart>()
        {
           new Chart { Data = new List<int> { r.Next(1, 40) }, Label  = "Data1" },
           new Chart {Data = new List<int> { r.Next(1, 40) }, Label  = "Data2" },
           new Chart {Data = new List<int> { r.Next(1, 40) }, Label  = "Data3" },
           new Chart {Data = new List<int> { r.Next(1, 40) }, Label  = "Data4" }
        }; 
        }
    }
}
