using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarFarm.BLL;
using SolarFarm.Core.Interfaces;
using SolarFarm.Core.DTO;

namespace SolarFarmAssessment.MenuItems
{
    class FindPanelsBySection : MenuItem
    {
        public FindPanelsBySection()
        {
            Selector = 1;
            Description = "Find Panels by Section";
        }
        public IPanelService Service { get; set; }
        public override bool Execute(ConsoleIO ui, ValidationID vID)
        {
            bool running = true;
            string section;
            ui.Display("section");  //eee

            while (running)
            {
                section = ui.GetString("Enter Section"); //may look nicer, be less copy&paste if put in validation
                vID = new ValidationID();
                if (!vID.CheckSectionIsNotNull(section))    //some overlap in responsibility
                {
                    ui.Warn("[Err] Must enter a name for section");
                    running = true;
                }
                else
                {
                    Result<List<Panel>> result = Service.FindPanelsBySection(section);  //here too
                    if (result.Success)
                    {
                        foreach (Panel panel in result.Data)
                        {
                            ui.Display(panel.ToString());
                        }
                    }
                    else
                    {
                        ui.Display(result.Message);
                    }

                    running = false;
                }
                                
            }            
            return true;
        }
    }
}
