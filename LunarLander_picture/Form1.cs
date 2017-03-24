using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LunarLander_picture
{
    public partial class Form1 : Form
    {
        //Background _background;
        
        Game _game;
        Graphics gfx;
        bool test = true;
        public Form1()
        {
            this.KeyPreview = true;
            InitializeComponent();
           
            DoubleBuffered = true;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gfx = Graphics.FromImage(pictureBox1.Image);
           // _background = new Background(pictureBox1);
            _game = new Game(gfx);


            timer1.Interval = 20;
            timer1.Start();
            
            
        }

        void pictureBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (test)
            {
                _game.Move();
            }
             _game.Draw(Graphics.FromImage(pictureBox1.Image));
            
            this.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.G)
                test = false;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.G)
                test = true;
        }

    
    }

}
