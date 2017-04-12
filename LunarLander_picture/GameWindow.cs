using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;


namespace LunarLander_picture
{
    public partial class GameWindow : Form
    {
        //Background _background;
        
        Game _game;
        int difficulty;
        Graphics gfx;
        public bool test = true;
        bool run = true;
        int landerState = (int)LanderState.Off;
        int gameState = (int)GameState.Running;
        int fuel = 100;
        SoundPlayer engines = new SoundPlayer(Properties.Resources.engines);
   








        public GameWindow(int difficulty)
        {
            this.KeyPreview = true;
            this.difficulty = difficulty;
            InitializeComponent();
            DoubleBuffered = true;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gfx = Graphics.FromImage(pictureBox1.Image);
            _game = new Game(gfx, difficulty);
          
            timer1.Interval = 20;
            timer1.Start();   
        }

       

        void pictureBox1_KeyPress(object sender, KeyPressEventArgs e){ }

        private void timer1_Tick(object sender, EventArgs e)
        {
         
           switch(gameState)
            {
                case (int)GameState.Running:
                    _game.Move();
                    _game.MoveLander(landerState);
                    _game.handleHUD(fuel);
                   
                    gameState = _game.checkForGameState();
                    _game.Draw(Graphics.FromImage(pictureBox1.Image));
                    break;
                case (int)GameState.Won:
                    pictureBox1.Image = Properties.Resources.game_won;
                    break;
                case (int)GameState.CollidedWithPlanet:
                    pictureBox1.Image = Properties.Resources.game_lost;
                    break;
                case (int)GameState.CollidedWithSatellite:
                    pictureBox1.Image = Properties.Resources.explosion_resized;
                    Font _font = new Font("Stencil", 30, FontStyle.Italic);
                    Font _font1 = new Font("Stencil", 20, FontStyle.Italic);

                    using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                    {
                        g.DrawString("Game Over !", _font, Brushes.Black, 275, 375); // requires font, brush etc
                    }

                    using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                    {
                        g.DrawString("Press Enter to restart the game !", _font1, Brushes.Black, 150, 450); // requires font, brush etc
                    }


                    break;
                default:
                    break;
            }
            
            this.Refresh();
        }

     

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
               
                if (fuel > 0 && gameState == (int)GameState.Running)
                {
                    landerState = (int)LanderState.Up;
                    fuel--;
                    engines.PlayLooping();
                }
            }

            if(e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }

            if(e.KeyCode ==  Keys.Enter && gameState != (int)GameState.Running )
            {

                restartGame();
            }

            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                if (fuel != 0 && gameState == (int)GameState.Running)
                {
                    landerState = (int)LanderState.Down;
                    fuel--;
                    engines.PlayLooping();
                }

            }

        

           

        }

        private void restartGame()
        {
                Application.Exit();
                Application.Restart();
            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up || e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                landerState = (int)LanderState.Off;
                engines.Stop();
            }
                
        }

        private void Form1Load(object sender, EventArgs e)
        {
          
        }

     
    }

   

}
