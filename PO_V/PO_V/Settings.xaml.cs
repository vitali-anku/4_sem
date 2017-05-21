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
        public Settings()
        {
            InitializeComponent();
        }

        db upremov = new db();

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Logi.Content = "";
            Name.Content = "";
            UpName nam = new UpName();
            nam.Show();
        }

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            Logi.Content = "";
            Name.Content = "";
            UpLog log = new UpLog();
            log.Show();
            this.NavigationService.Refresh();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Logi.Content = "";
            Name.Content = "";
            EE nam = new EE();
            nam.Show();
            this.NavigationService.Refresh();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Logi.Content = "";
            Name.Content = "";
            upremov.A();
            Logi.Content = "Логин: " + db.Login;
            Name.Content = "ФИО: " + db.Name;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Logi.Content = "";
            Name.Content = "";
            upremov.A();
            DeletAkk re = new DeletAkk();
            NavigationService.Navigate(re);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Logi.Content = "";
            Name.Content = "";
            Start glavn = new Start();
            NavigationService.Navigate(glavn);
        }
    }
}
