using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace MESdbToERPdb
{
    class DatabaseUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = "172.16.0.12";
            string database = "ERPSOFT";
            string username = "ERPUSER";
            string password = "12345";

            return DatabaseSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }

        public static SqlConnection GetERPDBConnection() //ERP trên con .11 db - TLVN2 (dùng để test) con chính ERP trong db TECHLINK (KHÔNG ĐƯỢC ĐỘNG VÀO NẾU CHƯA TEST KĨ )
        {
            string datasource = "172.16.0.11"; // Main ERP test connection "TLVN2"
            string database = "TLVN2";
            string username = "soft";
            string password = "techlink@!@#";

            //string connectionString = @"Data Source=DESKTOP-R9UCIUR/SQLEXPRESS;Initial Catalog=TLVN2; Integrated Security = True"; //Test on local server clone from mes_interface on MES database.
            return DatabaseSQLServerUtils.GetERPDBConnection(datasource, database, username, password);
        }

        //public static SqlConnection GetERPTargetDBConnection() 
        //{
        //    string datasource = "172.16.0.11"; 
        //    string database = "SOT";
        //    string username = "sa";
        //    string password = "dsc@123";

        //    return DatabaseSQLServerUtils.GetERPTargetDBConnection(datasource, database, username, password);
        //}

        public static MySqlConnection GetMes_InterfaceDBC() //MES trên con .22 mySQL - sử dụng MySQL DataProvider để clone về server local
        {
            string host = "172.16.0.22"; //mes connection
            string user = "guest";
            string password = "guest@123";
            string database = "mes_interface";

            return DatabaseSQLServerUtils.GetMesDBConnection(host, user, password, database);
        }


        public static MySqlConnection GetMes_Quality_ControlDBC()
        {
            string host = "172.16.0.22";
            string user = "guest";
            string password = "guest@123";
            string database = "mes_quality_control";

            return DatabaseSQLServerUtils.GetMesDBConnection(host, user, password, database);
        }

        public static MySqlConnection GetMes_Base_DataDBC()
        {
            string host = "172.16.0.22";
            string user = "guest";
            string password = "guest@123";
            string database = "mes_base_data";

            return DatabaseSQLServerUtils.GetMesDBConnection(host, user, password, database);
        }
    }
}