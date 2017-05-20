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
    /// Логика взаимодействия для RemovPass.xaml
    /// </summary>
    public partial class RemovPass : Window
    {
        public RemovPass()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            db re = new db();

            RemovePass remove = new RemovePass
            {
                Log = textBox1.Text,
                Password = passwordBox1.Password
            };

            if (Validate.Valid(remove))
            {
                if (re.Sign_in(remove.Log, remove.Password))
                {
                    re.A();
                    re.RemovePass();
                    db.Login = "";
                    db.Name = "";
                    MessageBox.Show("Аккаунт удален");
                    this.Close();
                }
                else
                    pass1.Content = "Неверные данные";
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
