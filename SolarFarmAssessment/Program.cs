using System;
using SolarFarm.BLL;
using SolarFarm.Core.DTO;
using SolarFarm.Core;
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
            const string dataDir = @"C:\Users\19722\Code\M03\SolarFarmAssessment\SolarFarmAssessment\Data\";

            const string dataFile = "Panels.csv";
            IPanelRepository repository;

            Directory.CreateDirectory(dataDir);
            repository = new PanelRepository(dataDir + dataFile);
            ValidationID vID = new ValidationID();

            var service = new PanelService(repository, vID);            
            ConsoleIO ui = new ConsoleIO();

            Menu menu = MenuFactory.GetMainMenu(ui, service);
            menu.Run();         
        }
    }
}
