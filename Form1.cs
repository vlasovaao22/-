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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pic_A_X = new List<int>();
            pic_A_Y = new List<int>();
        }

        //--------Старт
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult okay =  MessageBox.Show("Введите множество А");
            if (okay == DialogResult.OK)
            { 
                pic1 pic_ = new pic1(false);
                pic_.ShowDialog();
                pic_A_X = pic_.pic_X;
                pic_A_Y = pic_.pic_Y;
            }

            DialogResult okby = MessageBox.Show("Введите множество B");
            if (okby == DialogResult.OK)
            {
                pic1 pic_ = new pic1(true);
                pic_.ShowDialog();
                pic_B_X = pic_.pic_X;
                pic_B_Y = pic_.pic_Y;
            }
        }

        private List<int> pic_A_X;
        private List<int> pic_A_Y;
        private List<int> pic_B_X;
        private List<int> pic_B_Y;
        private List<int> pic_C_X;
        private List<int> pic_C_Y;
        private List<int> pic_D_X;
        private List<int> pic_D_Y;

        //показ множества А
        private void button2_Click(object sender, EventArgs e)
        {
            String s = "множество A";
            Brush p = Brushes.Red;
            Result res_ = new Result(p, pic_A_X, pic_A_Y,s);
            res_.ShowDialog();
        }

        //показ В
        private void button3_Click(object sender, EventArgs e)
        {
            String s="множество В";
            Brush p = Brushes.Blue;
            Result res_ = new Result(p, pic_B_X, pic_B_Y,s);
            res_.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String s = "пересечение множеств А и В";
            Brush p = Brushes.Plum;
            pic_C_X = new List<int>();
            pic_C_Y = new List<int>();

            for (int i = 0; i < pic_A_X.Count; i++)
            {
                 for (int j = 0; j < pic_B_X.Count; j++)
                 {
                    if((pic_A_X[i]==pic_B_X[j])&&(pic_A_Y[i]==pic_B_Y[j])){
                        pic_C_X.Add(pic_A_X[i]);
                        pic_C_Y.Add(pic_A_Y[i]);
                    }
                 }
            }

            Result res_ = new Result(p, pic_C_X, pic_C_Y, s);
            res_.ShowDialog();
        }

        
        private void button5_Click(object sender, EventArgs e)
        {
            String s = "разность множеств А и В";
            Brush p = Brushes.Green;
            pic_D_X = new List<int>();
            pic_D_Y = new List<int>();

            bool k=true;
            for (int i = 0; i < pic_A_X.Count; i++)
            {
                for (int j = 0; j < pic_B_X.Count; j++)
                {
                    if ((pic_A_X[i] == pic_B_X[j]) && (pic_A_Y[i] == pic_B_Y[j]))
                    {
                        k = false;
                    }
                }
                if (k) {
                    pic_D_X.Add(pic_A_X[i]);
                    pic_D_Y.Add(pic_A_Y[i]);
                }
                k = true;
            }

            Result res_ = new Result(p, pic_D_X, pic_D_Y, s);
            res_.ShowDialog();
        }

    }
}
