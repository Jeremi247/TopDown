using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{   //Storage for all properties that are accessible in various places throughout the project
    class GameProperties
    {
        public static Random Random = new Random(); //ALl random calls should be made from this Random
        public static Rectangle Viewport;
        public static Texture2D DefaultTexture;
        public static SpriteFont DefaultFont;
        public static SpriteFont BigDefaultFont;
    }
}
