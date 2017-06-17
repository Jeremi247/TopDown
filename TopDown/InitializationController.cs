using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{
    class InitializationController
    {
        public static void Init(Game game, GraphicsDeviceManager graphics)
        {
            Texture2D whitePixel;
            game.IsMouseVisible = true;
            game.Window.Title = "v0.1";

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;

            game.TargetElapsedTime = TimeSpan.FromSeconds(1.0 / 144.0f);
            graphics.SynchronizeWithVerticalRetrace = false;

            IntPtr ptr = game.Window.Handle;

            graphics.ApplyChanges();

            whitePixel = new Texture2D(game.GraphicsDevice, 1, 1);
            Color[] colorData = { Color.White };
            whitePixel.SetData<Color>(colorData);

            GameProperties.Viewport = game.GraphicsDevice.Viewport.Bounds;
            GameProperties.DefaultTexture = whitePixel;
            GameProperties.DefaultFont = game.Content.Load<SpriteFont>("PixelFont");
            GameProperties.BigDefaultFont = game.Content.Load<SpriteFont>("BigPixelFont");
			BoughtController.load();
			WeaponRegister.init();
            AbilitiesController.Init();
            AbilitiesRandomizer.Init();
            MenuController.Init();
            Actors.Init();
			Coin.load();
        }
    }
}
