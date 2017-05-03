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
            string log = Log.Text;
            string name = Nam.Text;
            string pass = passwordBox.Password;

            db reg = new db();
            SaltedHash salt = new SaltedHash(pass);

            string hash = salt.Hash;
            string sal = salt.Salt;

            try
            {
                if (pass != "" && name != "" && log != "") 
                {
                    if (reg.Vald(log))
                    {
                        reg.Reg(log, name, sal, hash);
                        MessageBox.Show("Благодарим вас за регистрацию.\nВойдите под своим логином и паролем.");
                        Sign_in ni = new Sign_in();
                        NavigationService.Navigate(ni);
                    }
                    else
                    {
                        lg.Content = "Пользователь с таким логином уже существует";
                        Log.Text = "";
                        Nam.Text = "";
                        passwordBox.Password = "";
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля для регистрации");
                }
                    
            }
            catch(Exception)
            {
                MessageBox.Show(ToString());
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Page1 home = new Page1();
            NavigationService.Navigate(home);
        }
    }
}
