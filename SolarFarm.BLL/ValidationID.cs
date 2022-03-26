using System;
using System.Collections.Generic;
using SolarFarm.Core.DTO;
using SolarFarm.Core.Interfaces;
using System.Text;

namespace SolarFarm.BLL
{
    public class ValidationID
    {
        public bool CheckSectionIsNotNull(string section)
        {
            if(String.IsNullOrEmpty(section))
            {
                return false;
            }
            else
            {
                return true;
            }            
        }

        public bool CheckRow(int row)
        {
            if(row > 250 || row < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckColumn(int column)
        {
            if(column > 250 || column < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckMaterial(string material)  //int or enum
        {
            //material is required and can be only one of the five
            if (String.IsNullOrEmpty(material))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckYear(DateTime year)
        {
            if (year > DateTime.Now)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //year is in the past

        public bool CheckIsTracking(string isTracking)  //bool?
        {
            //material is required and can be only one of the five
            if (String.IsNullOrEmpty(isTracking))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //must not duplicate a panel
        public bool CheckIfDuplicate()          //FIX THIS!!!!!!!
        {
            return true;
        }
    }
}
