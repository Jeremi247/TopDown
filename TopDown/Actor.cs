using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TopDown
{   //Base class for almost every other visibly existing object in the game
    class Actor
    {
        protected Random rnd = GameProperties.Random;
        public Vector2 position;
        public Vector2 scale;
        public Vector2 size;
        public Rectangle collisionBox;
        public Texture2D texture;
        public Color color;
        protected Boolean ShouldBeRemoved = false;

        public Actor(Texture2D texture, Vector2 position, Vector2 scale, Color color)
        {
            this.texture = texture;
            this.position = position;
            this.scale = scale;
            this.color = color;

            this.size.X = texture.Width * scale.X;
            this.size.Y = texture.Height * scale.Y;

            SetCollisionBox();
        }

        //Marks object as removable. Child classes have often more criteria when to mark them.
        public void Remove()
        {
            ShouldBeRemoved = true;
        }

        //Allows to check if object can be removed.
        public Boolean CanBeRemoved()
        {
            return ShouldBeRemoved;
        }

        //Creates collision box after size, scale and texture are loaded;
        protected void SetCollisionBox()
        {
            UpdateCollisionPosition();
            UpdateCollisionSize();
        }

        //Updates collision position. Needs to be called every time there is movement of the actor
        protected void UpdateCollisionPosition()
        {
            collisionBox.Location = position.ToPoint();
        }

        //Updates collision size. Needs to be called every time there is change in size, scale or texture of the actor
        protected void UpdateCollisionSize()
        {
            collisionBox.Width = (int)(texture.Width * scale.X);
            collisionBox.Height = (int)(texture.Height * scale.Y);
        }
    }
}
