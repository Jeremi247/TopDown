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

        public override void TakeAction()
        {
            ExitGame();
        }

        private void ExitGame()
        {
			Coin.save();
            Program.game.Exit();
        }
    }
}
