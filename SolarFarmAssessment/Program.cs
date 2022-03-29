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
            const string dataDir = "../data/";
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
