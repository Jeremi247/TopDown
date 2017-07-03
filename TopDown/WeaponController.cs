using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{
    class WeaponController
    {
        //Enum contains all possible weapon types
        private static SpriteFont font = GameProperties.DefaultFont;
        public static Weapon CurrentWeapon = WeaponTypes.pistol;

        private static float maxVisibleAbilityTime = 12000;
        public static float WeaponTime = 0;

        private static Rectangle barSize;
        private static Color barColor;
        private static Vector2 barTimerPos;
        private static Vector2 weaponNamePosition;

        //Intializates this controller. Sets timer bar height, it's vertical position and color
        public static void Init()
        {
            barSize = new Rectangle(0, 8, 0, 10);
            barTimerPos.Y = barSize.Y + barSize.Height + 2;
            barColor = Color.ForestGreen;

            SetWeaponNamePos();
        }

        //Adjust's weapon name position to be able to draw it in top right corner
        private static void SetWeaponNamePos()
        {
            weaponNamePosition.X = GameProperties.Viewport.Width -
                                   font.MeasureString(CurrentWeapon.WeaponName).X - 
                                   ScoreController.scorePosition.X;

            weaponNamePosition.Y = ScoreController.scorePosition.Y;
        }

        //Draws timer and it's bar when called
        public static void DrawTimer(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(GameProperties.DefaultTexture, barSize, barColor);

            spriteBatch.DrawString(font, CurrentWeapon.WeaponName, weaponNamePosition, Color.Aqua);
            if (WeaponTime > 0)
            {
                spriteBatch.DrawString(font, (WeaponTime / 1000).ToString("N"), barTimerPos, Color.Aqua);
            }
        }

        //Runs all update functions of this controller. Called in UpdateController
        public static void Run(GameTime gameTime)
        {
            Actors.Character.UpdateWeaponTimer(gameTime);

            if (WeaponTime > 0)
            {
                WeaponTime -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            else
            {
                WeaponTime = 0;
                CurrentWeapon = WeaponTypes.pistol;
            }

            SetWeaponNamePos();
            AdjustBar();
        }

        //Adjust bar that indicates how long the ability will last and adjust's bar timer's position
        private static void AdjustBar()
        {
            if (WeaponTime >= maxVisibleAbilityTime)
            {
                //If ability time is too long bar will have constant length
                barSize.Width = (int)(GameProperties.Viewport.Width / 1.5);
            }
            else
            {
                barSize.Width = (int)((WeaponTime / maxVisibleAbilityTime) * (GameProperties.Viewport.Width / 1.5));
            }

            barTimerPos.X = GameProperties.Viewport.Width / 2 - font.MeasureString((WeaponTime / 1000).ToString("N")).X / 2;
            barSize.X = GameProperties.Viewport.Width / 2 - barSize.Width / 2;
        }

        //resets current weapon to basic
        public static void Clear()
        {
            WeaponTime = 0;
            CurrentWeapon = WeaponTypes.pistol;
        }

        //Adds ability time if same weapon as the current one was collected 
        public static void AddTime(Weapon weapon)
        {
            if(CurrentWeapon.WeaponName == weapon.WeaponName)
            {
                WeaponTime += weapon.WeaponTime;
            }
            else
            {
                CurrentWeapon = weapon;
                WeaponTime = weapon.WeaponTime;
                Actors.Character.timeToNextShot = 0;
            }
        }
    }
}
