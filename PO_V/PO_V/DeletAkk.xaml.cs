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
    /// Логика взаимодействия для DeletAkk.xaml
    /// </summary>
    public partial class DeletAkk : Page
    {
        public DeletAkk()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            db re = new db();

            RemovePass remove = new RemovePass
            {
                Password = passwordBox1.Password
            };

            if (Validate.Valid(remove))
            {
                if (re.Sign_in(db.Login, remove.Password))
                {
                    re.A();
                    re.RemoveTicket();
                    re.RemovePass();
                    db.Login = "";
                    db.Name = "";
                    MessageBox.Show("Аккаунт удален");
                    Page1 start = new Page1();
                    NavigationService.Navigate(start);
                }
                else
                    pass1.Content = "Неверные данные";
            }
        }
    }
}
