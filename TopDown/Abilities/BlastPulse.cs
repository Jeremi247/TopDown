using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown.Abilities
{
    class BlastPulse
    {
		public static string name = "blastpulse"; // used in Weapon Register
		public static bool Bought = false; //Default for Bought Register
		public static float Value = 4000;
        private static Color defaultColor = Color.DodgerBlue;
		public static int id = 0;
		public static Weapon BP = new Weapon(name, Value, Weapon.RegisterWeaponAbility(id), defaultColor, Bought);

        public static void ApplyAbility()
        {
            float speed = 1000;
            double bulletsAmount = 200;
            for (double i = 0; i < bulletsAmount; i++)
            {
                float sinValue = (float)Math.Sin(2 * Math.PI * i / bulletsAmount) * speed;
                float cosValue = (float)Math.Cos(2 * Math.PI * i / bulletsAmount) * speed;
				Vector2 targetPosition = new Vector2(Actor.nposition.X + sinValue, Actor.nposition.Y + cosValue);
                Actors.Bullets.Add(new Bullet(GameProperties.DefaultTexture, Actor.nposition, new Vector2(5,5), Color.Blue, targetPosition, speed));
            }
        }
    }
}
