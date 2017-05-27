using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{
    class BasicEnemy : Entity
    {
        private float defaultSpeed = 0;
        private float value = 0;

        public BasicEnemy(Texture2D texture, Vector2 position, Vector2 scale, Color color, float baseSpeed, float value) : base(texture, position, scale, color) {
            this.baseSpeed = baseSpeed;
            defaultSpeed = baseSpeed;

            this.value = value;

            if (position == Vector2.Zero)
            {
                SetRandomPosition();
            }

            RandomizeVelocity();
            CalcValue();
            AdjustColor();

            updateCollisionSize();
        }

        private void CalcValue()
        {
            value = value * baseSpeed / defaultSpeed;
        }

        private void AdjustColor()
        {
            int red = (int)(color.R * Math.Pow(baseSpeed / defaultSpeed, 2));
            int green = (int)(color.G * Math.Pow(baseSpeed / defaultSpeed, 2));
            int blue = (int)(color.B * Math.Pow(baseSpeed / defaultSpeed, 2));

            Color newColor = new Color(red, green, blue);
            color = newColor;
        }

        private void RandomizeVelocity()
        {
            Random rnd = new Random();

            var percentChange = 0.8;
            var multiplayer = rnd.NextDouble() * percentChange - percentChange/2;

            baseSpeed += (float)multiplayer*baseSpeed;
        }

        private void SetRandomPosition()
        {
            var viewport = GameProperties.Viewport;

            Random rnd = new Random();
            int spawnSide = rnd.Next(0, 3);

            switch (spawnSide)
            {
                case 0: SetRandomLeft(rnd, viewport); break;
                case 1: SetRandomRight(rnd, viewport); break;
                case 2: SetRandomTop(rnd, viewport); break;
                case 3: SetRandomBottom(rnd, viewport); break;
            }
        }

        private void SetRandomLeft(Random rnd, Rectangle viewport)
        {
            position.X = viewport.X - texture.Width * scale.X;
            position.Y = rnd.Next(0, viewport.Height);
        }

        private void SetRandomRight(Random rnd, Rectangle viewport)
        {
            position.X = viewport.Width;
            position.Y = rnd.Next(0, viewport.Height);
        }

        private void SetRandomTop(Random rnd, Rectangle viewport)
        {
            position.X = rnd.Next(0, viewport.Width);
            position.Y = viewport.Y - texture.Height * scale.Y;
        }

        private void SetRandomBottom(Random rnd, Rectangle viewport)
        {
            position.X = rnd.Next(0, viewport.Width);
            position.Y = viewport.Height;
        }

        public new void Remove()
        {
            ShouldBeRemoved = true;
            MonsterSpawner.LowerRespawnTime(400);

            ScoreController.Add((int)value);
        }
    }
}
