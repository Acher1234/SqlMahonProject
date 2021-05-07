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
    /// Interaction logic for AddManager.xaml
    /// </summary>
    public partial class AddManager : Window
    {
        private List<string> idHotel;
        public int id  { get; set; }
        public int yearOfWork { get; set; }
        public AddManager()
        {
            try
            {
                idHotel = UtilsFunction.StaticMySQLFunction.GetHotelID();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "error");
                this.Close();
            }

            InitializeComponent();
            FillDataGrid();
            this.DataContext = this;
            CBID.ItemsSource = idHotel;
            CBID.SelectedIndex = 0;

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
                CmdString = "SELECT * FROM manager";
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

        private void AddManagerSql(object sender, RoutedEventArgs e)
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
                comm.CommandText = "INSERT INTO `manager`(`Id`, `yearOfWork`, `idHotel`) VALUES (@id,@yOW,@idHotel)";
                comm.Parameters.AddWithValue("@id", id);
                comm.Parameters.AddWithValue("@yOW", yearOfWork);
                comm.Parameters.AddWithValue("@idHotel", CBID.SelectedValue.ToString());
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
