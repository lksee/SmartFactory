using System;
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
            string host = "Host=localhost;";
            string port = "Port=5432;";
            string db   = "Database=test;";
            string user = "Username=postgres;";
            string pass = "Password=postgres12!@;";

            string conString = $"{host}{port}{db}{user}{pass}";

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
