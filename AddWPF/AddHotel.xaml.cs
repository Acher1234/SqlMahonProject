using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for AddHotel.xaml
    /// </summary>
    public partial class AddHotel : Window
    {
        public string name { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public int number { get; set; }
        public string server = "127.0.0.1";
        public string port = "3306";
        public string database = "mahonnew";
        public string uid = "root";
        public string password = "";
        public AddHotel()
        {
            InitializeComponent();
            this.DataContext = this;
            FillDataGrid();
        }
        private void FillDataGrid()
        {
 
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "PORT="+ port + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                CmdString = "SELECT * FROM hotel";
                MySqlCommand cmd = new MySqlCommand(CmdString, con);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                System.Data.DataTable dt = new DataTable("Hotel");
                sda.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                con.Close();
            }
            catch (Exception e)
            {
                  MessageBox.Show(e.Message,"alert",MessageBoxButton.OKCancel);
                  this.Close();
            }
        }

        private void AddHotelSql(object sender, RoutedEventArgs e)
        {
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = "INSERT INTO `hotel`(`Name`, `Number`, `Town`, `Street`) VALUES (@name,@number,@Town,@street)";
                comm.Parameters.AddWithValue("@name", name);
                comm.Parameters.AddWithValue("@number", number);
                comm.Parameters.AddWithValue("@Town", city);
                comm.Parameters.AddWithValue("@street", address);
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
