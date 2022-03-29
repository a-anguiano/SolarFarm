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
    class FindPanelsBySection : MenuItem
    {
        private readonly IPanelService Service;

        public FindPanelsBySection(IPanelService panelService)
        {
            Selector = 1;
            Description = "Find Panels by Section";
            Service = panelService;
        }

        Result<Panel> result = new Result<Panel>();

        public override bool Execute(ConsoleIO ui, PanelService svc, ValidationID vID)
        {
            Console.Clear();
            string section;
            ui.Display("Find Panels by Section");
            ui.Display("======================\n");
            section = ui.GetString("Enter Section");


            result = Service.CheckForSectionExistence(section);

            while(!result.Success)
            {                
                ui.Warn(result.Message);
                section = ui.GetString("Enter Section");
                result = Service.CheckForSectionExistence(section);               
            }            

            Result<List<Panel>> result2 = Service.FindPanelsBySection(section); 
        
            if (result2.Success)
            {
                ui.Display("\n");
                ui.Display($"Panels in the {section}");
                ui.Display("Row Col Year Material Tracking");

                foreach (Panel panel in result2.Data)
                {
                    string row = panel.Row.ToString();
                    string col = panel.Column.ToString();
                    string year = panel.Year.ToString("yyyy");
                    int matInt = panel.Material;
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
                    string track = panel.IsTracking;
                    if (track == "y")
                    {
                        track = "yes";
                    }
                    else
                    {
                        track = "no";
                    }

                    ui.Display($"{row}   {col}   {year}     {mat}      {track}");
                }
            }
            else
            {
                ui.Display(result2.Message);
            }
            ui.Display("\n");
            ui.PromptToContinue();
            Console.Clear();
            return true;
        }
    }
}
