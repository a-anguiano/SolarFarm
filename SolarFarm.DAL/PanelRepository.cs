using System;
using System.Collections.Generic;
using SolarFarm.Core.DTO;
using SolarFarm.Core.Interfaces;

namespace SolarFarm.DAL
{
    public class PanelRepository : IPanelRepository
    {
        private List<Panel> _panels;
        public PanelRepository()                    //for testing purposes
                                                    //made need list of list== sections, panels
        {
            _panels = new List<Panel>();
            Panel bogus = new Panel();
            bogus.Section = "Upper Hill";
            bogus.Row = 2;
            bogus.Column = 3;
            bogus.Year = new DateTime(2020);
            bogus.IsTracking = "y";
            _panels.Add(bogus);
        }

        public Result<Panel> Add(Panel panel)
        {
            _panels.Add(panel);
            Result<Panel> result = new Result<Panel>();
            result.Data = panel;
            result.Success = true;
            result.Message = "";
            return result;
            //todo: add record to private field
            //throw new NotImplementedException();
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
