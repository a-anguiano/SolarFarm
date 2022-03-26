﻿using System;
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
        public Result<Panel> Add(Panel panel)   //compare to weather
        {
            Result<Panel> result = new Result<Panel>();
            result.Data = panel;
            result.Success = true;
            _repo.Add(panel);
            return result;
        }
        public Result<Panel> Remove(string section, int row, int column)
        {
            throw new NotImplementedException();
        }
        public Result<Panel> Update(Panel panel)
        {
            throw new NotImplementedException();
        }
    }
}
