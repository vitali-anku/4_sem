using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace PO_V
{
    /// <summary>
    /// Логика взаимодействия для Start.xaml
    /// </summary>

    public partial class Start : Page
    {
        public Start()
        {
            InitializeComponent();
            button.Content = "Ближайшие прибытия";
        }

        db a = new db();

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Prib prib = new Prib();
            NavigationService.Navigate(prib);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Booking0 book = new Booking0();
            NavigationService.Navigate(book);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Settings pr = new Settings();
            NavigationService.Navigate(pr);
        }

        private void button2_Click_1(object sender, RoutedEventArgs e)
        { 
            Page1 glavn = new Page1();
            NavigationService.Navigate(glavn);
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                e.Handled = false;
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Booking1 booking = new Booking1();
            NavigationService.Navigate(booking);
        }


        public void Bron()
        {

        }
    }
}