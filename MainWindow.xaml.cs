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
        List<string> AddTable = new List<string> { "Hotel", "Rooms", "Link", "test" };
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            ListBoxAddItem.ItemsSource = AddTable;
            ListBoxAddItem.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(ListBoxAddItem.SelectedItem.ToString() == "Hotel")
            {
                Window a = new AddWPF.AddHotel();
                a.Show();
                a.Closed += WidowsClosed;
            }
        }

        private void WidowsClosed(object sender, EventArgs e)
        {
            
        }
    }
}
