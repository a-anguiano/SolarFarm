using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarFarm.BLL;
using SolarFarm.Core.Interfaces;
using SolarFarm.Core.DTO;

namespace SolarFarmAssessment.MenuItems
{
    class Remove : MenuItem
    {
        private readonly IPanelService Service;
        public Remove(IPanelService panelService)
        {
            Selector = 4;
            Description = "Remove a Panel";
            Service = panelService;
        }

        public override bool Execute(ConsoleIO ui, PanelService svc, ValidationID vID)
        {
            Console.Clear();
            ui.Display("Remove a Panel");
            ui.Display("==============\n");

            string section;            
            int row, column;

            //Panel panel = new Panel();  //hmmm
            vID = new ValidationID();

            section = ui.GetString("Enter Section");
            while (!vID.CheckSectionIsNotNull(section))
            {
                ui.Warn("[Err] Must enter a name for section");
                section = ui.GetString("Enter Section");
            }
            while (!Service.CheckForSectionExistence(section).Success)
            {
                ui.Warn("[Err] This section does not exist");
                section = ui.GetString("Enter Section");
            }

            row = ui.GetInt("Enter Row");
            while (!vID.CheckRowOrColumn(row).Success)
            {
                ui.Warn(vID.CheckRowOrColumn(row).Message);
                row = ui.GetInt("Enter Row");
            }

            column = ui.GetInt("Enter Column");
            while (!vID.CheckRowOrColumn(column).Success)
            {
                ui.Warn(vID.CheckRowOrColumn(row).Message);
                column = ui.GetInt("Enter Column");
            }

            Result<Panel> result = Service.Remove(section, row, column);

            ui.Display(result.Message);
            ui.Display("\n");
            ui.PromptToContinue();
            Console.Clear();
            return true;
        }
    }
}
