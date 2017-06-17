using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{   //Initializates everytihng in the project
    class InitializationController
    {
        public static void Init(Game game, GraphicsDeviceManager graphics)
        {
            SetGame(game);
            SetGraphicsProperties(graphics);

            SetGameProperties(game);
            CallInits();
        }

        //Sets base Game properies
        private static void SetGame(Game game)
        {
            IntPtr ptr = game.Window.Handle;
            game.IsMouseVisible = true;
            game.Window.Title = "v0.1";
            game.TargetElapsedTime = TimeSpan.FromSeconds(1.0 / 144.0f);
        }

        //Sets graphics' properties
        private static void SetGraphicsProperties(GraphicsDeviceManager graphics)
        {
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.SynchronizeWithVerticalRetrace = false;
            graphics.ApplyChanges();
        }

        //Sets game properties. More info in GameProperties
        private static void SetGameProperties(Game game)
        {
            GameProperties.Viewport = game.GraphicsDevice.Viewport.Bounds;
            GameProperties.DefaultTexture = GetDefaultTexture(game);
            GameProperties.DefaultFont = game.Content.Load<SpriteFont>("PixelFont");
            GameProperties.BigDefaultFont = game.Content.Load<SpriteFont>("BigPixelFont");
        }

        //Creates default texture of 1x1 white pixel
        private static Texture2D GetDefaultTexture(Game game)
        {
            Texture2D whitePixel;

            whitePixel = new Texture2D(game.GraphicsDevice, 1, 1);
            Color[] colorData = { Color.White };
            whitePixel.SetData<Color>(colorData);

            return whitePixel;
        }

        //Calls all of the starting inits
        private static void CallInits()
        {
            AbilitiesController.Init();
            AbilitiesRandomizer.Init();
            MenuController.Init();
            Actors.Init();
        }
    }
}
