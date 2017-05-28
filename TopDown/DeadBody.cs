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
        }
    }
}
