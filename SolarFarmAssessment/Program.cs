using System;
using SolarFarm.BLL;
using SolarFarm.Core.DTO;
using SolarFarm.Core.Interfaces;
using SolarFarmAssessment;
using SolarFarmAssessment.MenuItems;

namespace SolarFarmAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleIO ui = new ConsoleIO();
            Menu menu = MenuFactory.GetMainMenu(ui);

            IPanelService service = PanelServiceFactory.GetPanelService();
            menu.Service = service;   //Service = service;
            menu.Run();
        }
    }
}
