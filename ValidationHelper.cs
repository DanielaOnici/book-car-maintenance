/* book-car-maintenance.sln
 * 
 * The program contains string manipulation and input validation.
 * 
 * Daniela Onici 
 * Student ID# 8754297
 * 
 * 2022/06/11: created
 * 2022/06/12: Finished
 * 
 */

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
        public static string Capitalize(string txt)
        {
            if(txt == null)
            {
                txt = "";
                return txt;
            }
            else
            {
                string newString = txt.ToLower().Trim();
                char[] charArray = newString.ToCharArray();

                if(charArray.Length >= 1)
                {
                    charArray[0] = char.ToUpper(charArray[0]);
                }

                for(int i = 0; i < charArray.Length; i++)
                {
                    if(charArray[i] == ' ')
                    {
                        charArray[i + 1] = char.ToUpper(charArray[i + 1]);
                    }
                }

                return new string(charArray);
            }
        }

        public static bool IsValidPostalCode(string postalCode)
        {
            Regex validPostalCode = new Regex(@"^([a-z]|[A-Z])[0-9]([a-z]|[A-Z])\s?[0-9]([a-z]|[A-Z])[0-9]$");
            if(validPostalCode.IsMatch(postalCode))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidProvince(string province)
        {
            if (province == "NL" || province == "PE" || province == "NS" || province == "NB" || province == "QC" || province == "ON" || province == "MB" || province == "SK" || province == "AB" || province == "BC" || province == "YT" || province == "NT" || province == "NU")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            Regex validPhoneNumber = new Regex(@"^[0-9][0-9][0-9]-?[0-9][0-9][0-9]-?[0-9][0-9][0-9][0-9]$");
            if (validPhoneNumber.IsMatch(phoneNumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidName(string name)
        {
            Regex validName = new Regex(@"^([a-z]|[A-Z])*\s?([a-z]|[A-Z])*\s?([a-z]|[A-Z])*\s?([a-z]|[A-Z])*\s?([a-z]|[A-Z])*$");
            if(validName.IsMatch(name))
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
