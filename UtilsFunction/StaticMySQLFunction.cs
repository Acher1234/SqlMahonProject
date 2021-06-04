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
            List<String> id = new List<string>();
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                CmdString = "SELECT id FROM hotel";
                MySqlCommand cmd = new MySqlCommand(CmdString, con);
                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    id.Add(myReader.GetInt32(0).ToString());
                }
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return  id;

        }



        public static List<string> GetManagerID(string Hotel)
        {
            List<String> id = new List<string>();
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                CmdString = "SELECT id FROM manager where idHotel="+ Hotel.ToString();
                MySqlCommand cmd = new MySqlCommand(CmdString, con);
                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    id.Add(myReader.GetInt32(0).ToString());
                }
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return id;

        }

        public static List<string> GetCleanerID(string Hotel)
        {
            List<String> id = new List<string>();
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                CmdString = "SELECT id FROM cleaner where idHotel="+Hotel.ToString();
                MySqlCommand cmd = new MySqlCommand(CmdString, con);
                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    id.Add(myReader.GetInt32(0).ToString());
                }
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return id;

        }
        public static List<string> GetRoomID(string Hotel)
        {
            List<String> id = new List<string>();
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                CmdString = "SELECT NumberRoom FROM room where idHotel=" + Hotel.ToString();
                MySqlCommand cmd = new MySqlCommand(CmdString, con);
                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    id.Add(myReader.GetInt32(0).ToString());
                }
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return id;
        }



        public static string GetPersontID(string id)
        {
            string res;
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                CmdString = "SELECT idHotel  FROM persons where id=" + id;
                MySqlCommand cmd = new MySqlCommand(CmdString, con);
                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();
                myReader.Read();
                res =  myReader.GetInt32(0).ToString();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return res;
        }

        public static List<string> GetPersontID()
        {
            List<string> res = new List<string>();
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                CmdString = "SELECT id  FROM persons";
                MySqlCommand cmd = new MySqlCommand(CmdString, con);
                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    res.Add(myReader.GetInt32(0).ToString());
                }
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return res;
        }

        public static List<string> GetVisitorID()
        {
            List<string> res = new List<string>();
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                CmdString = "SELECT id  FROM visitors";
                MySqlCommand cmd = new MySqlCommand(CmdString, con);
                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    res.Add(myReader.GetInt32(0).ToString());
                }
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return res;
        }


        public static string GetHotelIDFromClient(string idClient)
        {
            String id;
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                CmdString = "SELECT idHotel FROM persons where ID=\'" + idClient+'\'';
                MySqlCommand cmd = new MySqlCommand(CmdString, con);
                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();
                myReader.Read();
                id = myReader.GetInt32(0).ToString();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return id;
        }

        public static List<string> GetIDFamilly()
        {
            List<string> res = new List<string>();
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                CmdString = "SELECT IdFamily FROM id_family";
                MySqlCommand cmd = new MySqlCommand(CmdString, con);
                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    res.Add(myReader.GetInt32(0).ToString());
                }
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return res;
        }


    }
}
