using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarFarm.BLL;

namespace SolarFarmAssessment.MenuItems
{
    class FindPanelsBySection : MenuItem
    {
        public FindPanelsBySection()
        {
            Selector = 1;
            Description = "Find Panels by Section";
        }
        public override bool Execute(ConsoleIO ui, ValidationID vID)
        {
            ui.Display("section");  //eee
            return true;
        }
    }
}
