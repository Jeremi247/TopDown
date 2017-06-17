using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{   //Container class. It contains all actors created throughout the game
    class Actors
    {
        public static Player Character;
        public static List<Actor> Drawable = new List<Actor>(); //If there is no list that object can be applied to or it's only one(like character) then it goes to Drawable list
        public static List<Bullet> Bullets = new List<Bullet>();
        public static List<BasicEnemy> Enemies = new List<BasicEnemy>();
        public static List<Particle> BloodParticles = new List<Particle>();
        public static List<DeadBody> DeadBodies = new List<DeadBody>();
        public static List<Ability> Abilities = new List<Ability>();

        //Creates character on the map
        public static void Init()
        {
            Character = new Player(GameProperties.DefaultTexture, Vector2.Zero, new Vector2(15,15), Color.Red, 400);

            Drawable.Add(Character);
        }
    }
}
