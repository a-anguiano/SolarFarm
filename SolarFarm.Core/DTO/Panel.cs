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
        public int Year { get; set; }   //int or DateTime
        // Material
        public bool IsTracking { get; set; }
    }
}
