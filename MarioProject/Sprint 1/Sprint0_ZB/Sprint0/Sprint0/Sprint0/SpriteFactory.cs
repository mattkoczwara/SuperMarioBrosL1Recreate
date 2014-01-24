using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class SpriteFactory
    {
        public void getMario(MarioProject.Game1 game1, int size, int state)
        {
            if (size == 0 && state == 0)
            {
                game1.mario = new SmallMarioStandingRightSprite(game1.texture, 11, 12);
            }

            if (size == 0 && state == 1)
            {
                game1.mario = new SmallMarioStandingLeftSprite(game1.texture, 11, 12);
            }

            if (size == 0 && state == 2)
            {
                game1.mario = new SmallMarioRunningRightSprite(game1.texture, 11, 12);
            }

            if (size == 0 && state == 3)
            {
                game1.mario = new SmallMarioRunningLeftSprite(game1.texture, 11, 12);
            }

            if (size == 0 && state == 4)
            {
                game1.mario = new SmallMarioJumpingRightSprite(game1.texture, 11, 12);
            }

            if (size == 0 && state == 5)
            {
                game1.mario = new SmallMarioJumpingLeftSprite(game1.texture, 11, 12);
            }

            if (size == 1 && state == 0)
            {
                game1.mario = new LargeMarioStandingRightSprite(game1.texture, 2, 14);
            }

            if (size == 1 && state == 1)
            {
                game1.mario = new LargeMarioStandingLeftSprite(game1.texture, 2, 14);
            }

            if (size == 1 && state == 2)
            {
                game1.mario = new LargeMarioRunningRightSprite(game1.texture, 2, 14);
            }

            if (size == 1 && state == 3)
            {
                game1.mario = new LargeMarioRunningLeftSprite(game1.texture, 2, 14);
            }

            if (size == 1 && state == 4)
            {
                game1.mario = new LargeMarioJumpingRightSprite(game1.texture, 2, 15);
            }

            if (size == 1 && state == 5)
            {
                game1.mario = new LargeMarioJumpingLeftSprite(game1.texture, 2, 15);
            }

            if (size == 1 && state == 6)
            {
                game1.mario = new LargeMarioCrouchingRightSprite(game1.texture, 2, 15);
            }

            if (size == 1 && state == 7)
            {
                game1.mario = new LargeMarioCrouchingLeftSprite(game1.texture, 2, 15);
            }

            if (size == 2 && state == 0)
            {
                game1.mario = new FireMarioStandingRightSprite(game1.texture, 6, 16);
            }

            if (size == 2 && state == 1)
            {
                game1.mario = new FireMarioStandingLeftSprite(game1.texture, 6, 16);
            }

            if (size == 2 && state == 2)
            {
                game1.mario = new FireMarioRunningRightSprite(game1.texture, 6, 16);
            }

            if (size == 2 && state == 3)
            {
                game1.mario = new FireMarioRunningLeftSprite(game1.texture, 6, 16);
            }

            if (size == 2 && state == 4)
            {
                game1.mario = new FireMarioJumpingRightSprite(game1.texture, 6, 16);
            }

            if (size == 2 && state == 5)
            {
                game1.mario = new FireMarioJumpingLeftSprite(game1.texture, 6, 16);
            }

            if (size == 2 && state == 6)
            {
                game1.mario = new FireMarioCrouchingRightSprite(game1.texture, 6, 16);
            }

            if (size == 2 && state == 7)
            {
                game1.mario = new FireMarioCrouchingLeftSprite(game1.texture, 6, 16);
            }

            if (state == 8)
            {
                game1.mario = new DeadMarioSprite(game1.texture, 5, 14);
            }
        }
    }
}
