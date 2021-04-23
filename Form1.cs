using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoTetris
{
    public partial class Form1 : Form
    {
        Board board = new Board();
        int value;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            board.LeftRight(MoveType.Left);
            timer1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            board.LeftRight(MoveType.Right);
            timer1.Enabled = true;
        }

        private void MyRefresh(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox1.Update();
            Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 5);
            foreach (Block b in board.Blocks)
            {

                Graphics g = pictureBox1.CreateGraphics();
                if (b.Filled)
                {
                    g.FillRectangle(new SolidBrush(Color.Red), b.Col * 20, b.Row * 20, 20, 20);
                }
                else
                {
                    //g.DrawRectangle(new Pen(Color.Red, 2f), b.Col * 20, b.Row * 20, 20, 20);
                    board.OrangeRicky();//criando a peça no array
                    //armazenar as posições sos dados da peça em variáveis??
                    //utilizar estas variáveis e subustituir dentro do drawRectangle abaixo??
                    g.DrawRectangle(new Pen(Color.Red, 2f), b.Col * 20, b.Row * 20, 40, 20);
                    g.DrawRectangle(new Pen(Color.Blue, 2f), b.Col * 20, b.Row * 20, 20, 40);
                    g.DrawRectangle(new Pen(Color.Green, 2f), b.Col * 20, b.Row * 20, 40, 20);
                    g.DrawRectangle(new Pen(Color.White, 2f), b.Col * 20, b.Row * 20, 20, 40);
                }

            }

            return;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            board.Down();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            board.Down();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            board.Refresh += new EventHandler(MyRefresh);
            GeraPeca();
            button5.Text = "Change";

        }

        private void button5_Click(object sender, EventArgs e)
        {   
            pictureBox1.Image = null;
            pictureBox1.Update();

            switch(value)
            {
                case 1:
                    button5.Text = "Orange Ricky";   //  __|
                    break;
                case 2:
                    button5.Text = "Blue Ricky";     //  |__
                    break;
                case 3:
                    button5.Text = "Cleveland Z";    //  -|_
                    break;
                case 4:
                    button5.Text = "Rhode Island Z"; //  _|-
                    break;
                case 5:
                    button5.Text = "Hero";           //  ______
                    break;
                case 6:
                    button5.Text = "Teewee";         //  _|_
                    break;
                case 7:
                    button5.Text = "Smashboy";       //  []
                    break;
            }
            //Graphics g = pictureBox1.CreateGraphics();
            //if (b.Filled)
            //{
            //    g.FillRectangle(new SolidBrush(Color.Red), b.Col * 20, b.Row * 20, 20, 20);
            //}
            //else
            //{
            //    g.DrawRectangle(new Pen(Color.Red, 2f), b.Col * 20, b.Row * 20, 20, 20);
            //}

        }

        public void GeraPeca()
        {
            int[] pecaTipo = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Random rand = new Random();
            value = rand.Next(0, pecaTipo.Length);
            switch (value)
            {
                case 1:
                    button5.Text = "Orange Ricky";   //  __|
                    board.OrangeRicky();
                    break;
                case 2:
                    button5.Text = "Blue Ricky";     //  |__
                    board.BlueRicky();
                    break;
                case 3:
                    button5.Text = "Cleveland Z";    //  -|_
                    board.ClevelandZ();
                    break;
                case 4:
                    button5.Text = "Rhode Island Z"; //  _|-
                    board.RhodeIslandZ();
                    break;
                case 5:
                    button5.Text = "Hero";           //  ______
                    board.Hero();
                    break;
                case 6:
                    button5.Text = "Teewee";         //  _|_
                    board.Teewee();
                    break;
                case 7:
                    button5.Text = "Smashboy";       //  []
                    board.Smashboy();
                    break;
            }
        }

        
    }
}
