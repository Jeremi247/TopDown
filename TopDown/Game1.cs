using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace TopDown
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D whitePixel;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            this.IsMouseVisible = true;

            whitePixel = new Texture2D(GraphicsDevice, 1, 1);
            Color[] colorData = { Color.White };
            whitePixel.SetData<Color>(colorData);

            GameProperties.Viewport = GraphicsDevice.Viewport.Bounds;
            GameProperties.DefaultTexture = whitePixel;
            GameProperties.DefaultFont = Content.Load<SpriteFont>("PixelFont");

            Actors.Init();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }
        
        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            UpdateController.Update(gameTime);

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            Window.Title = (1 / gameTime.ElapsedGameTime.TotalSeconds).ToString();

            DrawController.Draw(spriteBatch);
            
            base.Draw(gameTime);
        }
    }
}
