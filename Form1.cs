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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime;

namespace book_car_maintenance
{
    public partial class Form1 : Form
    {
        //Creating a method to include an error message in the empty label and focusing in the first invalid textbox
        public void ErrorMessage(string message, Control control)
        {
            if (lblErrorMessageOne.Text == null || lblErrorMessageOne.Text == "")
            {
                lblErrorMessageOne.Text = message;
                control.Focus();
            }
            else if (lblErrorMessageTwo.Text == null || lblErrorMessageTwo.Text == "")
            {
                lblErrorMessageTwo.Text = message;
            }
            else
            {
                lblErrorMessageThree.Text = message;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        //Loads the textboxes with valid data
        private void btnPreFill_Click(object sender, EventArgs e)
        {
            txtbCustomerName.Text = "example name";
            txtbAddress.Text = "777 example st";
            txtbCity.Text = "kitchener";
            txtbProvince.Text = "ON";
            txtbPostalCode.Text = "N2G 0C9";
            txtbHomePhone.Text = "5195195190";
            txtbCellPhone.Text = "5195195190";
            txtbEmail.Text = "example@example.com";
            txtbMakeModel.Text = "honda civic";
            txtbYear.Text = "2015";
        }

        //Closes the program
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Reset all textboxes and error messages
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtbCustomerName.Text = null;
            txtbAddress.Text = null;
            txtbCity.Text = null;
            txtbProvince.Text = null;
            txtbPostalCode.Text = null;
            txtbHomePhone.Text = null;
            txtbCellPhone.Text = null;
            txtbEmail.Text = null;
            txtbMakeModel.Text = null;
            txtbYear.Text = null;
            lblErrorMessageOne.Text = null;
            lblErrorMessageTwo.Text = null;
            lblErrorMessageThree.Text = null;
        }

        private void btnBookAppointment_Click(object sender, EventArgs e)
        {
            //When the name is null or empty a message is shown. Name is REQUIRED
            if(txtbCustomerName.Text == null| txtbCustomerName.Text == "")
            {
                lblErrorMessageOne.Text = "Customer Name is required";
                txtbCustomerName.Focus();
            }
            else
            {
                //When the name is valid each first letter of the word is capitalized
                if(ValidationHelper.IsValidString(txtbCustomerName.Text) == true)
                {
                    txtbCustomerName.Text = ValidationHelper.Capitalize(txtbCustomerName.Text);
                }
                //When is not valid a message is shown
                else
                {
                    lblErrorMessageOne.Text = "Invalid Customer Name";
                    txtbCustomerName.Focus();
                }
            }

            //When the Address is null or empty is necessary to check if the email is also empty or not
            if(txtbAddress.Text == null||txtbAddress.Text == "")
            {
                //When the email is null or empty a message is shown. Address is REQUIRED
                if(txtbEmail.Text == null||txtbEmail.Text == "")
                {
                    ErrorMessage("Address is required if email is not provided", txtbAddress);
                }
                //When email is NOT null or empty, the Address is OPTIONAL.
                //Converting an incoming null to empty
                else
                {
                    txtbAddress.Text = ValidationHelper.Capitalize(txtbAddress.Text);
                }
            }
            //Capitalizing the first letter of each word
            else
            {
                txtbAddress.Text = ValidationHelper.Capitalize(txtbAddress.Text);
            }

            //When the City is null or empty is necessary to check if the email is also empty or not
            if (txtbCity.Text == null || txtbCity.Text == "")
            {
                //When the email is null or empty a message is shown. City is REQUIRED
                if (txtbEmail.Text == null || txtbEmail.Text == "")
                {
                    ErrorMessage("City is required if email is not provided", txtbCity);
                }
                //When email is NOT null or empty, the City is OPTIONAL.
                //Converting incoming null to empty
                else
                {
                    txtbCity.Text = ValidationHelper.Capitalize(txtbCity.Text);
                }
            }
            //Capitalizing the first letter of each word
            else
            {
                txtbCity.Text = ValidationHelper.Capitalize(txtbCity.Text);
            }

            //When the Postal Code is null or empty is necessary to check if the email is also empty or not
            if (txtbPostalCode.Text == null || txtbPostalCode.Text == "")
            {
                //When the email is null or empty a message is shown. Postal Code is REQUIRED
                if (txtbEmail.Text == null || txtbEmail.Text == "")
                {
                    ErrorMessage("Postal Code is required if email is not provided", txtbPostalCode);
                }
                //When email is NOT null or empty, the Postal Code is OPTIONAL.
                //Converting incoming null to empty
                else
                {
                    txtbPostalCode.Text = ValidationHelper.Capitalize(txtbPostalCode.Text);
                }
            }
            else
            {
                //When the Postal Code is valid it is converted to upper case and trimmed
                if (ValidationHelper.IsValidPostalCode(txtbPostalCode.Text) == true)
                {
                    txtbPostalCode.Text = txtbPostalCode.Text.ToUpper().Trim();

                    //If the Postal Code doesn't have a space it will be included
                    if (!txtbPostalCode.Text.Contains(" "))
                    {
                        txtbPostalCode.Text = txtbPostalCode.Text.Substring(0, 3) + " " + txtbPostalCode.Text.Substring(3, 3);
                    }
                }
                //When the Postal Code is invalid a message is shown
                else
                {
                    ErrorMessage("Invalid Postal Code", txtbPostalCode);
                }
            }

            //When the Province is null or empty is necessary to check if the email is also empty or not
            if (txtbProvince.Text == null || txtbProvince.Text == "")
            {
                //When the email is null or empty a message is shown. Province is REQUIRED
                if (txtbEmail.Text == null || txtbEmail.Text == "")
                {
                    ErrorMessage("Province is required if email is not provided", txtbProvince);
                }
                //When email is NOT null or empty, the Postal Code is OPTIONAL.
                //Converting incoming null to empty
                else
                {
                    txtbProvince.Text = ValidationHelper.Capitalize(txtbProvince.Text);
                }
            }
            else
            {
                //When the Province is valid it is converted to upper case and trimmed
                if (ValidationHelper.IsValidProvince(txtbProvince.Text) == true)
                {
                    txtbProvince.Text = txtbProvince.Text.ToUpper().Trim();
                }
                //When the Province is invalid a message is shown
                else
                {
                    ErrorMessage("Invalid Province. Please insert a Province with two letters", txtbProvince);
                }
            }

            //A home phone or cell phone is REQUIRED, so if they are empty a message is shown
            if((txtbHomePhone.Text == null|| txtbHomePhone.Text == "") && (txtbCellPhone.Text == null || txtbCellPhone.Text == ""))
            {
                ErrorMessage("Home Phone or Cell Phone must be provided.", txtbHomePhone);
            }
            //When they are not empty a validating process starts
            else
            {
                //When the phone numbers are valid they are trimmed
                if(ValidationHelper.IsValidPhoneNumber(txtbHomePhone.Text) == true || ValidationHelper.IsValidPhoneNumber(txtbCellPhone.Text) == true)
                {
                    txtbCellPhone.Text = txtbCellPhone.Text.Trim();
                    txtbHomePhone.Text = txtbHomePhone.Text.Trim();

                    //If the Cell Phone doesn't have a dash it will be included
                    if (!(txtbCellPhone.Text.Contains("-")))
                    {
                        txtbCellPhone.Text = txtbCellPhone.Text.Substring(0, 3) + "-" + txtbCellPhone.Text.Substring(3, 3) + "-" + txtbCellPhone.Text.Substring(6);
                    }

                    //If the Home Phone doesn't have a dash it will be included
                    if (!(txtbHomePhone.Text.Contains("-")))
                    {
                        txtbHomePhone.Text = txtbHomePhone.Text.Substring(0, 3) + "-" + txtbHomePhone.Text.Substring(3, 3) + "-" + txtbHomePhone.Text.Substring(6);
                    }
                }
                else
                {
                    //When the phone number is not valid a message is shown
                    if(ValidationHelper.IsValidPhoneNumber(txtbHomePhone.Text) == false)
                    {
                        ErrorMessage("Invalid number. Insert a number XXX-XXX-XXXX", txtbHomePhone);
                    }
                    else if(ValidationHelper.IsValidPhoneNumber(txtbCellPhone.Text) == false)
                    {
                        ErrorMessage("Invalid number. Insert a number XXX-XXX-XXXX", txtbCellPhone);
                    }
                }
            }

            //The email is an OPTIONAL textbox
            //When valid it is trimmed
            if(ValidationHelper.IsValidEmail(txtbEmail.Text) == true)
            {
                txtbEmail.Text = txtbEmail.Text.Trim();
            }
            //When null it is converted to empty
            else if(txtbEmail.Text == null || txtbEmail.Text == "")
            {
                txtbEmail.Text = ValidationHelper.Capitalize(txtbEmail.Text);
            }
            //When it is invalid a message is shown
            else
            {
                ErrorMessage("Invalid email.", txtbEmail);
            }

            //When make and model is empty a message is shown. Make and Model is REQUIRED
            if (txtbMakeModel.Text == null|| txtbMakeModel.Text == "")
            {
                ErrorMessage("Make & Model is required", txtbMakeModel);
            }
            else
            {
                //When the make and model is valid each first letter of the word is capitalized
                if (ValidationHelper.IsValidString(txtbMakeModel.Text) == true)
                {
                    txtbMakeModel.Text = ValidationHelper.Capitalize(txtbMakeModel.Text);
                }
                //when it is invalid a message is shown
                else
                {
                    ErrorMessage("Invalid input. Please insert the make & model. Numbers and special characters are not allowed.", txtbMakeModel);
                }
            }

            //Year is OPTIONAL so when it is null it is converted to empty
            if (txtbYear.Text == null || txtbYear.Text == "")
            {
                txtbYear.Text = ValidationHelper.Capitalize(txtbYear.Text);
            }
            //When the year id valid it is trimmed
            else if (ValidationHelper.IsValidYear(txtbYear.Text) == true)
            {
                txtbYear.Text = txtbYear.Text.Trim();
            }
            //When it is invalid a message is shown
            else
            {
                ErrorMessage("Invalid input. Please insert a year between 1900 and current year +1", txtbYear);
            }

            DateTimePicker date = new DateTimePicker();
            date.MinDate = DateTime.Now;

            if (date.Value == DateTime.Now)
            {
                ErrorMessage("Please, insert a future date for booking", dateTimePicker);
            }
            else
            {
                date.CustomFormat = "dd MMM yyyy";
                date.Format = DateTimePickerFormat.Custom;
            }
        }
    }
}
