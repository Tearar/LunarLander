using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarLander_picture
{
    class Satellite : GameObject
    {
        Bitmap _bmp;
        double x = 300;
        double y = 100;
        double degrees = 0;
        public Satellite() {

           _bmp = new Bitmap(Properties.Resources.rosetta, 120, 60);
        }

        float angle = 0;
        float centerX = 300;
        float centerY = 410;


        public override void Draw(Graphics gfx)
        {
            
             
            gfx.DrawImage(_bmp, (float)x, (float)y);
            
        }

        public override void Move(Graphics gfx)
        {
            var save = gfx.Save();
            gfx.TranslateTransform(centerX, centerY);
            // gfx.RotateTransform(angle++);
            // gfx.TranslateTransform(centerX, centerY);
            // gfx.Restore(save);

            x = centerX + Math.Cos(degrees) * 300;
            y = centerY + Math.Sin(degrees) * 300;
            degrees = degrees +0.03;

        }
    }
}
