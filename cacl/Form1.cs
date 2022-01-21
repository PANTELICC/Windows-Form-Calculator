using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cacl
{
    public partial class Form1 : Form
    {
        int mov;
        int movX;
        int movY;
        double rez = 0;
        string Operation = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void Nuber_Only(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if(b.Text == ".")
            {
                if(textBox1.Text.IndexOf(".") < 0)
                    textBox1.Text += ".";
            }
            if (textBox1.Text == "0" && b.Text == "0")  textBox1.Text = "0";
            if (textBox1.Text == "0"){
                textBox1.Text = "";
                textBox1.Text += b.Text;
            }
            else  textBox1.Text += b.Text;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = (Math.Pow(double.Parse(textBox1.Text),2)).ToString();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = (Math.Sqrt(double.Parse(textBox1.Text))).ToString();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            rez = 0;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            label1.Text = "";
            rez = 0;
        }

        private void operation(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (rez != 0)
            {
                button14.PerformClick();
                Operation = b.Text;
                label1.Text = rez + Operation;
                textBox1.Text = "";
            }
            else
            {
                Operation = b.Text;
                rez = double.Parse(textBox1.Text);
                label1.Text = rez + Operation;
                textBox1.Text = "";

            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            switch (Operation)
            {
                case "+":
                    textBox1.Text = (rez + double.Parse(textBox1.Text)).ToString();
                    break;
                case "-":
                    textBox1.Text = (rez - double.Parse(textBox1.Text)).ToString();
                    break;
                case "×":
                    textBox1.Text = (rez * double.Parse(textBox1.Text)).ToString();
                    break;
                case "÷":
                    textBox1.Text = (rez / double.Parse(textBox1.Text)).ToString();
                    break;
                default:
                    break;
            }
            rez = double.Parse(textBox1.Text);
            Operation = "";
        }
    }
}
