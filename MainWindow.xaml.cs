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
        List<string> AddTable = new List<string> { "Hotel","Manager", "Cleaner", "Rooms", "Link", "Personn" };
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
