using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMS_Project
{
    class Register
    {
        string username;
        string password;
        string accNum;
        public Register(string u, string p, string a)
        {
            username = u;
            password = p;
            accNum = a;
        }
        public void Reg()
        {
            Validation validate = new Validation();
            if (!validate.Valid_UserName(username) || !validate.Valid_password(password))
                MessageBox.Show("Username length must be greater than 4 characters\nPassword length must be greater than 8 characters\nPassword must contain capital and small letters and numbers");
            else
            {
                Authentication auth = new Authentication("bms");
                bool accountInCurrentUsers = auth.Auth_AccN("user", accNum);
                bool accountInCustomer = auth.Auth_AccN("customerinfo", accNum);
                bool accountInAdmin = auth.Auth_AccN("admin", accNum);
                if (!accountInCustomer || !accountInAdmin || accountInCurrentUsers)
                {
                    MessageBox.Show("Enter Correct Account Number");
                }
                else
                {
                    bool usernameInCurrentUsers = auth.Auth_UserN("user", username);
                    bool usernameInCurrentAdmins = auth.Auth_UserN("admin", username);
                    if (usernameInCurrentAdmins || usernameInCurrentUsers)
                    {
                        MessageBox.Show("This username is already exists in database");
                    }
                    else
                    {
                        string query = "insert into user (Acc_Num, name, password) values (" + accNum + ",'" + username + "','" + password + "');";
                        DataBase db = new DataBase("bms");
                        db.OpenCon();
                        bool done = db.NonQuery(query);
                        db.CloseCon();
                        if (done)
                            MessageBox.Show("Succssfully registerd");
                        else
                            MessageBox.Show("Error!");
                    }
                }
            }
        }
    } 
}
