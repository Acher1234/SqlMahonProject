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
    /// Interaction logic for Links.xaml
    /// </summary>
    public partial class Links : Window
    {
        List<string> idHotelList { get; set; }
        List<string> idroomsList { get; set; }
        public Links()
        {
            idHotelList = UtilsFunction.StaticMySQLFunction.GetHotelID();
            InitializeComponent();
            FillDataGrid();
            idHotel.ItemsSource = idHotelList;
            idHotel.SelectionChanged += IdHotel_SelectionChanged;
        }

        private void IdHotel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            idroomsList = UtilsFunction.StaticMySQLFunction.GetRoomID(idHotel.SelectedValue.ToString());
            room1.ItemsSource = idroomsList;
            room2.ItemsSource = idroomsList;
            room3.ItemsSource = idroomsList;
            removeID.ItemsSource = UtilsFunction.GetRemoveId.GetLinksID(idHotel.SelectedValue.ToString());
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
                CmdString = "SELECT * FROM links";
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

        private void AddreceiveSql(object sender, RoutedEventArgs e)
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
                comm.CommandText = "INSERT INTO `links`(`RoomsPrincipal`, `Rooms1`, `Rooms2`, `idHotel`) VALUES (@room1,@room2,@room3,@idhotel)";
                comm.Parameters.AddWithValue("@idhotel", idHotel.SelectedValue.ToString());
                comm.Parameters.AddWithValue("@room1", room1.SelectedValue.ToString());
                comm.Parameters.AddWithValue("@room2", room2.SelectedValue.ToString());
                comm.Parameters.AddWithValue("@room3", room3.SelectedValue.ToString());
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
                    UtilsFunction.RemoveFunction.removeLinksID(removeID.SelectedItem.ToString(), idHotel.SelectedValue.ToString());
                    idHotelList = UtilsFunction.StaticMySQLFunction.GetHotelID();
                    FillDataGrid();
                    idHotel.ItemsSource = idHotelList;
                    idHotel.SelectionChanged += IdHotel_SelectionChanged;
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

