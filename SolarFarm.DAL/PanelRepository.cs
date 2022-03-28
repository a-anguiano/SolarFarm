using System;
using System.Collections.Generic;
using SolarFarm.Core.DTO;
using SolarFarm.Core.Interfaces;
using System.IO;
using SolarFarm.Core;
using System.Linq;

namespace SolarFarm.DAL
{

    //DAL testing
    //can we read file, if not, create
    //is the file writable
    public class PanelRepository : IPanelRepository        
    {
        private readonly string _fileName;
        private readonly List<Panel> _panels;       

        public PanelRepository(string fileName)
        {
            _fileName = fileName;
            _panels = new List<Panel>();
            Init();
        }
        public Result<List<Panel>> Index()
        {
            return new Result<List<Panel>> { Success = true, Data = _panels };
        }
        public Result<Panel> Add(Panel panel)
        {
            _panels.Add(panel);
            SaveAllPanels2File();
            return new Result<Panel> { Success = true, Data = panel };
        }
        public Result<Panel> Update(Panel panel2Update)
        {
            var result = new Result<Panel>();

            if (_panels.Where(panel => panel.Section == panel2Update.Section && panel.Row == panel2Update.Row && panel.Column == panel2Update.Column).Select(_ => panel2Update).Any())    //hmmm
            {
                SaveAllPanels2File();
                result.Success = true;
                return result;
            }

            result.Success = false;
            result.Message = "Panel not found";
            return result;
        }
        public Result<Panel> Remove(string section, int row, int col)
        {
            var result = new Result<Panel>();

            foreach (var record in _panels.Where(panel => panel.Section == section && panel.Row == row && panel.Column == col))
            {
                _panels.Remove(record);
                SaveAllPanels2File();
                result.Success = true;
                result.Data = record;
                return result;
            }

            result.Success = false;
            result.Message = "Record not found";
            return result;
        }
        private void Init()
        {
            if (!File.Exists(_fileName))
            {
                File.Create(_fileName).Close();
                return;
            }
            using var sr = new StreamReader(_fileName);
            string? row;
            while ((row = sr.ReadLine()) != null)
            {
                _panels.Add(Deserialize(row));
            }
        }

        private static Panel Deserialize(string row)
        {
            var panel = new Panel();
            var columns = row.Split(',');
            panel.Section = columns[0];
            panel.Row = int.Parse(columns[1]);
            panel.Column = int.Parse(columns[2]);
            string month = "1/1/";
            string yearString = columns[3];
            panel.Year = DateTime.Parse(month + yearString);
            panel.Material = int.Parse(columns[4]);
            panel.IsTracking = columns[5];

            return panel;
        }
        private void SaveAllPanels2File()
        {
            using var sw = new StreamWriter(_fileName);
            foreach (var panel in _panels)
            {
                sw.WriteLine(
                  $"{panel.Section},{panel.Row},{panel.Column},{panel.Year},{panel.Material},{panel.IsTracking}");
            }
        }
        public Result<List<Panel>> GetAll()
        {
            Result<List<Panel>> result = new Result<List<Panel>>();

            result.Success = true;
            result.Message = "";
            result.Data = _panels;
            return result;
        }
  

        //    public Result<Panel> Update(Panel panel)    
        //    {
        //        Result<Panel> result = new Result<Panel>();
        //        result.Data = panel;
        //        for (int i = 0; i < _panels.Count; i++)
        //        {
        //            if (_panels[i].Section == panel.Section && _panels[i].Row == panel.Row && _panels[i].Column == panel.Column)    //hmm
        //            {
        //                _panels[i] = panel;
        //            }
        //        }
        //        return result;
        //    }

        
        //    public Result<Panel> Remove(string section, int row, int column)
        //    {
        //        Result<Panel> result = new Result<Panel>();
        //        for (int i = 0; i < _panels.Count; i++)
        //        {
        //            if (_panels[i].Section == section && _panels[i].Row == row && _panels[i].Column == column)  //hmmm
        //            {
        //                result.Data = _panels[i];
        //                result.Success = true;
        //                result.Message = "";
        //                _panels.Remove(_panels[i]);
        //            }
        //        }
        //        return result;
        //    }
    }
}
