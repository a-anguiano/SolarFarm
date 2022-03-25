using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarFarm.BLL;

namespace SolarFarmAssessment.MenuItems
{
    class Add : MenuItem
    {        
        public Add()    
        {
            Selector = 2;
            Description = "Add a Panel";
        }
        public override bool Execute(ConsoleIO ui, ValidationID vID)        //not sure to make interface or not
        {
            bool running = true;

            while(running)
            {
                string section = ui.GetString("Enter Section");
                vID = new ValidationID();
                if (!vID.CheckSectionIsNotNull(section))
                {
                    ui.Warn("[Err] Must enter a name for section");
                    running = true;      //not sure
                }
                else
                {
                   running = false;
                }
            }            

            int row = ui.GetInt("Enter Row");
            int column = ui.GetInt("Enter Column");
            string material = ui.GetString("Enter material type");                //material
            string yearString = ui.GetString("Enter year installed");
            DateTime year = DateTime.Parse(yearString);                                                    //install year
            string isTracking = ui.GetString("Does it track? Enter [y/n]");


            return true;        //hmmm
        }
    }
}
