using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{
    class AbilitiesController
    {
        public enum WeaponTypes { pistol, minigun };
        public static WeaponTypes CurrentWeapon = WeaponTypes.pistol;
        public static float AbilityTime = 0;

        public static void Run(GameTime gameTime)
        {
            Actors.Character.UpdateWeaponTimer(gameTime);

            if (AbilityTime > 0)
            {
                AbilityTime -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            else
            {
                CurrentWeapon = WeaponTypes.pistol;
            }
        }

        public static void Clear()
        {
            AbilityTime = 0;
            CurrentWeapon = WeaponTypes.pistol;
        }

        public static void AddTime(float miliseconds, WeaponTypes weapon)
        {
            if(CurrentWeapon == weapon)
            {
                AbilityTime += miliseconds;
            }
            else
            {
                CurrentWeapon = weapon;
                AbilityTime = miliseconds;
            }
        }
    }
}
