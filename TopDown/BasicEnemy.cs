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

            UpdateCollisionSize();
        }

        private void CalcValue()
        {
            value = value * baseSpeed / defaultSpeed;
        }

        private void AdjustColor()
        {
            int red = (int)(color.R * Math.Pow(baseSpeed / defaultSpeed, 2)) +50;
            int green = (int)(color.G * Math.Pow(baseSpeed / defaultSpeed, 2)) +50;
            int blue = (int)(color.B * Math.Pow(baseSpeed / defaultSpeed, 2)) +50;

            Color newColor = new Color(red, green, blue);
            color = newColor;
        }

        private void RandomizeVelocity()
        {
            var percentChange = 0.8;
            var multiplayer = rnd.NextDouble() * percentChange - percentChange/2;

            baseSpeed += (float)multiplayer*baseSpeed;
        }

        private void SetRandomPosition()
        {
            var viewport = GameProperties.Viewport;
            
            int spawnSide = rnd.Next(0, 4);

            switch (spawnSide)
            {
                case 0: SetRandomLeft(viewport); break;
                case 1: SetRandomRight(viewport); break;
                case 2: SetRandomTop(viewport); break;
                case 3: SetRandomBottom(viewport); break;
            }
        }

        private void SetRandomLeft(Rectangle viewport)
        {
            position.X = viewport.X - texture.Width * scale.X;
            position.Y = rnd.Next(0, viewport.Height);
        }

        private void SetRandomRight(Rectangle viewport)
        {
            position.X = viewport.Width;
            position.Y = rnd.Next(0, viewport.Height);
        }

        private void SetRandomTop(Rectangle viewport)
        {
            position.X = rnd.Next(0, viewport.Width);
            position.Y = viewport.Y - texture.Height * scale.Y;
        }

        private void SetRandomBottom(Rectangle viewport)
        {
            position.X = rnd.Next(0, viewport.Width);
            position.Y = viewport.Height;
        }

        public void SpawnBlood(Bullet bullet)
        {
            for (int i = 0; i < rnd.Next(5, 10); i++)
            {
                Actors.BloodParticles.Add(new Particle(GameProperties.DefaultTexture, new Vector2(5, 5), Color.IndianRed, bullet, 30));
            }
        }

        public new void Remove()
        {
            ShouldBeRemoved = true;

            SpawnAbility();
            Actors.DeadBodies.Add(new DeadBody(this));
            MonsterSpawner.LowerRespawnTime(400);

            ScoreController.Add((int)value);
        }

        public void SpawnAbility()
        {
            AbilitiesRandomizer.SpawnAbility(this);
        }
    }
}
