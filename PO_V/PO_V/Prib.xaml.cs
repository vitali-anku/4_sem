﻿using System;
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
    /// Логика взаимодействия для Prib.xaml
    /// </summary>
    public partial class Prib : Page
    {
        public Prib()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Route();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Pribit();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Pribit()
        {

            string lin = @"Data Source=VITALI\SQLSERVER;
                         Initial Catalog=Kursach;
                         Integrated Security=True";

            string arr = string.Format("select arival_point[Откуда], arival_of_point[Куда], CONVERT(VARCHAR(8), arrival_time, 108)[Время прибытия]," +
                                "path_length[длина пути] from Route where arival_of_point like '%Минск%'");

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

        private void Route()
        {

            string lin = @"Data Source=VITALI\SQLSERVER;
                         Initial Catalog=Kursach;
                         Integrated Security=True";
            string arr = string.Format("select arival_point[Откуда], arival_of_point[Куда], CONVERT(VARCHAR(8), departure_time , 108)[Время отправления]," +
                                "CONVERT(VARCHAR(8), arrival_time, 108) [Время прибытия], path_length[длина пути] from Route where  arival_point like '%Минск%'");

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
