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
using System.Windows.Shapes;

namespace PO_V
{
    /// <summary>
    /// Логика взаимодействия для EE.xaml
    /// </summary>
    public partial class EE : Window
    {
        public EE()
        {
            InitializeComponent();
        }
        static db a = new db();

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            string pass = pass1.Password;
            string new_pass = pass2.Password;
            string login = a.ReturnLogin();
            SaltedHash password = new SaltedHash(new_pass);
            string salt = password.Salt;
            string hash = password.Hash;
            if (!string.IsNullOrEmpty(pass1.Password))
            {
                if (a.Sign_in(login, pass))
                {
                    pa1.Content = "";
                    if (!string.IsNullOrEmpty(new_pass))
                    {
                        a.UpdatePass(salt, hash);
                        MessageBox.Show("Пароль изменен");
                        pa2.Content = "";
                        pass1.Password = "";
                        pass2.Password = "";
                        this.Close();
                    }
                    else
                        pa2.Content = "Введите новый пароль!";
                }
                else
                {

                    pa1.Content = "Неверный пароль";
                    pa2.Content = "";
                    pass1.Password = "";
                    pass2.Password = "";
                }
            }
            else
            {
                pa2.Content = "";
                pa1.Content = "Введите пароль";
                pass2.Password = "";
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
