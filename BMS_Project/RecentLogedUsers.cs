using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;

namespace BMS_Project
{
    public partial class RecentLogedUsers : Form
    {
        AdminClass adminInfo;
        public RecentLogedUsers(AdminClass admin)
        {
            InitializeComponent();
            adminInfo = admin;

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            DataSet ds = adminInfo.GetRecentlogedusersReport();
            ds.Tables[0].Columns.Add("username");
            foreach(DataTable dt in ds.Tables)
                foreach(DataRow dr in dt.Rows)
                {
                    DataSet DS = adminInfo.GetCustomerUsername(dr[0].ToString());
                    string username = DS.Tables[0].Rows[0][0].ToString();
                    dr.SetField("username", username);
                }
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[1].DisplayIndex = 0;
            dataGridView1.Columns[0].DisplayIndex = 2;
            dataGridView1.Columns[3].DisplayIndex = 1;
            dataGridView1.Columns[0].HeaderText = "Account Number";
            dataGridView1.Columns[1].HeaderText = "Date / Time";
            dataGridView1.Columns[2].HeaderText = "Action";
            dataGridView1.Columns[3].HeaderText = "Username";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Recent Registerd Users History Report";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Online Banking System";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);
        }
    }
}
