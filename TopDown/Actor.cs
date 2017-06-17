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
		public static Vector2 nposition;
		public Vector2 scale;
        public Vector2 size;
		public Rectangle collisionBox;
        public Texture2D texture;
        public Color color;
        protected Boolean ShouldBeRemoved = false;

        public Actor(Texture2D _texture, Vector2 _position, Vector2 _scale, Color _color)
        {
            texture = _texture;
            position = _position;
            scale = _scale;
            color = _color;
			nposition = position;

            size.X = texture.Width * scale.X;
            size.Y = texture.Height * scale.Y;

            SetCollisionBox();
        }

		public void Remove()
        {
            ShouldBeRemoved = true;
        }

        public Boolean CanBeRemoved()
        {
            return ShouldBeRemoved;
        }

        protected void SetCollisionBox()
        {
            UpdateCollision();
            UpdateCollisionSize();
		}

        protected void UpdateCollision()
        {
            collisionBox.Location = position.ToPoint();
		}

        protected void UpdateCollisionSize()
        {
            collisionBox.Width = (int)(texture.Width * scale.X);
            collisionBox.Height = (int)(texture.Height * scale.Y);
		}
    }
}
