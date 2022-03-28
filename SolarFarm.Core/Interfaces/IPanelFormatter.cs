using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarFarm.Core.DTO;

namespace SolarFarm.Core.Interfaces
{
    public interface IPanelFormatter
    {
        Panel Deserialize(string data);
        string Serialize(Panel panel);
        bool HasHeaderLine();
        string HeaderLine();
    }
}
