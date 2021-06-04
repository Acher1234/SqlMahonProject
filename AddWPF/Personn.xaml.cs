using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SqlMahonProject.AddWPF
{
    /// <summary>
    /// Interaction logic for Personn.xaml
    /// </summary>
    public partial class Personn : Window
    {
        private List<string> idHotel { get; set; }
        private List<string> idRooms { get; set; }
        public int id { get; set; }
        public int Age { get; set; }   
        public string Nationality { get; set; }

        public DateTime dateentry { get; set; }

        public DateTime dateexit { get; set; }

        public Personn()
        {
            try
            {
                idHotel = UtilsFunction.StaticMySQLFunction.GetHotelID();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "error");
                this.Close();
            }

            InitializeComponent();
            dateentry = DateTime.Now;
            dateexit = DateTime.Now;
            this.DataContext = this;
            FillDataGrid();
            removeID.ItemsSource = UtilsFunction.GetRemoveId.GetpersonnID();
            CBIDHotel.ItemsSource = idHotel;
            CBIDHotel.SelectionChanged += ReturnRoom;
        }

        private void ReturnRoom(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                idRooms = UtilsFunction.StaticMySQLFunction.GetRoomID(CBIDHotel.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");
                this.Close();
            }
            CBIDRoom.ItemsSource = idRooms;
        }

        private void FillDataGrid()
        {

            string connectionString;
            connectionString = "SERVER=" + variableConnect.server + ";" + "PORT=" + variableConnect.port + ";" + "DATABASE=" +
            variableConnect.database + ";" + "UID=" + variableConnect.uid + ";" + "PASSWORD=" + variableConnect.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                CmdString = "SELECT * FROM persons";
                MySqlCommand cmd = new MySqlCommand(CmdString, con);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                System.Data.DataTable dt = new DataTable("Hotel");
                sda.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "alert", MessageBoxButton.OKCancel);
                this.Close();
            }
        }

        private void AddpersonsSql(object sender, RoutedEventArgs e)
        {
            string connectionString;
            connectionString = "SERVER=" + variableConnect.server + ";" + "PORT=" + variableConnect.port + ";" + "DATABASE=" +
            variableConnect.database + ";" + "UID=" + variableConnect.uid + ";" + "PASSWORD=" + variableConnect.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = "INSERT INTO `persons`(`ID`, `Rooms`, `EntryDate`, `ExitDate`, `idHotel`, `Age`, `Nationality`)"+
                    "VALUES (@id,@Room,@entrydate,@dateExit,@idHotel,@Age,@nationality)";
                comm.Parameters.AddWithValue("@id", id);
                comm.Parameters.AddWithValue("@Age", Age);
                comm.Parameters.AddWithValue("@nationality", Nationality);
                comm.Parameters.AddWithValue("@entrydate",dateentry);
                comm.Parameters.AddWithValue("@dateExit", dateexit);
                comm.Parameters.AddWithValue("@Room", Int32.Parse(CBIDRoom.SelectedValue.ToString()));
                comm.Parameters.AddWithValue("@idHotel", Int32.Parse(CBIDHotel.SelectedValue.ToString()));
                comm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "alert", MessageBoxButton.OKCancel);
                return;
            }
            MessageBox.Show("Success", "alert", MessageBoxButton.OK);
            FillDataGrid();
            removeID.ItemsSource = UtilsFunction.GetRemoveId.GetpersonnID();
        }
        private void remove(object sender, RoutedEventArgs e)
        {
            if (removeID.SelectedItem.ToString() == null || removeID.SelectedItem.ToString() == "")
            {
                return;
            }
            else
            {
                try
                {
                    UtilsFunction.RemoveFunction.removepersonnID(removeID.SelectedItem.ToString());
                    idHotel = UtilsFunction.StaticMySQLFunction.GetHotelID();
                    dateentry = DateTime.Now;
                    dateexit = DateTime.Now;
                    FillDataGrid();
                    removeID.ItemsSource = UtilsFunction.GetRemoveId.GetpersonnID();
                    CBIDHotel.ItemsSource = idHotel;
                    CBIDHotel.SelectionChanged += ReturnRoom;
                    MessageBox.Show("success", "success", MessageBoxButton.OKCancel);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "alert", MessageBoxButton.OKCancel);
                }
            }

        }

    }
}
