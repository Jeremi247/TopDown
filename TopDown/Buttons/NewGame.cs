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
            Actors.Bullets.Clear();
            Actors.Drawable.Clear();
            Actors.Enemies.Clear();
            Actors.Init();
        }

        private void ClearData()
        {
            MonsterSpawner.Clear();
            //InputController.Clear();
            ScoreController.score = 0;
            GameState.IsInProgress = true;
            GameState.SetGameState(GameState.States.Gameplay);
        }
    }
}
