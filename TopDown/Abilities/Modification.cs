using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{
    class Modification
    {
        public float Value;
        public Color ModColor;
        public Modification(float _value, Color _modColor)
        {
            Value = _value;
            ModColor = _modColor;
        }
    }
}
