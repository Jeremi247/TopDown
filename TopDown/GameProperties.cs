using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{
    class GameProperties
    {
        public static Vector2 GlobalScale = Vector2.One;
        public static Random Random = new Random();
        public static Rectangle Viewport;
        public static Texture2D DefaultTexture;
        public static SpriteFont DefaultFont;
        public static SpriteFont BigDefaultFont;
    }
}
