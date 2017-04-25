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
using System.Data.SqlClient;

namespace PO_V
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        db aue = new db();
        public Page1()
        {
            InitializeComponent();

        }

        private void buttonClick(object sender, RoutedEventArgs e)
        {
            Sign_in login = new Sign_in();
            NavigationService.Navigate(login);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Sign_up registr = new Sign_up();
            NavigationService.Navigate(registr);
        }
    }
}
