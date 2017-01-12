using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace BMS_Project
{
    public class DataBase
    {
        MySqlConnectionStringBuilder build;
        MySqlConnection myconnection;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        string DB;
        public DataBase(string db)
        {
            this.DB = db;
        }
        public void OpenCon()
        {
            build = new MySqlConnectionStringBuilder();
            build.Server = "localhost";
            build.Port = 3306;
            build.UserID = "root";
            build.Password = "root";
            build.Database = DB;
            myconnection = new MySqlConnection(build.ToString());
            myconnection.Open();
        }
        public bool NonQuery(string query)
        {
            try
            {
                cmd = new MySqlCommand(query, myconnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public DataSet Query(string query)
        {
            DataSet ds = new DataSet();
            try
            {
                da = new MySqlDataAdapter(query, myconnection);
                da.Fill(ds);
            }
            catch(Exception ex)
            {
                return null;
            }
            return ds;
        }
        
        public void CloseCon()
        {
            myconnection.Close();
        }
    }
}