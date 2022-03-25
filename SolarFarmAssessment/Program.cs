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

            //ApplicationMode mode = menu.Setup();  //Get test vs live mode
            //IRecordService service = RecordServiceFactory.GetRecordService(mode);
            //menu.Service = service;
            menu.Run();    //Do the thing!
        }
    }
}
