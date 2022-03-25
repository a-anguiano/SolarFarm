using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarFarmAssessment
{
    public abstract class MenuItem
    {
        public string Description { get; set; }
        public int Selector { get; set; }    //changed to int
        public abstract bool Execute(ConsoleIO ui);
    }
}
