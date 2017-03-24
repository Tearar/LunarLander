using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarLander_picture
{
    class Lander : GameObject
    {
        int x = 325;
        int y = 100;
        public Lander()
        {

        }

        public override void Draw(Graphics gfx)
        {
            Bitmap _bmp = new Bitmap(Properties.Resources.philae_engine_off, 50, 50);
            gfx.DrawImage(_bmp, x, y);
           
        }

        public override void Move(Graphics gfx)
        {

             y += 1;
           
        }

        public void up(Graphics gfx)
        {
            y = y - 1;
        }
    }
}
