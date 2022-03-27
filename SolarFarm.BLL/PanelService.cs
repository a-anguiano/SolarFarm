using System;
using System.Collections.Generic;
using SolarFarm.Core.DTO;
using SolarFarm.Core.Interfaces;
using SolarFarm.DAL;
using System.Text;

namespace SolarFarm.BLL
{
    public class PanelService : IPanelService
    {
        private IPanelRepository _repo;

    public PanelService(IPanelRepository repo)
        {
            _repo = repo;
        }

        //does this section exits?
        //are there any panels to display if the section exists
        public Result<List<Panel>> FindPanelsBySection(string section)  //dude what
        {   
            List<Panel> panels = _repo.GetAll().Data;
            Result<List<Panel>> result = new Result<List<Panel>>();
            List<Panel> listOfPanelsInSection = new List<Panel>();

                foreach (Panel p in panels)
                {
                    if (listOfPanelsInSection.Count == 0)    //mmmm
                    {
                        result.Success = false;
                        result.Message = " No panels in section";
                    }

                    if (p.Section == section)
                    {
                        Panel panel = p;
                        listOfPanelsInSection.Add(panel);
                    }
                }
                result.Data = listOfPanelsInSection;
                result.Success = true;
                result.Message = "";
                return result;            
            //throw new NotImplementedException();
        }
        public Result<Panel> Add(Panel panel)
        {
            Result<Panel> result = new Result<Panel>();
            result.Data = panel;
            result.Success = true;
            _repo.Add(panel);
            return result;
        }
        //hmmmm, need to find specific panel to remove
        //check if that panel exists
        public Result<Panel> Remove(string section, int row, int column)
        {
            Result<Panel> result = _repo.Remove(section, row, column);
            return result;
            //throw new NotImplementedException();
        }
        public Result<Panel> Update(Panel panel)
        {
            //check for enter key, or null
            //check if this panel even exists
            List<Panel> panels = _repo.GetAll().Data;
            Result<Panel> result = new Result<Panel>();
            for (int i = 0; i < panels.Count; i++)
            {
                if (panels[i].Section == panel.Section && panels[i].Row == panel.Row && panels[i].Column == panel.Column)
                {                    
                    panel.Material = panels[i].Material;
                    panel.Year = panels[i].Year;
                    panel.IsTracking = panels[i].IsTracking;
                    //check all this

                    result.Data = panel;
                    break;
                }
            }
            
            result = _repo.Update(panel);
            return result;

            //throw new NotImplementedException();
        }
    }
}
