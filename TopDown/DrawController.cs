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

            foreach(Actor actor in Actors.Drawable)
            {
                spriteBatch.Draw(actor.texture, actor.position, color: actor.color, scale: actor.scale);
            }
            foreach (Actor actor in Actors.Bullets)
            {
                spriteBatch.Draw(actor.texture, actor.position, color: actor.color, scale: actor.scale);
            }
            foreach (Actor actor in Actors.Enemies)
            {
                spriteBatch.Draw(actor.texture, actor.position, color: actor.color, scale: actor.scale);
            }
            spriteBatch.End();
        }
    }
}
