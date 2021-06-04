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
    /// Logique d'interaction pour Foreign_Country.xaml
    /// </summary>
    public partial class Foreign_Country : Window
    {
        public string country { get; set; }
        public string vaccin { get; set; }
        public double contaminationRate { get; set; }
        public double mortality { get; set; }
        public string population { get; set; }
        public Foreign_Country()
        {
            InitializeComponent();
            this.DataContext = this;
            FillDataGrid();
            removeID.ItemsSource = UtilsFunction.GetRemoveId.GetcountryID();
        }
        private void addCountry(object sender, RoutedEventArgs e)
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
                comm.CommandText = "INSERT INTO `foreign_country`(`Country`, `Vacination_Rate`, `Contamination_Rate`, `Mortality_Rate`, `Population`) VALUES (@country," +
                    "@vac,@con,@mortal,@population)";
                comm.Parameters.AddWithValue("@country", country);
                comm.Parameters.AddWithValue("@vac", vaccin);
                comm.Parameters.AddWithValue("@mortal", mortality);
                comm.Parameters.AddWithValue("@con", contaminationRate);
                comm.Parameters.AddWithValue("@population", population);
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
        private void FillDataGrid()
        {

            string connectionString;
            connectionString = "SERVER=" + variableConnect.server + ";" + "PORT=" + variableConnect.port + ";" + "DATABASE=" +
            variableConnect.database + ";" + "UID=" + variableConnect.uid + ";" + "PASSWORD=" + variableConnect.password + ";";
            string CmdString = string.Empty;
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                CmdString = "SELECT * FROM Foreign_Country";
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
                    UtilsFunction.RemoveFunction.removeFC(removeID.SelectedItem.ToString());
                    FillDataGrid();
                    removeID.ItemsSource = UtilsFunction.GetRemoveId.GetcountryID();
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
