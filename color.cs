using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace snake
{
    public partial class color : Form
    {
        public int red;
        public int green;
        public int blue;

        public color(int red, int green, int blue)
        {
            InitializeComponent();
            textBox1.Text = red.ToString();
            textBox2.Text = green.ToString();
            textBox3.Text = blue.ToString();
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool check_color(out int r, out int g, out int b)
        {
            r = 0;
            g = 0;
            b = 0;
            if ((int.TryParse(textBox1.Text, out r)) && (int.TryParse(textBox2.Text, out g)) && (int.TryParse(textBox3.Text, out b))
                && (r <= 255) && (g <= 255) && (b <= 255) && (r >= 0) && (g >= 0) && (b >= 0))
            {
                return true;
            }
            else return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int r;
            int g;
            int b;
            if (check_color(out r, out g, out b))
            {
                red = r;
                green = g;
                blue = b;
            }
            else MessageBox.Show("Исправьте значение цвета");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int r;
            int g;
            int b;
            if (check_color(out r, out g, out b))
            {
                Brush p2 = new SolidBrush(Color.FromArgb(r, g, b));
                Graphics gr = panel1.CreateGraphics();
                gr.FillRectangle(p2, 0, 0, panel1.Width, panel1.Height);
            }
            else MessageBox.Show("Исправьте значение цвета");
        }


    }
}
