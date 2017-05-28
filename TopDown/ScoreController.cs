using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{
    class ScoreController
    {
        public static SpriteFont font = GameProperties.DefaultFont;
        public static Color color = Color.Aqua;
        public static Vector2 position = new Vector2(10, 5);
        public static int score = 0;

        public static void Add(int points)
        {
            score += points;
        }

        public static String GetText()
        {
            return "Score: " + score;
        }
    }
}
