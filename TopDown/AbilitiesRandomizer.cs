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
        private static float totalDropChance = 800;

        //Initializates randomizer. Sums all abilities' values.
        public static void Init()
        {
            values.Add(Abilities.Minigun.Value);
            values.Add(Abilities.BlastPulse.Value);
            totalValue = values.Sum();
        }

        //Spawns ability on random basis. Ability drop chance is caluclated on base of total drop chance and it's value, percentage is multiplayed by 100
        public static void SpawnAbility(BasicEnemy enemy)
        {
            var val1 = totalDropChance - Abilities.Minigun.Value / totalValue * totalDropChance;
            var val2 = totalDropChance - Abilities.BlastPulse.Value / totalValue * totalDropChance;
            var random = rnd.Next(0, 10000);

            if (random >= 0 && random < val1)
            {
                Actors.Abilities.Add(new Abilities.Minigun(enemy));
            }
            else if (random >= val1 && random < val2)
            {
                Actors.Abilities.Add(new Abilities.BlastPulse(enemy));
            }
        }
    }
}
