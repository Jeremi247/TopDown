using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Threading.Tasks;

namespace TopDown
{
    class UpdateController
    {
        public static void Update(GameTime gameTime)
        {
            if (!Program.game.IsActive)
            {
                GameState.SetGameState(GameState.States.Menu);
            }

            InputController.ManageInputs(gameTime);

            if (GameState.GetGameState() == GameState.States.Gameplay)
            {
                GameState.IsInProgress = true;
                DeleteRedundant();

                MoveEntities(gameTime);
                MonsterSpawner.SpawnMonsters(gameTime);

                AbilitiesController.Run(gameTime);
                CheckCollisions();
            }
            else if(GameState.GetGameState() == GameState.States.Menu)
            {
                MenuController.CheckStates();
            }
        }

        private static void DeleteRedundant()
        {
            Actors.Bullets.RemoveAll(bullet => bullet.CanBeRemoved());
            Actors.Enemies.RemoveAll(enemy => enemy.CanBeRemoved());
            Actors.BloodParticles.RemoveAll(particle => particle.CanBeRemoved());
            Actors.DeadBodies.RemoveAll(body => body.CanBeRemoved());
            Actors.Abilities.RemoveAll(ability => ability.CanBeRemoved());
        }

        private static void MoveEntities(GameTime gameTime)
        {
            Actors.Character.Move(gameTime);
            Actors.Character.KeepInViewport();

            foreach (var bullet in Actors.Bullets)
            {
                bullet.Move(gameTime);
            }

            foreach (var enemy in Actors.Enemies)
            {
                enemy.MoveInDirection(gameTime, Actors.Character.position);
            }

            foreach (var particle in Actors.BloodParticles)
            {
                particle.Move(gameTime);
                particle.Fade(gameTime);
            }

            foreach (var body in Actors.DeadBodies)
            {
                body.Fade(gameTime);
            }

            foreach (var ability in Actors.Abilities)
            {
                ability.Pulse(gameTime);
            }
        }

        private static void CheckCollisions()
        {
            //CheckEnemiesCollisions();
            CheckAbilities();
        }

        private static void CheckAbilities()
        {
            foreach(var ability in Actors.Abilities)
            {
                if (Actors.Character.collisionBox.Intersects(ability.collisionBox))
                {
                    ability.ApplyAbility();
                    ability.Remove();
                }
            }
        }

        private static void CheckEnemiesCollisions()
        {
            foreach(var enemy in Actors.Enemies)
            {
                foreach(var bullet in Actors.Bullets)
                {
                    if(bullet.collisionBox.Intersects(enemy.collisionBox))
                    {
                        enemy.SpawnBlood(bullet);
                        bullet.Remove();
                        enemy.Remove();
                    }
                }
                if (enemy.collisionBox.Intersects(Actors.Character.collisionBox))
                {
                    GameState.SetGameState(GameState.States.Menu);
                    GameState.IsInProgress = false;
                }
            }
        }
    }
}
