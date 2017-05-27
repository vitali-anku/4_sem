using System;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lab_7
{
    public partial class Form1 : Form
    {
        List<Student> templist = new List<Student>();
        public Form1()
        {
            InitializeComponent();
            
            for (int i = 1; i <= 31; i++)
            {
                comboBoxDay.Items.Add(i);
            }
            
            for (int i = 1970; i <= DateTime.Now.Year; i++)
            {
                comboBoxYear.Items.Add(i);
            }
            for (int i = 1; i <= 12; i++)
            {
                comboBoxMonth.Items.Add(i);
            }
          }

        private void OnVozInFocus(object sender, EventArgs e)
        {
            if (comboBoxYear.SelectedItem != null && comboBoxMonth.SelectedItem != null && comboBoxDay.SelectedItem != null)
            {
                DateTime voz = new DateTime(Convert.ToInt32(comboBoxYear.SelectedItem.ToString()), Convert.ToInt32(comboBoxMonth.SelectedItem.ToString()), Convert.ToInt32(comboBoxDay.SelectedItem.ToString()));
                DateTime now = new DateTime(DateTime.Now.Year, DateTime.Now.Month,DateTime.Now.Day);
                TimeSpan v = now - voz;
                textBoxVoz.Text =   (Convert.ToInt32(v.TotalDays / 365)).ToString();
            }
            else
            {
                MessageBox.Show("Не выбрана дата рождения");
            }
           
        }

        private void OnClickSaveToXml(object sender, EventArgs e)
        {
            City _city = new City();
            Address _add = new Address();
            if (!Validate())
            {
                MessageBox.Show("Невалидные данные"); 
            }
            else { 
            _city.city = textBoxCity.Text;
            _city.zip = Convert.ToInt32(textBoxZIP.Text);
            
            _add.street = textBoxStreet.Text;
            _add.house = textBoxHouse.Text;
            _add.apartament = textBoxApartament.Text;

            AddressWithCity a = new AddressWithCity(_city, _add);
            Student s = new Student(textBoxName.Text, Convert.ToInt32(textBoxVoz.Text), comboBoxSpec.SelectedItem.ToString(), comboBoxDay.SelectedItem.ToString() + "@" + comboBoxMonth.SelectedItem.ToString() + "@" + comboBoxYear.SelectedItem.ToString(), comboBoxKurs.SelectedItem.ToString(), comboBoxGroup.SelectedItem.ToString(), radioButton1.Checked ? "М" : "Ж", textBoxSrBall.Text, a);
            XmlSerializer formatter = new XmlSerializer(typeof(Student));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("student_"+s.Name+"_"+s.City+"_"+s.BirthDay+".xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, s);
                MessageBox.Show("Объект сериализован");
            }
            //Process.Start("student.xml");
            }
        }

        bool  Validate()
        {
            if (textBoxName.Text != null && textBoxVoz.Text != null && comboBoxSpec.SelectedItem != null && comboBoxDay.SelectedItem != null && comboBoxMonth.SelectedItem != null && comboBoxYear.SelectedItem != null && comboBoxKurs.SelectedItem != null && comboBoxGroup.SelectedItem != null &&  textBoxSrBall.Text != null)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        private void Click_About_Software(object sender, EventArgs e)
        {
            MessageBox.Show("Версия: 0.182 \nРазработчик: Анкудович Виталий.","Версия программы");
        }

        private void SearchStudents(object sender, EventArgs e)
        {
            listBoxStudents.Items.Clear();
            templist.Clear();

            DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory);
            foreach (var item in dir.GetFiles())
            {
                if (item.Name.Contains(textBoxSearch.Text)&& item.Name.Contains("student"))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(Student));
                    TextReader reader = new StreamReader(item.Name);
                    object obj = deserializer.Deserialize(reader);
                    Student xml = (Student)obj;
                    reader.Close();
                    templist.Add(xml);
                    ListViewItem it = listBoxStudents.Items.Add(xml.Name);
                }
            }
           
        }

        private void OpenStudent(object sender, EventArgs e)
        {
            if (listBoxStudents.SelectedItems.Count > 0)
            {
                var item = templist[listBoxStudents.FocusedItem.Index];
                MessageBox.Show("Имя: "+item.Name+" \nАдрес: "+item.City+Environment.NewLine+item.street+"\nСпециальность: "+item.Spec+"\n День Рождения: "+item.BirthDay.Replace("@","."),"Информация о студенте");
            }
        }

        private void OnClickDateDesc(object sender, EventArgs e)
        {
            listBoxStudents.Items.Clear();
            var newList = templist.OrderByDescending(x => x.BirthDay.Split('@')[2]).ToList();
            int i = 0;
            foreach (var item in newList)
            {
                listBoxStudents.Items.Add(item.Name + " | " + item.BirthDay.Replace("@","."));
            }
        }
        private void OnClickDateAsc(object sender, EventArgs e)
        {
            listBoxStudents.Items.Clear();
            var newList = templist.OrderBy(x => x.BirthDay.Split('@')[2]).ToList();
            int i = 0;
            foreach (var item in newList)
            {
                listBoxStudents.Items.Add(item.Name + " | " + item.BirthDay.Replace("@", "."));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            City _city = new City();
            Address _add = new Address();
            if (!Validate())
            {
                MessageBox.Show("Невалидные данные");


            }
            else
            {
                _city.city = textBoxCity.Text;
                _city.zip = Convert.ToInt32(textBoxZIP.Text);

                _add.street = textBoxStreet.Text;
                _add.house = textBoxHouse.Text;
                _add.apartament = textBoxApartament.Text;

                AddressWithCity a = new AddressWithCity(_city, _add);
                Student s = new Student(textBoxName.Text, Convert.ToInt32(textBoxVoz.Text), comboBoxSpec.SelectedItem.ToString(), comboBoxDay.SelectedItem.ToString() + "@" + comboBoxMonth.SelectedItem.ToString() + "@" + comboBoxYear.SelectedItem.ToString(), comboBoxKurs.SelectedItem.ToString(), comboBoxGroup.SelectedItem.ToString(), radioButton1.Checked ? "М" : "Ж", textBoxSrBall.Text, a);
                XmlSerializer formatter = new XmlSerializer(typeof(Student));

                // получаем поток, куда будем записывать сериализованный объект
                using (FileStream fs = new FileStream("student_" + s.Name + "_" + s.City + "_" + s.BirthDay + ".xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, s);

                    MessageBox.Show("Объект сериализован");
                }
                //Process.Start("student.xml");
            }
        }
    }
}
