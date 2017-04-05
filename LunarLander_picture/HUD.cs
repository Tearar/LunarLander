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
            displayFuel(gfx);
            
        }

        private void displayFuel(Graphics gfx)
        {
            Rectangle[] fuelArray = new Rectangle[10];
            Pen pen = new Pen(Color.Black, 3);

            for(int i = 0; i < 10; i++)
            {
                Rectangle fuel = new Rectangle(725, 25+i*30, 50, 25 );
                
                gfx.DrawRectangle(pen, fuel);
                SolidBrush blueBrush = new SolidBrush(Color.Green);
                gfx.FillRectangle(blueBrush, fuel);

            }

            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            Font _font = new Font("Stencil", 15, FontStyle.Italic);
            TextRenderer.DrawText(gfx, "Fuel", _font, new Rectangle(720, 0, 200, 200), SystemColors.ControlLight, flags);
        }

        private void displaySpeed(Graphics gfx)
        {
            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            Font _font = new Font("Stencil", 15, FontStyle.Italic);
            TextRenderer.DrawText(gfx, "Speed: " + Math.Abs((100*_lander.speed)) + " KM/H", _font, new Rectangle(0, 0,200, 200), SystemColors.ControlLight, flags);
        }
    }
}
