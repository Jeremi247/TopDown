using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{   //Base class for all abilities
    abstract class Ability : Actor
    {
        static Vector2 defaultPosition = Vector2.Zero;
        static Vector2 defaultScale = new Vector2(18, 18);
        private Vector2 maxScale = new Vector2(21, 21);
        private Vector2 minScale = new Vector2(17, 17);

        private float pulseSpeed = 20;
        private Boolean shouldGrow = true;

        public Ability(BasicEnemy enemy, Color color) : base (GameProperties.DefaultTexture, defaultPosition, defaultScale, color)
        {
            SetPosition(enemy);
        }

        //Sets position to the place where enemy, from which it dropped, died
        private void SetPosition(BasicEnemy enemy)
        {
            position.X = enemy.position.X + (enemy.scale.X * enemy.texture.Width) / 2 - (defaultScale.X * texture.Width) / 2;
            position.Y = enemy.position.Y + (enemy.scale.Y * enemy.texture.Height) / 2 - (defaultScale.Y * texture.Height) / 2;
        }

        //All child abilities must have this function saying what should happen after collecting them
        public abstract void ApplyAbility();

        //Creates pulsating effect on the ability laying on the ground. Called by UpdateController
        public void Pulse(GameTime gameTime)
        {
            if (shouldGrow)
            {
                var changeValue = pulseSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                scale.X += changeValue;
                scale.Y += changeValue;

                position.X -= changeValue/2;
                position.Y -= changeValue/2;
            }
            else
            {
                var changeValue = pulseSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                scale.X -= changeValue;
                scale.Y -= changeValue;

                position.X += changeValue/2;
                position.Y += changeValue/2;
            }

            if (scale.X >= maxScale.X)
            {
                scale.X = maxScale.X;
                scale.Y = maxScale.Y;
                shouldGrow = false;
            }
            else if (scale.X <= minScale.Y)
            {
                scale.X = minScale.X;
                scale.Y = minScale.Y;
                shouldGrow = true;
            }

            UpdateCollisionSize();
            UpdateCollisionPosition();
        }
    }
}
