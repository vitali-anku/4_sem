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

        //public void Bron()
        //{
        //    string lin = @"Data Source=VITALI\SQLSERVER;
        //                 Initial Catalog=Kursach;
        //                 Integrated Security=True";

        //    string arr = string.Format("select * from BUs");

        //    using (SqlConnection conn = new SqlConnection(lin))
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand(arr, conn);
        //        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //        {
        //            DataTable dt = new DataTable();

        //            sda.Fill(dt);

        //            dataGrid.ItemsSource = dt.DefaultView;
        //        }
        //        conn.Close();
        //    }
        //}

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Prib prib = new Prib();
            NavigationService.Navigate(prib);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Bron();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //dataGrid.ItemsSource = null;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Settings pr = new Settings();
            NavigationService.Navigate(pr);
        }

        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                e.Handled = false;
            }
        }
    }
}