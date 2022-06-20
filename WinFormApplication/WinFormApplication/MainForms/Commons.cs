using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainForms
{
    internal class Commons
    {
        // 공통 변수 설정.
        //public static string sLoginUserID = string.Empty; // 사용자 ID
        //public static string sLoginUserName = string.Empty; // 사용자 명
        public static string sLoginUserID
        {
            get;
            set;
        }

        public static string sLoginUserName
        {
            get; set;
        }

        private static string getconnectionString()
        {
            string host = "Server=localhost;";
            string port = "";
            string db = "database=AppDev;";
            string user = "Uid=sa;";
            string pass = "Pwd = sqlserver12!@;";

            string conString = $"{host}{port}{db}{user}{pass}";

            return conString;
        }

        public static string sConnectInfo = getconnectionString();
    }
}
