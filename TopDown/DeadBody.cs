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
        public DeadBody(Entity parent) : base(GameProperties.DefaultTexture, Vector2.Zero, Vector2.One, Color.White)
        {
            texture = parent.texture;
            position = parent.position;
            scale = parent.scale;
            color = parent.color;

            AdjustColor();
        }

        private void AdjustColor()
        {
            int red = (int)Math.Sqrt(color.R)*2;
            int green = (int)Math.Sqrt(color.G)*2;
            int blue = (int)Math.Sqrt(color.B)*2;

            Color newColor = new Color(red, green, blue);
            color = newColor;
            colorFade = color.ToVector3() * 255;
        }

        public void Fade(GameTime gameTime)
        {
            var amount = (255 / 30) * gameTime.ElapsedGameTime.TotalSeconds;

            if (color.R <= amount && color.G <= amount && color.B <= amount)
            {
                ShouldBeRemoved = true;
            }

            if (color.R > amount)
            {
                colorFade.X -= (float)amount;
                color.R = (byte)colorFade.X;
            }

            if (color.G > amount)
            {
                colorFade.Y -= (float)amount;
                color.G = (byte)colorFade.Y;
            }

            if (color.B > amount)
            {
                colorFade.Z -= (float)amount;
                color.B = (byte)colorFade.Z;
            }
        }
    }
}
