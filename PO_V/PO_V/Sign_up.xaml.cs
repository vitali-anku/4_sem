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
using System.ComponentModel;

namespace PO_V
{
    /// <summary>
    /// Логика взаимодействия для Sign_up.xaml
    /// </summary>
    public partial class Sign_up : Page
    {
        public Sign_up()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Registr reg = new Registr
            {
                Log = Log.Text,
                FullName = Nam.Text,
                NumberPassport = Passp.Text,
                Password = pass1.Password,
                PasswordConfirm = pass2.Password
            };

            db re = new db();

            try
            {
                if (Validate.Valid(reg))
                {
                    SaltedHash salt = new SaltedHash(reg.Password);

                    string hash = salt.Hash;
                    string sal = salt.Salt;

                    if (re.Vald(reg.Log))
                    {
                        re.Reg(reg.Log, reg.FullName, sal, reg.NumberPassport, hash);
                        Sign_in ni = new Sign_in();
                        NavigationService.Navigate(ni);
                    }
                    else
                    {
                        MessageBox.Show("Пользователь с таким логином существует");
                    }
                }
                    
            }
            catch(Exception)
            {
                MessageBox.Show(ToString());
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Page1 start = new Page1();
            NavigationService.Navigate(start);
        }
    }
}
