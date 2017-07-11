using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{   //With use of this class it is possible to create bullets of various sizes, velocitys and looks
    class Bullet : Entity
    {
        public static Vector2 Scale = new Vector2(5, 5);
        Vector2 targetPosition;
        Vector2 velocity;
        double fadingTime = 30;
        Vector3 colorFade;

        public Bullet(Texture2D texture, Vector2 position, Vector2 scale, Color color, Vector2 targetPosition, float speed, float spread = 100, double _fadingTime = 1) : base(texture, position, scale, color)
        {
            //if scale is set to zero then default value is applied
            if (scale == Vector2.Zero)
            {
                this.scale = Scale;
            }

            fadingTime = _fadingTime;
            this.speed = speed;
            this.targetPosition = targetPosition;
            this.velocity = GetVelocity(targetPosition);

            AdjustTarget(spread);
            UpdateCollisionSize();
        }

        //returns actual velocity of the bullet after GetVelocity function sets it
        public Vector2 GetSpeed()
        {
            return velocity;
        }

        //return position which was the first destination of the bullet
        public Vector2 GetTargetPosition()
        {
            return targetPosition;
        }

        //moves the bullet by a proper amount calculated in GetVelocity
        public void Move(GameTime gameTime)
        {
            position.X += velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            position.Y += velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

            UpdateCollisionPosition();
        }

        //Calculates X and Y velocity based on location of the target position
        private Vector2 GetVelocity(Vector2 targetLocation)
        {
            Vector2 velocity = Vector2.Zero;
            Vector2 deltaLocation = GetPositionDelta(targetLocation);

            int xMultiplayer = GetMultiplayer(ref deltaLocation.X);
            int yMultiplayer = GetMultiplayer(ref deltaLocation.Y);

            Vector2 lengthVector = GetVectorLength(deltaLocation);

            velocity.X += lengthVector.X * xMultiplayer;
            velocity.Y += lengthVector.Y * yMultiplayer;

            return velocity;
        }

        private void AdjustTarget(float spread)
        {
            var maxSpeed = Math.Sqrt(Math.Pow(velocity.X, 2) + Math.Pow(velocity.Y, 2));

            var variety = rnd.Next(-(int)spread, (int)spread);
            velocity.X += (float)variety;

            variety = rnd.Next(-(int)spread, (int)spread);
            velocity.Y += (float)variety;
        }

        public void Fade(GameTime gameTime)
        {
            var amount = (255 / fadingTime) * gameTime.ElapsedGameTime.TotalSeconds;

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

        //returns true if bullet is outside of the viewport or is marked as removeable by ShouldBeRemoved variable. For more info go to Actor
        public new Boolean CanBeRemoved()
        {
            var viewport = GameProperties.Viewport;

            return (position.X > viewport.Width ||
                    position.X + texture.Width * scale.X < viewport.X ||
                    position.Y > viewport.Height ||
                    position.Y + texture.Height * scale.Y < viewport.Y) || ShouldBeRemoved;
        }
    }
}
