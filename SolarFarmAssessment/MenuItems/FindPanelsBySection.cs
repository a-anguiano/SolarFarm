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

        IPanelService Service = PanelServiceFactory.GetPanelService();

        public FindPanelsBySection()
        {
            Selector = 1;
            Description = "Find Panels by Section";
        }

        Result<List<Panel>> result = new Result<List<Panel>>(); //hmmm, may move in

        public override bool Execute(ConsoleIO ui, ValidationID vID)
        {
            Console.Clear();
            string section;
            ui.Display("Find Panels by Section");
            ui.Display("======================\n");
            section = ui.GetString("Enter Section");
            vID = new ValidationID();

            while (!vID.CheckSectionIsNotNull(section))
            {
               ui.Warn("[Err] Must enter a name for section");
               section = ui.GetString("Enter Section");
            }

            result = Service.FindPanelsBySection(section); 
        
            if (result.Success)
            {
                ui.Display("\n");
                ui.Display($"Panels in the {section}");
                ui.Display("Row Col Year Material Tracking");
                //or if it is csv, let's look into that

                foreach (Panel panel in result.Data)
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
                ui.Display(result.Message);
            }
            ui.Display("\n");
            ui.PromptToContinue();
            Console.Clear();
            return true;
        }
    }
}
