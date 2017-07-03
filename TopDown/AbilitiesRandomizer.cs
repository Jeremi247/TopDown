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
                var value = totalDropChance - mod.Value / totalValue * totalDropChance;//TO DO: REPAIR THIES SHIET
                if(random >= iteratedValue && random < value)
                {
                    if (mod.GetType() == typeof(Weapon))
                    {
                        Actors.Abilities.Add(new WeaponContainer(enemy, mod.ModColor, (Weapon)mod));
                    }
                    else if (mod.GetType() == typeof(Ability))
                    {
                        Actors.Abilities.Add(new AbilityContainer(enemy, mod.ModColor, (Ability)mod));
                    }
                }
                iteratedValue += value;
            }
        }

        private static void FillMods()
        {
            mods.Add(new Weapon(new Vector2(2, 2), 100, Color.Green, 0, 1, 100, 10000, 400, "one"));
            mods.Add(new Weapon(new Vector2(5, 5), 400, Color.Yellow, 1, 4, 500, 7000, 600, "two"));
            mods.Add(new Weapon(new Vector2(10, 10), 2000, Color.Blue, 2, 2, 2000, 13000, 1000, "three"));
            mods.Add(new Abilities.BlastPulse(1500, Color.AliceBlue));
        }

        private static float SumValues(List<Modification> mods)
        {
            float returnValue = 0;

            foreach (Modification mod in mods)
            {
                returnValue += mod.Value;
            }

            return returnValue;
        }
    }
}
