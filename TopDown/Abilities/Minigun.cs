using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown.Abilities
{
	class Minigun
	{
		public static string name = "minigun"; // used in Weapon Register
		public static bool Bought = false; //Default for Bought Register
		public static float Value = 2000;
		private static Color defaultColor = Color.AliceBlue;
		public static int id = 1;
		public static Weapon MG = new Weapon(name, Value, Weapon.RegisterWeaponAbility(id), defaultColor, Bought);

		public static void ApplyAbility()
		{
			AbilitiesController.AddTime(4000, AbilitiesController.WeaponTypes.minigun);
		}
	}
}
