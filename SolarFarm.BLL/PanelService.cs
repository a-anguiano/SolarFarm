﻿using System;
using System.Collections.Generic;
using SolarFarm.Core.DTO;
using SolarFarm.Core.Interfaces;
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
        public Result<List<Panel>> FindPanelsBySection(string section)
        {
            throw new NotImplementedException();
        }
        public Result<Panel> Add(Panel panel)
        {
            Result<Panel> result = new Result<Panel>();
            //StringBuilder sb = new StringBuilder();
            result.Data = panel;
            result.Success = true;
            _repo.Add(panel);

            //result.Message = sb.ToString();

            //if (result.Success)
            //{
            //    _repo.Add(panel);
            //}
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