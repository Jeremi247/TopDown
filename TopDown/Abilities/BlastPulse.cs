using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown.Abilities
{
    class BlastPulse : Ability
    {
        private static Color defaultColor = Color.DodgerBlue;
        public BlastPulse(BasicEnemy enemy) : base (enemy, defaultColor)
        {

        }

        public override void ApplyAbility()
        {
            float speed = 1000;
            double bulletsAmount = 200;
            for (double i = 0; i < bulletsAmount; i++)
            {
                float sinValue = (float)Math.Sin(2 * Math.PI * i / bulletsAmount) * speed;
                float cosValue = (float)Math.Cos(2 * Math.PI * i / bulletsAmount) * speed;
                Vector2 targetPosition = new Vector2(position.X + sinValue, position.Y + cosValue);

                Actors.Bullets.Add(new Bullet(GameProperties.DefaultTexture, this.position, new Vector2(5,5), Color.Blue, targetPosition, speed));
            }
        }
    }
}
