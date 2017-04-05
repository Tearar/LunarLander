using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarLander_picture
{
    class Game
    {
        List<GameObject> allObjects = new List<GameObject> ();
        Graphics g;
        Planet _planet;
        Background _background;
        Satellite _satellite;
        Lander _lander;
        
        

        public Game(Graphics g)
        {
            this.g = g;
            _background = new Background();
            _planet = new Planet();
            _satellite = new Satellite();
            _lander = new Lander();
            allObjects.Add(_background);
            allObjects.Add(_planet);
            //allObjects.Add(_lander);
            allObjects.Add(_satellite);
            allObjects.Add(_lander);

        }

        public void Move()
        {
            foreach(GameObject obj in allObjects)
            {
                obj.Move(g);
            }
        }

    

        public void Draw(Graphics gfx)
        {
            
            foreach(GameObject obj in allObjects)
            {
                obj.Draw(gfx);
            }
        }


        /*public void handleLanderUp(Graphics gfx)
        {
            _lander.up(gfx);
        }*/

      

      public void MoveLander(int landerState)
        {
            _lander.MoveLander(landerState);
        }
    }
}
