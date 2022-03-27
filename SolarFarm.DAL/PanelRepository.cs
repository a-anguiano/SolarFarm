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
            //string path = Directory.GetCurrentDirectory() + @"\Data\SolarPanels.csv";
            //CreateDirectory(path)

            //_panels = new List<Panel>();
            //Panel panel bogus = new panel();
            //bogus.section = "upper hill";
            //bogus.row = 2;
            //bogus.column = 3;
            //bogus.year = new datetime(2020);
            //bogus.istracking = "y";
            //_panels.add(bogus);
        }

        public Result<Panel> Add(Panel panel)
        {
            _panels.Add(panel);
            Result<Panel> result = new Result<Panel>();
            result.Data = panel;
            result.Success = true;
            result.Message = "";
            return result;
        }

        public Result<Panel> Update(Panel panel)    //change to section, row, col
        {
            Result<Panel> result = new Result<Panel>();
            result.Data = panel;
            for (int i = 0; i < _panels.Count; i++)
            {
                if (_panels[i].Section == panel.Section)    //hmm
                {
                    _panels[i] = panel;
                }
            }
            return result;
            //throw new NotImplementedException();
        }

        public Result<List<Panel>> GetAll()        //this not sure quite yet
        {
            Result<List<Panel>> result = new Result<List<Panel>>();
            result.Success = true;
            result.Message = "";
            result.Data = new List<Panel>(_panels);
            return result;
        }
        public Result<Panel> Remove(string section, int row, int column)
        {
            Result<Panel> result = new Result<Panel>();
            for (int i = 0; i < _panels.Count; i++)
            {
                if (_panels[i].Section == section && _panels[i].Row == row && _panels[i].Column == column)  //hmmm
                {
                    result.Data = _panels[i];
                    result.Success = true;
                    result.Message = "";
                    _panels.Remove(_panels[i]);
                }
            }
            return result;
            //throw new NotImplementedException();
        }

    }
}
