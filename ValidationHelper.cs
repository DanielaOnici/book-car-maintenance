/* book-car-maintenance.sln
 * 
 * The program contains string manipulation and input validation.
 * 
 * Daniela Onici 
 * Student ID# 8754297
 * 
 * 2022/06/11: created
 * 2022/06/12: modified
 * 2022/06/15: Finished
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Runtime;
using System.Reflection.Metadata;

namespace book_car_maintenance
{
    class ValidationHelper
    {
        //Creating a  method to return incoming null to empty or a string with each first letter of the word capitalized
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

        //Creating a method that returns TRUE if the Postal Code matches the format letterNumberLetter numberLetterNumber (accepting lower/upper case and with or without space)
        public static bool IsValidPostalCode(string postalCode)
        {
            postalCode = postalCode.Trim();

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

        //Creating a method that returns TRUE if the Province matches the internationally approved alpha code
        public static bool IsValidProvince(string province)
        {
            province = province.ToUpper().Trim();

            if (province == "NL" || province == "PE" || province == "NS" || province == "NB" || province == "QC" || province == "ON" || province == "MB" || province == "SK" || province == "AB" || province == "BC" || province == "YT" || province == "NT" || province == "NU")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Creating a method that returns TRUE if the phone number matches the format XXX-XXX-XXXX (accepting with or without dash)
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            phoneNumber = phoneNumber.Trim();

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

        //Creating a method that returnt TRUE if the string is valid (numbers are not accepted)
        public static bool IsValidString(string name)
        {
            name = name.Trim();

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

        //Creating a method that returns TRUE if the email is valid
        public static bool IsValidEmail(string email)
        {
            email = email.Trim();

            try
            {
                MailAddress mail = new MailAddress(email);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //Creating a method that returns TRUE if the year is a valid number between 1900 and current year +1
        public static bool IsValidYear(string year)
        {
            try
            {
                year = year.Trim();
                int newYear = int.Parse(year);

                if (newYear >= 1900 && newYear <= DateTime.Now.Year + 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
