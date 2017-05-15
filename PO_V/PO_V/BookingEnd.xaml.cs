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

namespace PO_V
{
    /// <summary>
    /// Логика взаимодействия для BookingEnd.xaml
    /// </summary>
    public partial class BookingEnd : Page
    {
        public BookingEnd()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            db bron = new db();
            if (bron.Bron())
            {
                label.Foreground = Brushes.Black;
                label.Content = "Вы забронировали билет";
            }
            else
            {
                label.Foreground = Brushes.Red;
                label.Content = "Нет свободных мест";
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Start glavn = new Start();
            NavigationService.Navigate(glavn);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
