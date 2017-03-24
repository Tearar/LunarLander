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
            Bitmap _bmp = new Bitmap(Properties.Resources.planet,200,200);
            //var save = gfx.Save();
           // gfx.RotateTransform(angle++);
            gfx.DrawImage(_bmp, 300,300);
           // gfx.Restore(save);
        }
    }
}
