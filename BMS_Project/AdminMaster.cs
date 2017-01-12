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
    public partial class AdminMaster : Form
    {
        AdminMasterClass masterInfo;
        void resetBtns()
        {
            btnDel.Visible = false;
            btn1.Visible = false;
            btn2.Visible = false;
            dataGridView1.Visible = false;

            button1.BackColor = Color.FromArgb(0, 0, 64);
            button2.BackColor = Color.FromArgb(0, 0, 64);
        }
        public AdminMaster(AdminMasterClass master)
        {
            InitializeComponent();
            masterInfo = master;
            lblUserName.Text = masterInfo.username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resetBtns();
            button1.BackColor = Color.Maroon;
            btn1.Text = "Confirm";
            btn2.Text = "Reject";
            btn1.Visible = true;
            btn2.Visible = true;

            dataGridView1.Visible = true;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.DataSource = masterInfo.getRequists().Tables[0];


            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;


            dataGridView1.Columns[0].HeaderText = "Account Number";
            dataGridView1.Columns[1].HeaderText = "Username";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resetBtns();
            button2.BackColor = Color.Maroon;
            btnDel.Visible = true;


            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.DataSource = masterInfo.getAdmins().Tables[0];
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[0].HeaderText = "Account Number";
            dataGridView1.Columns[1].HeaderText = "Username";


            dataGridView1.Visible = true;
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select row");
                return;
            }

            int idx = dataGridView1.SelectedRows[0].Index;
            string accNum = dataGridView1.Rows[idx].Cells[0].Value.ToString();

            DialogResult dialogResult = MessageBox.Show("Are You Sure to delete admin with account number = " + accNum, "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;

            bool done = masterInfo.delAdmin(accNum);
            if (done)
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[idx]);
                MessageBox.Show("Admin deleted succssfully");
            }
        }

        private void AdminMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Restart();
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to logout?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select row");
                return;
            }

            int idx = dataGridView1.SelectedRows[0].Index;
            string accNum = dataGridView1.Rows[idx].Cells[0].Value.ToString();

            DialogResult dialogResult = MessageBox.Show("Are You Sure to Add admin with account number = " + accNum, "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;

            bool done = masterInfo.addAdmin(accNum);
            if (done)
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[idx]);
                MessageBox.Show("Admin Added succssfully");
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select row");
                return;
            }

            int idx = dataGridView1.SelectedRows[0].Index;
            string accNum = dataGridView1.Rows[idx].Cells[0].Value.ToString();

            DialogResult dialogResult = MessageBox.Show("Are You Sure to reject admin with account number = " + accNum, "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;

            bool done = masterInfo.delAdmin(accNum);
            if (done)
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[idx]);
                MessageBox.Show("Admin rejected succssfully");
            }
        }

    }
}
