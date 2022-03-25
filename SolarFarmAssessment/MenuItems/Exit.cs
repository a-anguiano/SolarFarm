using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarFarmAssessment.MenuItems
{
    class Exit : MenuItem
    {
        public Exit()
        {
            Selector = 0;
            Description = "Quit";
        }
        public override bool Execute(ConsoleIO ui)
        {
            ui.Display("Goodbye!");
            return false;
        }
    }
}
