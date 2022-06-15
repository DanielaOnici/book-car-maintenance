/* book-car-maintenance.sln
 * 
 * The program contains string manipulation and input validation.
 * 
 * Daniela Onici 
 * Student ID# 8754297
 * 
 * 2022/06/11: created
 * 2022/06/13: Finished
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

namespace book_car_maintenance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPreFill_Click(object sender, EventArgs e)
        {
            txtbCustomerName.Text = "example name";
            txtbAddress.Text = "777 example st";
            txtbCity.Text = "kitchener";
            txtbProvince.Text = "ON";
            txtbPostalCode.Text = "N2G 0C9";
            txtbHomePhone.Text = "519 519 5190";
            txtbCellPhone.Text = "519 519 5190";
            txtbEmail.Text = "example@example.com";
            txtbMakeModel.Text = "honda civic";
            txtbYear.Text = "2015";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

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

            string[] errors = new string[3];

            if(txtbCustomerName.Text == null| txtbCustomerName.Text == "")
            {
                lblErrorMessageOne.Text = "Customer Name is required";
            }
            else
            {
                if(ValidationHelper.IsValidName(txtbCustomerName.Text) == true)
                {
                    txtbCustomerName.Text = ValidationHelper.Capitalize(txtbCustomerName.Text);
                }
                else
                {
                    lblErrorMessageOne.Text = "Invalid Customer Name";
                }
            }

            if(txtbAddress.Text == null||txtbAddress.Text == "")
            {
                if(txtbEmail.Text == null||txtbEmail.Text == "")
                {
                    if(lblErrorMessageOne.Text == null||lblErrorMessageOne.Text == "")
                    {
                        lblErrorMessageOne.Text = "Address is required if email is not provided";
                    }
                    else if(lblErrorMessageTwo.Text == null || lblErrorMessageTwo.Text == "")
                    {
                        lblErrorMessageTwo.Text = "Address is required if email is not provided";
                    }
                    else
                    {
                        lblErrorMessageThree.Text = "Address is required if email is not provided";
                    }
                }
            }
            else
            {
                txtbAddress.Text = ValidationHelper.Capitalize(txtbAddress.Text);
            }



            //if (txtbCustomerName.Text == null || txtbCustomerName.Text == "")
            //{
            //    lblErrorMessageOne.Text = "Customer Name is required.";
            //}
            //else
            //{
            //    if (txtbEmail.Text == null || txtbEmail.Text == "")
            //    {
            //        if (txtbAddress.Text == null || txtbAddress.Text == "")
            //        {
            //            lblErrorMessageTwo.Text = "Email not informed. Address, City, Province and Postal Code are required";
            //            txtbAddress.Focus();
            //        }
            //        else if (txtbCity.Text == null || txtbCity.Text == "")
            //        {
            //            lblErrorMessageTwo.Text = "Email not informed. Address, City, Province and Postal Code are required";
            //            txtbCity.Focus();
            //        }
            //        else if (txtbProvince.Text == null || txtbProvince.Text == "")
            //        {
            //            lblErrorMessageTwo.Text = "Email not informed. Address, City, Province and Postal Code are required";
            //            txtbProvince.Focus();
            //        }
            //        else if (txtbPostalCode.Text == null || txtbPostalCode.Text == "")
            //        {
            //            lblErrorMessageTwo.Text = "Email not informed. Address, City, Province and Postal Code are required";
            //            txtbPostalCode.Focus();
            //        }
            //    }
            //    else
            //    {

            //    }
            //}
        }
    }
}
