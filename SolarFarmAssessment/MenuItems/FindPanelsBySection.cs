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
                string[] rowA = new string[result.Data.Count];
                string[] colA = new string[result.Data.Count];
                string[] yearA = new string[result.Data.Count];
                int[] matInt = new int[result.Data.Count];
                string[] matA = new string[result.Data.Count];
                string[] trackA = new string[result.Data.Count];

                for (int i = 0; i < result.Data.Count; i ++)
                {
                    
                    rowA[i] = result.Data[i].Row.ToString();
                    colA[i] = result.Data[i].Column.ToString();
                    yearA[i] = result.Data[i].Year.ToString("yyyy");
                    matInt[i] = result.Data[i].Material;
                    
                    if (matInt[i] == (int)ValidationID.MaterialTypes.MuSi)
                    {
                        matA[i] = "MuSi";
                    }
                    else if (matInt[i] == (int)ValidationID.MaterialTypes.MoSi)
                    {
                        matA[i] = "MoSi";
                    }
                    else if (matInt[i] == (int)ValidationID.MaterialTypes.AmSi)
                    {
                        matA[i] = "AmSi";
                    }
                    else if (matInt[i] == (int)ValidationID.MaterialTypes.CdTe)
                    {
                        matA[i] = "CdTe";
                    }
                    else //if (matInt == (int)ValidationID.MaterialTypes.CIGS)
                    {
                        matA[i] = "CIGS";
                    }
                    trackA[i] = result.Data[i].IsTracking;
                    if (trackA[i] == "y")
                    {
                        trackA[i] = "yes";
                    }
                    else
                    {
                        trackA[i] = "no";
                    }

                    ui.Display($"{rowA[i]}   {colA[i]}   {yearA[i]}     {matA[i]}      {trackA[i]}");
                }
                //foreach (Panel panel in result.Data)
                //{
                    //string row = panel.Row.ToString();
                    //string col = panel.Column.ToString();
                    //string year = panel.Year.ToString("yyyy");
                    //int matInt = panel.Material;
                    //string mat;
                    //if (matInt == (int)ValidationID.MaterialTypes.MuSi)
                    //{
                    //    mat = "MuSi";
                    //}
                    //else if (matInt == (int)ValidationID.MaterialTypes.MoSi)
                    //{
                    //    mat = "MoSi";
                    //}
                    //else if (matInt == (int)ValidationID.MaterialTypes.AmSi)
                    //{
                    //    mat = "AmSi";
                    //}
                    //else if (matInt == (int)ValidationID.MaterialTypes.CdTe)
                    //{
                    //    mat = "CdTe";
                    //}
                    //else //if (matInt == (int)ValidationID.MaterialTypes.CIGS)
                    //{
                    //    mat = "CIGS";
                    //}
                    //string track = panel.IsTracking;
                    //if (track == "y")
                    //{
                    //    track = "yes";
                    //}
                    //else
                    //{
                    //    track = "no";
                    //}

                    //ui.Display($"{row}   {col}   {year}     {mat}      {track}");
                //}
            }
            else
            {
                ui.Display(result.Message);
            }
            ui.Display("\n");
            ui.PromptToContinue();
            return true;
        }
    }
}
