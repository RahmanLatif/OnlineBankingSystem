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
    public partial class AddCoo : Form
    {
        AdminClass adminInfo;
        public AddCoo(AdminClass admin)
        {
            InitializeComponent();
            adminInfo = admin;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            string cooName = txtCooName.Text;
            string req = txtRequirement.Text;
            string accNum = txtAccNum.Text;
            bool done = adminInfo.AddCoo(password, cooName, accNum, req);
            if (done)
            {
                MessageBox.Show("Cooperative added succssesfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Enter correct data!");
            }
        }
    }
}
