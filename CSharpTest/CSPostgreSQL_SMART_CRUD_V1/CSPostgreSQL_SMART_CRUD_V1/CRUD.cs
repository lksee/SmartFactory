using System;
<<<<<<< HEAD
using System.IO;
=======
>>>>>>> d6ba712b6df1c833a7469dc02329914eb01d8b93
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace CSPostgreSQL_SMART_CRUD_V1
{
    internal class CRUD
    {
        private static string getconnectionString()
        {
<<<<<<< HEAD
            string conString = string.Empty;
            try
            {
                conString = File.ReadAllText($"{Application.StartupPath}\\dbinfo.txt");
                MessageBox.Show(conString);
            }
            catch (Exception e)
            {
                MessageBox.Show($"데이터베이스 설정 파일인 {Application.StartupPath}\\dbinfo.txt을 찾을 수 없습니다.\r\n{e.ToString()}");
            }
            //string host = "Host=;";
            //string port = "Port=;";
            //string db   = "Database=;";
            //string user = "Username=;";
            //string pass = "Password=;";

            //string conString = $"{host}{port}{db}{user}{pass}";
=======
            string host = "Host=localhost;";
            string port = "Port=5432;";
            string db   = "Database=test;";
            string user = "Username=postgres;";
            string pass = "Password=postgres12!@;";

            string conString = $"{host}{port}{db}{user}{pass}";
>>>>>>> d6ba712b6df1c833a7469dc02329914eb01d8b93

            return conString;
        }

        public static NpgsqlConnection con = new NpgsqlConnection(getconnectionString());
        public static NpgsqlCommand cmd = default(NpgsqlCommand);
        public static string sql = string.Empty;

        public static DataTable PerformCRUD(NpgsqlCommand com)
        {
            NpgsqlDataAdapter da = default(NpgsqlDataAdapter);
            DataTable dt = new DataTable();

            try
            {
                da = new NpgsqlDataAdapter();
                da.SelectCommand = com;
                da.Fill(dt);

                return dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Perform CRUD Operations Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }
    }
}
