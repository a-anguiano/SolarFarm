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
        private readonly IPanelService Service; //hmmm
        public Update(IPanelService panelService)
        {
            Selector = 3;
            Description = "Update a Panel";
            Service = panelService;
        }
        //IPanelService Service = PanelServiceFactory.GetPanelService();

        public override bool Execute(ConsoleIO ui, ValidationID vID)
        {
            Console.Clear();
            ui.Display("Update a Panel");
            ui.Display("==============\n");

            string section, sectionNew, isTrackingNew, 
               materialNew, yearStringNew,
                rowStringNew, columnStringNew;              //other ones?

            int row, rowNew, column, columnNew;
            DateTime year, yearNew;
            Panel panel = new Panel();  //hmmm
            vID = new ValidationID();

            section = ui.GetString("Enter Section Name");
            while (!vID.CheckSectionIsNotNull(section))
            {
                ui.Warn("[Err] Must enter a name for section");
                section = ui.GetString("Enter Section");
            }
            while (!Service.CheckForSectionExistence(section))
            {
                ui.Warn("[Err] This section does not exist");
                section = ui.GetString("Enter Section");
            }
            panel.Section = section;            //needed or nah

            row = ui.GetInt("Enter Row");
            while (!vID.CheckRow(row))
            {
                ui.Warn("[Err] Row must be between 1 and 250");
                row = ui.GetInt("Enter Row");
            }
            panel.Row = row;

            column = ui.GetInt("Enter Column");
            while (!vID.CheckColumn(column))
            {
                ui.Warn("[Err] Column must be between 1 and 250");
                column = ui.GetInt("Enter Column");
            }
            if (!Service.CheckForPanelExistence(section, row, column))
            {
                ui.Warn("[Err] This panel does not exist!\nCannot edit a non-existing panel.");
                ui.PromptToContinue();
                Console.Clear();
                return true;    //go to main menu
            }
            panel.Column = column;            

            ui.Display($"\nEditing {panel.Section}-{panel.Row}-{panel.Column}");
            ui.Display("Press [Enter] to keep original value.\n");

            //a lot of this may need to go in PanelService
            sectionNew = ui.GetResponse($"Section ({panel.Section})");
            if (String.IsNullOrEmpty(sectionNew))
            {
                panel.Section = section;       //continue?
            }
            else
            {
                panel.Section = sectionNew;
            }

            rowStringNew = ui.GetResponse($"Row ({panel.Row})");       
            if (String.IsNullOrEmpty(rowStringNew))
            {
                panel.Row = row;
            }
            else
            {
                rowNew = int.Parse(rowStringNew);   //tryparse
                panel.Row = rowNew;
            }

            columnStringNew = ui.GetResponse($"Column ({panel.Column})");
            if (String.IsNullOrEmpty(columnStringNew))
            {
                panel.Column = column;
            }
            else
            {
                columnNew = int.Parse(columnStringNew);   //tryparse
                panel.Row = columnNew;
            }

            Panel oldPanel = new Panel();

            oldPanel = Service.GetPanel(section, row, column);

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

            materialNew = ui.GetResponse($"Material ({mat})");
            if (String.IsNullOrEmpty(materialNew))
            {
                panel.Material = oldPanel.Material; 
            }
            else
            {
                int materialIntNew = int.Parse(materialNew);
                panel.Material = materialIntNew;
            }

            string oldYear = oldPanel.Year.ToString("yyyy");

            yearStringNew = ui.GetResponse($"Installation Year ({oldYear})");
            if (String.IsNullOrEmpty(yearStringNew))
            {
                panel.Year = oldPanel.Year;
            }
            else
            {
                string month = "1/1/";
                yearNew = DateTime.Parse(month + yearStringNew);              //tryparse
                panel.Year = yearNew;
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
            if (String.IsNullOrEmpty(isTrackingNew))
            {
                panel.IsTracking = oldPanel.IsTracking;
            }
            else
            {
                panel.IsTracking = isTrackingNew;
            }

            Result<Panel> result = new Result<Panel>();
            result = Service.Update(panel);

            ui.Display("\n");
            ui.Display($"Panel {result.Data.Section}-{result.Data.Row}-{result.Data.Column} updated.");
            //ui.Display(result.Message);
            ui.PromptToContinue();
            Console.Clear();
            return true;
        }
    }
}
