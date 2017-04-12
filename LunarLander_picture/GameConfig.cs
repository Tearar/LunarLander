using System;

namespace LunarLander_picture
{
    class GameConfig
    {
        /* used strings */
        public const String EASY = "Easy";
        public const String MEDIUM = "Medium";
        public const String HARD = "Hard";
        public const String FONT = "Stencil";
        public const String WELCOME = "Welcome to Lunar Lander !";
        public const String DIFFICULTY = "Choose the difficulty:";
        public const String GAME_OVER = "Game over !";
        public const String RESTART = "Press Enter to restart the game !";

        /* often used numbers */
        public const int ZERO = 0;
        public const int ONE = 1;
        public const int TWO = 2;
        public const int THREE = 3;
        public const int FOUR = 4;

        /* StartingWindow.cs constants*/
        public const int WELCOME_FONTSIZE = 30;
        public const int RESTART_FONTSIZE = 20;
        public const int WELCOME_X = 175;
        public const int WELCOME_Y = 50;
        public const int DIFFICULTY_X = 200;
        public const int DIFFICULTY_Y = 100;

        /* GamingWindow.cs constants */
        public const int STARTING_FUEL = 100;
        public const int TIMER_TICK = 20;
        public const int GAME_OVER_X = 275;
        public const int GAME_OVER_Y = 375;
        public const int RESTART_X = 150;
        public const int RESTART_Y = 450;
        public const int SPEED_EASY = 6;
        public const int SPEED_MEDIUM = 4;
        public const int SPEED_HARD = 2;

        /* Planet.cs constants */
        public const int PLANET_DISTANCE = 300;
        public const int PLANET_X = 300;
        public const int PLANET_Y = 500;

        /* Satellite.cs constants*/
        public const int SATELLITE_HEIGHT = 60;
        public const int SATELLITE_WIDTH = 120;
        public const int SATELLITE_R = 300;

        /* HUD.cs constants */
        public const String FUEL = "Fuel";
        public const String SPEED = "Speed: ";
        public const String SPEEDUNIT = " KM/H";
        public const int FUEL_X = 725;
        public const int FUELLABEL_X = 720;
        public const int FUELREC_WIDTH = 50;
        public const int FUELREC_HEIGHT = 25;
        public const int LABELREC = 200;
        public const int HUDFONTSIZE = 15;

        /* Lander.cs constants*/
        public const int LANDER_HEIGHT = 50;
        public const int LANDER_WIDTH = 50;
        public const double SPEEDCHANGE_SLOW = 0.2;
        public const double SPEEDCHANGE_FAST = 0.5;
        public const int MAXSPEED = 10;










    }
}
