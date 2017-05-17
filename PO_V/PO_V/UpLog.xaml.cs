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
    /// Логика взаимодействия для UpLog.xaml
    /// </summary>
    public partial class UpLog : Window
    {
        public UpLog()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            db a = new db();
            UpdateLogin up = new UpdateLogin
            {
                Log = textBox.Text
            };

            if (Validate.Valid(up))
            {
                a.A();
                a.UpdateLog(up.Log);
                MessageBox.Show("Логин изменен!");
                this.Close();
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
