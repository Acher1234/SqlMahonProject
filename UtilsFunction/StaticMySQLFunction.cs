using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SqlMahonProject.UtilsFunction
{
    static class StaticMySQLFunction
    {
        public static string server = "127.0.0.1";
        public static string port = "3306";
        public static string database = "mahonnew";
        public static string uid = "root";
        public static string password = "";
        private static object dataGrid;

        public static List<string>  GetHotelID()
        {
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                CmdString = "SELECT * FROM hotel";
                MySqlCommand cmd = new MySqlCommand(CmdString, con);
                
            }
            catch (Exception e)
            {
                throw e;
            }
            return  new List<string> { "Hotel", "Rooms", "Link", "test" };

        }
    }
}
