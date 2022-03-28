using System;
using System.Collections.Generic;
using SolarFarm.Core.DTO;
using SolarFarm.Core.Interfaces;
using System.IO;
using SolarFarm.Core;

namespace SolarFarm.DAL
{
    public class PanelRepository : IPanelRepository         //do I need an interface for the repository?
    {
        private List<Panel> _panels;        


        //public PanelRepository()                    //for testing purposes
        //{ }
             public string Path { get; set; }
             public IPanelFormatter fmt { get; set; }
        
            public Result<List<Panel>> GetAll()
            {
                _panels = new();         
                Result<List<Panel>> result = new Result<List<Panel>>();            

                if (File.Exists(Path))
                {
                    using (StreamReader sr = new StreamReader(Path))
                    {
                        string line = sr.ReadLine();
                        if (line != null && fmt.HasHeaderLine())
                        {
                            line = sr.ReadLine();
                        }

                        while (line != null)
                        {
                            _panels.Add(fmt.Deserialize(line));
                            line = sr.ReadLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Cannot find {Path}");
                }

                result.Success = true;
                result.Message = "";
                result.Data = _panels;
                //result.Data = new List<Panel>(_panels);
                return result;
            }        

            public void WriteAll(List<Panel> panels)
            {
                using (StreamWriter sw = new StreamWriter(Path))
                {
                    if (fmt.HasHeaderLine())
                    {
                        sw.WriteLine(fmt.HeaderLine());
                    }

                    foreach (Panel p in panels)
                    {
                        sw.WriteLine(fmt.Serialize(p));
                    }
                }
            }
        //Work on ConsoleIO and serialization  (need package for serial)          

        //    string path = Directory.GetCurrentDirectory() + @"\Data\SolarPanels.csv";

        //    if (File.Exists(path))
        //    {
        //        // to hold data
        //        List<Panel> panels = new List<Panel>();

        //        // create and open streamreader
        //        using (StreamReader sr = new StreamReader(path))
        //        {
        //            string currentLine = sr.ReadLine(); // header line
        //                                                //maybe make variable for head row... or actually don't have to
        //            ///ask if there is a header
        //            currentLine = sr.ReadLine(); // 1st data row

        //            while (currentLine != null)
        //            {
        //                Panel p = new Panel(); // create a panel object for each line
        //                string[] columns = currentLine.Split(","); // split columns

        //                // add data to object, parsing types as necessary
        //                p.Section = columns[0];
        //                p.Row = int.Parse(columns[1]);
        //                p.Column = int.Parse(columns[2]);
        //                string month = "1/1/";
        //                string yearString = columns[3];
        //                p.Year = DateTime.Parse(month + yearString);
        //                p.Material = int.Parse(columns[4]);
        //                p.IsTracking = columns[5];

        //                panels.Add(p); // add object to list

        //                currentLine = sr.ReadLine(); // next line
        //            }
        //        }
        //    }

        //    //string wholeFile = File.ReadAllText(path);

        //    //Console.WriteLine(wholeFile);
        //    else
        //    {
        //            Create(path); //perhaps? create csv file
        //    }
        //}

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

        //public Result<List<Panel>> GetAll()       
        //{
        //    Result<List<Panel>> result = new Result<List<Panel>>();
        //    result.Success = true;
        //    result.Message = "";
        //    result.Data = new List<Panel>(_panels);
        //    return result;
        //}

    }
}
