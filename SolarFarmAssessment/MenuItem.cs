using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarFarm.BLL;

namespace SolarFarmAssessment
{
    public abstract class MenuItem
    {
        public string Description { get; set; }
        public int Selector { get; set; }    
        public abstract bool Execute(ConsoleIO ui, ValidationID vID);

        //public abstract bool Execute2(ConsoleIO ui, ValidationID vID);
    }
}
