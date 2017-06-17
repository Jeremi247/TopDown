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
        public static Vector2 scorePosition = new Vector2(10, 5);
        private static Vector2 comboPosition = new Vector2(scorePosition.X, scorePosition.Y + font.MeasureString("T").Y + 3);
        public static float scoreMultiplayer = 1;
        public static ulong score = 0;
        
        //Clear score variables
        public static void Clear()
        {
            score = 0;
            scoreMultiplayer = 1;
        }

        //Add given amount of points multiplayed by multiplayer. Adjust combo text position. Increseas score multiplayer.
        public static void Add(int points)
        {
            score += (ulong)(points * scoreMultiplayer);
            scoreMultiplayer += 0.01f;
            comboPosition = new Vector2(scorePosition.X, scorePosition.Y + font.MeasureString("T").Y + 3);
        }

        //Draws score and combo amount
        public static void DrawScore(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, GetText(), scorePosition, color);
            spriteBatch.DrawString(font, ("Combo! Score x"+scoreMultiplayer.ToString("N")), comboPosition, color);
        }

        //Returns current amount of points
        public static String GetText()
        {
            return "Score: " + score;
        }
    }
}
