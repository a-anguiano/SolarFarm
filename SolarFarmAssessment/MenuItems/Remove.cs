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
        public Remove()
        {
            Selector = 4;
            Description = "Remove a Panel";
        }
        public IPanelService Service { get; set; }      //hmmmm
        public override bool Execute(ConsoleIO ui, ValidationID vID)
        {
            ui.Display("Remove a Panel");
            ui.Display("==============");

            string section;            //other ones?
            int row, column;

            Panel panel = new Panel();  //hmmm
            vID = new ValidationID();

            section = ui.GetString("Enter Section");
            while (!vID.CheckSectionIsNotNull(section))
            {
                ui.Warn("[Err] Must enter a name for section");
                section = ui.GetString("Enter Section");
            }
            panel.Section = section;    //uneccessary?

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

            //get the Panel specified by section, row, col
            //check if panel exists
            //return other properties if it does exist

            Result<List<Panel>> result = Service.FindPanelsBySection(section);
            List<Panel> listOfPanelsInSection = result.Data;
            foreach (Panel p in listOfPanelsInSection)
            {
                if (p.Row == row && p.Column == column)
                {
                    //Panel specificPanal = p;
                    //panel exists
                    Service.Remove(section, row, column);   //specificPanel?
                }
                else
                {
                    ui.Display("The panel does not exist.");
                }
            }                
            return true;
        }
    }
}
