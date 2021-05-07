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
    /// Interaction logic for Cleaner.xaml
    /// </summary>
    public partial class Cleaner : Window
    {
        private List<string> idHotel { get; set; }
        private List<string> idManager { get; set; }
        public int id { get; set; }

        public int yearsOfWork { get; set; }
        public Cleaner()
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
            CBIDHotel.SelectionChanged += ReturnManager;
        }

        private void ReturnManager(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                idManager = UtilsFunction.StaticMySQLFunction.GetManagerID(CBIDHotel.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");
                this.Close();
            }
            CBIDManager.ItemsSource = idManager;
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
                CmdString = "SELECT * FROM cleaner";
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

        private void AddCleanerSql(object sender, RoutedEventArgs e)
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
                comm.CommandText = "INSERT INTO `cleaner`(`Id`, `yearOfWork`, `ManagerId`, `idHotel`) VALUES (@id,@yOW,@ManagerId,@idHotel)";
                comm.Parameters.AddWithValue("@id", id);
                comm.Parameters.AddWithValue("@yOW", yearsOfWork);
                comm.Parameters.AddWithValue("@ManagerId",  Int32.Parse(CBIDManager.SelectedValue.ToString()));
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
        }

    }
}

