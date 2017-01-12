using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace BMS_Project
{
    public class CustomerClass
    {
        public Authentication test = new Authentication("bms");
        public Validation vtest = new Validation();
        public DataBase d = new DataBase("bms");
        public DataBase info = new DataBase("bms");
        public DataSet dsUser, dsInfo;
        public string UserName, AccountNumber, Password, Fname, Mname, Lname, Nation, Gender, PhoneNumber, StreetAddress, AccountType;
        public DateTime Birth, Created, Expired;
        public double Balance;
        public CustomerClass(string username, string password)
        {
            UserName = username;
            Password = password;
        }
        void getInfo()
        {
            d.OpenCon();
            dsUser = d.Query("select * from user where binary name = '" + UserName + "' and binary password = '" + Password + "';");
            AccountNumber = dsUser.Tables[0].Rows[0]["Acc_Num"].ToString();
            d.CloseCon();
            info.OpenCon();
            dsInfo = info.Query("select * from customerinfo where Acc_Num = " + AccountNumber + ";");
            DataRow dr = dsInfo.Tables[0].Rows[0];
            Fname = dr["Fname"].ToString();
            Mname = dr["Mname"].ToString();
            Lname = dr["Lname"].ToString();
            Nation = dr["nation"].ToString();
            Gender = dr["gender"].ToString();
            Birth = dr.Field<DateTime>("dateofbirth");
            Expired = dr.Field<DateTime>("expiredate");
            Created = dr.Field<DateTime>("createdate");
            Balance = double.Parse(dr["initial_balance"].ToString());
            PhoneNumber = dr[7].ToString();
            AccountType = dr[9].ToString();
            StreetAddress = dr[8].ToString();
        }
        public DataSet GetCooperativeName()
        {
            d.OpenCon();
            DataSet ds = d.Query("select * from coorperation where Acc_Num = '" + AccountNumber + "'");
            d.CloseCon();
            return ds;
        }
        public bool Pay_Bill(string number, string coopName, string amount)
        {
            Double amou = Double.Parse(amount);
            if (amou > Balance)
                return false;
            Balance -= amou;
            DateTimePicker nw = new DateTimePicker();
            nw.Value = DateTime.Now;
            DataBase db = new DataBase("cooperations");
            db.OpenCon();
            DataSet ds = db.Query("select id from cooperative where name ='" + coopName + "'");
            string cooID = ds.Tables[0].Rows[0][0].ToString();
            bool done = db.NonQuery("delete from users where cooID='" + cooID + "' and number='" + number + "'");
            db.CloseCon();
            d.OpenCon();
            done &= d.NonQuery("update customerinfo set initial_balance = '" + Balance.ToString() + "' where Acc_num = '" + AccountNumber + "'");
            done &= d.NonQuery("delete from coorperation where Acc_Num ='" + AccountNumber + "' and name='" + coopName + "'");
            done &= d.NonQuery("insert into payment (amount,date,nameofcooperation,UserAccNum) values ('" + amount + "','" + nw.Value.ToString("yyyy-MM-dd H:mm:ss") + "','" + coopName + "','" + AccountNumber + "')");
            d.CloseCon();
            return done;
        }
        public DataSet GetBillAmount(string number, string coopName)
        {
            DataBase db = new DataBase("cooperations");
            db.OpenCon();
            DataSet ds = db.Query("select id from cooperative where name ='" + coopName + "'");
            db.CloseCon();
            string cooID = ds.Tables[0].Rows[0][0].ToString();
            db.OpenCon();
            ds = db.Query("select amount from users where number ='" + number + "' and cooID = '" + cooID + "'");
            db.CloseCon();
            return ds;
        }
        public DataSet getTransactions()
        {
            DataSet ds = new DataSet();
            DataBase db = new DataBase("bms");
            db.OpenCon();
            string query = "select * from transaction where From_Acc = " + AccountNumber + ";";
            ds = db.Query(query);
            db.CloseCon();
            return ds;
        }
        public DataSet getPaymentReport()
        {
            DataSet ds = new DataSet();
            DataBase db = new DataBase("bms");
            db.OpenCon();
            string query = "select * from payment where UserAccNum = " + AccountNumber + ";";
            ds = db.Query(query);
            db.CloseCon();
            return ds;
        }
        public bool TransferToSameBank(string ACC_NUM, string CON_ACC_NUM, string Amount)
        {
            if (!test.Auth_AccN("user", ACC_NUM) || CON_ACC_NUM != ACC_NUM || Double.Parse(Amount) < 0 || Double.Parse(Amount) > Balance)
                return false;
            Balance -= Double.Parse(Amount);
            DateTimePicker nw = new DateTimePicker();
            nw.Value = DateTime.Now;
            string same = "SAME BANK";
            d.OpenCon();
            dsInfo = new DataSet();
            dsInfo = info.Query("select initial_balance from customerinfo where Acc_num='" + ACC_NUM + "'");
            string newbal = dsInfo.Tables[0].Rows[0][0].ToString();
            newbal = ((Double.Parse(Amount) + Double.Parse(newbal)).ToString());
            bool done = d.NonQuery("update customerinfo set initial_balance = '" + Balance.ToString() + "' where Acc_num = '" + AccountNumber + "'");
            done &= d.NonQuery("update customerinfo set initial_balance = '" + newbal + "' where Acc_num = '" + ACC_NUM + "'");
            done &= d.NonQuery("insert into transaction (From_Acc,To_Acc,iban,Date_Time,amount) VALUES (" + AccountNumber + "," + ACC_NUM + ",'" + same + "','" + nw.Value.ToString("yyyy-MM-dd H:mm:ss") + "'," + Amount + ")");
            d.CloseCon();
            return done;
        }
        public bool TransferToOtherBank(string IBAN, string ACC_NUM, string CON_ACC_NUM, string Amount)
        {
            Authentication test1 = new Authentication("internationalbank");
            DataBase db = new DataBase("internationalbank");
            if (!test1.Auth_AccN_With_IBAN("accounts", ACC_NUM, IBAN) || CON_ACC_NUM != ACC_NUM || Double.Parse(Amount) < 0 || Double.Parse(Amount) > Balance)
                return false;
            Balance -= Double.Parse(Amount);
            DateTimePicker nw = new DateTimePicker();
            nw.Value = DateTime.Now;
            db.OpenCon();
            d.OpenCon();
            dsInfo = new DataSet();
            dsInfo = db.Query("select balance from accounts where acc_num='" + ACC_NUM + "' and iban='" + IBAN + "'");
            string newbal = dsInfo.Tables[0].Rows[0][0].ToString();
            newbal = ((Double.Parse(Amount) + Double.Parse(newbal)).ToString());
            bool done = d.NonQuery("update customerinfo set initial_balance = '" + Balance.ToString() + "' where Acc_num = '" + AccountNumber + "'");
            done &= db.NonQuery("update accounts set balance = '" + newbal + "' where acc_num='" + ACC_NUM + "' and iban='" + IBAN + "'");
            done &= d.NonQuery("insert into transaction (From_Acc,To_Acc,iban,Date_Time,amount) VALUES (" + AccountNumber + ",'" + ACC_NUM + "','" + IBAN + "','" + nw.Value.ToString("yyyy-MM-dd H:mm:ss") + "'," + Amount + ")");
            db.CloseCon();
            d.CloseCon();
            return done;
        }
        public bool Login()
        {
            if (!test.Auth_UserN("user", UserName) || !test.MatchUsernameWithPassword("user", UserName, Password))
                return false;
            getInfo();
            DateTimePicker nw = new DateTimePicker();
            nw.Value = DateTime.Now;
            string s = "Login";
            d.OpenCon();
            d.NonQuery("insert into log (acc_num,date,action,user) values ('" + AccountNumber + "','" + nw.Value.ToString("yyyy-MM-dd H:mm:ss") + "', '" + s + "','" + UserName + "')");
            d.CloseCon();
            return true;
        }
        public bool ChangePassword(string OldPass, string NewPass, string ConNewPass)
        {
            if (Password != OldPass || !vtest.Valid_password(NewPass) || NewPass != ConNewPass)
                return false;

            Password = NewPass;
            d.OpenCon();
            bool done = d.NonQuery("update user set password = '" + Password + "' where Acc_num = '" + AccountNumber + "'");
            d.CloseCon();
            return done;
        }
        public bool ChangeUserName(string OldPass, string NewUserName)
        {
            if (Password != OldPass || !vtest.Valid_UserName(NewUserName))
                return false;
            UserName = NewUserName;
            d.OpenCon();
            bool done = d.NonQuery("update user set name = '" + UserName + "' where Acc_num = '" + AccountNumber + "'");
            d.CloseCon();
            return done;
        }
    }
}
