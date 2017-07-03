using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{
    class WeaponContainer : ModificationContainer
    {
        public WeaponContainer(BasicEnemy enemy, Color _color, Weapon _mod) : base (enemy, _color, _mod)
        {

        }

        public override void ApplyAbility()
        {
            WeaponController.AddTime((Weapon)mod);
        }
    }
}
