using System.Drawing;

namespace LunarLander_picture
{
    class Background : GameObject
    {
        /* public constructor*/
        public Background() { }

        /* draws the background image */
        public override void Draw(Graphics gfx)
        {
            Bitmap _bmp = new Bitmap(Properties.Resources.stars);
            gfx.DrawImage(_bmp, GameConfig.ZERO, GameConfig.ZERO);          
        }
    }
}
