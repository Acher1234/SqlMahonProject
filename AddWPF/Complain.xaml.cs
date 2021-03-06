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
    /// Interaction logic for Complain.xaml
    /// </summary>
    public partial class Complain : Window
    {
        public List<string> idClient { get; set; }
        public List<string> idManager{ get; set; }

        public string complain { get; set; }

        public Complain()
        {
            idClient = UtilsFunction.StaticMySQLFunction.GetPersontID();
            InitializeComponent();
            this.DataContext = this;
            CBIDClient.ItemsSource = idClient;
            CBIDClient.SelectionChanged += CBIDClient_SelectionChanged;
            removeID.ItemsSource = UtilsFunction.GetRemoveId.GetcomplainID();
            FillDataGrid();

        }

        private void CBIDClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string getHotelID = UtilsFunction.StaticMySQLFunction.GetHotelIDFromClient(CBIDClient.SelectedValue.ToString());
            idManager = UtilsFunction.StaticMySQLFunction.GetManagerID(getHotelID);
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
                CmdString = "SELECT * FROM Complaint";
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
                comm.CommandText = "INSERT INTO `complaint`(`ClientID`, `ManagerId`, `complaint`) VALUES (@clientId,@ManagerId,@complain)";
                comm.Parameters.AddWithValue("@clientId", CBIDClient.SelectedValue);
                comm.Parameters.AddWithValue("@ManagerId", CBIDManager.SelectedValue);
                comm.Parameters.AddWithValue("@complain", complain);
                comm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "alert", MessageBoxButton.OKCancel);
                return;
            }
            MessageBox.Show("Success", "alert", MessageBoxButton.OK);
            removeID.ItemsSource = UtilsFunction.GetRemoveId.GetcomplainID();
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
                    UtilsFunction.RemoveFunction.removecomplainID(removeID.SelectedItem.ToString());
                    idClient = UtilsFunction.StaticMySQLFunction.GetPersontID();
                    CBIDClient.ItemsSource = idClient;
                    CBIDClient.SelectionChanged += CBIDClient_SelectionChanged;
                    removeID.ItemsSource = UtilsFunction.GetRemoveId.GetcomplainID();
                    FillDataGrid();
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
