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
    public partial class DeleteCoo : Form
    {
        AdminClass adminInfo;
        List<string> cooperatives;
        public DeleteCoo(AdminClass admin)
        {
            InitializeComponent();
            adminInfo = admin;
            cooperatives = new List<string>();
            cooperatives = adminInfo.getCoo();
            fillCombo();
        }

        private void fillCombo()
        {
            for (int i = 0; i < cooperatives.Count; i++)
            {
                comboBox1.Items.Add(cooperatives[i]);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) return;
            string password = txtPassword.Text;
            string cooName = cooperatives[comboBox1.SelectedIndex];
            bool done = adminInfo.DelCoo(password, cooName);
            if (done)
            {
                MessageBox.Show("Cooperative deleted succssesfully!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Enter correct data");
            }
        }
    }
}
