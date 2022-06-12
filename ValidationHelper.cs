using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace book_car_maintenance
{
    class ValidationHelper
    {
        public static string Capitalize(ref string txt)
        {
            if(txt == null)
            {
                txt = "";
                return txt;
            }
            else
            {
                string newString = txt.ToLower().Trim();
                return newString;
            }
        }

        public static bool IsValidPostalCode(string postalCode)
        {
            Regex validPostalCode = new Regex(@"^([a-z]|[A-Z])[0-9]([a-z]|[A-Z])\s?[0-9]([a-z]|[A-Z])[0-9]$");
            if(postalCode == null || postalCode == "")
            {
                return false;
            }
            else if(validPostalCode.IsMatch(postalCode))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
