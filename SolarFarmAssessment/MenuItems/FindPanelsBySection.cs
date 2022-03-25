﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarFarmAssessment.MenuItems
{
    class FindPanelsBySection : MenuItem
    {
        public FindPanelsBySection()
        {
            Selector = 1;
            Description = "Find Panels by Section";
        }
        public override bool Execute(ConsoleIO ui)
        {
            ui.Display("section");  //eee
            return true;
        }
    }
}
