using System;
using System.Drawing;
using System.Windows.Forms;

namespace LunarLander_picture
{
    class HUD : GameObject
    {
        /* declare class variables */
        Lander _lander;
        int numberOfRectangles;
        SolidBrush brush;
        Pen pen = new Pen(Color.Black, GameConfig.THREE);

        /* public constructor */
        public HUD(Lander _lander)
        {
            this._lander = _lander; 
        }

        /* draws the speed label and displays the current fuel level */
        public override void Draw(Graphics gfx)
        {
            displaySpeed(gfx);
            displayFuel(gfx); 
        }

        /* draws rectangles according to the current fuel state. */
        private void displayFuel(Graphics gfx)
        {
            for (int i = 0; i < numberOfRectangles; i++)
            {
                Rectangle fuel = new Rectangle(GameConfig.FUEL_X, GameConfig.FUELREC_HEIGHT + i*30, GameConfig.FUELREC_WIDTH, GameConfig.FUELREC_HEIGHT);
                if (i < GameConfig.THREE)
                {
                    brush = new SolidBrush(Color.DarkRed);
                }
                else if(i >= GameConfig.THREE && i <= GameConfig.FOUR)
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
            drawFuelLabel(gfx);
        }

        /* draws fuel label. */
        private void drawFuelLabel(Graphics gfx)
        {
            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            Font _font = new Font(GameConfig.FONT, GameConfig.HUDFONTSIZE, FontStyle.Italic);
            TextRenderer.DrawText(gfx, GameConfig.FUEL, _font, new Rectangle(GameConfig.FUELLABEL_X, GameConfig.ZERO, GameConfig.LABELREC, GameConfig.LABELREC), SystemColors.ControlLight, flags);
        }

        /* draws the speed label */
        private void displaySpeed(Graphics gfx)
        {
            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            Font _font = new Font(GameConfig.FONT, GameConfig.HUDFONTSIZE, FontStyle.Italic);
            TextRenderer.DrawText(gfx, GameConfig.SPEED + Math.Abs((100 * _lander.Speed)).ToString() + GameConfig.SPEEDUNIT, _font, new Rectangle(GameConfig.ZERO, GameConfig.ZERO, GameConfig.LABELREC, GameConfig.LABELREC), SystemColors.ControlLight, flags);
        }

        /*handles the fuel variable. there is way to much fuel in the release version to test the game. */
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
                numberOfRectangles = GameConfig.ZERO;
            }
        }
    }
}
