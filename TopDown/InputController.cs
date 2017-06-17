using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace TopDown
{
    class InputController
    {
        public static Boolean IsLeftMouseButtonHeld = false;
        private static Boolean IsEscButtonHeld = false;
        private static Boolean IsSpaceButtonHeld = false;
		public static Boolean IsLeftMouseButtonPressed = false;
        private static int framesPassed = 0;
		private static MouseState lastMouseState;
		private static MouseState currentMouseState;


		public static void Clear()
        {
			IsLeftMouseButtonPressed = false;
            IsLeftMouseButtonHeld = false;
            IsEscButtonHeld = false;
            framesPassed = 0;
        }

        public static void ManageInputs(GameTime gameTime)
        {
            var mouse = Mouse.GetState();
            var keyboard = Keyboard.GetState();

            MouseController(mouse);
            CharacterController(keyboard);
            OtherFunctions(keyboard);
        }

        private static void OtherFunctions(KeyboardState keyboard)
        {
            if(GameStateController.GetGameState() == GameStateController.States.Gameplay)
            {
                if (keyboard.IsKeyDown(Keys.Space) && !IsSpaceButtonHeld)
                {
                    GameStateController.SetGameState(GameStateController.States.Pause);
                    IsSpaceButtonHeld = true;
                }
            }
            else if(GameStateController.GetGameState() == GameStateController.States.Pause)
            {
                if (keyboard.IsKeyDown(Keys.Space) && !IsSpaceButtonHeld)
                {
                    GameStateController.SetGameState(GameStateController.States.Gameplay);
                    IsSpaceButtonHeld = true;
                }
            }

            if (keyboard.IsKeyUp(Keys.Space))
            {
                IsSpaceButtonHeld = false;
            }
        }

        private static void CharacterController(KeyboardState keyboard)
        {
            if (keyboard.IsKeyDown(Keys.W) || keyboard.IsKeyDown(Keys.Up))
            {
                Actors.Character.MoveUp();
            }

            if (keyboard.IsKeyDown(Keys.S) || keyboard.IsKeyDown(Keys.Down))
            {
                Actors.Character.MoveDown();
            }

            if (keyboard.IsKeyDown(Keys.A) || keyboard.IsKeyDown(Keys.Left))
            {
                Actors.Character.MoveLeft();
            }

            if (keyboard.IsKeyDown(Keys.D) || keyboard.IsKeyDown(Keys.Right))
            {
                Actors.Character.MoveRight();
            }

            if (keyboard.IsKeyDown(Keys.LeftShift))
            {
                Actors.Character.speedMultiplayer = 0.3f;
            }

            if (keyboard.IsKeyUp(Keys.LeftShift))
            {
                Actors.Character.speedMultiplayer = 1f;
            }
			if (keyboard.IsKeyDown(Keys.C) && keyboard.IsKeyDown(Keys.L))
			{
				Coin.Add(10);
			}
			if (keyboard.IsKeyDown(Keys.G))
			{
				//Abilities.Minigun.ApplyAbility();
				WeaponRegister.executeAbility(Abilities.Minigun.id);
			}
			if (keyboard.IsKeyDown(Keys.F))
			{
				Abilities.BlastPulse.ApplyAbility();
			}
            if (keyboard.IsKeyDown(Keys.Escape) && !IsEscButtonHeld && Program.game.IsActive)
            {
                IsEscButtonHeld = true;
                if(GameStateController.IsInProgress && GameStateController.GetGameState() == GameStateController.States.Menu)
                {
                    GameStateController.SetGameState(GameStateController.States.Gameplay);
                }
                else if(GameStateController.GetGameState() != GameStateController.States.Menu)
                {
                    GameStateController.SetGameState(GameStateController.States.Menu);
                }
            }

            if (keyboard.IsKeyUp(Keys.Escape))
            {
                IsEscButtonHeld = false;
            }
        }

        private static void MouseController(MouseState mouse)
        {
			// The active state from the last frame is now old
			lastMouseState = currentMouseState;

			// Get the mouse state relevant for this frame
			currentMouseState = Mouse.GetState();

			// Recognize a single click of the left mouse button
			if (lastMouseState.LeftButton == ButtonState.Released && currentMouseState.LeftButton == ButtonState.Pressed)
			{
				// React to the click
				IsLeftMouseButtonPressed = true;
			}
			else
			{
				IsLeftMouseButtonPressed = false;
			}
			if (mouse.LeftButton == ButtonState.Pressed)
			{
				if (framesPassed > 0)
				{
					IsLeftMouseButtonHeld = true;
				}
				else
				{
					framesPassed += 1;
				}

				if (GameStateController.GetGameState() == GameStateController.States.Gameplay)
				{
					Actors.Character.Shoot();
				}
			}
			else
			{
				framesPassed = 0;
				IsLeftMouseButtonHeld = false;
				IsLeftMouseButtonPressed = false;
			}
        }

        public static Vector2 GetMousePosition()
        {
            Vector2 mousePosition = Vector2.Zero;

            mousePosition = Mouse.GetState().Position.ToVector2();

            return mousePosition;
        }
    }
}
