using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LunarLander_picture
{
    class HUD : GameObject
    {
        Lander _lander;

        public HUD(Lander _lander)
        {
            this._lander = _lander;
        }

        public override void Draw(Graphics gfx)
        {
            displaySpeed(gfx);
            
        }

        private void displaySpeed(Graphics gfx)
        {
            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            Font _font = new Font("Stencil", 15, FontStyle.Regular);
            TextRenderer.DrawText(gfx, "Speed: " + (10 * _lander.speed).ToString(), _font, new Rectangle(0, 0, 120, 100), SystemColors.ControlLight, flags);
        }
    }
}
