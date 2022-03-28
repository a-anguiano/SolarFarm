using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarFarm.Core;
using SolarFarm.Core.DTO;
using SolarFarm.Core.Interfaces;
using Newtonsoft.Json;


namespace SolarFarm.DAL
{
    public class PanelJSONFormatter : IPanelFormatter
    {
        public Panel Deserialize(string data)
        {
            return JsonConvert.DeserializeObject<Panel>(data);
        }

        public string Serialize(Panel panel)
        {
            return JsonConvert.SerializeObject(panel);
        }

        public bool HasHeaderLine()
        {
            return false;
        }

        public string HeaderLine()
        {
            return null;
        }
    }
}
