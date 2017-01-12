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
    public partial class ViewTransactions : Form
    {
        
        public ViewTransactions(Object o)
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            if (o.GetType() == typeof(AdminClass))
            {
                AdminClass adminInfo = (AdminClass)o;
                dataGridView1.DataSource = adminInfo.GetTransactionReport().Tables[0];
            }
            else if (o.GetType() == typeof(CustomerClass))
            {
                CustomerClass customer = (CustomerClass)o;
                dataGridView1.DataSource = customer.getTransactions().Tables[0];
            }
            dataGridView1.Columns[3].DisplayIndex = 0;
            dataGridView1.Columns[0].DisplayIndex = 1;
            dataGridView1.Columns[1].DisplayIndex = 2;
            dataGridView1.Columns[2].DisplayIndex = 3;
            dataGridView1.Columns[4].DisplayIndex = 4;

            dataGridView1.Columns[0].HeaderText = "From Account Number";
            dataGridView1.Columns[1].HeaderText = "To Account Number";
            dataGridView1.Columns[2].HeaderText = "IBAN";
            dataGridView1.Columns[3].HeaderText = "Date / Time";
            dataGridView1.Columns[4].HeaderText = "Transfer Amount";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Transactions History Report";
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
