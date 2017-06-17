using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown.Buttons
{
    class Exit : Button
    {
        private static String name = "Exit";
        public Exit(Vector2 position) : base (position, name)
        {

        }

        //Callse ExitGame
        public override void TakeAction()
        {
            ExitGame();
        }

        //Closes the game
        private void ExitGame()
        {
            Program.game.Exit();
        }
    }
}
