using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDown.Abilities;
namespace TopDown
{
	public class Weapon
	{
		public enum WeaponAbilitys { };
		public static Weapon[] WeaponList;
		public static List<Weapon> weapons = new List<Weapon>();
		public static string name; // used in Weapon Register
		public static bool Bought; //Default for Bought Register
		public static float Value;
		private static Color defaultColor;
		private static WeaponAbilitys id;
		public Weapon(string _name, float _Value, WeaponAbilitys _id, Color _defaultcolor, bool _boughtdefault = false)
		{
			name = _name;
			Bought = _boughtdefault;
			Value = _Value;
			defaultColor = _defaultcolor;
			id = _id;
		}
		public static void registerWeapon(Weapon weapon)
		{
			weapons.Add(weapon);
			WeaponList = weapons.ToArray();
		}
		public static WeaponAbilitys RegisterWeaponAbility(int id)
		{
			Weapon.WeaponAbilitys a = (Weapon.WeaponAbilitys)id;
			return a;
		}
	}
	public class WeaponRegister
	{
		public static void init()
		{
			Weapon[] ws = new Weapon[] {
				BlastPulse.BP,
				Minigun.MG
					};
			RegisterAllWeapons(ws);
		}
		public static int RegisterAllWeapons(Weapon[] WL)
		{
			int x = 0;
			foreach (Weapon w in WL)
			{
				Weapon.registerWeapon(w);
				Weapon.RegisterWeaponAbility(x);
				x++;
			}
			return x;
		}
		public static void executeAbility(int weapon)
		{
			switch (weapon)
			{
				case 0:
					BlastPulse.ApplyAbility();
					break;
				case 1:
					Minigun.ApplyAbility();
					break;
				default:
					//TODO: Do Some Error here!
					break;
			}
		}
	}
}
