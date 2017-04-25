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
            string log = textBox3.Text;
            string email = textBox.Text;
            string name = textBox1.Text;

            db reg = new db();
            SaltedHash salt = new SaltedHash(passwordBox.ToString());

            string hash = salt.Hash;
            string sal = salt.Salt;
            
            try
            {
                reg.Reg(log, name, email, sal, hash);
                MessageBox.Show("Благодарим вас за регистрацию.\nВойдите под своим логином и паролем.");
                Sign_in ni = new Sign_in();
                NavigationService.Navigate(ni);
            }
            catch(Exception)
            {
                MessageBox.Show(ToString());
            }
        }
    }
}
