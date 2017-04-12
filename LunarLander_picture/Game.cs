using System;
using System.Collections.Generic;
using System.Drawing;

namespace LunarLander_picture
{
    class Game
    {
        /* declaring class variables */
        List<GameObject> allObjects = new List<GameObject> ();
        Graphics g;
        Planet _planet;
        Background _background;
        Satellite _satellite;
        Lander _lander;
        HUD _hud;
        int difficulty;
        int landerAbsSpeed;
 
        /* public constructor */
        public Game(Graphics g, int difficulty)
        {
            this.g = g;
            this.difficulty = difficulty;
            handleDifficulty();
            initializeGameObjects();
            addGameObjectsToList();
        }

        /*adds the game objects to the allObjects-list. */
        private void addGameObjectsToList()
        {
            allObjects.Add(_background);
            allObjects.Add(_planet);
            allObjects.Add(_satellite);
            allObjects.Add(_lander);
            allObjects.Add(_hud);
        }

        /*initializes all game objects. */
        private void initializeGameObjects()
        {
            _background = new Background();
            _planet = new Planet();
            _satellite = new Satellite();
            _lander = new Lander();
            _hud = new HUD(_lander);
        }

        /* determines difficulty of the current game. */
        private void handleDifficulty()
        {
            switch(difficulty)
            {
                case GameConfig.ZERO:
                    landerAbsSpeed = GameConfig.SPEED_EASY;
                    break;

                case GameConfig.ONE:
                    landerAbsSpeed = GameConfig.SPEED_MEDIUM;
                    break;

                case GameConfig.TWO:
                    landerAbsSpeed = GameConfig.SPEED_HARD;
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

        /* moves the lander(player) according to the landerState*/
      public void MoveLander(int landerState)
        {
            _lander.MoveLander(landerState);
        }
       
        /*checks for the current state of the game. 
          checks if the lander crashed onto the planet or collided with the satellite. 
          also checks if the lander landed safely and thus the game is won.
        */
       public int checkForGameState()
        {
           if(_lander.Y >= (_planet.Y + GameConfig.PLANET_DISTANCE) && _lander.Speed < landerAbsSpeed)
            {
                return (int)GameState.Won;
            }
           else if(_lander.Y >= (_planet.Y + GameConfig.PLANET_DISTANCE) && _lander.Speed >= landerAbsSpeed)
            {
                return (int)GameState.CollidedWithPlanet;
            }
           else if(((_lander.Y >= _satellite.Y) && (_lander.Y <= _satellite.Y + GameConfig.SATELLITE_HEIGHT)) && (_lander.X >= _satellite.X) && (_lander.X <= _satellite.X + GameConfig.SATELLITE_WIDTH))
            {
                return (int)GameState.CollidedWithSatellite;
            }
           else
            {
                return (int)GameState.Running;
            }
        }

        /* passes current fuel to the HUD class*/
        public void handleHUD(int fuel)
        {
            _hud.handleFuel(fuel);
        }
    }
}
