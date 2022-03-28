﻿using System;
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
        IPanelService Service = PanelServiceFactory.GetPanelService();

        public override bool Execute(ConsoleIO ui, ValidationID vID)
        {
            Console.Clear();
            ui.Display("Remove a Panel");
            ui.Display("==============\n");

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
            while (!Service.CheckForSectionExistence(section))
            {
                ui.Warn("[Err] This section does not exist");
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
            if (!Service.CheckForPanelExistence(section, row, column))  //it does not exist
            {
                ui.Warn("[Err] This panel does not exist!\nCannot remove.");
                ui.PromptToContinue();
                Console.Clear();
                return true;    //go to main menu
            }

            panel.Column = column;

            Service.Remove(section, row, column);

            ui.Display($"Panel {section}-{row}-{column} removed.");
            ui.PromptToContinue();
            Console.Clear();
            return true;
        }
    }
}
