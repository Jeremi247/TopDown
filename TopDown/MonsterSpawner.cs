using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{
    class MonsterSpawner
    {
        private static float elapsedTime = 0;
        private static float basicMonsterRespawnTime = 1000;

		public static void SpawnMonsters(GameTime gameTime)
        {
            if (Actors.Enemies.Count > 7)
            {
                if (elapsedTime > basicMonsterRespawnTime + 300)
                {
                    elapsedTime -= basicMonsterRespawnTime + 300;
                    SpawnBasicMonster();
                }
            }
            else
            {
                if (elapsedTime > basicMonsterRespawnTime)
                {
                    elapsedTime -= basicMonsterRespawnTime;
                    SpawnBasicMonster();
                }
            }

			elapsedTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        private static void SpawnBasicMonster()
        {
            Actors.Enemies.Add(new BasicEnemy(GameProperties.DefaultTexture, Vector2.Zero, Actors.Character.scale, Color.Green, 200, 10));
        }

		public static void LowerRespawnTime(int loweringLimit)
		{
			if (basicMonsterRespawnTime > loweringLimit)
			{
				basicMonsterRespawnTime -= 100;
			}
		}

        public static void Clear()
        {
            elapsedTime = 0;
            basicMonsterRespawnTime = 1000;
        }
    }
}
