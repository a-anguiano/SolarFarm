using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarFarmAssessment
{
    public class Menu
    {
        public string Name { get; set; }
        public List<MenuItem> MenuItems { get; }
        private ConsoleIO _ui;
        public Menu(ConsoleIO ui, string name)
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
            while (running)
            {
                DisplayMenu();
                int selection = _ui.GetInt("Select [0-4]");

                foreach (MenuItem mi in MenuItems)
                {
                    if (mi.Selector == selection)
                    {
                        running = mi.Execute(_ui);
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

            _ui.Display("");
        }
    }
}
