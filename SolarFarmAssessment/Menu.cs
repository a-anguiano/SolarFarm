using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarFarm.BLL;
using SolarFarm.Core.Interfaces;
using SolarFarm.Core.DTO;

namespace SolarFarmAssessment
{
    public class Menu       //consider renaming to MenuController
    {
        public string Name { get; set; }
        public IPanelService Service { get; set; }      //hmmmm, unneccessary?
        public List<MenuItem> MenuItems { get; }
        private ConsoleIO _ui;
        private ValidationID _vID;      //consider this
        public Menu(ConsoleIO ui, PanelService service, string name)
        {
            MenuItems = new List<MenuItem>();
            _ui = ui;
            Name = name;
        }

        public void AddMenuItem(MenuItem menuItem)
        {
            MenuItems.Add(menuItem);
        }

        public void Run()
        {
            _ui.Display("Welcome to Solar Farm");
            _ui.Display("=====================\n");

            bool running = true;
           //string section = "Upper Hill";  //testing

            while (running)
            {
                DisplayMenu();
                int selection = _ui.GetInt("Select [0-4]");
                foreach (MenuItem mi in MenuItems)
                {
                    if (mi.Selector == selection)
                    {
                        running = mi.Execute(_ui, _vID);
                        break;
                    }
                }
            }
        }
                 
        public void DisplayMenu()
        {
            _ui.Display(Name);
            _ui.Display(new string('=', Name.Length));

            foreach (MenuItem mi in MenuItems)
            {
                _ui.Display($"{mi.Selector} - {mi.Description}");
            }
        }
    }
}
