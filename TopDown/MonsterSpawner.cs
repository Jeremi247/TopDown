using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{   //Controls the spawns of all the monsters. Current and the future ones
    class MonsterSpawner
    {
        private static float elapsedTime = 0;
        private static float basicMonsterRespawnTime = 1000;

        //Spawns monster if elapsed time from last spawn is higher than respawnTime
        public static void SpawnMonsters(GameTime gameTime)
        {
            //If there is more than 7 enemies on the map their spawn rate is lowered by 0.3s
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

        //Creates new instance of the basic monster
        private static void SpawnBasicMonster()
        {
            Actors.Enemies.Add(new BasicEnemy(GameProperties.DefaultTexture, Vector2.Zero, Actors.Character.scale, Color.Green, 200, 10));
        }

        //Kalled on each kill. Lowers the respawn time delay. The more you kill the harder it gets. Lowering is limited by loweringLimit variable
        public static void LowerRespawnTime(int loweringLimit)
        {
            if(basicMonsterRespawnTime > loweringLimit)
            {
                basicMonsterRespawnTime -= 100;
            }
        }

        //Clears variables. Called on start of the new game
        public static void Clear()
        {
            elapsedTime = 0;
            basicMonsterRespawnTime = 1000;
        }
    }
}
