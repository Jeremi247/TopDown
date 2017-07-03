using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{
    class AbilityContainer : ModificationContainer
    {
        public AbilityContainer(BasicEnemy enemy, Color _color, Ability _mod) : base(enemy, _color, _mod)
        {

        }

        public override void ApplyAbility()
        {
            ((Ability)mod).Apply();
        }
    }
}
