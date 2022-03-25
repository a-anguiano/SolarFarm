using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarFarm.Core.DTO;

namespace SolarFarm.Core.Interfaces
{
    public interface IPanelRepository
    {
        Result<List<Panel>> FindPanelsBySection(string section);    // Retrieves all panels from storage, of a section???
        Result<Panel> Add(Panel panel);                             // Adds a panel to storage
        Result<Panel> Remove(string section, int row, int column);   // Removes panel for given section, row, col
        Result<Panel> Update(Panel panel);                          // Replaces a panel with ....?
    }
}
