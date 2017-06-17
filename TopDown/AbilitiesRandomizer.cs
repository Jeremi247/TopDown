using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{
    class AbilitiesRandomizer
    {
        private static List<float> values = new List<float>();
        private static Random rnd = GameProperties.Random;
        private static float totalValue;

        public static void Init()
        {
            values.Add(Abilities.Minigun.Value);
            values.Add(Abilities.BlastPulse.Value);
            totalValue = values.Sum();
        }

        public static void SpawnAbilityEasy(BasicEnemy enemy)
        {
            var val1 = Abilities.Minigun.Value / totalValue * 700;
            var val2 = Abilities.BlastPulse.Value / totalValue * 700;
            var random = rnd.Next(0, 10000);

			if (random >= 0 && random < val1)
			{
				//TODO: MAKE WEAPON[] WHICH CONTAINS ALL OF THE WEAPONS! (AND APPLY IT!)
				if (BoughtController.getStateBool(Abilities.Minigun.name) == true)
				{
					WeaponRegister.executeAbility(0);
				}
			}
			else if (random >= val1 && random < val2)
			{
				if (BoughtController.getStateBool(Abilities.BlastPulse.name) == true)
				{
					//if some is in the top left, spawns 1000000 particles!
					WeaponRegister.executeAbility(1);
				}
			}
        }
	}
}
