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
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            board.LeftRight(MoveType.Left);
            MyRefresh();
            timer1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            board.LeftRight(MoveType.Right);
            MyRefresh();
            timer1.Enabled = true;
        }

        private void MyRefresh()
        {
            pictureBox1.Image = null;
            pictureBox1.Update();
            foreach (Block b in board.Blocks)
            {

                Graphics g = pictureBox1.CreateGraphics();
                if (b.Filled)
                {
                    g.FillRectangle(new SolidBrush(Color.Red), b.Col * 20, b.Row * 20, 20, 20);
                }
                else
                {
                    g.DrawRectangle(new Pen(Color.Red, 2f), b.Col * 20, b.Row * 20, 20, 20);
                }

            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            board.Down();
            MyRefresh();
            if (board.HasBlocksToClear())
            {
                Thread.Sleep(100);
                board.ClearComplete();
                MyRefresh();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Interval = 1;
            board.Down();
            MyRefresh();
            if (board.HasBlocksToClear())
            {
                Thread.Sleep(100);
                board.ClearComplete();
                MyRefresh();
            }
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
