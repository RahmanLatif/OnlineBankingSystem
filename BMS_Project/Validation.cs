using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace BMS_Project
{
    public class Validation
    {
        public Validation()
        {
        }
        public bool Valid_UserName(string name)
        {
            if (name.Length < 5)
                return false;
            return true;
        }
        public bool Valid_password(string password)
        {
            int c1 = 0, c2 = 0, c3 = 0;
            for (int i = 0; i < password.Length; i++)
                if (char.IsDigit(password[i]))
                    ++c1;
                else if (char.IsUpper(password[i]))
                    ++c2;
                else if (char.IsLower(password[i]))
                    ++c3;
            if (password.Length >= 8 && c1 > 0 && c2 > 0 && c3 > 0)
                return true;
            return false;
        }
        public bool Valid_AccN(string accN)
        {
            for (int i = 0; i < accN.Length; i++)
                if (!Char.IsDigit(accN[i]))
                    return false;
            return true;
        }
        public bool Valid_pNum(string pNum)
        {
            string s1 = pNum.Substring(0, 3);
            int x = 1;
            for (int i = 0; i < pNum.Length; i++)
                if (!Char.IsDigit(pNum[i]))
                {
                    x = 0;
                    break;
                }
            if ((s1 != "011" && s1 != "012" && s1 != "010") || x == 0 || pNum.Length < 11)
                return false;
            return true;
        }
    }
}