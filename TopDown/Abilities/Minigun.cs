using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown.Abilities
{
    class Minigun : Ability
    {
        private static Color defaultColor = Color.AliceBlue;
        public Minigun(BasicEnemy enemy) : base (enemy, defaultColor)
        {

        }

        public override void ApplyAbility()
        {
            AbilitiesController.AddTime(4000, AbilitiesController.WeaponTypes.minigun);
        }
    }
}
