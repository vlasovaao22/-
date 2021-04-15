using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace проект_13
{
    public partial class pic1 : Form
    {

        public pic1(bool blue)
        {
            InitializeComponent();
            pic_X = new List<int>();
            pic_Y = new List<int>();
            pic_X_temp = new List<int>();
            pic_Y_temp = new List<int>();
            if (blue)
                p = Brushes.Blue;
            else p = Brushes.Red;
            w = panel1.Width;
            h = panel1.Height;
            
        }

        private void pic1_Load(object sender, EventArgs e)
        {
           
        }

        private void pic1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
             
            //MessageBox.Show(e.Location.ToString());
            //Graphics g = this.CreateGraphics();
            //g.DrawEllipse(p, e.Location.X, e.Location.Y, 10, 10);
            //pic_X.Add(e.Location.X);
            //pic_Y.Add(e.Location.Y);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            label2.Text = "x= " + e.Location.X + " " + "y= " + (panel1.Height - e.Location.Y).ToString();
           // MessageBox.Show(label2.Text);
            Graphics g = panel1.CreateGraphics();
            g.FillEllipse(p, e.Location.X-5, e.Location.Y-5, 10, 10);
            pic_X_temp.Add(e.Location.X);
            pic_Y_temp.Add(panel1.Height - e.Location.Y);
        }
        public List<int> pic_X;
        public List<int> pic_Y;
        private Brush p;
        private int w;
        private int h;
        private List<int> pic_X_temp;
        private List<int> pic_Y_temp;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x;
            int y;
            if (int.TryParse(textBox1.Text, out x))
            {
                if (int.TryParse(textBox2.Text, out y))
                {
                    pic_X_temp.Add(x);
                    pic_Y_temp.Add(y);
                    if ((x <= w) && (y <= h))
                    {
                        Graphics g = panel1.CreateGraphics();
                        g.FillEllipse(p, x - 5, panel1.Height - y - 5, 10, 10);
                    }
                }
                else MessageBox.Show("Исправьте Y");
            }
            else MessageBox.Show("Исправьте X");
        }

        private void pic1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = panel1.CreateGraphics();
            Pen ps = Pens.Black;
            for (int i = 100; i < panel1.Width; i = i + 100)
            {
                g.DrawLine(ps, 0, panel1.Height - i, panel1.Width, panel1.Height - i);
            }
            for (int i = 100; i < panel1.Height; i = i + 100)
            {
                g.DrawLine(ps, i, panel1.Height, i, 0);
            }
            for (int i = 0; i < pic_X_temp.Count; i++)
            {
                g.FillEllipse(p, pic_X_temp[i] - 5, panel1.Height - pic_Y_temp[i] - 5, 10, 10);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {//сохранить
            for (int i = 0; i < pic_X_temp.Count; i++)
            {
                pic_X.Add(pic_X_temp[i]);
                pic_Y.Add(pic_Y_temp[i]);
            }
            this.Close();
        }

      

    }
}
