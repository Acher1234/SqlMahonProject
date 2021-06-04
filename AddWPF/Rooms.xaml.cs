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
    /// Interaction logic for Rooms.xaml
    /// </summary>
    public partial class Rooms : Window
    {
        private List<string> idHotel { get; set; }
        private List<string> idCleaner { get; set; }
        public int numberOfRoom { get; set; }

        public int FloorOfTheRoom { get; set; }

        public int numberOfPersonn { get; set; }


        public Rooms()
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
            this.DataContext = this;
            FillDataGrid();
            CBIDHotel.ItemsSource = idHotel;
            CBIDHotel.SelectionChanged += ReturnCleaner;
        }

        private void ReturnCleaner(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                idCleaner = UtilsFunction.StaticMySQLFunction.GetCleanerID(CBIDHotel.SelectedItem.ToString());
                removeID.ItemsSource = UtilsFunction.StaticMySQLFunction.GetRoomID(CBIDHotel.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");
                this.Close();
            }
            CBIDCleaner.ItemsSource = idCleaner;
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
                CmdString = "SELECT * FROM room";
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

        private void AddRoomSql(object sender, RoutedEventArgs e)
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
                comm.CommandText = "INSERT INTO `room`(`NumberRoom`, `floor`, `maxNumberOfPersonne`, `CleanerId`, `idHotel`) VALUES (@NUR,@floor,@Max,@cleaner,@IdHotel)";
                comm.Parameters.AddWithValue("@NUR", numberOfRoom);
                comm.Parameters.AddWithValue("@floor", FloorOfTheRoom);
                comm.Parameters.AddWithValue("@Max", numberOfPersonn);
                comm.Parameters.AddWithValue("@cleaner", Int32.Parse(CBIDCleaner.SelectedValue.ToString()));
                comm.Parameters.AddWithValue("@IdHotel", Int32.Parse(CBIDHotel.SelectedValue.ToString()));
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
                    UtilsFunction.RemoveFunction.removeroomID(removeID.SelectedItem.ToString(), CBIDHotel.SelectedValue.ToString());
                    FillDataGrid();
                    idHotel = UtilsFunction.StaticMySQLFunction.GetHotelID();
                    CBIDHotel.ItemsSource = idHotel;
                    CBIDHotel.SelectionChanged += ReturnCleaner;
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
