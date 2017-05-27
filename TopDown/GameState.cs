using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{
    class GameState
    {
        public static Boolean IsInProgress = false;
        public enum States { GameOver, Menu, Gameplay };
        private static States gameState = States.Gameplay;

        public static States GetGameState()
        {
            return gameState;
        }

        public static void SetGameState(States newState)
        {
            gameState = newState;
        }
    }
}
