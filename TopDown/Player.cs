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
        }

        public void Shoot()
        {
            Texture2D bulletTexture = GameProperties.DefaultTexture;
            Vector2 bulletSize = Bullet.Scale;
            Vector2 spawnPosition;
            Vector2 bulletTarget;

            bulletTarget.X = InputController.GetMousePosition().X - (bulletTexture.Width * bulletSize.X) / 2;
            bulletTarget.Y = InputController.GetMousePosition().Y - (bulletTexture.Height * bulletSize.Y) / 2;

            spawnPosition.X = position.X + (texture.Width * scale.X) / 2 - (bulletTexture.Width * bulletSize.X) / 2;
            spawnPosition.Y = position.Y + (texture.Height * scale.Y) / 2 - (bulletTexture.Height * bulletSize.Y) / 2;

            if (CanPistolShoot())
            {
                Bullet bullet = new Bullet(bulletTexture, spawnPosition, bulletSize, Color.Yellow, bulletTarget, 700);

                Actors.Bullets.Add(bullet);
                timeToNextShot = 200;
            }
            else if (AbilitiesController.CurrentWeapon == AbilitiesController.WeaponTypes.minigun && timeToNextShot <= 0)
            {
                var minigunBulletSize = bulletSize * new Vector2(0.8f, 0.8f);
                Bullet bullet = new Bullet(bulletTexture, spawnPosition, minigunBulletSize, Color.PaleGoldenrod, bulletTarget, 1000);

                Actors.Bullets.Add(bullet);
                timeToNextShot = 30;
            }
        }

        private Boolean CanPistolShoot()
        {
            return AbilitiesController.CurrentWeapon == AbilitiesController.WeaponTypes.pistol &&
                   (!InputController.IsLeftMouseButtonHeld ||
                   (InputController.IsLeftMouseButtonHeld && timeToNextShot <= 0));
        }

        public void UpdateWeaponTimer(GameTime gameTime)
        {
            if (timeToNextShot > 0)
            {
                timeToNextShot -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }

        public void MoveLeft()
        {
            CorrectSpeed();
            moveTarget.X = position.X - speed;
        }

        public void MoveRight()
        {
            CorrectSpeed();
            moveTarget.X = position.X + speed;
        }

        public void MoveUp()
        {
            CorrectSpeed();
            moveTarget.Y = position.Y - speed;
        }

        public void MoveDown()
        {
            CorrectSpeed();
            moveTarget.Y = position.Y + speed;
        }

        public void Move(GameTime gameTime)
        {
            MoveInDirection(gameTime, moveTarget);
            moveTarget = position;
        }

        public void SetPositionToCenter()
        {
            position.X = GameProperties.Viewport.Width / 2 - this.scale.X * texture.Width / 2;
            position.Y = GameProperties.Viewport.Height / 2 - this.scale.Y * texture.Height / 2;
        }

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
