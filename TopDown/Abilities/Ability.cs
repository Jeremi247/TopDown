using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{
    abstract class Ability : Modification
    {
        public Ability(float _value, Color _modColor) : base(_value, _modColor)
        {

        }

        public abstract void Apply();
    }
}
