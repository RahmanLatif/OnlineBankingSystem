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
    public partial class TransferToOtherBank : Form
    {
        CustomerClass c;
        public TransferToOtherBank(CustomerClass customerinfo)
        {
            InitializeComponent();
            c = customerinfo;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!c.TransferToOtherBank(txtIBAN.Text, txtBoxAccNum.Text, txtBoxAccNum2.Text, numericUpDown1.Value.ToString()))
                MessageBox.Show("Not Enough Balance !!");
            else
            {
                MessageBox.Show("Transfer Done,Your New Balnce is '" + c.Balance.ToString() + "'");
                this.Close();
            }
        }
    }
}
