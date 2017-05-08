﻿using System;
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
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            UpName nam = new UpName();
            nam.Show();
        }

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            UpLog log = new UpLog();
            log.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            EE nam = new EE();
            nam.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Logi.Content = "Логин: " + upremov.ReturnLogin();
            Name.Content = "ФИО: " + upremov.ReturnName();
        }
    }
}