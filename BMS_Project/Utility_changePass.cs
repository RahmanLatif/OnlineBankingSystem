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
    public partial class  Utility_changePass : Form
    {
        Object info;
        public Utility_changePass(Object inf)
        {
            InitializeComponent();
            info = inf;
        }

        private void btnRstLogin_Click(object sender, EventArgs e)
        {
            txtBoxConfirmPass.Clear();
            txtBoxCurrPass.Clear();
            txtBoxNewPass.Clear();
        }

        private void btnSbmt_Click(object sender, EventArgs e)
        {
            string confirme = txtBoxCurrPass.Text;
            string newPass = txtBoxNewPass.Text;
            string confirmNewPass = txtBoxConfirmPass.Text;
            if (newPass.Equals(confirmNewPass))
            {
                if (info.GetType() == typeof(AdminClass))
                {
                    AdminClass admin = (AdminClass)info;
                    bool done = admin.ChangePassword(confirme, newPass);
                    if (done)
                    {
                        MessageBox.Show("Password updated succssesfully");
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Enter a correct password");
                    }
                } 
                else if (info.GetType() == typeof(CustomerClass))
                {
                    CustomerClass customer = (CustomerClass)info;
                    bool done = customer.ChangePassword(confirme, newPass, confirmNewPass);
                    if (done)
                    {
                        MessageBox.Show("Password updated succssesfully");
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Enter a correct password");
                    }
                }
            }
            else
            {
                MessageBox.Show("New passwords don't match!");
            }
        }
    }
}
