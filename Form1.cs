using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace snake
{
    public partial class Form1 : Form
    {
        private int x;
        private int y;
        private int ch;
        private int x_food;
        private int y_food;
        private Direction dir;
        private bool finish;
        private int max_ch;
        private int red;
        private int green;
        private int blue;
        private int red_bk;
        private int green_bk;
        private int blue_bk;
        private static System.Media.SoundPlayer player_Cat_Meow;
        private static System.Media.SoundPlayer player_AM;
        private const string REZ_FILE = "rez.txt";

        public enum Direction
        {
            DIR_UNDEF = 0, //0
            DIR_UP = 1,    //1-вверх
            DIR_RIGHT = 2,//2-вправо
            DIR_DOWN = 3, //3-вниз
            DIR_LEFT = 4 //4-влево
        };

        private void Init_Game()
        {
            x = 300;
            y = 300;
            ch = 0;
            x_food = 200;
            y_food = 200;
            dir = Direction.DIR_UNDEF;
            timer1.Enabled = true;
            finish = false;

            string[] containFile = File.ReadAllLines(REZ_FILE);
            textBox1.Text = containFile[0].Trim() + " " + containFile[1].Trim();
            int.TryParse(containFile[0].Trim(), out max_ch);
        }

        public Form1()
        {
            InitializeComponent();
            Init_Game();
            button4.Enabled = false;
            player_Cat_Meow = new System.Media.SoundPlayer("Cat Meow.wav");
            player_AM = new System.Media.SoundPlayer("Sound2.wav");
            red = 255;
            green = 0;
            blue = 0;
            red_bk = 128;
            green_bk = 255;
            blue_bk = 128;
            MessageBox.Show("Введите ник");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Init_Game();
            timer1.Interval = 2000;
            
            textBox2.Text = ch.ToString();
            timer1.Enabled = true;

            Brush p2 = new SolidBrush(Color.FromArgb(red_bk, green_bk, blue_bk));
            Graphics g = panel1.CreateGraphics();
            g.FillRectangle(p2, 0, 0, panel1.Width, panel1.Height);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            new_Paint();
        }

        private void new_Paint()
        {
            Brush p = new SolidBrush(Color.FromArgb(red, green, blue));
            Graphics g = panel1.CreateGraphics();
            g.FillEllipse(p, x, y, 10, 10);
            new_Paint_food();
        }
        private void old_Paint()
        {
            Brush p2 = new SolidBrush(Color.FromArgb(red_bk, green_bk, blue_bk));
            Graphics g = panel1.CreateGraphics();
            g.FillEllipse(p2, x, y, 10, 10);

        }

        private void new_Paint_food()
        {
            Brush p1 = Brushes.Blue;
            Graphics g = panel1.CreateGraphics();
            g.FillEllipse(p1, x_food, y_food, 5, 5);

        }

        private void old_Paint_food()
        {
            Brush p2 = new SolidBrush(Color.FromArgb(red_bk,green_bk,blue_bk));
            Graphics g = panel1.CreateGraphics();
            g.FillEllipse(p2, x_food, y_food, 5, 5);

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!finish){
                if (keyData == Keys.Down)
                {
                    old_Paint();
                    y = y + 10;
                    new_Paint();
                    dir = Direction.DIR_DOWN;
                }
                if (keyData == Keys.Up)
                {
                    old_Paint();
                    y = y - 10;
                    new_Paint();
                    dir = Direction.DIR_UP;
                }

                if (keyData == Keys.Left)
                {
                    old_Paint();
                    x = x - 10;
                    new_Paint();
                    dir = Direction.DIR_LEFT;
                }
                if (keyData == Keys.Right)
                {
                    old_Paint();
                    x = x + 10;
                    new_Paint();
                    dir = Direction.DIR_RIGHT;
                }
                if ((Math.Abs(x - x_food) < 10) && (Math.Abs(y - y_food) < 10))
                {  
                    ch = ch+1;
                    player_AM.Play();
                    textBox2.Text=ch.ToString();
                    old_Paint_food();
                    Random rnd = new Random();
                    x_food = rnd.Next(15, panel1.Width - 15);
                    y_food = rnd.Next(15, panel1.Height - 15);

                    timer1.Enabled = false;
                    if (timer1.Interval>=200)
                    {
                         timer1.Interval = timer1.Interval - 100;
                    }
                    timer1.Enabled = true;
                }
                if (dir != Direction.DIR_UNDEF)
                {
                    die_apple();

                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dir == Direction.DIR_DOWN)
            {
                old_Paint();
                y = y + 10;
                new_Paint();
            }
            if (dir == Direction.DIR_UP)
            {
                old_Paint();
                y = y - 10;
                new_Paint();
            }

            if (dir == Direction.DIR_LEFT)
            {
                old_Paint();
                x = x - 10;
                new_Paint();
            }
            if (dir == Direction.DIR_RIGHT)
            {
                old_Paint();
                x = x + 10;
                new_Paint();
            }

            if ((Math.Abs(x - x_food) < 10) && (Math.Abs(y - y_food) < 10))
            {  //-----съел
                ch = ch + 1;
               
                player_AM.Play();

                textBox2.Text = ch.ToString();
                old_Paint_food();
                Random rnd = new Random();
                x_food = rnd.Next(1, panel1.Width - 1);
                y_food = rnd.Next(1, panel1.Height - 1);

                if (timer1.Interval >= 200)
                {
                    timer1.Interval = timer1.Interval - 100;
                }
            }
            if (dir != Direction.DIR_UNDEF)
            {
                die_apple();
            }
        }

        void die_apple() {
            if ((x < 10) || (y < 10) || (x > panel1.Height - 10) || (y > panel1.Width - 10))
            {
                finish = true;
                //System.Media.SoundPlayer player = new System.Media.SoundPlayer("Cat Meow.wav");
                player_Cat_Meow.Play();
                timer1.Enabled = false;
                dir = Direction.DIR_UNDEF;
                MessageBox.Show("Игра завершена");
                if (ch > max_ch) 
                {
                    MessageBox.Show("Вы установили рекорд!");
                    StreamWriter sw;
                    File.Delete(REZ_FILE);
                    sw = File.AppendText(REZ_FILE);
                    
                    sw.WriteLine(ch.ToString());
                    sw.WriteLine(textBox3.Text);

                    sw.Flush();
                    sw.Close();
                    textBox1.Text = ch.ToString() + " " + textBox3.Text;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        { //изменить цвет шарика
            color page = new color(red,green,blue);
            DialogResult res = page.ShowDialog();
            if (res == DialogResult.Yes)
            {
                red = page.red;
                green = page.green;
                blue = page.blue;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {//изменения цвета поля
            color page = new color(red_bk, green_bk, blue_bk);
            DialogResult res = page.ShowDialog();
            if (res == DialogResult.Yes)
            {
                red_bk = page.red;
                green_bk = page.green;
                blue_bk = page.blue;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {//пауза
            timer1.Enabled = false;
            button4.Enabled = true;
            dir = Direction.DIR_UNDEF;
        }

        private void button4_Click(object sender, EventArgs e)
        {//игра
            timer1.Enabled = true;
            button4.Enabled = false;
        } 

    }
}
