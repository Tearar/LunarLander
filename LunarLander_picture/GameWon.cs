using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarLander_picture
{
    class GameWon : GameObject
    {

        public GameWon()
        {

        }

        public override void Draw(Graphics gfx)
        {
            Bitmap _bmp = new Bitmap(Properties.Resources.game_won);
            gfx.DrawImage(_bmp, 0, 0);

        }
    }
}
