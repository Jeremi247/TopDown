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
            ClearActors();
            ClearData();
        }

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

        private void ClearData()
        {
            MonsterSpawner.Clear();
            AbilitiesController.Clear();
            ScoreController.Clear();
            GameState.IsInProgress = true;
            GameState.SetGameState(GameState.States.Gameplay);
        }
    }
}
