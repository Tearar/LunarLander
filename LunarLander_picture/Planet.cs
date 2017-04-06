using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LunarLander_picture
{
    class Planet : GameObject
    {
        int x = 200;
        int y = 200;


        public Planet()
        {
            
        }

        public override void Move(Graphics gfx)
        {
            base.Move(gfx);
        }

        int angle = 0;
        public override void Draw(Graphics gfx)
        {
            Bitmap _bmp = new Bitmap(Properties.Resources.planet,x,y);
            //var save = gfx.Save();
           // gfx.RotateTransform(angle++);
            gfx.DrawImage(_bmp, 300,500);
           // gfx.Restore(save);
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
