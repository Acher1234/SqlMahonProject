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
    /// Interaction logic for same_familly.xaml
    /// </summary>
    public partial class same_familly : Window
    {

        public List<string> idPersonnList { get; set; }
        public List<string> idFamillyList { get; set; }
        public same_familly()
        {
            idPersonnList = UtilsFunction.StaticMySQLFunction.GetPersontID();

            idFamillyList = UtilsFunction.StaticMySQLFunction.GetIDFamilly();

            InitializeComponent();
            FillDataGrid();

            idPersonn.ItemsSource = idPersonnList;
            idFamilly.ItemsSource = idFamillyList;
            removeID.ItemsSource = UtilsFunction.GetRemoveId.GetSMID();
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
                    UtilsFunction.RemoveFunction.removeSamefamillyID(removeID.SelectedItem.ToString());
                    idPersonnList = UtilsFunction.StaticMySQLFunction.GetPersontID();
                    idFamillyList = UtilsFunction.StaticMySQLFunction.GetIDFamilly();
                    FillDataGrid();
                    idPersonn.ItemsSource = idPersonnList;
                    idFamilly.ItemsSource = idFamillyList;
                    removeID.ItemsSource = UtilsFunction.GetRemoveId.GetSMID();
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
                CmdString = "SELECT * FROM same_family";
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

        private void Addsame_familly_Sql(object sender, RoutedEventArgs e)
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
                comm.CommandText = "INSERT INTO `same_family`(`Id`, `idFamilly`) VALUES (@idPersone,@idFamilly)";
                comm.Parameters.AddWithValue("@idPersone", idPersonn.SelectedValue);
                comm.Parameters.AddWithValue("@idFamilly", idFamilly.SelectedValue);
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
            removeID.ItemsSource = UtilsFunction.GetRemoveId.GetSMID();
        }
    }
}
