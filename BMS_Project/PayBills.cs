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
    public partial class PayBills : Form
    {
        CustomerClass c;
        DataSet ds;
        Boolean ok = false;
        public PayBills(CustomerClass cl)
        {
            List<string> l = new List<string>();
            c = cl;
            ds = c.GetCooperativeName();
            foreach (DataTable table in ds.Tables)
                foreach (DataRow dr in table.Rows)
                    l.Add(dr[0].ToString());
            if (l.Count == 0)
            {
                MessageBox.Show("There Is No Bills !!");
                this.Close();
            }
            else
            {
                InitializeComponent();
                foreach (string s in l)
                    comboBox1.Items.Add(s);
                this.Show();
            }
        }

        private void btnShowAmount_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Select Cooperative !!");
                return;
            }
            if (txtBoxAccNum.Text == "")
            {
                MessageBox.Show("Enter " + label1.Text + " !!");
                return;
            }
            ds = c.GetBillAmount(txtBoxAccNum.Text, comboBox1.Text);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Number Not Exist !!");
                return;
            }
            ok = true;
            textBox1.Text = ds.Tables[0].Rows[0][0].ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string coop = comboBox1.Text;
            DataRow dr = null;
            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow dar in table.Rows)
                {
                    if (dar[0].ToString() == coop)
                    {
                        dr = dar;
                        break;
                    }
                }
            }
            label1.Text = dr[1].ToString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Select Cooperative !!");
                return;
            }
            if (ok)
            {
                if (!c.Pay_Bill(txtBoxAccNum.Text, comboBox1.Text, textBox1.Text))
                    MessageBox.Show("Not Enough Balance !!");
                else
                    MessageBox.Show("Payment Is Done. Your New Balnce Is '" + c.Balance.ToString() + "'");
                this.Hide();
            }
            else
            {
                if (txtBoxAccNum.Text != "")
                    MessageBox.Show("Number Not Exist !!");
                else
                    MessageBox.Show("Enter " + label1.Text + " !!");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
