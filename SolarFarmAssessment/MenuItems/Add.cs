using System;
//using System.Gloabalization;  //?
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarFarm.BLL;
using SolarFarm.Core.Interfaces;
using SolarFarm.Core.DTO;

namespace SolarFarmAssessment.MenuItems
{
    
    public class Add : MenuItem
    {
        //maybe move quite a bit of this into BLL

        public Add()    
        {
            Selector = 2;
            Description = "Add a Panel";
        }
        IPanelService Service = PanelServiceFactory.GetPanelService();

        public override bool Execute(ConsoleIO ui, ValidationID vID)   
        {
            Console.Clear();
            string section, isTracking, yearString;
            int row, column;
            DateTime year;
            Panel panel = new Panel();  //hmmm
            vID = new ValidationID();

            ui.Display("Add a Panel");
            ui.Display("===========\n");
            section = ui.GetString("Enter Section Name");        
            while (!vID.CheckSectionIsNotNull(section))
            {
                ui.Warn("[Err] Must enter a name for section");
                section = ui.GetString("Enter Section");
            }
            //while (!Service.CheckForSectionExistence(section))  //still happening
            //{
            //    ui.Warn("[Err] This section does not exist");
            //    section = ui.GetString("Enter Section");
            //}
            panel.Section = section;

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

            if (Service.CheckForPanelExistence(section, row, column))   //it exists already
            {
                ui.Warn("[Err] This panel exists!\nCannot duplicate.");
                ui.PromptToContinue();
                return true;    //go to main menu
            }
            panel.Column = column;

            ui.Display("Enter material type:");
            int material = ui.GetInt("0 = MuSi, 1 = MoSi, 2 = AmSi, 3 = CdTe, 4 = CIGS"); //make another enum so not as long?
            
            
            while (!vID.CheckMaterial(material))
            {
                ui.Warn("A single material of the five listed is required");
                material = ui.GetInt("Enter material type");                                   
            }
            panel.Material = material;

            yearString = ui.GetString("Enter year installed");
            string month = "1/1/";
            year = DateTime.Parse(month + yearString);

            while (!vID.CheckYear(year))
            {
                ui.Warn("Year installed must be in the past");
                yearString = ui.GetString("Enter year installed");
                year = DateTime.Parse(month + yearString);
                //need to tryparse        //install year
            }
            panel.Year = year;

            isTracking = ui.GetString("Does it track? Enter [y/n]");
            while (!vID.CheckIsTracking(isTracking))
            {
                ui.Warn("Must enter 'y' or 'n'");
                isTracking = ui.GetString("Does it track? Enter [y/n]");
            }
            panel.IsTracking = isTracking;

            Result<Panel> result = new Result<Panel>();

            result = Service.Add(panel);

            if (result.Success)
            {
                ui.Display("\n");
                ui.Display(result.Data.ToString());
                ui.PromptToContinue();
                //running = false;
            }
            else
            {
                ui.Display(result.Message);
                ui.PromptToContinue();
            }
            return true;
        }
    }
}
