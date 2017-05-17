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

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            db a = new db();
            UpdatePass up = new UpdatePass
            {
                Password = pass1.Password,
                NewPassword = pass2.Password
            };
            a.A();
            string login = db.Login;
            SaltedHash password = new SaltedHash(up.Password);
            string salt = password.Salt;
            string hash = password.Hash;
            if (Validate.Valid(up))
            {
                if (a.Sign_in(login, up.Password))
                {
                    a.UpdatePass(salt, hash);
                    MessageBox.Show("Пароль изменен");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Вы ввели неверный пароль!");
                    pass1.Password = "";
                    pass2.Password = "";
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
