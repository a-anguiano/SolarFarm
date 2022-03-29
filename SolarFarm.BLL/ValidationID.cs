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
            MuSi,       //multicrystalline_silicon,       
            MoSi,       //monocrystalline_silicon, 
            AmSi,       //amorphous_silicon, 
            CdTe,       //cadmium_telluride,      
            CIGS        //copper_indium_gallium_selenide 
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

        public Result<Panel> CheckRowOrColumn(int rowOrColumn)
        {
            Result<Panel> result = new Result<Panel>();
            if (rowOrColumn > 250 || rowOrColumn < 1)
            {
                result.Message = "[Err] Row/Column must be between 1 and 250";
                result.Success = false;
                return result;
            }
            else
            {
                result.Success = true;
                return result;
            }
        }

        public Result<Panel> CheckMaterial(int material)
        {
            Result<Panel> result = new Result<Panel>();
            result.Success = true;
            if (material == (int)MaterialTypes.MuSi)
            {                
                return result;
            }
            if (material == (int)MaterialTypes.MoSi)
            {
                return result;
            }
            if (material == (int)MaterialTypes.AmSi)
            {
                return result;
            }
            if (material == (int)MaterialTypes.CdTe)
            {
                return result;
            }
            if (material == (int)MaterialTypes.CIGS)
            {
                return result;
            }

            else
            {
                result.Success = false;
                result.Message = "A single material of the five listed is required";
                return result;
            }
        }

        public Result<Panel> CheckYear(DateTime year)
        {
            Result<Panel> result = new Result<Panel>();
            if (year > DateTime.Now)
            {
                result.Success = false;
                result.Message = "Year installed must be in the past.";
                return result;
            }
            else
            {
                result.Success = true;
                return result;
            }
        }

        public Result<Panel> CheckIsTracking(string isTracking)
        {
            Result<Panel> result = new Result<Panel>();
            if (!String.IsNullOrEmpty(isTracking))
            {
                isTracking = isTracking.ToLower();

                if (isTracking == "y" || isTracking == "n")
                {
                    result.Success = true;
                    return result;
                }
                else
                {
                    result.Success = false;
                    result.Message = "Must enter 'y' or 'n'";
                    return result;
                }
            }            
            else
            {
                result.Success = false;
                result.Message = "Must enter a string of 'y' or 'n'";
                return result;
            }
        }
    }
}
