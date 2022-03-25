using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarFarmAssessment.MenuItems
{
    class Update : MenuItem
    {
        public Update() //fix
        {
            Selector = 3;
            Description = "Update a Panel";
        }
        public override bool Execute(ConsoleIO ui)
        {
            ui.Display("update");   ///eee
            return true;
        }
    }
}
