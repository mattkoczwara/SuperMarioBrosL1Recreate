using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;


namespace MarioProject
{
    public class CommandSet : ICommand
    {
        // size = {0, 1, 2}{small, big, fire}
        // state = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14}{idleright, idleleft, runright, runleft, jumpright, jumpleft,
        //      crouchright, crouchleft, dead, questionBlock, usedBlock, hiddenBlock, brickBlock, stairBlock, floorBlock}
        int size = 0;
        int state = 0;
        SpriteFactory sprites = new SpriteFactory();

        public void IComExecute(MarioProject.Game1 game1, int command)
        {
            int oldsize = size;
            int oldstate = state;

            if (command == 1)
            {
                size = 0;
                if (state == 8)
                {
                    state = 0;
                }
            }
            else if (command == 2)
            {
                size = 1;
                if (state == 8)
                {
                    state = 0;
                }
            }
            else if (command == 3)
            {
                size = 2;
                if (state == 8)
                {
                    state = 0;
                }
            }
            else if (command == 4)
            {
                state = 8;
            }
            else if (command == 5)
            {
                // Question Block
                game1.iBlocks[1].Update();
            }
            else if (command == 6)
            {
                // Used Block
                game1.iBlocks[5].Update();
            }
            else if (command == 7)
            {
                // Brick Block
                game1.iBlocks[4].Update();
            }
            else if (command == 8)
            {
                // Floor Block
                game1.iBlocks[3].Update();
            }
            else if (command == 9)
            {
                // Stair Block
                game1.iBlocks[2].Update();
            }
            else if (command == 10)
            {
                // Hidden Block
                game1.iBlocks[0].Update();
            }
            else if (command == 11)
            {
                if (state == 0)
                {
                    state = 2;
                }
                else
                {
                    state = 0;
                }
            }
            else if (command == 12)
            {
                if (state == 1)
                {
                    state = 3;
                }
                else
                {
                    state = 1;
                }
            }
            else if (command == 13)
            {
                //if crouching then idle, else jumping
                if (state == 6)
                {
                    state = 0;
                }
                else if (state == 7)
                {
                    state = 1;
                }
                else if (state == 0 || state == 2)
                {
                    state = 4;
                }
                else if (state == 1 || state == 3)
                {
                    state = 5;
                }
            }
            else if (command == 14)
            {
                // if idle then jumping, else crouching
                if (state == 4)
                {
                    state = 0;
                }
                else if (state == 5)
                {
                    state = 1;
                }
                else if (state % 2 == 0)
                {
                    state = 6;
                }
                else
                {
                    state = 7;
                }
            }

            if (oldstate != state || oldsize != size)
            {
                sprites.getMario(game1, size, state);
            }
        }
    }
}