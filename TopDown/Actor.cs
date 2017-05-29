using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TopDown
{
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

            setCollisionBox();
        }

        public void Remove()
        {
            ShouldBeRemoved = true;
        }

        public Boolean CanBeRemoved()
        {
            return ShouldBeRemoved;
        }

        protected void setCollisionBox()
        {
            updateCollisionPosition();
            updateCollisionSize();
        }

        protected void updateCollisionPosition()
        {
            collisionBox.Location = position.ToPoint();
        }

        protected void updateCollisionSize()
        {
            collisionBox.Width = (int)(texture.Width * scale.X);
            collisionBox.Height = (int)(texture.Height * scale.Y);
        }
    }
}
