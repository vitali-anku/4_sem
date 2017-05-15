using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    /// Логика взаимодействия для Atribut.xaml
    /// </summary>
    public partial class Atribut : Page
    {
        public Atribut()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Atrib asd = new Atrib
            {
                Pole = textBox.Text
            };
            if (Validate(asd))
            {
                MessageBox.Show(asd.Pole);
            }
        }
        private static bool Validate(Atrib a)
        {
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(a);
            if (!Validator.TryValidateObject(a, context, results, true))
            {
                foreach (var item in results)
                {
                    MessageBox.Show(item.ErrorMessage);
                    return false;
                }
            }
            return true;
        }
    }
}
