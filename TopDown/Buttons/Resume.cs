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

        //Checks if the game is in progress and if this button can be activated
        public override void SetsActiveStatus()
        {
            if (!GameStateController.IsInProgress)
            {
                isActive = false;
            }
            else
            {
                isActive = true;
            }
        }

        //Takes action. Is called after the button is clicked
        public override void TakeAction()
        {
            if (isActive)
            {
                ResumeGame();
            }
        }

        //Sets game state to Gameplay
        private void ResumeGame()
        {
            GameStateController.SetGameState(GameStateController.States.Gameplay);
        }
    }
}
