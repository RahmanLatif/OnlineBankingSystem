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
    public partial class TransferSameBank : Form
    {
        CustomerClass c;
        public TransferSameBank(CustomerClass customerinfo)
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
            if (!c.TransferToSameBank(txtBoxAccNum.Text, txtBoxAccNum2.Text, numericUpDown1.Value.ToString()))
                MessageBox.Show("Not Enough Balance !!");
            else
            {
                MessageBox.Show("Transfer Done,Your New Balnce is '" + c.Balance.ToString() + "'");
                this.Close();
            }
        }
    }
}
