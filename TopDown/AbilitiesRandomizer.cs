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

        public static void SpawnAbility(BasicEnemy enemy)
        {
            var val1 = Abilities.Minigun.Value / totalValue * 700;
            var val2 = Abilities.BlastPulse.Value / totalValue * 700;
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
