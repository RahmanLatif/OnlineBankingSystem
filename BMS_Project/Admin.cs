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
    public partial class Admin : Form
    {
        AdminClass adminInfo;
        void resetBtns()
        {
            // Colors
            button1.BackColor = Color.FromArgb(0, 0, 64);
            button2.BackColor = Color.FromArgb(0, 0, 64);
            button3.BackColor = Color.FromArgb(0, 0, 64);
            button4.BackColor = Color.FromArgb(0, 0, 64);
           

            // Visablity
            btnAddCoo.Visible = false;
            btnDeleteCoo.Visible = false;
            btnTransactions.Visible = false;
            btnPayments.Visible = false;
            btnRecenUsers.Visible = false;
            btnChangePass.Visible = false;
            btnChangeUsername.Visible = false;
        }
        public Admin(AdminClass admin)
        {
            InitializeComponent();
            adminInfo = admin;
            string username = adminInfo.username;
            if (username.Length > 8)
            {
                string tmp = "";
                for (int i = 0; i < 8; i++)
                    tmp += username[i];
                tmp += "..";
                username = tmp;
            }
            lblUserName.Text = username;
        }

       
        private void button4_Click(object sender, EventArgs e)
        {
            resetBtns();
            button4.BackColor = Color.Maroon;
            btnTransactions.Visible = true;
            btnPayments.Visible = true;
            btnRecenUsers.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            resetBtns();
            button3.BackColor = Color.Maroon;
            btnAddCoo.Visible = true;
            btnDeleteCoo.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resetBtns();
            button1.BackColor = Color.Maroon;
            ViewAdminAcc v = new ViewAdminAcc(adminInfo);
            v.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            resetBtns();
            btnChangePass.Visible = true;
            btnChangeUsername.Visible = true;
            button2.BackColor = Color.Maroon;
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            ViewTransactions viewT = new ViewTransactions(adminInfo);
            viewT.Show();
        }

        private void btnAddCoo_Click(object sender, EventArgs e)
        {
            AddCoo addCoo = new AddCoo(adminInfo);
            addCoo.Show();
        }

        private void btnDeleteCoo_Click(object sender, EventArgs e)
        {
            DeleteCoo delForm = new DeleteCoo(adminInfo);
            delForm.Show();
        }

        private void btnRecenUsers_Click(object sender, EventArgs e)
        {
            RecentLogedUsers re = new RecentLogedUsers(adminInfo);
            re.Show();
        }  

             
        private void logoutbtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to logout?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Restart();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            Utility_changePass ut = new Utility_changePass(adminInfo);
            ut.Show();
        }

        private void btnChangeUsername_Click(object sender, EventArgs e)
        {
            Utility_changeUsername ut = new Utility_changeUsername(adminInfo);
            ut.Show();
            Application.Restart();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            ViewPaymentHistory view = new ViewPaymentHistory(adminInfo);
            view.Show();
        }

      
    }
}
