using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarFarm.Core;
using SolarFarm.Core.DTO;
using SolarFarm.Core.Interfaces;

namespace SolarFarm.DAL
{
    public class PanelCSVFormatter : IPanelFormatter
    {
        public Panel Deserialize(string data)
        {
            Panel result = new Panel();
            string[] fields = data.Split(",");
            result.Section = fields[0];
            result.Row = int.Parse(fields[1]);
            result.Column = int.Parse(fields[2]);
            result.Material = int.Parse(fields[3]);
            string month = "1/1/";
            string yearString = fields[4];
            result.Year = DateTime.Parse(month + yearString);
            //result.Year = DateTime.Parse(fields[4]);
            result.IsTracking = fields[5];

            return result;
        }

        public string Serialize(Panel panel)
        {
            return $"{panel.Section},{panel.Row},{panel.Column},{panel.Material},{panel.Year},{panel.IsTracking}";
        }

        public bool HasHeaderLine()
        {
            return true;
        }

        public string HeaderLine()
        {
            return "Section,Row,Column,Material,Year,IsTracking";
        }
    }
}
