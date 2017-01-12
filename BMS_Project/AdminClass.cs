using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMS_Project
{
    public class AdminClass
    {
        Validation validate;
        public string username;
        public string password;
        public string firstName;
        public string middleName;
        public string lastName;
        public string nationality;
        public string gender;
        public string dateOfBirth;
        public string phoneNumber;
        public string streetAddress;
        public string accountNum;
        public AdminClass(string usr, string pass)
        {
            this.username = usr;
            this.password = pass;
            validate = new Validation();
        }
        public bool Login()
        {
            Authentication auth = new Authentication("bms");
            bool ret = auth.MatchUsernameWithPassword("admin", username, password);
            if (ret) getInfo();
            return ret;
        }

        public bool ChangeUsername(string confrimPass, string newUsername)
        {
            if (confrimPass.Equals(password) == false)
                return false;
            DataBase db = new DataBase("bms");
            db.OpenCon();
            string query = "update admin set name = \"" + newUsername + "\" where Acc_Num = " + accountNum + ";";
            bool done = db.NonQuery(query);
            db.CloseCon();
            if (done) username = newUsername;
            
            return done;
        }
        public bool ChangePassword(string confrimPass, string newPassword)
        {
            if (confrimPass.Equals(password) == false)
                return false;
            DataBase db = new DataBase("bms");
            db.OpenCon();
            string query = "update admin set password = \"" + newPassword + "\" where Acc_Num = " + accountNum + ";";
            bool done = db.NonQuery(query);
            db.CloseCon();
            if (done) password = newPassword;
            return done;
        }

        public DataSet GetTransactionReport()
        {
            DataSet ret = new DataSet();
            DataBase db = new DataBase("bms");
            db.OpenCon();
            string query = "select * from transaction;";
            ret = db.Query(query);
            db.CloseCon();
            return ret;
        }

        public DataSet GetPaymentReport()
        {
            DataSet ret = new DataSet();
            DataBase db = new DataBase("bms");
            db.OpenCon();
            string query = "select * from payment;";
            ret = db.Query(query);
            db.CloseCon();
            return ret;
        }
        public DataSet GetRecentlogedusersReport()
       {
           DataSet ret = new DataSet();
           DataBase db = new DataBase("bms");
           db.OpenCon();
           string query = "select * from log"; 
           ret = db.Query(query);
           db.CloseCon();
           return ret;
       }
        public DataSet GetCustomerUsername(string acc_num)
        {
            DataBase db = new DataBase("bms");
            db.OpenCon();
            DataSet ds = db.Query("select name from user where Acc_num = '" + acc_num + "'");
            db.CloseCon();
            return ds;
        }
        public bool AddCoo(string confirmPass, string cooName, string accNum, string Req)
        {
            if (confirmPass.Equals(password) == false)
                return false;
            Authentication auth = new Authentication("bms");
            bool found = auth.Auth_AccN("coorperation", accNum);
            bool found2 = auth.Auth_AccN("customerinfo", accNum);
            if (found || !found2) return false;
            DataBase db = new DataBase("bms");
            db.OpenCon();
            string query = "insert into coorperation (name, requirement, Acc_Num) values ('" + cooName + "','" + Req + "'," + accNum + ");";
            bool done = db.NonQuery(query);
            db.CloseCon();
            return done;
        }
        public List<string> getCoo()
        {
            List<string> coo = new List<string>();
            DataBase db = new DataBase("bms");
            db.OpenCon();
            string query = "select * from coorperation;";
            DataSet ds = db.Query(query);
            if (ds == null) return coo;
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                string cooName = dr[0].ToString();
                coo.Add(cooName);
            }
            db.CloseCon();
            return coo;
        }
        public bool DelCoo(string confirmPass, string cooName)
        {
            if (confirmPass.Equals(password) == false)
                return false;
            DataBase db = new DataBase("bms");
            db.OpenCon();
            string query = "select * from coorperation where binary name = '" + cooName + "';";
            DataSet ds = db.Query(query);
            if(ds == null) return false;
            string accNum = ds.Tables[0].Rows[0][2].ToString();
            query = "delete from coorperation where Acc_Num = " + accNum + ";";
            bool done = db.NonQuery(query);
            db.CloseCon();
            return done;
        }
       
        public void getInfo()
        {
            DataBase db = new DataBase("bms");
            db.OpenCon();
            string query = "select * from admin where binary name = \"" + username + "\" and binary password = \"" + password + "\";";
            DataSet ds = db.Query(query);
            accountNum = ds.Tables[0].Rows[0][0].ToString();
            query = "select * from customerinfo where Acc_Num = " + accountNum + ";";
            ds = db.Query(query);
            firstName = ds.Tables[0].Rows[0][1].ToString();
            middleName = ds.Tables[0].Rows[0][2].ToString();
            lastName = ds.Tables[0].Rows[0][3].ToString();
            nationality = ds.Tables[0].Rows[0][4].ToString();
            gender = ds.Tables[0].Rows[0][5].ToString();
            dateOfBirth = ds.Tables[0].Rows[0][6].ToString();
            phoneNumber = ds.Tables[0].Rows[0][7].ToString();
            streetAddress = ds.Tables[0].Rows[0][8].ToString();
            string tmp = "";
            for (int i = 0; i < 10; i++)
                tmp += dateOfBirth[i];
            dateOfBirth = tmp;
            db.CloseCon();
        }
    }
}
