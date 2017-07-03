using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{
    class Player : Entity
    {
        private Vector2 moveTarget;
        public float timeToNextShot = 100;
        
        public Player(Texture2D texture, Vector2 position, Vector2 scale, Color color, float baseSpeed) : base (texture, position, scale, color)
        {
            this.baseSpeed = baseSpeed;

            moveTarget = position;
            SetPositionToCenter();
        }

        //Shoots the given weapon in the direction of the cursor
        public void Shoot()
        {
            Weapon weapon = WeaponController.CurrentWeapon;
            Texture2D bulletTexture = GameProperties.DefaultTexture;
            Vector2 bulletSize = weapon.BulletSize;
            Vector2 spawnPosition;
            Vector2 bulletTarget;

            bulletTarget.X = InputController.GetMousePosition().X - (bulletTexture.Width * bulletSize.X) / 2;
            bulletTarget.Y = InputController.GetMousePosition().Y - (bulletTexture.Height * bulletSize.Y) / 2;

            spawnPosition.X = position.X + (texture.Width * scale.X) / 2 - (bulletTexture.Width * bulletSize.X) / 2;
            spawnPosition.Y = position.Y + (texture.Height * scale.Y) / 2 - (bulletTexture.Height * bulletSize.Y) / 2;

            if (timeToNextShot <= 0)
            {
                for (int i = 0; i < weapon.BulletsInOneShot; i++)
                {
                    Bullet bullet = new Bullet(bulletTexture, spawnPosition, bulletSize, weapon.BulletColor, bulletTarget, weapon.BulletSpeed);

                    SpawnSmoke(bullet, Color.Gray, weapon.FireRate / 1000, 7);
                    SpawnSmoke(bullet, Color.Orange, 0.01, 7);
                    Actors.Bullets.Add(bullet);
                }
                timeToNextShot = weapon.FireRate;
            }
        }

        //Smoke effect near player object when shooting
        private void SpawnSmoke(Bullet bullet, Color color, double time, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Actors.BloodParticles.Add(new Particle(GameProperties.DefaultTexture, new Vector2(5, 5), color, bullet, time));
            }
        }

        //Updates timer delaying the shots
        public void UpdateWeaponTimer(GameTime gameTime)
        {
            if (timeToNextShot > 0)
            {
                timeToNextShot -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }

        //Sets target movemwnt direction to the left of the player's position
        public void MoveLeft()
        {
            CorrectSpeed();
            moveTarget.X = position.X - speed;
        }

        //Sets target movemwnt direction to the left of the player's position
        public void MoveRight()
        {
            CorrectSpeed();
            moveTarget.X = position.X + speed;
        }

        //Sets target movemwnt direction to the left of the player's position
        public void MoveUp()
        {
            CorrectSpeed();
            moveTarget.Y = position.Y - speed;
        }

        //Sets target movemwnt direction to the left of the player's position
        public void MoveDown()
        {
            CorrectSpeed();
            moveTarget.Y = position.Y + speed;
        }

        //Moves the player to the vector position set by Move<Direction> functions
        public void Move(GameTime gameTime)
        {
            MoveInDirection(gameTime, moveTarget);
            moveTarget = position;
        }

        //Places player at the center of the viewport
        public void SetPositionToCenter()
        {
            position.X = GameProperties.Viewport.Width / 2 - this.scale.X * texture.Width / 2;
            position.Y = GameProperties.Viewport.Height / 2 - this.scale.Y * texture.Height / 2;
        }

        //Keeps the player in the viewport
        public void KeepInViewport()
        {
            if (position.X < GameProperties.Viewport.Left)
            {
                position.X = GameProperties.Viewport.Left;
            }

            if (position.X > GameProperties.Viewport.Right - texture.Width * scale.X)
            {
                position.X = GameProperties.Viewport.Right - texture.Width * scale.X;
            }

            if (position.Y < GameProperties.Viewport.Top)
            {
                position.Y = GameProperties.Viewport.Top;
            }

            if (position.Y > GameProperties.Viewport.Bottom - texture.Height * scale.Y)
            {
                position.Y = GameProperties.Viewport.Bottom - texture.Height * scale.Y;
            }
        }
    }
}
