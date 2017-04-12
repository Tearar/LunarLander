using System.Drawing;

namespace LunarLander_picture
{
    class Lander : GameObject
    {
        /* initialize class variables */
        int x = 370;
        double y = 0;
        double speed;
        Bitmap _bmp;

        /* public constructor */
        public Lander()
        {
             _bmp = new Bitmap(Properties.Resources.philae_engine_off, GameConfig.LANDER_WIDTH, GameConfig.LANDER_HEIGHT);
            speed = GameConfig.ZERO;
        }
        
        public override void Draw(Graphics gfx)
        {
            gfx.DrawImage(_bmp, x, (float)y);
        }

        public override void Move(Graphics gfx) { }

        public double Speed
        {
            get { return speed; }
        }
        public double Y
        {
            get { return y; } 
        }

        public double X
        {
            get { return x; }
        }

        /* moves lander according to landerState and changes its speed. */
        public void MoveLander(int landerState)
        {
            
            switch(landerState)
            {
                case (int)LanderState.Off:
                    _bmp = new Bitmap(Properties.Resources.philae_engine_off, GameConfig.LANDER_WIDTH, GameConfig.LANDER_HEIGHT);
                    if (speed <= GameConfig.MAXSPEED)
                    {
                        speed += GameConfig.SPEEDCHANGE_SLOW;
                    }
                    else
                    {
                        speed = GameConfig.MAXSPEED;
                    }
                    updateSpeed();
                    break;

                case (int)LanderState.Up:
                    _bmp = new Bitmap(Properties.Resources.philae_moving_up, GameConfig.LANDER_WIDTH, GameConfig.LANDER_HEIGHT);
                    if (speed >= -GameConfig.MAXSPEED)
                    {
                        speed -= GameConfig.SPEEDCHANGE_SLOW;
                    }
                    else
                    {
                        speed = -GameConfig.MAXSPEED;
                    }
                    updateSpeed();
                    break;

                case (int)LanderState.Down:
                    _bmp = new Bitmap(Properties.Resources.philae_moving_down, GameConfig.LANDER_WIDTH, GameConfig.LANDER_HEIGHT);
                    if (speed <= GameConfig.MAXSPEED)
                    {
                        speed += GameConfig.SPEEDCHANGE_FAST;
                    }
                    else
                    {
                        speed = GameConfig.MAXSPEED;
                    }
                    updateSpeed();
                    break;

                default:
                    break;
            }
        }

        /* updates lander position */
        private void updateSpeed()
        {
            y = y + speed;
        }
    }
}
