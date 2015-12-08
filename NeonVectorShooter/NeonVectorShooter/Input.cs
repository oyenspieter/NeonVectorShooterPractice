using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace NeonVectorShooter
{
    static class Input
    {
        private static KeyboardState keyboardState, lastKeyboardState;
        private static MouseState mouseState, lastMouseState;
        private static GamePadState gamepadeState, lastGamepadState;

        private static bool isAimingWithMouse = false;

        public static Vector2 MousePosition { get { return new Vector2(mouseState.X, mouseState.Y); } }

        public static void Update()
        {
            lastKeyboardState = keyboardState;
            lastGamepadState = gamepadeState;
            lastMouseState = mouseState;

            keyboardState = Keyboard.GetState();
            gamepadeState = GamePad.GetState(PlayerIndex.One);
            mouseState = Mouse.GetState();

            // if player pressed one of the arrow key or is using a gamepad to aim, we want to disable mouse aiming.
            // Otherwise, if the player moves the mouse, enable mouse aiming.
            if (new[] { Keys.Left, Keys.Right, Keys.Up, Keys.Down }.Any(x => keyboardState.IsKeyDown(x)) || gamepadeState.ThumbSticks.Right != Vector2.Zero)
                isAimingWithMouse = false;

            else if (MousePosition != new Vector2(lastMouseState.X, lastMouseState.Y))
                isAimingWithMouse = true;
        }

        // Checks if a key was just pressed down
        public static bool WasKeyPressed(Keys key)
        {
            return lastKeyboardState.IsKeyUp(key) && keyboardState.IsKeyDown(key);
        }

        public static bool WasButtonPressed(Buttons button)
        {
            return lastGamepadState.IsButtonUp(button) && lastGamepadState.IsButtonDown(button);
        }

        public static Vector2 GetMovementDirection()
        {
            Vector2 direction = gamepadeState.ThumbSticks.Left;
            direction.Y *= -1; // inverts the y-axis

            if (keyboardState.IsKeyDown(Keys.A))
                direction.X -= 1;
            if (keyboardState.IsKeyDown(Keys.D))
                direction.X += 1;
            if (keyboardState.IsKeyDown(Keys.W))
                direction.Y -= 1;
            if (keyboardState.IsKeyDown(Keys.S))
                direction.Y += 1;

            // Clamp the length of the vector to a maximum of 1
            if (direction.LengthSquared() > 1)
                direction.Normalize();

            return direction;
        }

        public static Vector2 GetAimDirection()
        {
            //TODO
            return Vector2.Zero;
        }


    }
}
