﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarFarm.BLL;

namespace SolarFarmAssessment.MenuItems
{
    class Remove : MenuItem
    {
        public Remove() //fix
        {
            Selector = 4;
            Description = "Remove a Panel";
        }
        public override bool Execute(ConsoleIO ui, ValidationID vID)
        {
            ui.Display("remove");   //eee
            return true;
        }
    }
}