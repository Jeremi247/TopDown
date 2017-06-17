using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{   //Base class for all buttons used in menu
    abstract class Button
    {
        protected Boolean isActive = true;
        public Boolean isHovered = false;
        public static Vector2 size = new Vector2(300, 30);
        public Rectangle boundary;
        public String text;
        private Vector2 textPosition;

        //Constructor sets size of the button, it's triger box, and position of the text written on it
        public Button(Vector2 position, String text)
        {
            size.X = GameProperties.Viewport.Width - position.X;
            boundary = new Rectangle(position.ToPoint(), size.ToPoint());
            this.text = text;

            textPosition.X = boundary.X + 10;
            textPosition.Y = boundary.Y + boundary.Height/2 - (float)Math.Floor(GameProperties.DefaultFont.MeasureString(text).Y/2);
        }

        //Draws the button in proper style dependent of state of the button.
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

        //Checks if button can be set to active, is not required for button to work. All child classes are handling it by themself. Buttons are active by default
        public virtual void SetsActiveStatus()
        {

        }

        //Function that must be called by all child classes for button to take action
        public abstract void TakeAction();
    }
}
