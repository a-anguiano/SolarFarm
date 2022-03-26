using System;
using System.Collections.Generic;
using SolarFarm.Core.DTO;
using SolarFarm.Core.Interfaces;
using System.Text;

namespace SolarFarm.BLL
{
    public class ValidationID
    {
        //public bool CheckIfPanelExists()
        //{

        //}

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
            if(row > 250 || row < 1)
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
            if(column > 250 || column < 1)
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
            //if (String.IsNullOrEmpty(material))
            //{
            //    return false;
            //}
            if (material == "MuSi" || material == "MoSi" || material == "AmSi" || material == "CdTe" || material == "CIGS")
            {
                return true;
            }

            else
            {
                return false;
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

        public bool CheckIsTracking(string isTracking)  //bool? may have to have variable for tracker string
        {
            if (!String.IsNullOrEmpty(isTracking))
            {
                isTracking = isTracking.ToLower();

                if (isTracking == "y" || isTracking == "n")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }            
            else
            {
                return false;
            }
        }

        //must not duplicate a panel
        public bool CheckIfDuplicate()          //FIX THIS!!!!!!!
        {
            return true;
        }
    }
}
