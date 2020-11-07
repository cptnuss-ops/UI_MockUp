using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_MockUp
{
    public static class SQLHandler
    {
        public static DataTable dataTable1 = new DataTable();

        public static string ReturnConnectionString()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.InitialCatalog = "TestDatabase";
            sqlConnectionStringBuilder.DataSource = "h2910102.stratoserver.net";
            sqlConnectionStringBuilder.UserID = "ReadTableForLogin";
            sqlConnectionStringBuilder.Password = "CyTN#Y!fxGo%";

            return sqlConnectionStringBuilder.ConnectionString.ToString();
        }
        public static DataTable ReturnModule()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from ModuleWI";
            SqlConnection conn = new SqlConnection(ReturnConnectionString());
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            conn.Close();
            da.Dispose();

            return dataTable;
        }

        public static void GetModulInfo(int Modulnummer)
        {
            dataTable1.Clear();
            SqlConnection connection = new SqlConnection(ReturnConnectionString());

            SqlCommand sqlCommand = new SqlCommand("select * FROM Moduldaten WHERE Modulnummer=@modulnummer", connection);
            sqlCommand.Parameters.AddWithValue("@modulnummer", Modulnummer);            
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            da.Fill(dataTable1);            
            connection.Close();
            da.Dispose();


        }


    }
}
