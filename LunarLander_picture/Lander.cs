using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LunarLander_picture
{
    class Lander : GameObject
    {
        int x = 370;
        double y = 0;
        public double speed;
        private const double maxSpeed = 10;
       
        Bitmap _bmp;
     
       
      
        
        

        public Lander()
        {
             _bmp = new Bitmap(Properties.Resources.philae_engine_off, 50, 50);
            speed = 0;
        }

 

        public override void Draw(Graphics gfx)
        {
           
            gfx.DrawImage(_bmp, x, (float)y);
           
        }

        public override void Move(Graphics gfx)
        {
        
        }

        public double Y
        {
            get { return y; }
             
        }

        public double X
        {
            get { return x; }

        }

        public void MoveLander(int landerState)
        {
            
            switch(landerState)
            {
                case (int)LanderState.Off:
                    _bmp = new Bitmap(Properties.Resources.philae_engine_off, 50, 50);
                    if (speed <= maxSpeed)
                    {
                        speed += 0.2;
                    }
                    else
                    {
                        speed = maxSpeed;
                    }
                    y = y + speed;
                    break;

                case (int)LanderState.Up:
                    _bmp = new Bitmap(Properties.Resources.philae_moving_up, 50, 50);
                    if (speed >= -maxSpeed)
                    {
                        speed -= 0.2;
                    }
                    else
                    {
                        speed = -maxSpeed;
                    }
                    y = y + speed;
                    break;

                case (int)LanderState.Down:
                    _bmp = new Bitmap(Properties.Resources.philae_moving_down, 50, 50);
                    if (speed <= maxSpeed)
                    {
                        speed = speed + 0.5;
                    }
                    else
                    {
                        speed = maxSpeed;
                    }
                    
                    y = y + speed;
                    break;

                

                default:
                    break;

            }
        }

        

    
        
      
    }
}
