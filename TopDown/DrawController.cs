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
            spriteBatch.Begin();

            DrawActors(Actors.BloodParticles.ToList<Actor>(), spriteBatch);
            DrawActors(Actors.Drawable.ToList<Actor>(), spriteBatch);
            DrawActors(Actors.Bullets.ToList<Actor>(), spriteBatch);
            DrawActors(Actors.Enemies.ToList<Actor>(), spriteBatch);

            if (GameState.GetGameState() == GameState.States.Menu)
            {
                MenuController.DrawMenu(spriteBatch);
            }

            DrawGUI(spriteBatch);

            spriteBatch.End();
        }

        private static void DrawActors(List<Actor> list, SpriteBatch spriteBatch)
        {
            foreach (Actor actor in list)
            {
                spriteBatch.Draw(actor.texture, actor.position, color: actor.color, scale: actor.scale);
            }
        }

        private static void DrawGUI(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(ScoreController.font, ScoreController.GetText(), ScoreController.position, ScoreController.color);
        }
    }
}
