using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{
    class DrawController
    {
        public static void Draw(SpriteBatch spriteBatch)
        {
            DrawActors(Actors.DeadBodies.ToList<Actor>(), spriteBatch);
            DrawActors(Actors.BloodParticles.ToList<Actor>(), spriteBatch);
            DrawActors(Actors.Abilities.ToList<Actor>(), spriteBatch);
            DrawActors(Actors.Bullets.ToList<Actor>(), spriteBatch);
            DrawActors(Actors.Drawable.ToList<Actor>(), spriteBatch);
            DrawActors(Actors.Enemies.ToList<Actor>(), spriteBatch);

            if (GameStateController.GetGameState() == GameStateController.States.Menu)
            {
                MenuController.DrawMenu(spriteBatch);
            }
            if(GameStateController.GetGameState() == GameStateController.States.Pause)
            {
                MenuController.DrawPause(spriteBatch);
            }

			DrawGUI(spriteBatch);
        }

        private static void DrawActors(List<Actor> list, SpriteBatch spriteBatch)
        {
			//TODO: Dont need this?
            foreach (Actor actor in list)
            {
                spriteBatch.Draw(actor.texture, actor.position, color: actor.color, scale: actor.scale);
            }
			
        }

        private static void DrawGUI(SpriteBatch spriteBatch)
        {
            ScoreController.DrawScore(spriteBatch);
            AbilitiesController.DrawTimer(spriteBatch);
        }
    }
}
