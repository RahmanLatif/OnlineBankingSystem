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
    public partial class Customer : Form
    {
        CustomerClass customerInfo;
        void resetBtns()
        {
            button1.BackColor = Color.FromArgb(0, 0, 64);
            button2.BackColor = Color.FromArgb(0, 0, 64);
            button3.BackColor = Color.FromArgb(0, 0, 64);
            button4.BackColor = Color.FromArgb(0, 0, 64);

            // hide

            btnSameBank.Visible = false;
            btnDiffBank.Visible = false;
            btnPayPaymentHistory.Visible = false;
            btnPayBills.Visible = false;
            btnChangePass.Visible = false;
            btnChangeUsername.Visible = false;
            btnTransInfo.Visible = false;
            btnAccountInfo.Visible = false;
        }
        public Customer(CustomerClass c)
        {
            InitializeComponent();
            customerInfo = c;
            string username = c.UserName;
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

        private void button3_Click(object sender, EventArgs e)
        {
            resetBtns();
            btnTransInfo.Visible = true;
            btnAccountInfo.Visible = true;
            button3.BackColor = Color.Maroon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resetBtns();
            btnSameBank.Visible = true;
            btnDiffBank.Visible = true;
            button1.BackColor = Color.Maroon;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            resetBtns();
            btnChangePass.Visible = true;
            btnChangeUsername.Visible = true;
            button2.BackColor = Color.Maroon;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            resetBtns();
            btnPayPaymentHistory.Visible = true;
            btnPayBills.Visible = true;
            button4.BackColor = Color.Maroon;
        }


        private void logoutbtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to logout?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Customer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Restart();
        }


        private void btnAccountInfo_Click(object sender, EventArgs e)
        {
            ShowCustomerInfo custInfo = new ShowCustomerInfo(customerInfo);
            custInfo.Show();
        }

        private void btnTransInfo_Click(object sender, EventArgs e)
        {
            ViewTransactions viewTransactions = new ViewTransactions(customerInfo);
            viewTransactions.Show();
        }



        private void btnSameBank_Click(object sender, EventArgs e)
        {
            TransferSameBank tr = new TransferSameBank(customerInfo);
            tr.Show();
        }

        private void btnDiffBank_Click(object sender, EventArgs e)
        {
            TransferToOtherBank tr = new TransferToOtherBank(customerInfo);
            tr.Show();
        }

        private void btnPayBills_Click(object sender, EventArgs e)
        {
            PayBills pay = new PayBills(customerInfo);
        }

        private void btnPayPaymentHistory_Click(object sender, EventArgs e)
        {
            ViewPaymentHistory viewPayment = new ViewPaymentHistory(customerInfo);
            viewPayment.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btnChangeUsername_Click(object sender, EventArgs e)
        {
            Utility_changeUsername ut = new Utility_changeUsername(customerInfo);
            ut.Show();    
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            Utility_changePass ut = new Utility_changePass(customerInfo);
            ut.Show();
        }
    }
}
