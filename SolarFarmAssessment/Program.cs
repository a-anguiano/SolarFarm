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
            string jsonPath = Directory.GetCurrentDirectory() + @"\Data\Panels.json";

            IPanelFormatter csvFormat = new PanelCSVFormatter();
            IPanelFormatter jsonFormat = new PanelJSONFormatter();

            PanelRepository csv = new PanelRepository();
            csv.Fmt = csvFormat;
            csv.Path = csvPath;

            PanelRepository json = new PanelRepository();
            json.Fmt = jsonFormat;
            json.Path = jsonPath;

            // Copy from csv format to json (one record per line) format
            json.WriteAll(csv.GetAll().Data);

            //string csvPath2 = Directory.GetCurrentDirectory() + @"\Data\Panels2.csv";
            //PanelRepository csv2 = new PanelRepository();
            //csv2.fmt = csvFormat;
            //csv2.Path = csvPath2;


            //Copy from json (one record per line) to csv in a secondary csv file
            //csv2.WriteAll(json.GetAll().Data);

            ConsoleIO ui = new ConsoleIO();
            Menu menu = MenuFactory.GetMainMenu(ui);

            IPanelService service = PanelServiceFactory.GetPanelService();
            menu.Service = service;
            menu.Run();
        }
    }
}
