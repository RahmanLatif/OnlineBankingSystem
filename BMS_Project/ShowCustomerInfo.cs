using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMS_Project
{
    public partial class ShowCustomerInfo : Form
    {
     
        public ShowCustomerInfo(CustomerClass cus)
        {
            InitializeComponent();
            txtBxAccount.Text = cus.AccountNumber;
            txtBxAccountType.Text = cus.AccountType;
            txtBxAddress.Text = cus.StreetAddress;
            txtBxBalance.Text = cus.Balance.ToString();
            txtBxCreationDate.Text = cus.Created.ToString();
            txtBxDateOfBirth.Text = cus.Birth.ToString();
            txtBxExpDate.Text = cus.Expired.ToString();
            txtBxFName.Text = cus.Fname;
            txtBxGender.Text = cus.Gender;
            txtBxLName.Text = cus.Lname;
            txtBxMName.Text = cus.Mname;
            txtBxNationality.Text = cus.Nation;
            txtBxPhone.Text = cus.PhoneNumber;
        }

        private void btnRstLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
