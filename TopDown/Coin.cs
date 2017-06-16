using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace TopDown
{
	public class Coin
	{
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
			string[] lines = new string[21];
			int x = 0;
			foreach (string l in lines)
			{
				if (x != 20)
				{
					Random rg = new Random();
					int randomvalue = rg.Next(1, 10);
					lines[x] = RandomString(randomvalue);
				}
				x++;
			}
			for (int i = 0; i < count; i++)
			{
				lines[20] = lines[20] + "x";
			}
			File.WriteAllLines(path, lines);
		}
		public static void load()
		{
			try
			{
				if (File.Exists(path))
				{
					string[] x = File.ReadAllLines(path);
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