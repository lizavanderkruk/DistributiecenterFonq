using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DistributiecenterFonq.Data_annotations
{
    public class VeelvoudVanTweeAttribute : ValidationAttribute
    {
        public VeelvoudVanTweeAttribute()
        {
            ErrorMessage = "Het veld moet een veelvoud van 2 zijn.";
        }

        public override bool IsValid(object value)
        {
            //if (value is int)
            //{
            //    var intValue = (int)value;
            //    if (intValue % 2 == 0)
            //    {
            //        return intValue % 2 == 0;
            //    }
            //}
            //return false;

            if ((int)value % 2 == 0)
            {
                return (int)value % 2 == 0; 
            }
            return false;
        }
    }
}