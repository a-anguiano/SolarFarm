using System;
using SolarFarm.BLL;
using SolarFarm.Core.DTO;
using SolarFarm.Core.Interfaces;
using SolarFarmAssessment;
using SolarFarmAssessment.MenuItems;
using System.IO;
using SolarFarm.DAL;

namespace SolarFarmAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvPath = Directory.GetCurrentDirectory() + @"\Data\Panels.csv";
            IPanelFormatter csvFormat = new PanelCSVFormatter();

            PanelRepository csv = new PanelRepository();
            csv.fmt = csvFormat;
            csv.Path = csvPath;

            ConsoleIO ui = new ConsoleIO();
            Menu menu = MenuFactory.GetMainMenu(ui);

            IPanelService service = PanelServiceFactory.GetPanelService();
            menu.Service = service;
            menu.Run();
        }
    }
}
