using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{
    class Particle : Entity
    {
        double fadingTime = 30;
        Vector3 colorFade;
        Vector2 velocity = Vector2.Zero;
        Vector2 conVelocity = Vector2.Zero;
        Vector2 targetPosition;
        static Vector2 defaultPosition = Vector2.Zero;

        public Particle(Texture2D texture, Vector2 scale, Color color, Bullet bullet, double fadingTime) : base(texture, defaultPosition, scale, color)
        {
            this.fadingTime = fadingTime;
            position = bullet.position;
            velocity = bullet.GetSpeed();
            targetPosition = bullet.GetTargetPosition();
            conVelocity = new Vector2(rnd.Next(10, 30), rnd.Next(10, 30));

            AdjustColor();
            AdjustTarget();
        }

        //Changes colors' values, if object is not visible it is set as removable
        public void Fade(GameTime gameTime)
        {
            var amount = (255/ fadingTime) *gameTime.ElapsedGameTime.TotalSeconds;

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

        //moves the bullet by a proper amount got from the adjustment of the bullet speed
        public void Move(GameTime gameTime)
        {
            position.X += velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            position.Y += velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

            AdjustSpeed(gameTime);
        }

        //Varies velocity for splatter effect
        private void AdjustTarget()
        {
            var maxSpeed = Math.Sqrt(Math.Pow(velocity.X, 2) + Math.Pow(velocity.Y, 2));

            var variety = rnd.Next((int)maxSpeed / 2, (int)maxSpeed);
            variety -= (int)(maxSpeed*0.75);
            velocity.X += (float)variety;

            variety = rnd.Next((int)maxSpeed / 2, (int)maxSpeed);
            variety -= (int)(maxSpeed * 0.75);
            velocity.Y += (float)variety;
        }

        //Slows down the particle
        public void AdjustSpeed(GameTime gameTime)
        {
            velocity.X -= velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds * 15;
            velocity.Y -= velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds * 15;
        }

        //Sets the base color of the particle with some variation
        private void AdjustColor()
        {
            var divider = 0.5;
            var variety = (1 - (1/ divider) / 2) + (rnd.NextDouble() / divider);

            int red = (int)(color.R * variety);
            int green = (int)(color.G * variety);
            int blue = (int)(color.B * variety);

            Color newColor = new Color(red, green, blue);
            color = newColor;
            colorFade = color.ToVector3()*255;
        }
    }
}
