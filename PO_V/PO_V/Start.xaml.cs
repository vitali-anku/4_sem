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
        static db n = new db();
        public string name = n.ReturnName();


        public Start()
        {
            InitializeComponent();
            button.Content = "Ближайшие прибытия";
            Nam.Content = name;
        }

        public void Bron()
        {
            string lin = @"Data Source=VITALI\SQLSERVER;
                         Initial Catalog=Kursach;
                         Integrated Security=True";

            string arr = string.Format("select * from BUs");

            using (SqlConnection conn = new SqlConnection(lin))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(arr, conn);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    sda.Fill(dt);

                    dataGrid.ItemsSource = dt.DefaultView;
                }
                conn.Close();
            }

        }

        public void Route()
        {

            string lin = @"Data Source=VITALI\SQLSERVER;
                         Initial Catalog=Kursach;
                         Integrated Security=True";

            string arr = string.Format("select number, arival_point, area, region, departure_time, arrival_time from Route order by departure_time");

            using (SqlConnection conn = new SqlConnection(lin))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(arr, conn);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    sda.Fill(dt);

                    dataGrid.ItemsSource = dt.DefaultView;
                }
                conn.Close();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Route();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Bron();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Settings pr = new Settings();
            NavigationService.Navigate(pr);
        }
    }
}