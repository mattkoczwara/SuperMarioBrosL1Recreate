/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MarioProject
{
    class GamepadController : IController
    {
        /// <summary>
        /// Gets the current state of the controller and returns an int based on which button is being pressed
        /// </summary>
        /// <returns>
        /// 0 - if Start was pressed, quitting the game
        /// 1 - if A was pressed, displaying marioRunningRightSprite
        /// 2 - if B was pressed, displaying deadMarioSprite
        /// </returns>
        public void Update(MarioProject.Game1 game1)
        {
            GamePadState state = GamePad.GetState(PlayerIndex.One);
            if (state.IsButtonDown(Buttons.Start))
            {
                //return int value to quit the game
            }
            else if (state.IsButtonDown(Buttons.A))
            {
                //return int value to display marioRunningRightSprite on screen
            }
            else if (state.IsButtonDown(Buttons.B))
            {
                //return int value to display DeadMarioSprite on screen
            }

            //return returnState;
        }
    }
}
*/