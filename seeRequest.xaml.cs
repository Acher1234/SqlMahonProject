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
        Dictionary<string, string> view = new Dictionary<string, string>();

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
            dicttoid.Add("not israely visitor person", i);
            idtocomand.Add(i++, "SELECT Persons.ID from Persons,Visits,Visitors where Persons.ID = Visits.ClientID and Visits.visitorId = Visitors.ID and Visitors.Nationality <> \"israel\"");
            dicttoid.Add("max person who receive visit", i);
            idtocomand.Add(i++, "SELECT Persons.id,COUNT(Persons.id) AS numberOfVisit from Persons,Visits where Persons.ID = Visits.ClientID GROUP By Persons.ID HAVING COUNT(Persons.id) = ( SELECT MAX(T2.compte2) from (SELECT COUNT(Persons.id) AS compte2 from Persons,Visits where Persons.ID = Visits.ClientID GROUP By Persons.ID) as T2)");
            dicttoid.Add("max person who give visit", i);
            idtocomand.Add(i++, "SELECT Visitors.id,COUNT(Visitors.id) AS numberOfVisit from Visitors,Visits where Visitors.ID = Visits.visitorId GROUP By Visitors.ID HAVING COUNT(Visitors.id) = (SELECT MAX(T2.compte2) from (SELECT COUNT(Visitors.id) AS compte2 from Visitors,Visits where Visitors.ID = Visits.visitorId GROUP By Visitors.ID) as T2)");
            dicttoid.Add("see all complaint", i);
            idtocomand.Add(i++, "SELECT Complaint.complaint, Persons.ID,Cleaner.Id as cleanerid,NumberRoom from Persons,Complaint,Cleaner,Room WHERE Persons.ID = Complaint.ClientID and Persons.Rooms = Room.NumberRoom and Cleaner.Id = Room.CleanerId and Persons.idHotel=Room.idHotel");
            dicttoid.Add("max receive complain to an  employee", i);
            idtocomand.Add(i++, "SELECT count(Complaint.complaint),Cleaner.Id from Persons,Complaint,Cleaner,Room WHERE Persons.ID = Complaint.ClientID and Persons.Rooms = Room.NumberRoom and Cleaner.Id = Room.CleanerId and Persons.idHotel=Room.idHotel GROUP by Cleaner.Id");
            dicttoid.Add("number of average complain by hotel in %", i);
            idtocomand.Add(i++, "SELECT Room.idHotel,CEILING((COUNT(Complaint)/COUNT(Persons.ID)*100)) FROM Persons LEFT JOIN Complaint ON Persons.ID = Complaint.ClientID JOIN Room ON Persons.Rooms = Room.NumberRoom AND Persons.idHotel = Room.idHotel GROUP BY Room.idHotel");
            dicttoid.Add("number of complain by room", i);
            idtocomand.Add(i++, "SELECT count(DISTINCT Complaint.ClientID),Room.NumberRoom,Room.IDHotel from Persons,Complaint,Cleaner,Room WHERE Persons.ID = Complaint.ClientID and Persons.Rooms = Room.NumberRoom and Cleaner.Id = Room.CleanerId and Persons.idHotel=Room.idHotel GROUP by Room.NumberRoom");
            dicttoid.Add("person of same familly come from red country", i);
            idtocomand.Add(i++, "SELECT previous_illnesses.Illness_name,same_family.idFamilly from previous_illnesses,persons,same_family,stayed_in_foreign_country,color where persons.ID in (SELECT id from same_family)and persons.id = same_family.Id and persons.ID = previous_illnesses.ID and stayed_in_foreign_country.ID = persons.id and stayed_in_foreign_country.Country = color.Country and color.Dangerous = 'red' order by same_family.idFamilly");
            dicttoid.Add("person who come from france and seek", i);
            idtocomand.Add(i++, "SELECT personal_data.first_name,personal_data.last_name FROM visited_france_person NATURAL join personal_data NATURAL join previous_illnesses NATURAL JOIN stayed_in_foreign_country where stayed_in_foreign_country.Number_Days >= 14");
            dicttoid.Add("person who come from bayit vegan and can left the hotel", i);
            idtocomand.Add(i++, "select * from bayitveganhotel natural join stayed_in_foreign_country NATURAL join foreign_country NATURAL JOIN color where foreign_country.Vacination_Rate > 80 and color.Dangerous = 'green'");
            dicttoid.Add("mail from  person who make a plaint", i);
            idtocomand.Add(i++, "SELECT personal_data.mail from bayitveganhotel join personal_data,complaint where personal_data.ID = complaint.ClientID");
            dicttoid.Add("view dangerous hotel", i);
            idtocomand.Add(i++, "Select * from dangeroushotel ");
            dicttoid.Add("view bayitvegan hotel person data", i);
            idtocomand.Add(i++, "Select * from bayitveganhotel  ");
            dicttoid.Add("view person visited france", i);
            idtocomand.Add(i++, "Select * from VISITED_France_PERSON  ");


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
