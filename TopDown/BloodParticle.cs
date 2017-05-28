﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{
    class BloodParticle : Entity
    {
        double fadingSpeed = 20;
        Vector3 colorFade;
        Vector2 velocity = Vector2.Zero;
        Vector2 conVelocity = Vector2.Zero;
        Vector2 targetPosition;
        static Vector2 defaultPosition = Vector2.Zero;

        public BloodParticle(Texture2D texture, Vector2 scale, Color color, Bullet bullet) : base(texture, defaultPosition, scale, color)
        {
            position = bullet.position;
            velocity = bullet.GetSpeed();
            targetPosition = bullet.GetTargetPosition();
            conVelocity = new Vector2(rnd.Next(10, 30), rnd.Next(10, 30));

            AdjustColor();
            AdjustTarget();
        }

        public void Fade(GameTime gameTime)
        {
            var amount = (255/30)*gameTime.ElapsedGameTime.TotalSeconds;

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

        public void Move(GameTime gameTime)
        {
            position.X += velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            position.Y += velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

            AdjustSpeed();
        }

        private void AdjustTarget()
        {
            var maxSpeed = Math.Sqrt(Math.Pow(velocity.X, 2) + Math.Pow(velocity.Y, 2));

            var variety = rnd.Next((int)maxSpeed / 2, (int)maxSpeed);
            variety -= (int)maxSpeed/2;
            velocity.X += (float)variety;

            variety = rnd.Next((int)maxSpeed / 2, (int)maxSpeed);
            variety -= (int)maxSpeed / 2;
            velocity.Y += (float)variety;
        }

        public void AdjustSpeed()
        {
            velocity.X -= velocity.X/5;
            velocity.Y -= velocity.Y/5;
        }

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
