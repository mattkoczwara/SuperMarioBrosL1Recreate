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
        public void Update(MarioProject.Game1 game1)
        {
           
            KeyboardState NewKeyState = Keyboard.GetState();

            if (NewKeyState.IsKeyDown(Keys.Q) && OldKeyState.IsKeyUp(Keys.Q))
            {
                // Exits game
                game1.Exit();
            }
            else if (NewKeyState.IsKeyDown(Keys.Y) && OldKeyState.IsKeyUp(Keys.Y))
            {
                // Animate change mario to a small state
                game1.commandSet.IComExecute(game1, 1);
            }
            else if (NewKeyState.IsKeyDown(Keys.U) && OldKeyState.IsKeyUp(Keys.U))
            {
                // Animate change mario to a big state
                game1.commandSet.IComExecute(game1, 2);
             }
            else if (NewKeyState.IsKeyDown(Keys.I) && OldKeyState.IsKeyUp(Keys.I))
            {
                // Animate Fire Mario
                game1.commandSet.IComExecute(game1, 3); 
            }
            else if (NewKeyState.IsKeyDown(Keys.O) && OldKeyState.IsKeyUp(Keys.O))
            {
                // Animate Dead Mario
                game1.commandSet.IComExecute(game1, 4); 
            }
            else if (NewKeyState.IsKeyDown(Keys.Z) && OldKeyState.IsKeyUp(Keys.Z))
            {
                // Animate Question Block
                game1.commandSet.IComExecute(game1, 5); 
            }
            else if (NewKeyState.IsKeyDown(Keys.X) && OldKeyState.IsKeyUp(Keys.X))
            {
                // Animate Used Block
                game1.commandSet.IComExecute(game1, 6); 
            }
            else if (NewKeyState.IsKeyDown(Keys.C) && OldKeyState.IsKeyUp(Keys.C))
            {
                // Animate Brick
                game1.commandSet.IComExecute(game1, 7); 
            }
            else if (NewKeyState.IsKeyDown(Keys.V) && OldKeyState.IsKeyUp(Keys.V))
            {
                // Animate Floor Block
                game1.commandSet.IComExecute(game1, 8); 
            }
            else if (NewKeyState.IsKeyDown(Keys.B) && OldKeyState.IsKeyUp(Keys.B))
            {
                // Animate Stair Block
                game1.commandSet.IComExecute(game1, 9); 
            }
            else if (NewKeyState.IsKeyDown(Keys.N) && OldKeyState.IsKeyUp(Keys.N))
            {
                // Animate Hidden Block
                game1.commandSet.IComExecute(game1, 10); 
            }
            else if (NewKeyState.IsKeyDown(Keys.D) && OldKeyState.IsKeyUp(Keys.D) || NewKeyState.IsKeyDown(Keys.Right) && OldKeyState.IsKeyUp(Keys.Right))
            {
                // Animate moving right
                game1.commandSet.IComExecute(game1, 11); 
            }
            else if (NewKeyState.IsKeyDown(Keys.A) && OldKeyState.IsKeyUp(Keys.A) || NewKeyState.IsKeyDown(Keys.Left) && OldKeyState.IsKeyUp(Keys.Left))
            {
                // Animate moving left
                game1.commandSet.IComExecute(game1, 12);
            }
            else if (NewKeyState.IsKeyDown(Keys.W) && OldKeyState.IsKeyUp(Keys.W) || NewKeyState.IsKeyDown(Keys.Up) && OldKeyState.IsKeyUp(Keys.Up))
            {
                // Animate idle if crouching, jumping if not crouching
                game1.commandSet.IComExecute(game1, 13);
            }
            else if (NewKeyState.IsKeyDown(Keys.S) && OldKeyState.IsKeyUp(Keys.S) || NewKeyState.IsKeyDown(Keys.Down) && OldKeyState.IsKeyUp(Keys.Down))
            {
                // Animate idle if jumping, crouching if not jumping
                game1.commandSet.IComExecute(game1, 14);
            }

            OldKeyState = NewKeyState;
        }
    }
}
