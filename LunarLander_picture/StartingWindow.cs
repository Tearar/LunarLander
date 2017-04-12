using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace LunarLander_picture
{
    public partial class StartingWindow : Form
    {
        /* initializing class variables */
        SoundPlayer snd = new SoundPlayer(Properties.Resources.background);

        /* public constructor */
        public StartingWindow()
        {
            InitializeComponent();
            KeyPreview = true;
            pictureBox1.Image = Properties.Resources.stars;
            handleComboBox();
            snd.PlayLooping();
        }

       /* adds items to the combobox and sets the index to 0. */
        private void handleComboBox()
        {
            comboBox1.Items.Add(GameConfig.EASY);
            comboBox1.Items.Add(GameConfig.MEDIUM);
            comboBox1.Items.Add(GameConfig.HARD);
            comboBox1.SelectedIndex = GameConfig.ZERO;
        }

        /* draws two strings on the canvas when the form loads. */
        private void StartingWindow_Load(object sender, EventArgs e)
        {
            Font _font = new Font(GameConfig.FONT, GameConfig.WELCOME_FONTSIZE, FontStyle.Italic);
            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                g.DrawString(GameConfig.WELCOME, _font, Brushes.White, GameConfig.WELCOME_X, GameConfig.WELCOME_Y);
            }

            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                g.DrawString(GameConfig.DIFFICULTY, _font, Brushes.White, GameConfig.DIFFICULTY_X, GameConfig.DIFFICULTY_Y); 
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        /* when the button is clicked this form is closed and the game window is opened. */
        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            GameWindow frm = new GameWindow(comboBox1.SelectedIndex);
            frm.Show();
        }

        /* closes the application when Escape is pressed*/
        private void StartingWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.ExitThread();
                Environment.Exit(GameConfig.ZERO);
            }
        }
    }
}
