using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarFarm.Core.DTO;

namespace SolarFarm.Core.Interfaces
{
    public interface IPanelService
    {
        Result<List<Panel>> FindPanelsBySection(string section);    // Retrieves all panels in a section from storage
        Result<Panel> Add(Panel panel);                             // Adds a panel to storage
        Result<Panel> Remove(string section, int row, int column);   // Removes panel for given section, row, col
        Result<Panel> Update(Panel panel);                          // Replaces a panel with given location?
        //may need to change parameter
        bool CheckForSectionExistence(string section);
        bool CheckForPanelExistence(string section, int row, int column);
        Panel GetPanel(string section, int row, int column);
    }
}
