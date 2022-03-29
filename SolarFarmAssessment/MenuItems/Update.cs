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
    class Update : MenuItem
    {
        private readonly IPanelService Service;
        public Update(IPanelService panelService)
        {
            Selector = 3;
            Description = "Update a Panel";
            Service = panelService;
        }

        public override bool Execute(ConsoleIO ui, PanelService svc, ValidationID vID)
        {
            Console.Clear();
            ui.Display("Update a Panel");
            ui.Display("==============\n");

            string section, sectionNew, isTrackingNew, 
               materialNew, yearStringNew,
                rowStringNew, columnStringNew;            

            int row, rowNew, column, columnNew;
            DateTime year, yearNew;
            Panel panel = new Panel();  
            vID = new ValidationID();

            section = ui.GetString("Enter Section Name");
            while (!Service.CheckForSectionExistence(section).Success)
            {
                ui.Warn(Service.CheckForSectionExistence(section).Message);
                section = ui.GetString("Enter Section");
            }

            panel.Section = section;            //needed or nah

            row = ui.GetInt("Enter Row");
            while (!vID.CheckRowOrColumn(row).Success)
            {
                ui.Warn(vID.CheckRowOrColumn(row).Message);
                row = ui.GetInt("Enter Row");
            }
            panel.Row = row;

            column = ui.GetInt("Enter Column");
            while (!vID.CheckRowOrColumn(column).Success)
            {
                ui.Warn(vID.CheckRowOrColumn(column).Message);
                column = ui.GetInt("Enter Column");
            }
            if (!Service.CheckForPanelExistence(section, row, column).Success)
            {
                ui.Warn(Service.CheckForPanelExistence(section, row, column).Message);
                ui.Warn("\nCannot edit a non-existing panel.");
                ui.PromptToContinue();
                Console.Clear();
                return true;   
            }
            panel.Column = column;            

            ui.Display($"\nEditing {panel.Section}-{panel.Row}-{panel.Column}");
            ui.Display("Press [Enter] to keep original value.\n");
            
            sectionNew = ui.GetResponse($"Section ({panel.Section})");

            if (Service.CheckForUpdate(sectionNew))
            {
                panel.Section = sectionNew;       //continue?
            }

            rowStringNew = ui.GetResponse($"Row ({panel.Row})");  
            
            if(Service.CheckForUpdate(rowStringNew))
            {
                rowNew = int.Parse(rowStringNew);   //tryparse
                panel.Row = rowNew;
            }

            columnStringNew = ui.GetResponse($"Column ({panel.Column})");

            if(Service.CheckForUpdate(columnStringNew))
            {
                columnNew = int.Parse(columnStringNew);   //tryparse
                panel.Row = columnNew;
            }

            Panel oldPanel = Service.GetPanel(section, row, column);

            int matInt = oldPanel.Material;
            string mat;
            if (matInt == (int)ValidationID.MaterialTypes.MuSi)
            {
                mat = "MuSi";
            }
            else if (matInt == (int)ValidationID.MaterialTypes.MoSi)
            {
                mat = "MoSi";
            }
            else if (matInt == (int)ValidationID.MaterialTypes.AmSi)
            {
                mat = "AmSi";
            }
            else if (matInt == (int)ValidationID.MaterialTypes.CdTe)
            {
                mat = "CdTe";
            }
            else 
            {
                mat = "CIGS";
            }            

            ui.Display("0 = MuSi, 1 = MoSi, 2 = AmSi, 3 = CdTe, 4 = CIGS");
            materialNew = ui.GetResponse($"Material ({mat})");

            if(Service.CheckForUpdate(materialNew))
            {
                int materialIntNew = int.Parse(materialNew);
                panel.Material = materialIntNew;
            }
            else
            {
                panel.Material = oldPanel.Material;
            }

            string oldYear = oldPanel.Year.ToString("yyyy");

            yearStringNew = ui.GetResponse($"Installation Year ({oldYear})");

            if(Service.CheckForUpdate(yearStringNew))
            {
                string month = "1/1/";
                yearNew = DateTime.Parse(month + yearStringNew);              //tryparse
                panel.Year = yearNew;
            }
            else
            {
                panel.Year = oldPanel.Year;
            }

            string track = oldPanel.IsTracking;
            if (track == "y")
            {
                track = "yes";
            }
            else
            {
                track = "no";
            }
            isTrackingNew = ui.GetResponse($"Tracked ({track}) [y/n]");

            if(Service.CheckForUpdate(isTrackingNew))
            {
                panel.IsTracking = isTrackingNew;
            }
            else
            {
                panel.IsTracking = oldPanel.IsTracking;
            }

            Result<Panel> result = new Result<Panel>();
            result = Service.Update(panel);

            ui.Display("\n");
            ui.Display(result.Message);
            ui.PromptToContinue();
            Console.Clear();
            return true;
        }
    }
}
