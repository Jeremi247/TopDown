using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{   //Controlls the state of the game
    class GameStateController
    {
        public static Boolean IsInProgress = false;
        public enum States { GameOver, Menu, Gameplay, Pause}; //All posible game states are stored here
        private static States gameState = States.Menu;

        //Returns the actual game state
        public static States GetGameState()
        {
            return gameState;
        }

        //Sets state to the provided one
        public static void SetGameState(States newState)
        {
            gameState = newState;
        }
    }
}
