using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS_Project
{
    public class AdminMasterClass
    {
        public string username;
        public string password;
        public AdminMasterClass(string user, string pass)
        {
            username = user;
            password = pass;
        }
        public bool Login()
        {
            Authentication auth = new Authentication("bms");
            bool ret = auth.MatchUsernameWithPassword("master", username, password);
            return ret;
        }
        public DataSet getRequists()
        {
            DataSet ds = new DataSet();
            DataBase db = new DataBase("bms");
            db.OpenCon();
            string query = "select * from admin where status = 'NO'";
            ds = db.Query(query);
            db.CloseCon();
            return ds;
        }
        public bool delAdmin(string accNum)
        {
            DataBase db = new DataBase("bms");
            db.OpenCon();
            string query = "delete from admin where Acc_Num = " + accNum + ";"; 
            bool done = db.NonQuery(query);
            db.CloseCon();
            return done;
        }

        public DataSet getAdmins()
        {
            DataSet ds = new DataSet();
            DataBase db = new DataBase("bms");
            db.OpenCon();
            string query = "select * from admin where status = 'YES'";
            ds = db.Query(query);
            db.CloseCon();
            return ds;
        }
        public bool addAdmin(string accNum)
        {
            DataBase db = new DataBase("bms");
            db.OpenCon();
            string query = "UPDATE admin SET `status`='YES' WHERE `Acc_Num`=" + accNum + ";"; 
            bool done = db.NonQuery(query);
            db.CloseCon();
            return done;
        }
    }
}
