using System;
using System.Collections.Generic;
using SolarFarm.Core.DTO;
using SolarFarm.Core.Interfaces;

namespace SolarFarm.DAL
{
    public class PanelRepository : IPanelRepository
    {
        private List<Panel> _panels;
        public Result<Panel> Add(Panel panel)
        {
            throw new NotImplementedException();
        }

        public Result<Panel> Update(Panel panel)
        {
            throw new NotImplementedException();
        }

        public Result<List<Panel>> FindPanelsBySection(string section)        //this not sure quite yet
        {
            Result<List<Panel>> result = new Result<List<Panel>>();
            result.Success = true;
            result.Message = "";
            result.Data = new List<Panel>(_panels);
            return result;
        }
        public Result<Panel> Remove(string section, int row, int column)
        {
            throw new NotImplementedException();
        }

    }
}
