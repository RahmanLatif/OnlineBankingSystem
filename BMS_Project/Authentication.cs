using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace BMS_Project
{

    public class Authentication
    {
        DataBase mydb;
        public Authentication(string dB)
        {
            mydb = new DataBase(dB);
            play();
        }
        private void play()
        {
            mydb.OpenCon();
        }
        public bool Auth_UserN(string Tname, string Uname)
        {
            string query = "select * from " + Tname + " where BINARY name = \"" + Uname + "\";";
            try
            {
                DataSet ds = mydb.Query(query);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    mydb.CloseCon();
                    return false;
                }
            }
            catch (Exception ex)
            {
                mydb.CloseCon();
                return false;
            }
            mydb.CloseCon();
            return true;
        }
        public bool Auth_AccN(string Tname, string AccN)
        {
            string query = "select * from " + Tname + " where acc_num = " + AccN + ";";
            try
            {
                DataSet ds = mydb.Query(query);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    mydb.CloseCon();
                    return false;
                }
            }
            catch (Exception ex)
            {
                mydb.CloseCon();
                return false;
            }
            mydb.CloseCon();
            return true;
        }
        public bool Auth_AccN_With_IBAN(string Tname, string AccN, string IBAN)
        {
            string query = "select * from " + Tname + " where acc_num = " + AccN + " and iban = " + IBAN + ";";
            try
            {
                DataSet ds = mydb.Query(query);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    mydb.CloseCon();
                    return false;
                }
            }
            catch (Exception ex)
            {
                mydb.CloseCon();
                return false;
            }
            mydb.CloseCon();
            return true;
        }
        public bool MatchUsernameWithPassword(string Tname, string Uname, string Pass)
        {
            string query = "SELECT * FROM " + Tname + " where BINARY name = \"" + Uname + "\" and BINARY password = \"" + Pass + "\"";
            if (Tname == "admin")
                query += "and status = \"YES\";";
            else
                query += ";";
            try
            {
                DataSet ds = mydb.Query(query);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    mydb.CloseCon();
                    return false;
                }
            }
            catch (Exception ex)
            {
                mydb.CloseCon();
                return false;
            }
            mydb.CloseCon();
            return true;
        }
    }
}