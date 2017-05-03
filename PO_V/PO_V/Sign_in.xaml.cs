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
            string log = textBox.Text;
            string pass = passwordBox1.Password;
             
            db d = new db();
            if (!string.IsNullOrEmpty(textBox.Text) && !string.IsNullOrEmpty(passwordBox1.Password) && d.Sign_in(log, pass))
            {
                SaltedHash p = new SaltedHash(pass);
                Start a = new Start();

                NavigationService.Navigate(a);
                textBox.Text = "";
                passwordBox1.Password = "";
            }
            else
            {
                label2.Content = "Введен неверный логин или пароль";
                textBox.Text = "";
                passwordBox1.Password = "";
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Page1 home = new Page1();
            NavigationService.Navigate(home);
        }
    }
}
