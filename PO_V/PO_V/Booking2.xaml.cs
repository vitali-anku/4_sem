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
    /// Логика взаимодействия для Booking2.xaml
    /// </summary>
    public partial class Booking2 : Page
    {
        public Booking2()
        {
            InitializeComponent();
            string a = Booking1.Item;
            Route(a);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Bron2 b = new Bron2
            {
                Item = calendar.SelectedDate.ToString(),
                Time = comboBox.Text
            };
            string m = b.Item;
            if (Validate.Valid(b))
            {
                if (int.Parse(m.Substring(0, m.Length - 16)) >= DateTime.Today.Day)
                {
                    m = m.Substring(0, m.Length - 13);
                    db rout = new db();
                    if (rout.Ticket(Booking1.Item, m, b.Time))
                    {
                        db bron = new db();
                        if (bron.Bron())
                        {
                            MessageBox.Show("Вы забронировали билет");
                            Booking0 go = new Booking0();
                            NavigationService.Navigate(go);
                        }
                        else
                        {
                            MessageBox.Show("Нет свободных мест");
                        }
                    }
                    else { MessageBox.Show("В этот день автобус не идет"); return; }
                }
                else
                {
                    MessageBox.Show("Выбран неправильный день");
                }
            }

        }
        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Start glavn = new Start();
            NavigationService.Navigate(glavn);
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Route(string y)
        {
            string lin = @"Data Source=VITALI\SQLSERVER;
                         Initial Catalog=Kursach;
                         Integrated Security=True";
            string arr = string.Format("select departure_point[Отправление], arival_point[Прибытие], data[Дата]," +
                                                            "CONVERT(VARCHAR(5), departure_time, 108)[Departure], " +
                                                            "CONVERT(VARCHAR(5), Travel_time , 108)[Путь], number_of_places[Места]" +
                                       "from Route where departure_point like 'Минск' and arival_point like @arival_point");

            using (SqlConnection conn = new SqlConnection(lin))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(arr, conn);
                cmd.Parameters.AddWithValue("@arival_point", y);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    sda.Fill(dt);

                    dataGrid.ItemsSource = dt.DefaultView;
                }
                conn.Close();
            }
        }
    }
}
