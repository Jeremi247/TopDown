using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{
    class GameStateController
    {
        public static Boolean IsInProgress = false;
        public enum States { GameOver, Menu, Gameplay, Pause};
        private static States gameState = States.Menu;

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
