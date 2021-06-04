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
    /// Interaction logic for visits.xaml
    /// </summary>
    /// 
    public partial class visits : Window
    {

        public DateTime date { get; set; }
        public List<string> idVisitor { get; set; }
        public List<string> idPerson { get; set; }
        public visits()
        {
            InitializeComponent();
            date = DateTime.Now;
            idPerson = UtilsFunction.StaticMySQLFunction.GetPersontID();
            idVisitor = UtilsFunction.StaticMySQLFunction.GetVisitorID();
            FillDataGrid();
            visitorID.ItemsSource = idVisitor;
            personId.ItemsSource = idPerson;
            removeID.ItemsSource = UtilsFunction.GetRemoveId.GetVisitsID();
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
                CmdString = "SELECT * FROM visits";
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

        private void Save(object sender, RoutedEventArgs e)
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
                comm.CommandText = "INSERT INTO `visits`(`DateOfVisit`, `ClientID`, `visitorId`) VALUES (@date,@client,@Visitor)";
                comm.Parameters.AddWithValue("@date", date);
                comm.Parameters.AddWithValue("@client", personId.SelectedValue);
                comm.Parameters.AddWithValue("@Visitor", visitorID.SelectedValue);
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
            removeID.ItemsSource = UtilsFunction.GetRemoveId.GetVisitsID();
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
                    UtilsFunction.RemoveFunction.removevisitsID(removeID.SelectedItem.ToString());
                    idPerson = UtilsFunction.StaticMySQLFunction.GetPersontID();
                    idVisitor = UtilsFunction.StaticMySQLFunction.GetVisitorID();
                    FillDataGrid();
                    visitorID.ItemsSource = idVisitor;
                    personId.ItemsSource = idPerson;
                    removeID.ItemsSource = UtilsFunction.GetRemoveId.GetVisitsID();
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
