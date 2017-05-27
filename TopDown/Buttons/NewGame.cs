using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown.Buttons
{
    class NewGame : Button
    {
        private static String name = "New Game";

        public NewGame(Vector2 position) : base (position, name)
        {

        }

        public override void TakeAction()
        {
            StartNewGame();
        }

        private void StartNewGame()
        {

        }
    }
}
