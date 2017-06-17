using System;
using System.Collections.Generic;
using System.IO;
using TopDown.Abilities;

namespace TopDown
{
	//TODO: When there is an General Type for all Weapons, Rework this into weapon Controller!
	public class BoughtController
	{
		private static bool loaded = false;
		private static string path = Environment.CurrentDirectory + "BoughtRegister.register";
		private static Dictionary<string, bool> boughtDic = new Dictionary<string, bool>();
		internal static string pass = "BoughtRegister";
		private static int index = 0;
		private static string[] Weapons;

		public static string GetCurrentItem()
		{
			Weapons = new string[boughtDic.Count];

			boughtDic.Keys.CopyTo(Weapons, 0);
			return Weapons[index];
		}
		public static string getState(string item)
		{
			bool a = false;
			boughtDic.TryGetValue(item, out a);
			return a.ToString();
		}
		public static bool getStateBool(string item)
		{
			bool a = false;
			boughtDic.TryGetValue(item, out a);
			return a;
		}
		public static void NextItem()
		{
			index++;
			if (index > boughtDic.Count - 1)
			{
				index = 0;
			}
		}
		public static void PreviousItem()
		{
			index--;
			if (index < 0)
			{
				index = boughtDic.Count - 1;
			}
		}
		public static void ShowCurrentItem()
		{
			MenuController.ItemName = Weapons[index];
		}

		public static void load()
		{
			if (loaded == true) { return; }
			if (File.Exists(path))
			{
				string[] enryptedstats = File.ReadAllLines(path);
				string[] stats = new string[enryptedstats.Length];
				int i = 0;
				foreach (string s in enryptedstats)
				{
					stats[i] = Crypter.Decrypt(s, pass);
					i++;
				}
				//each line looks like this: "WEAPONNAME|BOUGHT"
				foreach (string f in stats)
				{
					string name = f.Split('|')[0];
					string statuse = f.Split('|')[1];
					name = name.ToLower();
					statuse = statuse.ToLower();
					bool status = false;
					if (statuse == "true")
					{
						status = true;
					}
					else if (statuse == "false")
					{
						status = false;
					}
					else if (statuse != "false" && statuse != "true")
					{
						File.Delete(path);
						generateWeaponBoughtRegister();
						break;
					}
					if (boughtDic != null)
					{
						if (boughtDic.ContainsKey(name))
						{ boughtDic.Remove(name); }
						boughtDic.Add(name, status);
					}
					else { throw new NotImplementedException("boughtDic = null?"); }
				}
				loaded = true;
			}
			else
			{
				generateWeaponBoughtRegister();
			}
		}

		private static void generateWeaponBoughtRegister()
		{
			//Format: "WEAPONNAME|BOUGHT"
			//TODO: ADD ALL WEAPONS HERE!
			bool minigunstate = Minigun.Bought;
			bool blastpulsestate = BlastPulse.Bought;
			boughtDic.TryGetValue(Minigun.name, out minigunstate);
			boughtDic.TryGetValue(BlastPulse.name, out blastpulsestate);
			string[] weapons = new string[] { Minigun.name + "|" + minigunstate.ToString().ToLower(), BlastPulse.name + "|" + blastpulsestate.ToString().ToLower() };
			//TODO: FIND AN MORE DYNAMIC WAY
			string[] encyptedweapons = new string[weapons.Length];
			int h = 0;
			foreach (string x in weapons)
			{
				encyptedweapons[h] = Crypter.Encrypt(weapons[h], pass); 
				h++;
				FileStream fs = File.Create(path);
				fs.Close();
				File.WriteAllLines(path, encyptedweapons);
			}
			//Reload
			loaded = false;
			load();
		}
		//TODO: If i have an More Dynamic Way (where every weapons are in one Class Type) I can make an Buy function!
		//For Now, just call this temporary buy!
		public static void buy(string item)
		{
			//TODO: Dynamic Pricing!
			if (item == Abilities.Minigun.name && Int32.Parse(Coin.getAmount()) < 500)
			{
				MenuController.ShopMessage = "Not Enough Coins: " + Coin.getAmount() + "/500";
				return;
			}
			else if (item == Abilities.BlastPulse.name && Int32.Parse(Coin.getAmount()) < 1000)
			{
				MenuController.ShopMessage = "Not Enough Coins: " + Coin.getAmount() + "/1000";
				return;
			}
			boughtDic.Remove(item);
			boughtDic.Add(item, true);
			generateWeaponBoughtRegister();
		}
	}
}