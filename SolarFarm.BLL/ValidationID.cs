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

        //year is in the past
        //material is required and can be only one of the five
        //isTracking is required
        //must not duplicate a panel

        //if (result.Data.Year < DateTime.Now) //DateTime year
        //{
        //    result.Success = false;
        //    sb.Append("Year installed must be in the past");
        //}
        //if (String.IsNullOrEmpty(result.Data.IsTracking))
        //{
        //    result.Success = false;
        //    sb.Append("Must say if panel has sun-tracking hardware");
        //}

        ////Only one material
    }
}
