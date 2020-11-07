using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_MockUp
{
    public static class SQLHandler
    {
        public static DataTable ReturnModule()
        {
            DataTable dataTable = new DataTable();
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.InitialCatalog = "TestDatabase";
            sqlConnectionStringBuilder.DataSource = "h2910102.stratoserver.net";
            sqlConnectionStringBuilder.UserID = "ReadTableForLogin";
            sqlConnectionStringBuilder.Password = "CyTN#Y!fxGo%";            
            string connString = sqlConnectionStringBuilder.ConnectionString.ToString();
            string query = "select * from ModuleWI";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();            
            SqlDataAdapter da = new SqlDataAdapter(cmd);            
            da.Fill(dataTable);
            conn.Close();
            da.Dispose();

            return dataTable;
        }

        
    }
}
