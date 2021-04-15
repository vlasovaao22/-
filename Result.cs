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
    public partial class Result : Form
    {

        public Result(Brush p, List<int> pic_X, List<int> pic_Y, String s)
        {
            InitializeComponent();
            this.pic_X = pic_X;
            this.pic_Y = pic_Y;
            w = panel1.Width;
            h = panel1.Height;
            label2.Text = s;
            this.p= p;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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
            for (int i = 0; i < pic_X.Count; i++)
            {
                g.FillEllipse(p, pic_X[i] - 5, panel1.Height - 5 - pic_Y[i], 10, 10);
            }
        }

        public List<int> pic_X;
        public List<int> pic_Y;
        private Brush p;
        private int w;
        private int h;

      }
}
