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
    public partial class Utility_changeUsername : Form
    {
        Object info;
        public Utility_changeUsername(Object o)
        {
            InitializeComponent();
            info = o;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBoxCurrPass.Clear();
            txtBoxNewUsername.Clear();
        }

        private void btnSbmt_Click(object sender, EventArgs e)
        {
            string confirme = txtBoxCurrPass.Text;
            string newUsername = txtBoxNewUsername.Text;
            if (info.GetType() == typeof(AdminClass))
            {
                AdminClass admin = (AdminClass)info;
                bool done = admin.ChangeUsername(confirme, newUsername);
                if (done)
                {
                    MessageBox.Show("Username updated succssesfully");
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
                bool done = customer.ChangeUserName(confirme, newUsername);
                if (done)
                {
                    MessageBox.Show("Username updated succssesfully");
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Enter a correct password");
                }
            }
        }
    }
}
