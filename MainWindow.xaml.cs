using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SqlMahonProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Window a;
        List<string> AddTable = new List<string> { "Hotel","Manager", "Cleaner", "Rooms", "Personn","visits", "id famille", "visitor", "complain","sameFamilly","links","receiveVaccin","address","Color","Foreign country","Personal Data","Previous Illeness","stayed in foreign countrey" };
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            ListBoxAddItem.ItemsSource = AddTable;
            ListBoxAddItem.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxAddItem.SelectedItem.ToString() == "Hotel")
            {
                a = new AddWPF.AddHotel();
                a.Show();
                a.Closed += WidowsClosed;
            }
            else if (ListBoxAddItem.SelectedItem.ToString() == "address") 
            {
                a = new AddWPF.Address();
                a.Show();
                a.Closed += WidowsClosed;
            }
            else if (ListBoxAddItem.SelectedItem.ToString() == "Color") {
                a = new AddWPF.Color();
                a.Show();
                a.Closed += WidowsClosed;
            }
            else if (ListBoxAddItem.SelectedItem.ToString() == "Foreign country") {
                a = new AddWPF.Foreign_Country();
                a.Show();
                a.Closed += WidowsClosed;
            }
            else if (ListBoxAddItem.SelectedItem.ToString() == "Personal Data")
            {
                a = new AddWPF.Personal_Data();
                a.Show();
                a.Closed += WidowsClosed;
            }
            else if (ListBoxAddItem.SelectedItem.ToString() == "Previous Illeness")
            {
                a = new AddWPF.Previous_Illnesses();
                a.Show();
                a.Closed += WidowsClosed;
            }
            else if (ListBoxAddItem.SelectedItem.ToString() == "stayed in foreign countrey")
            {
                a = new AddWPF.Stayed_In_Foreign_Country();
                a.Show();
                a.Closed += WidowsClosed;
            }
            else if (ListBoxAddItem.SelectedItem.ToString() == "receiveVaccin")
            {
                a = new AddWPF.receiveVaccin();
                a.Show();
                a.Closed += WidowsClosed;
            }
            else if (ListBoxAddItem.SelectedItem.ToString() == "Manager")
            {
                a = new AddWPF.AddManager();
                a.Show();
                a.Closed += WidowsClosed;
            }
            else if (ListBoxAddItem.SelectedItem.ToString() == "Cleaner")
            {
                a = new AddWPF.Cleaner();
                a.Show();
                a.Closed += WidowsClosed;
            }
            else if (ListBoxAddItem.SelectedItem.ToString() == "visits")
            {
                a = new AddWPF.visits();
                a.Show();
                a.Closed += WidowsClosed;
            }
            else if (ListBoxAddItem.SelectedItem.ToString() == "sameFamilly")
            {
                a = new AddWPF.same_familly();
                a.Show();
                a.Closed += WidowsClosed;
            }
            else if (ListBoxAddItem.SelectedItem.ToString() == "id famille")
            {
                a = new AddWPF.idFamilly();
                a.Show();
                a.Closed += WidowsClosed;
            }
            else if (ListBoxAddItem.SelectedItem.ToString() == "complain")
            {
                a = new AddWPF.Complain();
                a.Show();
                a.Closed += WidowsClosed;
            }
            else if (ListBoxAddItem.SelectedItem.ToString() == "visitor")
            {
                a = new AddWPF.Visitor();
                a.Show();
                a.Closed += WidowsClosed;
            }
            else if (ListBoxAddItem.SelectedItem.ToString() == "Rooms")
            {
                a = new AddWPF.Rooms();
                a.Show();
                a.Closed += WidowsClosed;
            }
            else if (ListBoxAddItem.SelectedItem.ToString() == "Personn")
            {
                a = new AddWPF.Personn();
                a.Show();
                a.Closed += WidowsClosed;
            }
        }

        private void WidowsClosed(object sender, EventArgs e)
        {
            
        }
    }
}
