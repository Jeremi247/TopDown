using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{
    class DeadBody : Actor
    {
        Vector3 colorFade;
        //Sets dead body properties based on the enemy from which it is spawned
        public DeadBody(Entity parent) : base(GameProperties.DefaultTexture, Vector2.Zero, Vector2.One, Color.White)
        {
            texture = parent.texture;
            position = parent.position;
            scale = parent.scale;
            color = parent.color;

            AdjustColor();
        }

        //Adjust color based on the time of existence of this object
        private void AdjustColor()
        {
            int red = (int)Math.Sqrt(color.R)*2;
            int green = (int)Math.Sqrt(color.G)*2;
            int blue = (int)Math.Sqrt(color.B)*2;

            Color newColor = new Color(red, green, blue);
            color = newColor;
            colorFade = color.ToVector3() * 255;
        }

        //Changes colors' values, if object is not visible it is set as removable
        public void Fade(GameTime gameTime)
        {
            var amountToRemove = (255 / 30) * gameTime.ElapsedGameTime.TotalSeconds;

            if (color.R <= amountToRemove && color.G <= amountToRemove && color.B <= amountToRemove)
            {
                ShouldBeRemoved = true;
            }

            if (color.R > amountToRemove)
            {
                colorFade.X -= (float)amountToRemove;
                color.R = (byte)colorFade.X;
            }

            if (color.G > amountToRemove)
            {
                colorFade.Y -= (float)amountToRemove;
                color.G = (byte)colorFade.Y;
            }

            if (color.B > amountToRemove)
            {
                colorFade.Z -= (float)amountToRemove;
                color.B = (byte)colorFade.Z;
            }
        }
    }
}
