using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarFarm.BLL;

namespace SolarFarmAssessment.MenuItems
{
    class Update : MenuItem
    {
        public Update() //fix
        {
            Selector = 3;
            Description = "Update a Panel";
        }
        public override bool Execute(ConsoleIO ui, ValidationID vID)
        {
            ui.Display("update");   ///eee
            return true;
        }
    }
}
