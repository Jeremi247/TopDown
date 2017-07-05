using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{
    class WeaponTypes
    {
        public static Weapon Pistol = new Weapon(Bullet.Scale, 700, Color.Yellow, 0, 1, 200, 0, 0, "Pistol");
        public static Weapon TestWeaponOne = new Weapon(new Vector2(2, 2), 100, Color.Green, 0, 1, 100, 10000, 400, "TestWeaponOne");
        public static Weapon TestWeaponTwo = new Weapon(new Vector2(5, 5), 2000, Color.Yellow, 1, 4, 20, 7000, 600, "TestWeaponTwo");
        public static Weapon TestWeaponThree = new Weapon(new Vector2(10, 10), 2000, Color.Blue, 2, 2, 2000, 13000, 1000, "TestWeaponThree");
    }
}
