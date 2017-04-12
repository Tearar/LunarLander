using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;


namespace LunarLander_picture
{
    public partial class GameWindow : Form
    {
        /* initialize class variables*/
        Game _game;
        Graphics gfx;
        SoundPlayer engines = new SoundPlayer(Properties.Resources.engines);
        int difficulty;
        int landerState = (int)LanderState.Off;
        int gameState = (int)GameState.Running;
        int fuel = GameConfig.STARTING_FUEL;

        /* public constructor */
        public GameWindow(int difficulty)
        {
            InitializeComponent(); 
            this.difficulty = difficulty;
            KeyPreview = true;
            DoubleBuffered = true;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gfx = Graphics.FromImage(pictureBox1.Image);
            _game = new Game(gfx, difficulty);
            handleTimer();         
        }

        /* sets the timer interval and starts it. */
        private void handleTimer()
        {
            timer1.Interval = GameConfig.TIMER_TICK;
            timer1.Start();
        }

        void pictureBox1_KeyPress(object sender, KeyPressEventArgs e){ }

        /* handles the game in a tick event. Actions depend on the gameState variable. */
        private void timer1_Tick(object sender, EventArgs e)
        {
           switch(gameState)
            {
                case (int)GameState.Running:
                    handleGameObjects();
                    break;

                case (int)GameState.Won:
                    setGameWonBackground();
                    break;

                case (int)GameState.CollidedWithPlanet:
                    setGameLostBackground();
                    break;

                case (int)GameState.CollidedWithSatellite:
                    setExplosionBackground();
                    drawLabels();
                    break;

                default:
                    break;
            }
            Refresh();
        }

        /* draws game instructions */
        private void drawLabels()
        {
            Font _font = new Font(GameConfig.FONT, GameConfig.WELCOME_FONTSIZE, FontStyle.Italic);
            Font _font1 = new Font(GameConfig.FONT, GameConfig.RESTART_FONTSIZE, FontStyle.Italic);

            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                g.DrawString(GameConfig.GAME_OVER, _font, Brushes.Black, GameConfig.GAME_OVER_X, GameConfig.GAME_OVER_Y);
            }

            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                g.DrawString(GameConfig.RESTART, _font1, Brushes.Black, GameConfig.RESTART_X, GameConfig.RESTART_Y);
            }
        }

        /* sets a background to the picturebox*/
        private void setExplosionBackground()
        {
            pictureBox1.Image = Properties.Resources.explosion_resized;
        }

        /* sets a background to the picturebox*/
        private void setGameLostBackground()
        {
            pictureBox1.Image = Properties.Resources.game_lost;
        }

        /* sets a background to the picturebox*/
        private void setGameWonBackground()
        {
            pictureBox1.Image = Properties.Resources.game_won;
        }

        /* moves the non-player objects, handles HUD, reacts to player inputs, checks constantly for the game state and draws all objects to the canvas. */
        private void handleGameObjects()
        {
            _game.Move();
            _game.MoveLander(landerState);
            _game.handleHUD(fuel);
             gameState = _game.checkForGameState();
            _game.Draw(Graphics.FromImage(pictureBox1.Image));
        }

        /* handles the keyboard inputs*/
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {              
                if (fuel > GameConfig.ZERO && gameState == (int)GameState.Running)
                {
                    landerState = (int)LanderState.Up;
                    reactToInput();    
                }
            }

            if(e.KeyCode == Keys.Escape)
            {
                Application.ExitThread();
                Environment.Exit(GameConfig.ZERO);
            }

            if(e.KeyCode ==  Keys.Enter && gameState != (int)GameState.Running )
            {
                restartGame();
            }

            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                if (fuel != GameConfig.ZERO && gameState == (int)GameState.Running)
                {
                    landerState = (int)LanderState.Down;
                    reactToInput();
                }
            } 
        }

        /* reduces the fuel and plays the engine sound. */
        private void reactToInput()
        {
            fuel--;
            engines.PlayLooping();
        }

        /* restarts the whole application. */
        private void restartGame()
        {
            Application.ExitThread();
            Application.Restart();
        }

        /*handles actions when keys are released. */
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up || e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                landerState = (int)LanderState.Off;
                engines.Stop();
            }       
        }

        private void Form1Load(object sender, EventArgs e) { }
    }
}
