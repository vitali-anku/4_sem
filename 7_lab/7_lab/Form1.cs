using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace _7_lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            for (int i=1; i<=31; i++)
            {
                comboBox1.Items.Add(i);
            }

            for(int i = 1990; i <= DateTime.Now.Year; i++)
            {
                comboBox3.Items.Add(i);
            }

            for(int i = 1; i <= 12; i++)
            {
                comboBox2.Items.Add(i);
            }
            
            for(int i = 1; i <= 4; i++)
            {
                comboBox4.Items.Add(i);
            }
            for(int i = 1; i <= 10; i++)
            {
                comboBox5.Items.Add(i);
            }
        }

        private void Vozrast()
        {
            if(comboBox1.SelectedItem != null && comboBox2.SelectedItem!=null && comboBox3.SelectedItem != null)
            {
                DateTime ue = new DateTime(Convert.ToInt32(comboBox3.SelectedItem.ToString()),
                                            Convert.ToInt32(comboBox2.SelectedItem.ToString()),
                                            Convert.ToInt32(comboBox1.SelectedItem.ToString()));
                DateTime now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                TimeSpan a = now - ue;
                textBox2.Text = Convert.ToInt32(a.TotalDays / 365).ToString();
            }
            else
            {
                MessageBox.Show("Дата рождения не выбрана");
            }
        }

        bool Validate()
        {
            if (textBox1.Text != null && textBox2.Text != null
                && comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && comboBox3.SelectedItem != null
                && comboBox4.SelectedItem != null && comboBox5.SelectedItem != null && comboBox6.SelectedItem != null
                && textBox3.Text != null && textBox4.Text != null && textBox5.Text != null
                && textBox6.Text != null && textBox7.Text != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vozrast();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            File.Delete("xml.txt");
            MessageBox.Show("Очищено");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            City city = new City();
            Address add = new Address();
            if (!Validate())
            {
                MessageBox.Show("Невалидные данные");
            }
            else
            {
                city.city = textBox4.Text;

                add.street = textBox5.Text;
                add.house = textBox6.Text;
                add.apartament = textBox7.Text;

                AddressWithCity a = new AddressWithCity(city, add);
                Stud s = new Stud(textBox1.Text, Convert.ToInt32(textBox2.Text), comboBox6.SelectedItem.ToString(),
                                    comboBox1.SelectedItem.ToString() + "/"
                                    + comboBox2.SelectedItem.ToString() + "/" +
                                    comboBox3.SelectedItem.ToString(),
                                    comboBox4.SelectedItem.ToString(), comboBox5.SelectedItem.ToString(),
                                    radioButton1.Checked ? "М" : "Ж", textBox3.Text, a);
                try
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(Stud));
                    // получаем поток, куда будем записывать сериализованный объект
                    using (FileStream fs = new FileStream("student.xml", FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, s);

                        MessageBox.Show("Объект стериализован");
                    }
                    richTextBox1.Text = File.ReadAllText("student.xml");
                }
                catch (Exception p)
                {
                    MessageBox.Show(p.ToString());
                }
            }
        }
    }
}
