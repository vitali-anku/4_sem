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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            db upremov = new db();
            UpdateName a = new UpdateName
            {
                FullName = textBox.Text
            };
            if (Validate.Valid(a))
            {
                upremov.A();
                upremov.UpdateName(a.FullName);
                MessageBox.Show("ФИО изменено");
                this.Close();
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
