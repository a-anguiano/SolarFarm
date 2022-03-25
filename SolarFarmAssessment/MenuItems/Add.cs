using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarFarmAssessment.MenuItems
{
    class Add : MenuItem
    {
        public Add()    //fix
        {
            Selector = 2;
            Description = "Add a Panel";
        }
        public override bool Execute(ConsoleIO ui)
        {
            ui.Display("add");  //eee
            return true;
        }
    }
}
