using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlMahonProject.UtilsFunction
{
    class RemoveFunction
    {
        public static void removeHotelID(string ID)
        {
            int Idnumber = Int32.Parse(ID);
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = "DELETE FROM `hotel` WHERE id = @id";
                comm.Parameters.AddWithValue("@id", Idnumber);
                comm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void removemanagerID(string ID)
        {
            int Idnumber = Int32.Parse(ID);
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = "DELETE FROM `manager` WHERE Id = @id";
                comm.Parameters.AddWithValue("@id", Idnumber);
                comm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void removecleanerID(string ID)
        {
            int Idnumber = Int32.Parse(ID);
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = "DELETE FROM `Cleaner` WHERE Id = @id";
                comm.Parameters.AddWithValue("@id", Idnumber);
                comm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void removefamillyID(string ID)
        {
            int Idnumber = Int32.Parse(ID);
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = "DELETE FROM `id_family` WHERE IdFamily = @id";
                comm.Parameters.AddWithValue("@id", Idnumber);
                comm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void removeAdress(string ID)
        {
            int Idnumber = Int32.Parse(ID);
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = "DELETE FROM `address` WHERE Id = @id";
                comm.Parameters.AddWithValue("@id", Idnumber);
                comm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void removeSC(string id)
        {
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = "DELETE FROM `stayed_in_foreign_country` WHERE ID = @id";
                comm.Parameters.AddWithValue("@id", id);
                comm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static void removeFC(string country)
        {
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = "DELETE FROM `foreign_country` WHERE Country = @countrye";
                comm.Parameters.AddWithValue("@id", country);
                comm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void removePD(string ID)
        {
            int Idnumber = Int32.Parse(ID);
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = "DELETE FROM `personal_data` WHERE ID = @id";
                comm.Parameters.AddWithValue("@id", Idnumber);
                comm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static void removePI(string ID)
        {
            int Idnumber = Int32.Parse(ID);
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = "DELETE FROM `previous_illnesses` WHERE ID = @id";
                comm.Parameters.AddWithValue("@id", Idnumber);
                comm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static void removecountryColor(string country)
        {
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = "DELETE FROM `color` WHERE Country = @country";
                comm.Parameters.AddWithValue("@country", country);
                comm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void removecountry(string country)
        {
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = "DELETE FROM `foreign_country` WHERE Country = @country";
                comm.Parameters.AddWithValue("@country", country);
                comm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static void removeLinksID(string ID,string idHotel)
        {
            int Idnumber = Int32.Parse(ID);
            int Idnumber2 = Int32.Parse(idHotel);
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = "DELETE FROM `links` WHERE RoomsPrincipal  = @id and idHotel = @idHotel";
                comm.Parameters.AddWithValue("@id", Idnumber);
                comm.Parameters.AddWithValue("@idHotel", idHotel);
                comm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void removeroomID(string ID, string idHotel)
        {
            int Idnumber = Int32.Parse(ID);
            int Idnumber2 = Int32.Parse(idHotel);
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = "DELETE FROM `room` WHERE NumberRoom  = @id and idHotel = @idHotel";
                comm.Parameters.AddWithValue("@id", Idnumber);
                comm.Parameters.AddWithValue("@idHotel", idHotel);
                comm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void removepersonnID(string ID)
        {
            int Idnumber = Int32.Parse(ID);
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = "DELETE FROM `persons` WHERE ID = @id";
                comm.Parameters.AddWithValue("@id", Idnumber);
                comm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void removereceiveVaccinID(string ID)
        {
            int Idnumber = Int32.Parse(ID);
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = "DELETE FROM `receive_vaccin` WHERE Id = @id";
                comm.Parameters.AddWithValue("@id", Idnumber);
                comm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void removeSamefamillyID(string id)
        {
            int Idnumber = Int32.Parse(id);
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = "DELETE FROM `same_family` WHERE Id = @id";
                comm.Parameters.AddWithValue("@id", Idnumber);
                comm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void removevisitorID(string id)
        {
            int Idnumber = Int32.Parse(id);
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = "DELETE FROM `visitors` WHERE ID = @id";
                comm.Parameters.AddWithValue("@id", Idnumber);
                comm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void removevisitsID(string id)
        {
            int Idnumber = Int32.Parse(id);
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = "DELETE FROM `visits` WHERE id = @id";
                comm.Parameters.AddWithValue("@id", Idnumber);
                comm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void removecomplainID(string ID)
        {
            int Idnumber = Int32.Parse(ID);
            string connectionString;
            connectionString = "SERVER=" + StaticMySQLFunction.server + ";" + "PORT=" + StaticMySQLFunction.port + ";" + "DATABASE=" +
            StaticMySQLFunction.database + ";" + "UID=" + StaticMySQLFunction.uid + ";" + "PASSWORD=" + StaticMySQLFunction.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = "DELETE FROM `complaint` WHERE id = @id";
                comm.Parameters.AddWithValue("@id", Idnumber);
                comm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
