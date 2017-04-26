using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6_lab
{
    public partial class Form1 : Form
    {
        UInt32 a, b;
        double ll;
        int count, mn, pl;
        private void Calculate()
        {
            switch (count)
            {
                case 1:
                    int p = pl + int.Parse(textBox1.Text);
                    textBox2.Text += pl.ToString() + "+" + textBox1.Text + "=" + p.ToString() + Environment.NewLine;
                    textBox1.Text = b.ToString();
                    break;
                case 2:
                    int m = mn - int.Parse(textBox1.Text);
                    textBox2.Text += mn.ToString() + "-" + textBox1.Text + "=" + m.ToString() + Environment.NewLine;
                    textBox1.Text = m.ToString();
                    break;
                case 3:
                    double o = a / double.Parse(textBox1.Text);
                    textBox2.Text += a.ToString() + "/" + textBox1.Text + "=" + o.ToString() + Environment.NewLine;
                    textBox1.Text = o.ToString();
                    break;
                case 4:
                    b = a * UInt32.Parse(textBox1.Text);
                    textBox2.Text += a.ToString() + "*" + textBox1.Text + "=" + b.ToString() + Environment.NewLine;
                    textBox1.Text = b.ToString();
                    break;
                case 5:
                    double x = double.Parse(textBox1.Text);
                    double bb = Math.Pow(ll, x);
                    textBox2.Text += ll.ToString() + "^" + textBox1.Text + "=" + bb.ToString() + Environment.NewLine;
                    textBox1.Text = bb.ToString();
                    break;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            pl = int.Parse(textBox1.Text);
            textBox1.Clear();
            count = 1;
            label1.Text = pl.ToString() + "+";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            mn = int.Parse(textBox1.Text);
            textBox1.Clear();
            count = 2;
            label1.Text = mn.ToString() + "-";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            a = UInt32.Parse(textBox1.Text);
            textBox1.Clear();
            count = 3;
            label1.Text = a.ToString() + "/";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            a = UInt32.Parse(textBox1.Text);
            textBox1.Clear();
            count = 4;
            label1.Text = a.ToString()+ "*";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            ll = Double.Parse(textBox1.Text);
            textBox1.Clear();
            count = 5;
            label1.Text = ll.ToString() + "^";
        }


        private void button11_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += 0;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += 9;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += 8;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += 7;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += 6;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += 5;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += 4;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += 3;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += 1;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            Calculate();
            label1.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label1.Text = "";
        }

        private void Form1_SystemColorsChanged(object sender, EventArgs e)
        {

        }
    }

}
