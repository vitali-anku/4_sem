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
    /// Логика взаимодействия для UpName.xaml
    /// </summary>
    public partial class UpName : Window
    {
        public UpName()
        {
            InitializeComponent();
        }
        static db upremov = new db();
        private void button_Click(object sender, RoutedEventArgs e)
        {
            string nam = textBox.Text;
            if (nam != "")
            {
                upremov.UpdateName(nam);
                upremov.A();
            }
            else
                MessageBox.Show("Введите значение в поле");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
