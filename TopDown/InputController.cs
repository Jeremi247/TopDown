using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace TopDown
{   //Controls all game inputs
    class InputController
    {
        public static Boolean IsLeftMouseButtonHeld = false;
        private static Boolean IsEscButtonHeld = false;
        private static Boolean IsSpaceButtonHeld = false;
        private static int framesPassed = 0;

        //Clears variables. Called on the start of the new game
        public static void Clear()
        {
            IsLeftMouseButtonHeld = false;
            IsEscButtonHeld = false;
            framesPassed = 0;
        }

        //Base class called by UpdateController.
        public static void ManageInputs(GameTime gameTime)
        {
            var mouse = Mouse.GetState();
            var keyboard = Keyboard.GetState();

            MouseController(mouse);
            CharacterController(keyboard);
            OtherFunctions(keyboard);
        }

        //Gets all buttons usage that are useful and can not be assigned to any category
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

        //Controls the input that moves the character. For information about each character move function go to Player class
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

            //Checks if Escape key is pressed and ignores if is held
            if (keyboard.IsKeyDown(Keys.Escape) && !IsEscButtonHeld)
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

        //Controls the mouse input
        private static void MouseController(MouseState mouse)
        {
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
            }
        }

        //Returns current position of the cursor
        public static Vector2 GetMousePosition()
        {
            Vector2 mousePosition = Vector2.Zero;

            mousePosition = Mouse.GetState().Position.ToVector2();

            return mousePosition;
        }
    }
}
