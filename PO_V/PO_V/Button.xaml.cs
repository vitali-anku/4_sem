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
    /// Логика взаимодействия для Button.xaml
    /// </summary>
    public partial class Button : Page
    {
        public Button()
        {
            InitializeComponent();
        }

        private void acceptbutton_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = "ОТкрыто";
        }
        private void escbutton_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = "Закрыто";
        }
    }
}
