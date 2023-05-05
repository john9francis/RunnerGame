using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnerGame
{
    public class Keyboard1
    {
        static KeyboardState currentKeyState;
        static KeyboardState previousKeyState;

        public static KeyboardState CheckKey()
        {
            previousKeyState = currentKeyState;
            currentKeyState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            return currentKeyState;
        }

        public static bool ActivateContinually(Keys key)
        {
            return currentKeyState.IsKeyDown(key);
        }

        public static bool ActivateOnce(Keys key)
        {
            return currentKeyState.IsKeyDown(key) && !previousKeyState.IsKeyDown(key);
        }
    }
}
