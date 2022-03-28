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
        //IPanelService check
        private IPanelRepository _repo;

        public PanelService(IPanelRepository repo)
        {
            _repo = repo;
        }

        public bool CheckForSectionExistence(string section)  //hmmm
        {
            List<Panel> panels = _repo.GetAll().Data;           //AND HERE something with the _repo is null!!!!!!
            foreach (Panel p in panels)
            {
                if (p.Section == section)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckForPanelExistence(string section, int row, int column) //hmm
        {
            List<Panel> panels = _repo.GetAll().Data;
            foreach (Panel p in panels)
            {
                if (p.Section == section && p.Row == row && p.Column == column) //could let them know sooner but oh well
                {
                    return true;
                }
            }
            return false;
        }

        public Result<List<Panel>> FindPanelsBySection(string section)  //dude what
        {
            List<Panel> panels = _repo.GetAll().Data;
            Result<List<Panel>> result = new Result<List<Panel>>();
            List<Panel> listOfPanelsInSection = new List<Panel>();

            if (!CheckForSectionExistence(section))
            {
                result.Success = false;
                result.Message = "The section name you entered does not exist";
                return result;
            }
            else
            {
               // List<Panel> listOfPanelsInSection = new List<Panel>();

                foreach (Panel p in panels)
                {                    
                    if (p.Section == section)
                    {
                        //Panel panel = new Panel();
                        Panel panel = p;
                        listOfPanelsInSection.Add(panel);
                    }
                }               

                if (listOfPanelsInSection.Count == 0)    //mmmm
                {
                    result.Success = false;
                    result.Message = "No panels in section.";
                    //return result;
                }
                else
                {
                    result.Data = listOfPanelsInSection;
                    result.Success = true;
                    result.Message = "Here are the panels";
                }

                return result;
            }
        }
        public Result<Panel> Add(Panel panel)
        {
            Result<Panel> result = new Result<Panel>();
            StringBuilder sb = new StringBuilder();         //added
            result.Data = panel;
            result.Success = true;           

            if(CheckForPanelExistence(panel.Section, panel.Row, panel.Column))
            {
                result.Success = false;
                sb.Append("Cannot add duplicate panel.");
            }

            result.Message = sb.ToString();

            if (result.Success == true)
            {
                _repo.Add(panel);
            }            
            return result;
        }
        //hmmmm, need to find specific panel to remove
        //check if that panel exists
        public Result<Panel> Remove(string section, int row, int column)
        {
            Result<Panel> result = new Result<Panel>();
            StringBuilder sb = new StringBuilder();         //added, what about result.message
            //result.Data = panel;
            result.Success = true;

            if (!CheckForSectionExistence(section))
            {
                result.Success = false;
                sb.Append("The section does not exist.");
            }

            if (!CheckForPanelExistence(section, row, column))
            {
                result.Success = false;
                sb.Append("The panel does not exist to be removed.");
            }

            if (result.Success == true)
            {
                _repo.Remove(section, row, column);
            }            
            return result;
        }
        public Result<Panel> Update(Panel panel)    //change to section, column, row?
        {
            //check for enter key, or null
            List<Panel> panels = _repo.GetAll().Data;
            Result<Panel> result = new Result<Panel>();
            StringBuilder sb = new StringBuilder();         //added, what about result.message
            result.Success = true;

            if (!CheckForSectionExistence(panel.Section))
            {
                result.Success = false;
                sb.Append("The section does not exist.");
            }

            if (!CheckForPanelExistence(panel.Section, panel.Row, panel.Column))
            {
                result.Success = false;
                sb.Append("The panel does not exist to be edited.");
            }

            else
            {
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
            }
            
            if (result.Success == true)
            {
                result = _repo.Update(panel);
            }
            
            return result;
        }
    }
}
