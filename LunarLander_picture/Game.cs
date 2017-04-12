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
        HUD _hud;
        int difficulty;
        int landerAbsSpeed;
        
        

        public Game(Graphics g, int difficulty)
        {
            this.g = g;
            this.difficulty = difficulty;
            handleDifficulty();
            _background = new Background();
            _planet = new Planet();
            _satellite = new Satellite();
            _lander = new Lander();
            _hud = new HUD(_lander);
            allObjects.Add(_background);
            allObjects.Add(_planet);
            //allObjects.Add(_lander);
            allObjects.Add(_satellite);
            allObjects.Add(_lander);
            allObjects.Add(_hud);

        }

        private void handleDifficulty()
        {
            switch(difficulty)
            {
                case 0:
                    landerAbsSpeed = 5;
                    break;
                case 1:
                    landerAbsSpeed = 3;
                    break;
                case 2:
                    landerAbsSpeed = 1;
                    break;
                default:
                    break;
            }
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

       public int checkForGameState()
        {
           if(_lander.Y >= (_planet.Y + 300) && _lander.speed < landerAbsSpeed)
            {
                return (int)GameState.Won;
            }
           else if(_lander.Y >= (_planet.Y + 300) && _lander.speed >= landerAbsSpeed)
            {
                return (int)GameState.CollidedWithPlanet;
            }
           else if(((_lander.Y >= _satellite.Y) && (_lander.Y <= _satellite.Y +60)) && (_lander.X >= _satellite.X) && (_lander.X <= _satellite.X+120))
            {
                return (int)GameState.CollidedWithSatellite;
            }
           else
            {
                return (int)GameState.Running;
            }
        }

     

        public void handleHUD(int fuel)
        {
            _hud.handleFuel(fuel);
        }
    }
}
