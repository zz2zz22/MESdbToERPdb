﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using MySql.Data.MySqlClient;

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
        public static MySqlConnection GetMESDBConnection(string host, string user, string password, string database)
        {
            string connectionString = String.Format("host={0};user={1};password={2}; database={3};", host, user, password, database);
            MySqlConnection con = new MySqlConnection(connectionString);
            return con;
        }
    }
}
