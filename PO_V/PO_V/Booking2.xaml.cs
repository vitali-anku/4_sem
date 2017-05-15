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
    /// Логика взаимодействия для Booking2.xaml
    /// </summary>
    public partial class Booking2 : Page
    {
        public Booking2()
        {
            InitializeComponent();
        }

        private static string Day { get; set; }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Day = calendar.SelectedDate.ToString();
            if (int.Parse(Day.Substring(0, Day.Length - 16)) >= DateTime.Today.Day && Day.Length > 0)
            {
                Day = Day.Substring(0, Day.Length - 13);
                db rout = new db();
                Booking1 book = new Booking1();
                if (rout.Ticket(book.ReturnItem(), Day))
                {
                    BookingEnd end = new BookingEnd();
                    NavigationService.Navigate(end);
                }
                else { MessageBox.Show("Пусто"); return; }
            }
            else { MessageBox.Show("Error!"); }
        }

        public string ReturnDay()
        {
            return Day;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
