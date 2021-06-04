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
    /// Logique d'interaction pour Personal_Data.xaml
    /// </summary>
    public partial class Personal_Data : Window
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Mail { get; set; }
        public long tel { get; set; }
        public int age { get; set; }

        public List<string> id;


       
        public Personal_Data()
        {
            id = UtilsFunction.StaticMySQLFunction.GetPersontID();
            InitializeComponent();
            this.DataContext = this;
            FillDataGrid();
            idPersonn.ItemsSource = id;
            removeID.ItemsSource = id;
        }

        private void addData(object sender, RoutedEventArgs e)
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
                comm.CommandText = "INSERT INTO `personal_data`(`ID`, `first_name`, `last_name`, `mail`, `tel`, `Age`) VALUES (@Id,@FN,@LN,@mail,@tel,@age)";
                comm.Parameters.AddWithValue("@Id", idPersonn.SelectedItem.ToString());
                comm.Parameters.AddWithValue("@FN", Fname.ToString());
                comm.Parameters.AddWithValue("@LN", Lname.ToString());
                comm.Parameters.AddWithValue("@mail", Mail.ToString());
                comm.Parameters.AddWithValue("@tel", tel.ToString());
                comm.Parameters.AddWithValue("@age", age.ToString());
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
                CmdString = "SELECT * FROM Personal_Data";
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
                    UtilsFunction.RemoveFunction.removePD(removeID.SelectedItem.ToString());
                    FillDataGrid();
                    id = UtilsFunction.StaticMySQLFunction.GetPersontID();
                    idPersonn.ItemsSource = id;
                    removeID.ItemsSource = id;
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
