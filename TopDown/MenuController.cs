using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{
	class MenuController
	{
		public static List<Button> Buttons = new List<Button>();
		private static String menuText = "v0.1 MENU";
		public static string ItemName;
		public static string ShopMessage = "";

		public static void Init()
		{
			Vector2 buttonPosition = new Vector2(GameProperties.Viewport.Width - 270, GameProperties.Viewport.Height - Button.size.Y * 2 - 10);
			Buttons.Add(new Buttons.Exit(buttonPosition));

			buttonPosition.X -= 10;
			buttonPosition.Y -= Button.size.Y + 10;
			Buttons.Add(new Buttons.Resume(buttonPosition));

			buttonPosition.X -= 10;
			buttonPosition.Y -= Button.size.Y + 10;
			Buttons.Add(new Buttons.NewGame(buttonPosition));

			buttonPosition.X -= 10;
			buttonPosition.Y -= Button.size.Y + 10;
			buttonPosition.X -= 10;
			buttonPosition.Y -= Button.size.Y + 10;
			Buttons.Add(new Buttons.Previous(buttonPosition));

			buttonPosition.X -= 10;
			buttonPosition.Y -= Button.size.Y + 10;
			Buttons.Add(new Buttons.Next(buttonPosition));

			buttonPosition.X -= 10;
			buttonPosition.Y -= Button.size.Y + 10;
			Buttons.Add(new Buttons.Buy(buttonPosition));
		}

		public static void CheckStates()
		{
			Rectangle mouse = new Rectangle(InputController.GetMousePosition().ToPoint(), Point.Zero);
			foreach (Button button in Buttons)
			{
				if (button.boundary.Intersects(mouse))
				{
					button.isHovered = true;
					if (InputController.IsLeftMouseButtonPressed)
					{
						button.TakeAction();
					}
				}
				else
				{
					button.isHovered = false;
				}
				button.CheckState();
			}
		}

		public static void DrawMenu(SpriteBatch spriteBatch)
		{
			Color background = Color.Black;
			background.A = 180;
			spriteBatch.Draw(GameProperties.DefaultTexture, GameProperties.Viewport, background);

			foreach (Button button in Buttons)
			{
				button.Draw(spriteBatch);
			}

			Vector2 textPos = new Vector2(GameProperties.Viewport.Width / 2 - GameProperties.BigDefaultFont.MeasureString(menuText).X / 2, 40);
			spriteBatch.DrawString(GameProperties.BigDefaultFont, menuText, textPos, Color.White);
			DrawShop(spriteBatch);
		}

		public static void DrawPause(SpriteBatch spriteBatch)
		{
			Vector2 textPos = new Vector2(GameProperties.Viewport.Width / 2 - GameProperties.BigDefaultFont.MeasureString("PAUSE").X / 2, 40);
			spriteBatch.DrawString(GameProperties.BigDefaultFont, "PAUSE", textPos, Color.White);
		}
		public static void DrawShop(SpriteBatch spriteBatch)
		{
			Color background = Color.Aqua;

			foreach (Button shopbutton in Buttons)
			{
				shopbutton.Draw(spriteBatch);
			}
			string ItemName = BoughtController.GetCurrentItem();
			string itemstatus = BoughtController.getState(ItemName);
			Vector2 CurrentItemTextPos = new Vector2(GameProperties.Viewport.Width / 2 - GameProperties.DefaultFont.MeasureString("Item Selected: " + ItemName).X, GameProperties.Viewport.Height / 2);
			spriteBatch.DrawString(GameProperties.DefaultFont, "Item Selected: " + ItemName, CurrentItemTextPos, Color.White);
			CurrentItemTextPos.Y = CurrentItemTextPos.Y + GameProperties.DefaultFont.MeasureString("Bought: " + itemstatus).Y;
			spriteBatch.DrawString(GameProperties.DefaultFont, "Bought: " + itemstatus, CurrentItemTextPos, Color.White);
			CurrentItemTextPos.Y = CurrentItemTextPos.Y + GameProperties.DefaultFont.MeasureString(ShopMessage).Y;
			spriteBatch.DrawString(GameProperties.DefaultFont, ShopMessage, CurrentItemTextPos, Color.White);
		}
	}
}
