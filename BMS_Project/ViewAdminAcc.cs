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
    public partial class ViewAdminAcc : Form
    {

        public ViewAdminAcc(AdminClass admin)
        {
            InitializeComponent();
            txtFname.Text = admin.firstName;
            txtMname.Text = admin.middleName;
            txtLname.Text = admin.lastName;
            txtNationality.Text = admin.nationality;
            txtGender.Text = admin.gender;
            txtDateOfBirth.Text = admin.dateOfBirth;
            txtPhone.Text = admin.phoneNumber;
            txtAddress.Text = admin.streetAddress;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
