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
    /// Logique d'interaction pour Previous_Illnesses.xaml
    /// </summary>
    public partial class Previous_Illnesses : Window
    {
        public bool check { get; set; }
        public string ill  { get; set; }
        public List<string> idlist { get; set; }

        public Previous_Illnesses()
        {
            idlist = UtilsFunction.StaticMySQLFunction.GetPersontID();
            InitializeComponent();
            this.DataContext = this;
            FillDataGrid();
            id.ItemsSource = idlist;
            removeID.ItemsSource = UtilsFunction.StaticMySQLFunction.GetPersontID();
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
                    UtilsFunction.RemoveFunction.removePI(removeID.SelectedItem.ToString());
                    FillDataGrid(); 
                    idlist = UtilsFunction.StaticMySQLFunction.GetPersontID();
                    id.ItemsSource = idlist;
                    removeID.ItemsSource = UtilsFunction.StaticMySQLFunction.GetPersontID();
                    MessageBox.Show("success", "success", MessageBoxButton.OKCancel);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "alert", MessageBoxButton.OKCancel);
                }
            }
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
                CmdString = "SELECT * FROM Previous_Illnesses";
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

        private void addillness(object sender, RoutedEventArgs e)
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
                comm.CommandText = "INSERT INTO `previous_illnesses`(`ID`, `Already_sick`, `Illness_name`) VALUES (@id,@AS,@IN)";
                comm.Parameters.AddWithValue("@id",id.SelectedItem.ToString());
                comm.Parameters.AddWithValue("@AS", check);
                comm.Parameters.AddWithValue("@IN", ill);
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
