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
    /// Логика взаимодействия для Booking0.xaml
    /// </summary>
    public partial class Booking0 : Page
    {
        public Booking0()
        {
            InitializeComponent();
            Ticket();
        }

        private void Ticket()
        {

            string lin = @"Data Source=VITALI\SQLSERVER;
                         Initial Catalog=Kursach;
                         Integrated Security=True";

            string arr = string.Format("select c.departure_point[Отправление], c.arival_point[Прибытие], c.data[Дата], c.number_bus[Номер автобуса]," +
                                                "CONVERT(VARCHAR(5), c.departure_time, 108)[Время_отправления], c.price[Цена], b.full_name[ФИО], b.number_passprort[Паспорт]" +
                                       "from Ticket a inner join _user b on a.number_user = b.number_user " +
                                                     "inner join Route c on a.number_route = c.number_route");
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
    }
}
