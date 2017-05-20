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
    /// Логика взаимодействия для Booking1.xaml
    /// </summary>
    public partial class Booking1 : Page
    {
        public Booking1()
        {
            InitializeComponent();
        }
        public static string Item { get; set; }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Bron1 a = new Bron1
            {
                Item = comboBox.Text
            };
            if (Validate.Valid(a))
            {
                Item = a.Item;
                Booking2 next = new Booking2();
                NavigationService.Navigate(next);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
