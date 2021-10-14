using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MESdbToERPdb
{
    class DatabaseSQLServerUtils
    {
        public static SqlConnection GetDBConnection(string datasource, string database, string username, string password)
        {
            string connectionString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }
        public static SqlConnection GetERPDBConnection(string datasource, string database, string username, string password)
        {
            string connectionString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }
        public static SqlConnection GetMESDBConnection(string server, string database, string port, string user, string password, string sslM)
        {
            string connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", server, port, user, password, database, sslM);
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }
    }
}
