using System;
using System.Drawing;

namespace LunarLander_picture
{
    class Satellite : GameObject
    {
        /*initialize class variables */
        Bitmap _bmp;
        double x = 300;
        double y = 100;
        double degrees = 0;
        const double increment = 0.03;
        float centerX = 300;
        float centerY = 410;

        /* public constructor */
        public Satellite()
        {
           _bmp = new Bitmap(Properties.Resources.rosetta, GameConfig.SATELLITE_WIDTH, GameConfig.SATELLITE_HEIGHT);
        }

        /* draws the satellite */
        public override void Draw(Graphics gfx)
        {
            gfx.DrawImage(_bmp, (float)x, (float)y); 
        }

        /* moves the satellite around in a circle */
        public override void Move(Graphics gfx)
        {
            var save = gfx.Save();
            gfx.TranslateTransform(centerX, centerY);
            x = centerX + Math.Cos(degrees) * GameConfig.SATELLITE_R;
            y = centerY + Math.Sin(degrees) * GameConfig.SATELLITE_R;
            degrees = degrees + increment;
        }

        public double X
        {
            get { return x; }
        }

        public double Y
        {
            get { return y; }
        }
    }
}
