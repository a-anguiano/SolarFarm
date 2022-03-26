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

        public IPanelService Service { get; set; }      //not sure
        //Result<List<Panel>> result = new Result<List<Panel>>(); //hmmm
        public override bool Execute(ConsoleIO ui, ValidationID vID)
        {
            string section;
            ui.Display("Find Panels by Section");
            ui.Display("======================");
            section = ui.GetString("Enter Section");
            vID = new ValidationID();
           
            // public List<Card> Cards = new List<Card>();
            //Card card = new Card(rank, suit);
            //public List<Panel> panels = new List<Panel>;
            //Panel panel = new Panel();

            while (!vID.CheckSectionIsNotNull(section))
            {
               ui.Warn("[Err] Must enter a name for section");
               section = ui.GetString("Enter Section");
            }

            section = "Upper Hill";     //testing
            //var Service = new IPanelService()
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
            return true;
        }
    }
}
