using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlMahonProject.UtilsFunction
{
    static class GetRemoveId
    {
        public static List<string> GetcountryID()
        {
            List<String> id = new List<string>();
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                CmdString = "SELECT `Country` FROM `foreign_country`";
                MySqlCommand cmd = new MySqlCommand(CmdString, con);
                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    id.Add(myReader.GetString(0));
                }
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return id;

        }
        public static List<string> GetHotelID()
        {
            List<String> id = new List<string>();
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
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
            return id;

        }
        public static List<string> GetcleanerID()
        {
            List<String> id = new List<string>();
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                CmdString = "SELECT id FROM cleaner";
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

        public static List<string> GetcomplainID()
        {
            List<String> id = new List<string>();
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                CmdString = "SELECT id FROM complaint";
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

        public static List<string> GetFamillyID()
        {
            List<String> id = new List<string>();
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
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

        public static List<string> GetLinksID(string idHotel)
        {
            List<String> id = new List<string>();
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                CmdString = "SELECT RoomsPrincipal FROM links where idHotel="+ idHotel;
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

        public static List<string> GetmanagerID()
        {
            List<String> id = new List<string>();
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                CmdString = "SELECT id FROM manager";
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

        public static List<string> GetpersonnID()
        {
            List<String> id = new List<string>();
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                CmdString = "SELECT ID FROM persons";
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

        public static List<string> GetrvID()
        {
            List<String> id = new List<string>();
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                CmdString = "SELECT Id FROM receive_vaccin";
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

        public static List<string> GetSMID()
        {
            List<String> id = new List<string>();
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                CmdString = "SELECT Id FROM same_family";
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

        public static List<string> GetVisitorID()
        {
            List<String> id = new List<string>();
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                CmdString = "SELECT ID FROM visitors";
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

        public static List<string> GetVisitsID()
        {
            List<String> id = new List<string>();
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                CmdString = "SELECT id FROM visits";
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


    }
}
