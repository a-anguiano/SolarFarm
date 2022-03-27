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
        public Update()
        {
            Selector = 3;
            Description = "Update a Panel";
        }
        //public IPanelService Service { get; set; }      //hmmmm
        public override bool Execute(ConsoleIO ui, ValidationID vID, PanelService service)
        {
            Console.Clear();
            ui.Display("Update a Panel");
            ui.Display("==============\n");

            string section, sectionNew, isTracking, isTrackingNew, 
                material, materialNew, yearStringNew,
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
            while (!service.CheckForSectionExistence(section))
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
            if (service.CheckForPanelExistence(section, row, column))   //it exists already
            {
                ui.Warn("[Err] This panel exists!\nCannot duplicate.");
                ui.PromptToContinue();
                return true;    //go to main menu
            }
            panel.Column = column;

            //get the Panel specified by section, row, col
            //return other properties if it does exist

            ui.Display($"\nEditing {panel.Section}-{panel.Row}-{panel.Column}");
            ui.Display("Press [Enter] to keep original value.\n");


            //watch for enter key
            //a lot of this may need to go in PanelService
            sectionNew = ui.GetString($"Section ({panel.Section})");
            if (String.IsNullOrEmpty(sectionNew))
            {
                panel.Section = section;        //continue?
            }
            else
            {
                panel.Section = sectionNew;
            }

            rowStringNew = ui.GetString($"Row ({panel.Row})");       //read as string perhaps
            if (String.IsNullOrEmpty(rowStringNew))
            {
                panel.Row = row;
            }
            else
            {
                rowNew = int.Parse(rowStringNew);   //tryparse
                panel.Row = rowNew;
            }

            columnStringNew = ui.GetString($"Column ({panel.Column})");
            if (String.IsNullOrEmpty(columnStringNew))
            {
                panel.Column = column;
            }
            else
            {
                columnNew = int.Parse(columnStringNew);   //tryparse
                panel.Row = columnNew;
            }


            material = "TestMaterial";      //for testing
            year = new DateTime();          //for testing
            isTracking = "y";               //for testing

            materialNew = ui.GetString($"Material ({panel.Material})");
            if (String.IsNullOrEmpty(materialNew))
            {
                int materialInt = int.Parse(material); 
                panel.Material = materialInt;
            }
            else
            {
                int materialIntNew = int.Parse(materialNew);
                panel.Material = materialIntNew;
            }

            yearStringNew = ui.GetString($"Installation Year ({panel.Year})");
            if (String.IsNullOrEmpty(yearStringNew))
            {
                panel.Year = year;
            }
            else
            {
                string month = "1/1/";
                yearNew = DateTime.Parse(month + yearStringNew);              //tryparse
                panel.Year = yearNew;
            }
            
            isTrackingNew = ui.GetString($"Tracked ({panel.IsTracking}) [y/n]");
            if (String.IsNullOrEmpty(isTrackingNew))
            {
                panel.IsTracking = isTracking;
            }
            else
            {
                panel.IsTracking = isTrackingNew;
            }

            Result<Panel> result = new Result<Panel>();
            result = service.Update(panel);  //HERE

            //success or error
            ui.Display("\n");
            ui.Display(result.Message);
            return true;
        }
    }
}
