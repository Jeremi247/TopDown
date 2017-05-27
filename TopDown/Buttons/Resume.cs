using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown.Buttons
{
    class Resume : Button
    {
        private static String name = "Resume";
        public Resume(Vector2 position) : base (position, name)
        {
            
        }

        public override void CheckState()
        {
            if (!GameState.IsInProgress)
            {
                isActive = false;
            }
            else
            {
                isActive = true;
            }
        }

        public override void TakeAction()
        {
            if (isActive)
            {
                ResumeGame();
            }
        }

        private void ResumeGame()
        {
            GameState.SetGameState(GameState.States.Gameplay);
        }
    }
}
