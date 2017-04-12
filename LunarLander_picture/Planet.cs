using System.Drawing;

namespace LunarLander_picture
{
    class Planet : GameObject
    {
        /*initialize class variables */
        int x = 200;
        int y = 200;

        /* public constructor */ 
        public Planet() { }
 
        public override void Move(Graphics gfx)
        {
            base.Move(gfx);
        }

        /* draws the planet */
        public override void Draw(Graphics gfx)
        {
            Bitmap _bmp = new Bitmap(Properties.Resources.planet, x, y);
            gfx.DrawImage(_bmp, GameConfig.PLANET_X, GameConfig.PLANET_Y);
        }

        public int X
        {
            get { return x; }
        }
        
        public int Y
        {
            get { return y; }
        }
    }
}
