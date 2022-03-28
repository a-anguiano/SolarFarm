using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarFarm.Core.DTO;
using SolarFarm.Core.Interfaces;
using SolarFarm.DAL;

namespace SolarFarm.BLL
{
    public class PanelServiceFactory
    {
        public static IPanelService GetPanelService()
        {            
            return new PanelService(new PanelRepository());            
        }

    }
}
