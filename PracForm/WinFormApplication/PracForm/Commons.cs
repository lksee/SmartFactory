﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PracForm
{
    internal class Commons
    {
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

        public static SqlConnection conn = new SqlConnection(getconnectionString());
        public static SqlCommand cmd = default(SqlCommand);
        public static string sql = string.Empty;

        public static DataTable PerformCRUD(SqlCommand com)
        {
            SqlDataAdapter da = default(SqlDataAdapter);
            DataTable dt = new DataTable();

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = com;
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Perform CRUD Operations Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

    }
}
