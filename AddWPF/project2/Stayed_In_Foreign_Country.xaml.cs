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
    /// Logique d'interaction pour Stayed_In_Foreign_Country.xaml
    /// </summary>
    public partial class Stayed_In_Foreign_Country : Window
    {
        public int number { get; set; }
        public List<string> id { get; set; }
        public List<string> color { get; set; }

        public Stayed_In_Foreign_Country()
        {
            id = UtilsFunction.StaticMySQLFunction.GetPersontID();
            InitializeComponent();
            this.DataContext = this;
            FillDataGrid();
            idbox.ItemsSource = id;
            cbox.ItemsSource = UtilsFunction.GetRemoveId.GetcountryID();
            removeID.ItemsSource = UtilsFunction.GetRemoveId.GetpersonnID();
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
                CmdString = "SELECT * FROM Stayed_In_Foreign_Country";
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
                    UtilsFunction.RemoveFunction.removeSC(removeID.SelectedItem.ToString());
                    FillDataGrid();
                    cbox.ItemsSource = UtilsFunction.GetRemoveId.GetcountryID();
                    removeID.ItemsSource = UtilsFunction.GetRemoveId.GetpersonnID();
                    idbox.ItemsSource = UtilsFunction.GetRemoveId.GetpersonnID();
                    MessageBox.Show("success", "success", MessageBoxButton.OKCancel);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "alert", MessageBoxButton.OKCancel);
                }
            }
        }


        private void addStayed(object sender, RoutedEventArgs e)
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
                comm.CommandText = "INSERT INTO `stayed_in_foreign_country`(`ID`, `Country`, `Number_Days`) VALUES (@id,@country,@numberDays)";
                comm.Parameters.AddWithValue("@id", idbox.SelectedValue.ToString());
                comm.Parameters.AddWithValue("@country", cbox.SelectedValue.ToString());
                comm.Parameters.AddWithValue("@numberDays", number);
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
