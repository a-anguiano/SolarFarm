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
    
    class Add : MenuItem
    {        
        public Add()    
        {
            Selector = 2;
            Description = "Add a Panel";
        }
        public override bool Execute(ConsoleIO ui, ValidationID vID)        //not sure to make interface or not
        {           
            bool running = true;
            string section, isTracking;
            int row, column;
            DateTime year;
            Panel panel = new Panel();  //hmmm

            while (running)
            {             
                section = ui.GetString("Enter Section"); //may look nicer, be less copy&paste if put in validation
                vID = new ValidationID();
                if (!vID.CheckSectionIsNotNull(section))    //some overlap in responsibility
                {
                    ui.Warn("[Err] Must enter a name for section");
                    running = true;
                }
                else
                {
                    panel.Section = section;
                    running = false;
                }
            }

            running = true;
            while(running)
            {
                row = ui.GetInt("Enter Row");
                vID = new ValidationID();
                if (!vID.CheckRow(row))
                {
                    ui.Warn("[Err] Row must be between 1 and 250");
                }
                else
                {
                    panel.Row = row;
                    running = true;
                }
            }

            running = true;
            while (running)
            {
                column = ui.GetInt("Enter Column");
                vID = new ValidationID();
                if (!vID.CheckColumn(column))       //could refactor check row/column
                {
                    ui.Warn("[Err] Column must be between 1 and 250");
                }
                else
                {
                    panel.Column = column;
                    running = true;
                }

                //validation
                string material = ui.GetString("Enter material type");                //material
                panel.Material = material;

                string yearString = ui.GetString("Enter year installed");
                year = DateTime.Parse(yearString);                                          //install year

                panel.Year = year;
                isTracking = ui.GetString("Does it track? Enter [y/n]");

                panel.IsTracking = isTracking;


                //PanelService.Add(panel);        //in or out of loop
            }
            PanelService.Add(panel);
            return true;        //hmmm, return to menu??
        }
    }
}
