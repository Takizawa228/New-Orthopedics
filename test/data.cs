using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace test
{
    internal class data
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HUVPOBV\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");

        public void openConnection()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void closeConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
        public SqlConnection GetConnection()
        {
            return con;
        }
    }
}
