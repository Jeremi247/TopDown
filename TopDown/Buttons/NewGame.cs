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

        //Starts new game
        public override void TakeAction()
        {
            StartNewGame();
        }

        //Calls clearing functions
        private void StartNewGame()
        {
            ClearActors();
            ClearData();
        }

        //Clear Actors container and initializates it again
        private void ClearActors()
        {
            Actors.Abilities.Clear();
            Actors.Bullets.Clear();
            Actors.Drawable.Clear();
            Actors.Enemies.Clear();
            Actors.BloodParticles.Clear();
            Actors.DeadBodies.Clear();
            Actors.Init();
        }

        //Clears statuses and variables of various classes
        private void ClearData()
        {
            MonsterSpawner.Clear();
            WeaponController.Clear();
            ScoreController.Clear();
            GameStateController.IsInProgress = true;
            GameStateController.SetGameState(GameStateController.States.Gameplay);
        }
    }
}
