using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarFarmAssessment.MenuItems
{
        public class MenuFactory
        {
            public static Menu GetMainMenu(ConsoleIO ui)
            {
                Menu m = new Menu(ui, "Main Menu");
                m.AddMenuItem(new Exit());
                m.AddMenuItem(new FindPanelsBySection());
                m.AddMenuItem(new Add());
                m.AddMenuItem(new Update());
                m.AddMenuItem(new Remove());

            return m;
            }
        }
}
