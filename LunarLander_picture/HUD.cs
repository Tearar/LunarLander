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
        int numberOfRectangles;

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
          //  Rectangle[] fuelArray = new Rectangle[10];
            Pen pen = new Pen(Color.Black, 3);
            SolidBrush brush;

            for (int i = 0; i < numberOfRectangles; i++)
            {
                Rectangle fuel = new Rectangle(725, 25+i*30, 50, 25 );
                if (i <= 3)
                {
                    brush = new SolidBrush(Color.DarkRed);
                }
                else if(i >= 4 && i <= 5)
                {
                    brush = new SolidBrush(Color.DarkOrange);
                }
                else
                {
                    brush = new SolidBrush(Color.DarkGreen);
                }
                gfx.DrawRectangle(pen, fuel);
                gfx.FillRectangle(brush, fuel);

            }

            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            Font _font = new Font("Stencil", 15, FontStyle.Italic);
            TextRenderer.DrawText(gfx, "Fuel", _font, new Rectangle(720, 0, 200, 200), SystemColors.ControlLight, flags);
        }

        private void displaySpeed(Graphics gfx)
        {
            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            Font _font = new Font("Stencil", 15, FontStyle.Italic);
            TextRenderer.DrawText(gfx, "Speed: " + Math.Abs((100*_lander.speed)).ToString() + " KM/H", _font, new Rectangle(0, 0,200, 200), SystemColors.ControlLight, flags);
        }

        public void handleFuel(int fuel)
        {
            

            if(fuel <= 100 && fuel > 90)
            {
                numberOfRectangles = 10;
            }
            else if(fuel <= 90 && fuel > 80)
            {
                numberOfRectangles = 9;
            }
            else if(fuel <= 80 && fuel > 70)
            {
                numberOfRectangles = 8;
            }
            else if(fuel <= 70 && fuel > 60)
            {
                numberOfRectangles = 7;
            }
            else if(fuel <= 60 && fuel > 50)
            {
                numberOfRectangles = 6;
            }
            else if(fuel <= 50 && fuel > 40)
            {
                numberOfRectangles = 5;
            }
            else if(fuel <= 40 && fuel > 30)
            {
                numberOfRectangles = 4;
            }
            else if(fuel <= 30 && fuel > 20)
            {
                numberOfRectangles = 3;
            }
            else if(fuel <= 20 && fuel > 10)
            {
                numberOfRectangles = 2;
            }
            else if(fuel <= 10 && fuel > 0)
            {
                numberOfRectangles = 1;
            }
            else
            {
                numberOfRectangles = 0;
            }
        }

     
    }
}
