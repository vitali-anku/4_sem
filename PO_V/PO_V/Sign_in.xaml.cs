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

            string hash = "x09CZFC34mONzN+VnZsCNkWDGjMq+RU65XSzvzysL3bFh7fKJy49o211MOI5a71C2l6udHaSpklMQd54ntAxKA==";
            string salt = "Mi2qLPEGlNy3Dl6rEBHAdl2kR7jEH1GdZ5l4j58hFyP6sAA/H7KxZbAYygAb3DFIxpnCclVtjBLcDcRYjgU9lg==";

            if (SaltedHash.Verify(hash, pass, salt))
            {
                MessageBox.Show("Получилось войти!");
            }
            else
                label2.Content = "Неверный логин или пароль";
            db autor = new db();

        }
    }
}
