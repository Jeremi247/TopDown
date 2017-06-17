using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{   //Base class for every moving entity
    class Entity : Actor
    {
        protected float speed;
        public float baseSpeed;
        public float speedMultiplayer = 1;

        public Entity(Texture2D texture, Vector2 position, Vector2 scale, Color color) : base (texture, position, scale, color)
        {
        }

        //Moves in the given direction. Speed is caluclated on base of 
        public void MoveInDirection(GameTime gameTime, Vector2 targetLocation)
        {
            CorrectSpeed();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 deltaLocation = GetPositionDelta(targetLocation);

            int xMultiplayer = GetMultiplayer(ref deltaLocation.X);
            int yMultiplayer = GetMultiplayer(ref deltaLocation.Y);

            Vector2 lengthVector = GetVectorLength(deltaLocation);

            this.position.X += lengthVector.X * xMultiplayer * deltaTime;
            this.position.Y += lengthVector.Y * yMultiplayer * deltaTime;

            UpdateCollisionPosition();
        }

        //if delta is negative it is changed to positive number and multiplatyer for it's plane is set to negative
        protected int GetMultiplayer(ref float delta)
        {
            int multiplayer = 1;

            if(delta < 0)
            {
                multiplayer = -1;
                delta = -delta;
            }
            return multiplayer;
        }

        //returns difference between this location and target location
        protected Vector2 GetPositionDelta(Vector2 targetLocation)
        {
            Vector2 deltaLocation;

            deltaLocation.Y = targetLocation.Y - this.position.Y;
            deltaLocation.X = targetLocation.X - this.position.X;

            return deltaLocation;
        }

        //Gets vector magnitude in X and Y plane and returns them. X and Y are calculated on base of Pythagoras triangle. Z^2 = X^2 + Y^2
        protected Vector2 GetVectorLength(Vector2 deltaPosition)
        {
            Vector2 returnVector = Vector2.Zero;

            if (deltaPosition.X != 0)
            {
                float vectorLengthMultiplayer = deltaPosition.Y / deltaPosition.X;
                returnVector.X = (float)(this.speed / Math.Sqrt(1 + Math.Pow(vectorLengthMultiplayer, 2)));
                returnVector.Y = returnVector.X * vectorLengthMultiplayer;
            }
            else if(deltaPosition.Y != 0)
            {
                returnVector.X = 0;
                returnVector.Y = speed;
            }

            return returnVector;
        }

        //Correctes vector direction
        protected void CorrectSpeed()
        {
            speed = baseSpeed * speedMultiplayer;
        }
    }
}
