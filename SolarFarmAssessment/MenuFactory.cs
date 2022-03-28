using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarFarm.BLL;
using SolarFarm.Core;

namespace SolarFarmAssessment.MenuItems
{
        public class MenuFactory
        {
            public static Menu GetMainMenu(ConsoleIO ui, PanelService service)
            {
                Menu m = new Menu(ui, service, "Main Menu");
                m.AddMenuItem(new Exit());
                m.AddMenuItem(new FindPanelsBySection(service));
                m.AddMenuItem(new Add(service));
                m.AddMenuItem(new Update(service));
                m.AddMenuItem(new Remove(service));

            return m;
            }
        }
}
