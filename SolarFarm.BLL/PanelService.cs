using System;
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
            StringBuilder sb = new StringBuilder();
            result.Data = panel;
            result.Success = true;

            //create validation thingy

            if (String.IsNullOrEmpty(result.Data.Section))      //swap
            {
                result.Success = false;
                sb.Append("Must input a section name");
            }
            if (result.Data.Row > 250 || result.Data.Row <= 0)
            {
                result.Success = false;
                sb.Append("Row must be a positive number greater than or equal to 250. ");
            }
            if (result.Data.Column > 250 || result.Data.Row <= 0)
            {
                result.Success = false;
                sb.Append("Column must be a positive number greater than or equal to 250. ");
            }
            if (result.Data.Year < DateTime.Now) //DateTime year
            {
                result.Success = false;
                sb.Append("Year installed must be in the past");
            }
            if (String.IsNullOrEmpty(result.Data.IsTracking))
            {
                result.Success = false;
                sb.Append("Must say if panel has sun-tracking hardware");
            }

            //Only one material

            result.Message = sb.ToString();

            if (result.Success)
            {
                _repo.Add(panel);
            }
            return result;
            //throw new NotImplementedException();
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
