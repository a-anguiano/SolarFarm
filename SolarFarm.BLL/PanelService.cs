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
        private ValidationID _vID;

        public PanelService(IPanelRepository repo, ValidationID vID)        //HERE
        {
            _repo = repo;
            _vID = vID;
        }

        public Panel GetPanel(string section, int row, int column)
        {
            List<Panel> panels = _repo.GetAll().Data;
            Panel panel = new Panel();
            foreach (Panel p in panels)
            {
                if (p.Section == section && p.Row == row && p.Column == column) //could let them know sooner but oh well
                {
                    return panel;
                }
            }
            return panel;
        }

        public Result<Panel> CheckForSectionExistence(string section) 
        {
            if (_vID.CheckSectionIsNotNull(section))
            {
                List<Panel> panels = _repo.GetAll().Data;
                foreach (Panel p in panels)
                {
                    if (p.Section.ToUpper().Trim() == section.ToUpper().Trim())
                    {
                        return new Result<Panel> { Success = true};
                    }
                }                
            }
                return new Result<Panel> { Success = false, Message = "The section you entered does not exist." };
        }

        public Result<Panel> CheckForPanelExistence(string section, int row, int column)
        {
            Result<Panel> result = new Result<Panel>();
            List<Panel> panels = _repo.GetAll().Data;

            foreach (Panel p in panels)
            {
                if (p.Section == section && p.Row == row && p.Column == column)
                {
                    result.Success = true;
                    result.Message = "This panel exists!";
                    return result;
                }
            }
            result.Message = "This panel does not exist!";
            result.Success = false;
            return result;
        }

        public Result<List<Panel>> FindPanelsBySection(string section)
        {
            List<Panel> panels = _repo.GetAll().Data;
            Result<List<Panel>> result = new Result<List<Panel>>();
            List<Panel> listOfPanelsInSection = new List<Panel>();

                foreach (Panel p in panels)
                {                    
                    if (p.Section == section)
                    {
                        Panel panel = p;
                        listOfPanelsInSection.Add(panel);
                    }
                }               

                if (listOfPanelsInSection.Count == 0)
                {
                    result.Success = false;
                    result.Message = "No panels in section.";
                }
                else
                {
                    result.Data = listOfPanelsInSection;
                    result.Success = true;
                    result.Message = "";
                }

                return result;
        }
        public Result<Panel> Add(Panel panel)
        {
            Result<Panel> result = new Result<Panel>();
            result.Data = panel;
            result.Success = true;  

            if(CheckForPanelExistence(panel.Section, panel.Row, panel.Column).Success)
            {
                result.Success = false;
                result.Message = "Cannot add duplicate panel.";
                return result;
            }

            if (result.Success == true)
            {
                result.Message = $"{panel.Section}-{panel.Row}-{panel.Column} added.";
                _repo.Add(panel);
            }            
            return result;
        }

        public Result<Panel> Remove(string section, int row, int column)
        {
            Result<Panel> result = new Result<Panel>();       

            if (!CheckForSectionExistence(section).Success)
            {
                result.Success = false;
                result.Message = "The section does not exist.";
                return result;
            }

            if (!CheckForPanelExistence(section, row, column).Success)
            {
                result.Success = false;
                result.Message = "The panel does not exist to be removed.";
                return result;
            }

            else 
            {
                result.Success = true;
                _repo.Remove(section, row, column);
                result.Message = $"Panel {section}-{row}-{column} removed.";
                return result;
            }                        
        }
        public Result<Panel> Update(Panel panel) 
        {
            List<Panel> panels = _repo.GetAll().Data;
            Result<Panel> result = new Result<Panel>();
            result.Success = true;

            //    for (int i = 0; i < panels.Count; i++)
            //    {
            //        if (panels[i].Section == panel.Section && panels[i].Row == panel.Row && panels[i].Column == panel.Column)
            //        {
            //            panel.Material = panels[i].Material;
            //            panel.Year = panels[i].Year;
            //            panel.IsTracking = panels[i].IsTracking;
            //            //check all this

            //            result.Success = true;
            //            result.Data = panel;
            //            break;
            //        }
            //    }
            
            //if (result.Success == true)
            //{
                result = _repo.Update(panel);
                result.Message = $"Panel {panel.Section}-{panel.Row}-{panel.Column} updated.";    //HERE
            //}
            
            return result;            
        }
        //public Result<WeatherRecord> UpdateRecord(WeatherRecord record2Update)
        //{
        //    var error = ValidateRecord(record2Update);

        //    return string.IsNullOrEmpty(error)
        //      ? _recordRepository.Update(record2Update)
        //      : new Result<WeatherRecord> { IsSuccess = false, Message = error };
        //}
        public bool CheckForUpdate(string response)
        {
            if (String.IsNullOrEmpty(response))
            {
                return false;       
            }
            else
            {
                return true;
            }
        }
    }
}
