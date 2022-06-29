using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace Assambly
{
    public class Commons
    {
        // 공통 변수 설정.
        //public static string sLoginUserID = string.Empty; // 사용자 ID
        //public static string sLoginUserName = string.Empty; // 사용자 명

        public static string DbPath = File.ReadAllText($"{Application.StartupPath}\\dbinfo.txt");

        public static string sLoginUserID = "admin";
        //{
        //    get;
        //    set;
        //}

        public static string sLoginUserName = "admin";
        //{
        //    get; set;
        //}

        private static string getconnectionString()
        {
            string path = $"{Application.StartupPath}\\dbinfo2.txt";
            string conString = File.ReadAllText(path);

            return conString;
        }

        public static string sConnectInfo = getconnectionString();

        public void increaseValueNumOfFail(SqlConnection _conn, string sLoginID)
        {
            //SqlConnection _conn = new SqlConnection(getconnectionString());
            SqlTransaction _tx = _conn.BeginTransaction("increaseValueNumOfFail");
            SqlCommand _cmd;
            try
            {
                _cmd = new SqlCommand();
                _cmd.Transaction = _tx;
                _cmd.Connection = _conn;
                _cmd.CommandText = $"UPDATE TB_USER SET NUM_OF_FAIL = ISNULL(NUM_OF_FAIL, 0) + 1 WHERE USER_ID = '{sLoginID}';";
                _cmd.ExecuteNonQuery();
                _tx.Commit();
            }
            catch (Exception ex)
            {
                _tx.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            
        }

        public void resetNumOfFail(SqlConnection _conn, string sLoginID)
        {
            //SqlConnection _conn = new SqlConnection(getconnectionString());
            SqlTransaction _tx = _conn.BeginTransaction("resetNumOfFail");
            SqlCommand _cmd;
            try
            {
                _cmd = new SqlCommand();
                _cmd.Transaction = _tx;
                _cmd.Connection = _conn;
                _cmd.CommandText = $"UPDATE TB_USER SET NUM_OF_FAIL = 0 WHERE USER_ID = '{sLoginID}';";
                _cmd.ExecuteNonQuery();
                _tx.Commit();
            }
            catch (Exception ex)
            {
                _tx.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _conn.Close();
            }

        }
    }
}
