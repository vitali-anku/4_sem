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
            lg.Content = "Логин не должен содержать буквы русского алфавита";
            lg.Foreground = Brushes.White;
        }
        private string s = "Error";
        private void button_Click(object sender, RoutedEventArgs e)
        {
            string log = Log.Text;
            string name = Nam.Text;
            string pass = pass1.Password;
            string passport = Passp.Text;
            string phone = Phone.Text;
            if (CheckString(log))
            {
                if (!(ValidPhone() == s))
                {
                    phone = Phone.Text;
                    log = Log.Text;
                }
                else
                {
                    label7.Content = "Невалидные данные";
                    Phone.Text = "";
                    return;
                }
            }
            else
            {
                lg.Content = "Логин не должен содержать буквы русского алфавита";
                lg.Foreground = Brushes.Red;
                return;
            }


            db reg = new db();
            SaltedHash salt = new SaltedHash(pass);

            string hash = salt.Hash;
            string sal = salt.Salt;

            try
            {
                if (!string.IsNullOrEmpty(Log.Text) && !string.IsNullOrEmpty(Nam.Text) && !string.IsNullOrEmpty(pass1.Password)
                    && !string.IsNullOrEmpty(Passp.Text) && !string.IsNullOrEmpty(Phone.Text))
                {
                    if (reg.Vald(log))
                    {
                        lg.Content = "";
                        if (CheckString(pass))
                        {
                            if (pass1.Password == pass2.Password)
                            {
                                reg.Reg(log, name, sal, passport, phone, hash);
                                MessageBox.Show("Благодарим вас за регистрацию.\nВойдите под своим логином и паролем.");
                                Sign_in ni = new Sign_in();
                                NavigationService.Navigate(ni);
                            }
                            else
                            {
                                pass2.Password = "";
                                pass1.Password = "";
                                label8.Content = "";
                                label3.Content = "Пароли не совпадают";
                            }
                        }
                        else
                        {
                            label8.Content = "Встречаются русские символы";
                            return;
                        }
                    }
                    else
                    {
                        lg.Content = "Пользователь с таким логином уже существует";
                        lg.Foreground = Brushes.Red;
                        Log.Text = "";
                        Nam.Text = "";
                        Passp.Text = "";
                        Phone.Text = "";
                        pass1.Password = "";
                        pass2.Password = "";
                        label3.Content = "";
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
            Page1 start = new Page1();
            NavigationService.Navigate(start);
        }

        private bool CheckString(string str)
        {
            bool y = false;
            int a = str.Length;
            if (a < 255 && a!=0)
            {
                lg.Content = "";
                for (int i = 0; i < a; ++i)
                {
                    char p = str[i];
                    if ((p >= 'а') && (p <= 'я') || (p >= 'А') && (p <= 'Я'))
                    {
                        return y = false;
                    }
                    else
                    {
                        y = true;
                    }
                }
            }
            return y;
        }

        private string ValidPhone()
        {
            string o;
            try
            {
                if (Phone.Text.Length < 20)
                {
                    if (Int32.Parse(Phone.Text) > 0)
                    {
                        label7.Content = "";
                        o = "";
                    }
                    else
                    {
                        label7.Content = "Невалидные данные";
                        Phone.Text = "";
                        o = "Error";
                    }
                }
                else
                {
                    label7.Content = "Слишком длинный номер";
                    Phone.Text = "";
                    o = "Error";
                }
            }
            catch (Exception)
            {
                o="Error";
            }
            return o;
        }
    }
}
