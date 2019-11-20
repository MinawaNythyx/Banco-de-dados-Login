using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Login
{
    class databaseUse
    {
        public void connect()
        {
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\victor.lima\source\repos\Login\Login\DB\DatabaseLogin.mdf;Integrated Security=True;Connect Timeout=30");
            //string query = "SELECT loginID"
        }
    }
}
