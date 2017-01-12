using MySql.Data.MySqlClient;
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
    public partial class Welcome : Form
    {
      
        public Welcome()
        {
            InitializeComponent();
            pnlLogin.Parent = this;
            pnlReg.Parent = this;
            pnlLogin.BringToFront();
            pnlLogin.Location = new Point(11, 30);
            ////////////////////////
            
            ////////////////////////
        }


        private void btnRegForm_Click(object sender, EventArgs e)
        {
            pnlLogin.Visible = false;
            pnlReg.Visible = true;
            pnlReg.BringToFront();
            pnlReg.Location = new Point(11, 30);
        }

        private void btnLoginForm_Click(object sender, EventArgs e)
        {
            pnlReg.Visible = false;
            pnlLogin.Visible = true;
            pnlLogin.BringToFront();
            pnlLogin.Location = new Point(11, 30);
        }

        private void btnSbmtLogin_Click(object sender, EventArgs e)
        {
            int idx = cmboUserType.SelectedIndex;
            if (idx == 0)
            {
                this.Hide();
                AdminMasterClass master = new AdminMasterClass(txtbxUsernameLogin.Text, txtbxPassLogin.Text);
                if (master.Login())
                {
                    AdminMaster adminMaster = new AdminMaster(master);
                    adminMaster.Show();
                }
                else
                {
                    MessageBox.Show("Please Enter Correct Username and Password");
                    Application.Restart();
                }
            }
            else if (idx == 1)
            {
                this.Hide();
                AdminClass a = new AdminClass(txtbxUsernameLogin.Text, txtbxPassLogin.Text);
                if (a.Login())
                {
                    Admin admin = new Admin(a);
                    admin.Show();
                }
                else
                {
                    MessageBox.Show("Please Enter Correct Username and Password!");
                    Application.Restart();
                }
            }
            else if (idx == 2)
            {
                this.Hide();
                CustomerClass cstmr = new CustomerClass(txtbxUsernameLogin.Text, txtbxPassLogin.Text);
                if (cstmr.Login())
                {
                    Customer customer = new Customer(cstmr);
                    customer.Show();
                }
                else
                {
                    MessageBox.Show("Please Enter Correct Username and Password!");
                    Application.Restart();
                }
            }
        }

        private void btnRstLogin_Click(object sender, EventArgs e)
        {
            txtbxUsernameLogin.Clear();
            txtbxPassLogin.Clear();
            cmboUserType.SelectedIndex = -1;
        }

        private void btnRstReg_Click(object sender, EventArgs e)
        {
            txtbxAccNumReg.Clear();
            txtbxPassReg.Clear();
            txtbxUsernameReg.Clear();
        }

        private void btnSbmtReg_Click(object sender, EventArgs e)
        {
            string username = txtbxUsernameReg.Text;
            string password = txtbxPassReg.Text;
            string accNum = txtbxAccNumReg.Text;
            Register reg = new Register(username, password, accNum);
            reg.Reg();

        }
        
    }
}
