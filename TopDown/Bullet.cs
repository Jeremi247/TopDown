using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{
    class Bullet : Entity
    {
        public static Vector2 Scale = new Vector2(5, 5);
        Vector2 targetPosition;
        Vector2 velocity;

        public Bullet(Texture2D texture, Vector2 position, Vector2 scale, Color color, Vector2 targetPosition, float speed) : base(texture, position, scale, color)
        {
            if (scale == Vector2.Zero)
            {
                this.scale = Scale;
            }

            this.speed = speed;
            this.targetPosition = targetPosition;
            this.velocity = GetVelocity(targetPosition);

            UpdateCollisionSize();
        }

        public Vector2 GetSpeed()
        {
            return velocity;
        }

        public Vector2 GetTargetPosition()
        {
            return targetPosition;
        }

        public void Move(GameTime gameTime)
        {
            position.X += velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            position.Y += velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

            UpdateCollisionPosition();
        }

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
