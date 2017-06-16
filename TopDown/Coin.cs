using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace TopDown
{
	public class Coin
	{
		private static string pass = "Coin";
		private static Random random = new Random();
		public static string RandomString(int length)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, length)
			  .Select(s => s[random.Next(0, 10)]).ToArray());
		}
		private static string path = Environment.CurrentDirectory.ToString() + "CoinSave.Coins";
		private static int count;
		public static void setAmount(int Amount)
		{
			count = Amount;
		}
		public static void Add(int Amount)
		{
			count = count + Amount;
		}
		public static string getAmount()
		{
			return count.ToString();
		}
		public static void save()
		{
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			Random rnd = new Random();
			var v = File.Create(path);
			v.Close();
			string[] lines = new string[101];
			int x = 0;
			foreach (string l in lines)
			{
				if (x != 100)
				{
					Random rg = new Random();
					int randomvalue = rg.Next(1, 10);
					lines[x] = RandomString(randomvalue);
				}
				x++;
			}
			for (int i = 0; i < count; i++)
			{
				lines[100] = lines[100] + "x";
			}
			int g = 0;
			foreach (string f in lines)
			{
				lines[g] = Crypter.Encrypt(lines[g], pass);
				g++;
			}
			File.WriteAllLines(path, lines);
		}
		public static void load()
		{
			try
			{
				if (File.Exists(path))
				{
					string[] h = File.ReadAllLines(path);
					string[] x = new string[h.Length];
					int i = 0;
					foreach (string b in h)
					{
						x[i] = Crypter.Decrypt(h[i], pass);
						i++;
					}
					if (x[x.Length - 1].StartsWith("x") && x[x.Length - 1].EndsWith("x"))
					{
						count = x[x.Length - 1].Length;
					}
					else
					{
						throw new Exception();
					}
				}
			}
			catch (Exception e)
			{
				File.Delete(path);
			}
		}
	}
}