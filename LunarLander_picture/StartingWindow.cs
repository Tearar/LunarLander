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
    public partial class StartingWindow : Form
    {
        SoundPlayer snd = new SoundPlayer(Properties.Resources.background);
       
        public StartingWindow()
        {
            InitializeComponent();
            KeyPreview = true;
            pictureBox1.Image = Properties.Resources.stars;
            comboBox1.Items.Add("Easy");
            comboBox1.Items.Add("Medium");
            comboBox1.Items.Add("Hard");
            comboBox1.SelectedIndex = 0;
            snd.PlayLooping();
            

        }

        private void StartingWindow_Load(object sender, EventArgs e)
        {
            Font _font = new Font("Stencil", 30, FontStyle.Italic);
            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                g.DrawString("Welcome to Lunar Lander !", _font, Brushes.White, 175, 50); // requires font, brush etc
            }

            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                g.DrawString("Choose the difficulty:", _font, Brushes.White, 200, 100); // requires font, brush etc
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameWindow frm = new GameWindow(comboBox1.SelectedIndex);
            frm.Show();
        }

        private void StartingWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
        }
    }
}
