using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{
    class Button
    {
        protected Boolean isActive = true;
        public Boolean isHovered = false;
        public static Vector2 size = new Vector2(300, 30);
        public Rectangle boundary;
        public String text;
        private Vector2 textPosition;

        public Button(Vector2 position, String text)
        {
            boundary = new Rectangle(position.ToPoint(), size.ToPoint());
            this.text = text;

            textPosition.X = boundary.X + 10;
            textPosition.Y = boundary.Y + boundary.Height/2 - (float)Math.Floor(GameProperties.DefaultFont.MeasureString(text).Y/2);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isHovered && isActive)
            {
                spriteBatch.Draw(GameProperties.DefaultTexture, boundary, Color.LightGray);
                spriteBatch.DrawString(GameProperties.DefaultFont, text, textPosition, Color.Teal);
            }
            else if (isActive)
            {
                spriteBatch.Draw(GameProperties.DefaultTexture, boundary, Color.Teal);
                spriteBatch.DrawString(GameProperties.DefaultFont, text, textPosition, Color.LightGray);
            }
            else
            {
                spriteBatch.Draw(GameProperties.DefaultTexture, boundary, Color.Teal);
                spriteBatch.DrawString(GameProperties.DefaultFont, text, textPosition, Color.DarkSlateGray);
            }
        }

        public virtual void CheckState()
        {

        }

        public virtual void TakeAction()
        {

        }
    }
}
