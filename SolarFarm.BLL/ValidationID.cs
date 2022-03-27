using System;
using System.Collections.Generic;
using SolarFarm.Core.DTO;
using SolarFarm.Core.Interfaces;
using System.Text;

namespace SolarFarm.BLL
{
    public class ValidationID
    {
        public enum MaterialTypes
        {
            MuSi,       //multicrystalline_silicon,       //0
            MoSi,       //monocrystalline_silicon, 
            AmSi,       //amorphous_silicon, 
            CdTe,       //cadmium_telluride,      
            CIGS        //copper_indium_gallium_selenide      //format
        }

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

        public bool CheckMaterial(int material)
        {           
            if (material == (int)MaterialTypes.MuSi)
            {
                return true;
            }
            if (material == (int)MaterialTypes.MoSi)
            {
                return true;
            }
            if (material == (int)MaterialTypes.AmSi)
            {
                return true;
            }
            if (material == (int)MaterialTypes.CdTe)
            {
                return true;
            }
            if (material == (int)MaterialTypes.CIGS)
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

        public bool CheckIsTracking(string isTracking)
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
        //public bool CheckIfDuplicate()          //FIX THIS!!!!!!!
        //{
        //    return true;
        //}
    }
}
