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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SqlMahonProject.AddWPF
{
    /// <summary>
    /// Logique d'interaction pour Address.xaml
    /// </summary>
    public partial class Address : Window
    {
        public string city { get; set; }
        public string street { get; set; }
        public string entry { get; set; }

        public int number { get; set; }
        public Address()
        {
            InitializeComponent();
            idPersonn.ItemsSource = UtilsFunction.StaticMySQLFunction.GetPersontID();
            this.DataContext = this;
            FillDataGrid();
            removeID.SelectedItem = UtilsFunction.StaticMySQLFunction.GetPersontID();
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
                CmdString = "SELECT * FROM Address";
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
                    UtilsFunction.RemoveFunction.removeAdress(removeID.SelectedItem.ToString());
                    FillDataGrid();
                    removeID.ItemsSource = UtilsFunction.GetRemoveId.GetpersonnID();
                    idPersonn.ItemsSource = UtilsFunction.StaticMySQLFunction.GetPersontID();
                    MessageBox.Show("success", "success", MessageBoxButton.OKCancel);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "alert", MessageBoxButton.OKCancel);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
                comm.CommandText = "INSERT INTO `address`(`Id`, `City`, `Street`, `Number_of_building`, `Entry`) VALUES (@id,@city,@street,@numberbuilding,@entry)";
                comm.Parameters.AddWithValue("@id", idPersonn.SelectedValue.ToString());
                comm.Parameters.AddWithValue("@city",city);
                comm.Parameters.AddWithValue("@street",street);
                comm.Parameters.AddWithValue("@numberbuilding", number);
                comm.Parameters.AddWithValue("@entry", entry);
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
    }
}
