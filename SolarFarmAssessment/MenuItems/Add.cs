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
        public IPanelService Service { get; set; }      //hmmmm
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
                    running = true;
                }
                else
                {
                    panel.Row = row;
                    running = false;
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
                    running = true;
                }
                else
                {
                    panel.Column = column;
                    running = false;
                }
            }

            running = true;
            while (running)
            {
                string material = ui.GetString("Enter material type");                //material
                vID = new ValidationID();
                if (!vID.CheckMaterial(material))
                {
                    ui.Warn("A single material of the five listed is required");    //list materials?
                    running = true;
                }
                else
                {
                    panel.Material = material;
                    running = false;
                }
            }
            //validation

            running = true;
            while (running)
            {
                string yearString = ui.GetString("Enter year installed");
                year = DateTime.Parse(yearString);                           //need to tryparse        //install year
                vID = new ValidationID();
                if (!vID.CheckYear(year))
                {
                    ui.Warn("Year installed must be in the past");
                    running = true;
                }
                else
                {
                    panel.Year = year;
                    running = false;
                }
            }

            running = true;
            while (running)
            {
                isTracking = ui.GetString("Does it track? Enter [y/n]");
                
                vID = new ValidationID();
                if (!vID.CheckIsTracking(isTracking))   //bool?
                {
                    ui.Warn("Must enter 'y' or 'n'");
                    running = true;
                }
                else
                {
                    panel.IsTracking = isTracking;
                    running = false;
                }
            }                
            Service.Add(panel);
            return true;        //hmmm, return to menu??
        }
    }
}
