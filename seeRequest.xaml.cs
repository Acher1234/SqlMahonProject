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

namespace SqlMahonProject
{
    /// <summary>
    /// Interaction logic for seeRequest.xaml
    /// </summary>
    public partial class seeRequest : Window
    {
        static int i = 0;
        int selected = 0;
        Dictionary<string, int> dicttoid = new Dictionary<string, int>();
        Dictionary<int,string> idtocomand = new Dictionary<int, string>();

        public seeRequest()
        {
            InitializeComponent();
            addRequest();
            command.ItemsSource = dicttoid.Keys;
            command.SelectionChanged += Command_SelectionChanged;
        }

        private void Command_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selected = dicttoid.GetValueOrDefault(command.SelectedValue.ToString());
            FillDataGrid();
        }

        public void addRequest()
        {
            dicttoid.Add("linked room without same family", i);
            idtocomand.Add(i++, "Select id from Persons where Persons.ID not in (SELECT id from Same_family) AND Persons.Rooms in (SELECT Links.RoomsPrincipal from Links UNION SELECT Links.Rooms1 from Links Union SELECT Links.Rooms2 from Links)");
            dicttoid.Add("not israely person", i);
            idtocomand.Add(i++, "SELECT Persons.ID from Persons,Visits,Visitors where Persons.ID = Visits.ClientID and Visits.visitorId = Visitors.ID and Visitors.Nationality <> \"israel\"");
            dicttoid.Add("max receive visit", i);
            idtocomand.Add(i++, "SELECT Persons.id,COUNT(Persons.id) AS compte from Persons,Visits where Persons.ID = Visits.ClientID GROUP By Persons.ID HAVING COUNT(Persons.id) = ( SELECT MAX(T2.compte2) from (SELECT COUNT(Persons.id) AS compte2 from Persons,Visits where Persons.ID = Visits.ClientID GROUP By Persons.ID) as T2)");
            dicttoid.Add("max give visit", i);
            idtocomand.Add(i++, "SELECT Visitors.id,COUNT(Visitors.id) AS compte from Visitors,Visits where Visitors.ID = Visits.visitorId GROUP By Visitors.ID HAVING COUNT(Visitors.id) = (SELECT MAX(T2.compte2) from (SELECT COUNT(Visitors.id) AS compte2 from Visitors,Visits where Visitors.ID = Visits.visitorId GROUP By Visitors.ID) as T2)");
            dicttoid.Add("see complaint", i);
            idtocomand.Add(i++, "SELECT Complaint.complaint, Persons.ID,Cleaner.Id as cleanerid,NumberRoom from Persons,Complaint,Cleaner,Room WHERE Persons.ID = Complaint.ClientID and Persons.Rooms = Room.NumberRoom and Cleaner.Id = Room.CleanerId and Persons.idHotel=Room.idHotel");
            dicttoid.Add("max receive complain employee", i);
            idtocomand.Add(i++, "SELECT count(Complaint.complaint),Cleaner.Id from Persons,Complaint,Cleaner,Room WHERE Persons.ID = Complaint.ClientID and Persons.Rooms = Room.NumberRoom and Cleaner.Id = Room.CleanerId and Persons.idHotel=Room.idHotel GROUP by Cleaner.Id");
            dicttoid.Add("average complain", i);
            idtocomand.Add(i++, "SELECT Room.idHotel,COUNT(Complaint)/COUNT(Persons.ID) FROM Persons LEFT JOIN Complaint ON Persons.ID = Complaint.ClientID JOIN Room ON Persons.Rooms = Room.NumberRoom AND Persons.idHotel = Room.idHotel GROUP BY Room.idHotel");
            dicttoid.Add("number complain by room", i);
            idtocomand.Add(i++, "SELECT count(DISTINCT Complaint.ClientID),Room.NumberRoom from Persons,Complaint,Cleaner,Room WHERE Persons.ID = Complaint.ClientID and Persons.Rooms = Room.NumberRoom and Cleaner.Id = Room.CleanerId and Persons.idHotel=Room.idHotel GROUP by Room.NumberRoom");


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
                CmdString = idtocomand.GetValueOrDefault(selected);
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
    }
}
