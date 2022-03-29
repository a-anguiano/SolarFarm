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
    
    public class Add : MenuItem
    {

        private readonly IPanelService Service; 

        public Add(IPanelService panelService)
        {
            Selector = 2;
            Description = "Add a Panel";
            Service = panelService;                
        }

        public override bool Execute(ConsoleIO ui, PanelService svc, ValidationID vID)      
        {
            Console.Clear();
            string section, isTracking, yearString;
            int row, column;
            DateTime year;
            Panel panel = new Panel();  
            vID = new ValidationID();

            ui.Display("Add a Panel");
            ui.Display("===========\n");
            section = ui.GetString("Enter Section Name");

            Result<Panel> result = Service.CheckForSectionExistence(section);
            while(!result.Success)
            {
                ui.Warn(result.Message);
                section = ui.GetString("Enter Section Name");
                result = Service.CheckForSectionExistence(section);
            }            

            panel.Section = section;

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
                ui.Warn(vID.CheckRowOrColumn(row).Message);
                column = ui.GetInt("Enter Column");                    
            }
            panel.Column = column;

            Result<Panel> result3 = Service.CheckForPanelExistence(section, row, column);
            while (result3.Success)
            {
                ui.Warn($"[Err] {result.Message} Cannot Duplicate!");
                ui.PromptToContinue();
                Console.Clear();
                return true;
            }            

            ui.Display("Enter material type:");
            int material = ui.GetInt("0 = MuSi, 1 = MoSi, 2 = AmSi, 3 = CdTe, 4 = CIGS");
                       
            while (!vID.CheckMaterial(material).Success)
            {
                ui.Warn(vID.CheckMaterial(material).Message);
                material = ui.GetInt("Enter material type");                                   
            }
            panel.Material = material;

            yearString = ui.GetString("Enter year installed");
            string month = "1/1/";
            year = DateTime.Parse(month + yearString);

            while (!vID.CheckYear(year).Success)
            {
                ui.Warn(vID.CheckYear(year).Message);
                yearString = ui.GetString("Enter year installed");
                year = DateTime.Parse(month + yearString);
            }
            panel.Year = year;

            isTracking = ui.GetString("Does it track? Enter [y/n]");
            while (!vID.CheckIsTracking(isTracking).Success)
            {
                ui.Warn(vID.CheckIsTracking(isTracking).Message);
                isTracking = ui.GetString("Does it track? Enter [y/n]");
            }
            panel.IsTracking = isTracking;


            Result<Panel>  resultFinal = Service.Add(panel);
            if (resultFinal.Success)
            {
                ui.Display("\n");                
                ui.Display(resultFinal.Message);
                ui.PromptToContinue();
            }
            else
            {
                ui.Display(result.Message);
                ui.PromptToContinue();
            }
            Console.Clear();
            return true;
        }
    }
}
