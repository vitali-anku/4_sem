using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    /// Логика взаимодействия для Sign_in.xaml
    /// </summary>
    public partial class Sign_in : Page
    {
        public Sign_in()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Login lo = new Login
            {
                Log = textBox.Text,
                Pass = passwordBox1.Password
            };
             
            db d = new db();

            if (Validate.Valid(lo))
            {
                if (d.Sign_in(lo.Log, lo.Pass))
                {
                    Start a = new Start();
                    NavigationService.Navigate(a);
                    textBox.Text = "";
                }
                else
                {
                    label2.Content = "Введен неверный логин или пароль";
                    textBox.Text = "";
                    passwordBox1.Password = "";
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Page1 home = new Page1();
            NavigationService.Navigate(home);
        }
    }
}
