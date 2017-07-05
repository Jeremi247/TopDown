using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{
    class AbilitiesRandomizer
    {
        private static List<Modification> mods = new List<Modification>();
        private static Random rnd = GameProperties.Random;
        private static float totalValue;
        private static float totalDropChance = 800; //8%

        //Initializates randomizer. Sums all abilities' values.
        public static void Init()
        {
            FillMods();

            totalValue = SumValues(mods);
        }

        //Spawns ability on random basis. Ability drop chance is caluclated on base of total drop chance and it's value, percentage is multiplayed by 100
        public static void SpawnAbility(BasicEnemy enemy)
        {
            var random = rnd.Next(0, 10000);
            float iteratedValue = 0;
            foreach (Modification mod in mods)
            {
                var value = mod.DropChance / totalValue * totalDropChance;
                if(random >= iteratedValue && random < iteratedValue + value)
                {
                    if (mod.GetType() == typeof(Weapon))
                    {
                        Actors.Abilities.Add(new WeaponContainer(enemy, mod.ModColor, (Weapon)mod));
                    }
                    else
                    {
                        Actors.Abilities.Add(new AbilityContainer(enemy, mod.ModColor, (Ability)mod));
                    }
                }
                iteratedValue += value;
            }
        }

        private static void FillMods()
        {
            mods.Add(WeaponTypes.TestWeaponOne);
            mods.Add(WeaponTypes.TestWeaponTwo);
            mods.Add(WeaponTypes.TestWeaponThree);

            mods.Add(new Abilities.BlastPulse(1500, Color.AliceBlue));
        }

        private static float SumValues(List<Modification> mods)
        {
            float returnValue = 0;

            foreach (Modification mod in mods)
            {
                returnValue += mod.DropChance;
            }

            return returnValue;
        }
    }
}
