using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LunarLander_picture
{
     class Background : GameObject
    {

        public Background()
        {
            
        }

        public override void Draw(Graphics gfx)
        {
            Bitmap _bmp = new Bitmap(Properties.Resources.stars);
            //var save = gfx.Save();
            // gfx.RotateTransform(angle++);
            gfx.DrawImage(_bmp,0,0);
            // gfx.Restore(save);
        }
    }
}
