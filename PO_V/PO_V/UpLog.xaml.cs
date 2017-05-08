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
            string log = textBox.Text;
            if (log != "")
            {
                a.UpdateLog(log);
                MessageBox.Show("Логин изменен!");
                a.A();
                this.Close();
            }
            else
                label.Content = "Введите значение в поле";
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
