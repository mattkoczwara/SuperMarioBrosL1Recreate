using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;


namespace MarioProject
{
    public class KeyboardController : IController
    {
        /// <summary>
        /// Gets the current state of the controller and passes an int to CommandSet based on which key is being pressed
        /// </summary>
        /// <returns></returns>
        KeyboardState OldKeyState;

        public List<Keys> Update(MarioProject.Game1 game1)
        {
            List<Keys> keysPressed = new List<Keys>();
            KeyboardState NewKeyState = Keyboard.GetState();

            if (NewKeyState.IsKeyDown(Keys.Q))
            {
                keysPressed.Add(Keys.Q);
            }

            if (NewKeyState.IsKeyDown(Keys.D))
            {
                keysPressed.Add(Keys.D);
            }

            if (NewKeyState.IsKeyDown(Keys.Right))
            {
                keysPressed.Add(Keys.Right);
            }

            if (NewKeyState.IsKeyDown(Keys.A))
            {
                keysPressed.Add(Keys.A);
            }

            if (NewKeyState.IsKeyDown(Keys.Left))
            {
                keysPressed.Add(Keys.Left);
            }

            if (NewKeyState.IsKeyDown(Keys.W))
            {
                keysPressed.Add(Keys.W);
            }

            if (NewKeyState.IsKeyDown(Keys.Up))
            {
                keysPressed.Add(Keys.Up);
            }

            if (NewKeyState.IsKeyDown(Keys.S))
            {
                keysPressed.Add(Keys.S);
            }

            if (NewKeyState.IsKeyDown(Keys.Down))
            {
                keysPressed.Add(Keys.Down);
            }

            if (NewKeyState.IsKeyDown(Keys.Space))
            {
                keysPressed.Add(Keys.Space);
            }

            if (NewKeyState.IsKeyDown(Keys.F))
            {
                keysPressed.Add(Keys.F);
            }

            if (NewKeyState.IsKeyDown(Keys.B))
            {
                keysPressed.Add(Keys.B);
            }

            OldKeyState = NewKeyState;

            return keysPressed;
        }
    }
}
