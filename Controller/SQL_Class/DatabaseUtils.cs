using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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

        public static SqlConnection GetMESDBConnection() //MES trên con .22 mySQL port 3306 - sử dụng MySQL DataProvider để clone về server local
        {
            string server = "172.16.0.22"; // Main MES connection
            string database = "mes_interface";
            string user = "guest";
            string password = "guest@123";
            string port = "3306";
            string sslM = "none";

            return DatabaseSQLServerUtils.GetMESDBConnection(server, database, port, user, password, sslM);
        }
    }
}