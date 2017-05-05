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
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        static db upremov = new db();

        public Settings()
        {
            InitializeComponent();
            Logi.Content = upremov.ReturnLogin();
            Name.Content = upremov.ReturnName();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string nam = Upd.Text;
            if (nam != "")
            {
                upremov.UpdateName(nam);
                upremov.A();
                Name.Content = upremov.ReturnName();
            }
            else
                MessageBox.Show("Введите значение в поле");
        }

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            string log = Upd.Text;
            if (log != "") 
            {   
                upremov.UpdateLog(log);
                upremov.A();
                Logi.Content = upremov.ReturnLogin();
            }
            else
                MessageBox.Show("Введите значение в поле");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            UpdatePass up = new UpdatePass();
            NavigationService.Navigate(up);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            DeletAc del = new DeletAc();
            NavigationService.Navigate(del);
        }
    }
}
