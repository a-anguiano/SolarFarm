using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarFarm.BLL;

namespace SolarFarmAssessment.MenuItems
{
    class Exit : MenuItem
    {
        public Exit()
        {
            Selector = 0;
            Description = "Exit";
        }
        public override bool Execute(ConsoleIO ui, ValidationID vID)
        {
            ui.Display("Goodbye!");
            return false;
        }
    }
}
