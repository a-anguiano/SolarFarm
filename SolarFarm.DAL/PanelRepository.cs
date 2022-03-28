using System;
using System.Collections.Generic;
using SolarFarm.Core.DTO;
using SolarFarm.Core.Interfaces;
using System.IO;
using SolarFarm.Core;

namespace SolarFarm.DAL
{
    public class PanelRepository : IPanelRepository        
    {
        private List<Panel> _panels;        


        //public PanelRepository()                    //for testing purposes
        //{
        //}
             public string Path { get; set; }             
             public IPanelFormatter Fmt { get; set; }

             //string csvPath = Directory.GetCurrentDirectory() + @"\Data\Panels.csv";    //testing
             //IPanelFormatter csvFormat = new PanelCSVFormatter();

        //PanelRepository csv.Fmt = csvFormat;
        //csv.Path = csvPath;
        public Result<List<Panel>> GetAll()
        {
            
            _panels = new();
            Result<List<Panel>> result = new Result<List<Panel>>();

            if (File.Exists(csvPath))
            {
                using (StreamReader sr = new StreamReader(csvPath))    //testing
                {
                    string line = sr.ReadLine();
                    if (line != null && Fmt.HasHeaderLine())    //exception thrown 
                    {
                        line = sr.ReadLine();
                    }

                    while (line != null)
                    {
                        _panels.Add(Fmt.Deserialize(line));
                        line = sr.ReadLine();
                    }
                }
            }
            else
            {
                Console.WriteLine($"Cannot find {csvPath}");
            }

            result.Success = true;
            result.Message = "";
            result.Data = _panels;
            //result.Data = new List<Panel>(_panels);
            return result;
        }

        public void WriteAll(List<Panel> _panels)   //hmmm
        {
            using (StreamWriter sw = new StreamWriter(csvPath))    //HERE
            {
                if (Fmt.HasHeaderLine())
                {
                    sw.WriteLine(Fmt.HeaderLine());
                }

                foreach (Panel p in _panels)
                {
                    sw.WriteLine(Fmt.Serialize(p));
                }
            }
        }
        //Work on ConsoleIO and serialization  (need package for serial)          

        //        string path = Directory.GetCurrentDirectory() + @"\Data\Panels.csv";

        //            if (File.Exists(path))
        //            {
        //                // to hold data
        //                List<Panel> panels = new List<Panel>();

        //                // create and open streamreader
        //                using (StreamReader sr = new StreamReader(path))
        //                {
        //                    string currentLine = sr.ReadLine(); // header line
        //                                                        //maybe make variable for head row... or actually don't have to
        //    ///ask if there is a header
        //    currentLine = sr.ReadLine(); // 1st data row

        //                    while (currentLine != null)
        //                    {
        //                        Panel p = new Panel(); // create a panel object for each line
        //    string[] columns = currentLine.Split(","); // split columns

        //    // add data to object, parsing types as necessary
        //    p.Section = columns[0];
        //                        p.Row = int.Parse(columns[1]);
        //    p.Column = int.Parse(columns[2]);
        //    string month = "1/1/";
        //    string yearString = columns[3];
        //    p.Year = DateTime.Parse(month + yearString);
        //                        p.Material = int.Parse(columns[4]);
        //    p.IsTracking = columns[5];

        //                        panels.Add(p); // add object to list

        //                        currentLine = sr.ReadLine(); // next line
        //                    }
        //                }
        //            }

        //            //string wholeFile = File.ReadAllText(path);

        //    //Console.WriteLine(wholeFile);
        //else
        //{
        //    Console.WriteLine($"File at {path} not found.");
        //}
        //        }

        public Result<Panel> Add(Panel panel)
            {
                _panels = GetAll().Data;
                _panels.Add(panel);
                Result<Panel> result = new Result<Panel>();
                result.Data = panel;
                result.Success = true;
                result.Message = "";
                return result;
            }

            public Result<Panel> Update(Panel panel)    
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
