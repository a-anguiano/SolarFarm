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
    
    class Add : MenuItem
    {        
        public Add()    
        {
            Selector = 2;
            Description = "Add a Panel";
        }
        public IPanelService Service { get; set; }      //hmmmm
        public override bool Execute(ConsoleIO ui, ValidationID vID)        //not sure to make interface or not
        {           
            string section, isTracking, yearString;
            int row, column;
            DateTime year;
            Panel panel = new Panel();  //hmmm
            vID = new ValidationID();

            section = ui.GetString("Enter Section");        
            while (!vID.CheckSectionIsNotNull(section))
            {
                ui.Warn("[Err] Must enter a name for section");
                section = ui.GetString("Enter Section");
            }
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
            panel.Column = column;

            string material = ui.GetString("Enter material type");
            while (!vID.CheckMaterial(material))
            {
                ui.Warn("A single material of the five listed is required");
                material = ui.GetString("Enter material type");                //material
                      //list materials?                    
            }
            panel.Material = material;
            //validation

            yearString = ui.GetString("Enter year installed");
            year = DateTime.Parse(yearString);
            //DateTime.year.ToString("yyyy")

            while (!vID.CheckYear(year))
            {
                ui.Warn("Year installed must be in the past");
                yearString = ui.GetString("Enter year installed");
                year = DateTime.Parse(yearString);
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
            //Service.Add(panel);

            Result<Panel> result = new Result<Panel>();
            result = Service.Add(panel);  //HERE

            if (result.Success)
            {
                ui.Display(result.Data.ToString());
                ui.Display("idk");
                //running = false;
            }
            else
            {
                ui.Display(result.Message);
                ui.Display("Idk");
                //ui.PromptToContinue();
            }

            return true;        //hmmm, return to menu??
        }
        //public string Execute(ConsoleIO ui, ValidationID vID)    //fix from bool to 
        //{
        //    return "";
        //}

    }
}
