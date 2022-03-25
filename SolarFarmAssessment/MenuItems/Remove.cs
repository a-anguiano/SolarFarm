using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarFarmAssessment.MenuItems
{
    class Remove : MenuItem
    {
        public Remove() //fix
        {
            Selector = 4;
            Description = "Remove a Panel";
        }
        public override bool Execute(ConsoleIO ui)
        {
            ui.Display("remove");   //eee
            return true;
        }
    }
}
