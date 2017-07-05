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
        public float DropChance;
        public Color ModColor;
        public Modification(float _dropChance, Color _modColor)
        {
            DropChance = _dropChance;
            ModColor = _modColor;
        }
    }
}
