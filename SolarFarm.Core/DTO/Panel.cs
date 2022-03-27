using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarFarm.Core.DTO
{
    public class Panel
    {
        public string Section { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public DateTime Year { get; set; } 
        public int Material { get; set; }        
        public string IsTracking { get; set; }      //string, or um bool?, display as string
    }
}
