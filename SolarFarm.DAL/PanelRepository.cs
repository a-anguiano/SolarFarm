using System;
using System.Collections.Generic;
using SolarFarm.Core.DTO;
using SolarFarm.Core.Interfaces;
using System.IO;

namespace SolarFarm.DAL
{
    public class PanelRepository : IPanelRepository         //do I need an interface for the repository?
    {
        private List<Panel> _panels;        //will I need it
        public PanelRepository()                    //for testing purposes
                                                    //made need list of list== sections, panels
        {
            //Work on ConsoleIO and serialization  (need package for serial)          

            //string path = Directory.GetCurrentDirectory() + @"\Data\SolarPanels.csv";

            //if (File.Exists(path))
            //{
            //// to hold data
            // List<Panel> panels = new List<Panel>();

            //// create and open streamreader
            //    using (StreamReader sr = new StreamReader(path))
            //    {
            //        string currentLine = sr.ReadLine(); // header line
            ////maybe make variable for head row... or actually don't have to
            /////ask if there is a header
            //        currentLine = sr.ReadLine(); // 1st data row

            //        while (currentLine != null)
            //        {
            //            Panel p = new Panel(); // create a panel object for each line
            //            string[] columns = currentLine.Split(","); // split columns

            //            // add data to object, parsing types as necessary
            //            p.Section = columns[0];
            //            p.Row = int.Parse(columns[1]);
            //            p.Column = int.Parse(columns[2]);
            //            string month = "1/1/";
            //            string yearString = columns[3];
            //            p.Year = DateTime.Parse(month + yearString);
            //            p.Material = int.Parse(columns[4]);
            //            p.IsTracking = columns[5];

            //            panels.Add(p); // add object to list

            //            currentLine = sr.ReadLine(); // next line
            //        }
            //    }
            //}

            //    string wholeFile = File.ReadAllText(path);

            //    Console.WriteLine(wholeFile);
            //}
            //else
            //{
                    //CreateDirectory(path); //perhaps? create csv file
            //    Console.WriteLine($"File at {path} not found.");
            //}           

            //for now, test with these
            _panels = new List<Panel>();
            Panel bogus = new Panel();
            bogus.Section = "upper hill";
            bogus.Row = 2;
            bogus.Column = 3;
            bogus.Year = new DateTime(2020);
            bogus.IsTracking = "y";
            _panels.Add(bogus);

            Panel bogus2 = new Panel();
            bogus2.Section = "upper hill";
            bogus2.Row = 3;
            bogus2.Column = 3;
            bogus2.Year = new DateTime(2020);
            bogus2.IsTracking = "y";
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
        }

        public Result<Panel> Update(Panel panel)    //change to section, row, col
        {
            Result<Panel> result = new Result<Panel>();
            result.Data = panel;
            for (int i = 0; i < _panels.Count; i++)
            {
                if (_panels[i].Section == panel.Section && _panels[i].Row == panel.Row && _panels[i].Column == panel.Column)    //hmm
                {
                    _panels[i] = panel;
                }
            }
            return result;
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
        }

    }
}
