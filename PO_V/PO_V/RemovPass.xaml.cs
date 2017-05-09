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
            MessageBox.Show(re.ReturnPhone());
            string pas = textBox.Password;
            string log = textBox1.Text;
            pass1.Content = "";
            if (!string.IsNullOrEmpty(textBox.Password) && !string.IsNullOrEmpty(textBox1.Text))
            {
                if (re.Sign_in(log, pas))
                {
                    re.A();
                    re.RemovePass();
                    MessageBox.Show("Аккаунт удален");
                    this.Close();
                }
                else
                    pass1.Content = "Неверные данные";
            }
            else
                pass1.Content = "Введите данные";
        }
    }
}
