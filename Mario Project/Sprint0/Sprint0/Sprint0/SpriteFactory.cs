using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    public class SpriteFactory
    {
        public void getMario(MarioProject.Game1 game1)
        {
            int star;
            if (game1.gamePlayScreen.mario != null)
            {
                star = game1.gamePlayScreen.mario.marioSprite.colorTimer;
            }
            else
            {
                star = 0;
            }
            
            if (game1.gamePlayScreen.mario.marioSize == Mario.size.small && game1.gamePlayScreen.mario.marioState == Mario.state.standingRight)
            {
                game1.gamePlayScreen.mario.marioSprite = new SmallMarioStandingRightSprite(game1.gamePlayScreen.texture, 11, 12);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.small && game1.gamePlayScreen.mario.marioState == Mario.state.standingLeft)
            {
                game1.gamePlayScreen.mario.marioSprite = new SmallMarioStandingLeftSprite(game1.gamePlayScreen.texture, 11, 12);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.small && game1.gamePlayScreen.mario.marioState == Mario.state.runningRight)
            {
                game1.gamePlayScreen.mario.marioSprite = new SmallMarioRunningRightSprite(game1.gamePlayScreen.texture, 11, 12);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.small && game1.gamePlayScreen.mario.marioState == Mario.state.runningLeft)
            {
                game1.gamePlayScreen.mario.marioSprite = new SmallMarioRunningLeftSprite(game1.gamePlayScreen.texture, 11, 12);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.small && game1.gamePlayScreen.mario.marioState == Mario.state.jumpingRight)
            {
                game1.gamePlayScreen.mario.marioSprite = new SmallMarioJumpingRightSprite(game1.gamePlayScreen.texture, 11, 12);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.small && game1.gamePlayScreen.mario.marioState == Mario.state.jumpingLeft)
            {
                game1.gamePlayScreen.mario.marioSprite = new SmallMarioJumpingLeftSprite(game1.gamePlayScreen.texture, 11, 12);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.small && game1.gamePlayScreen.mario.marioState == Mario.state.slidingRight)
            {
                game1.gamePlayScreen.mario.marioSprite = new SmallMarioSlidingRightSprite(game1.gamePlayScreen.texture, 11, 12);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.small && game1.gamePlayScreen.mario.marioState == Mario.state.slidingLeft)
            {
                game1.gamePlayScreen.mario.marioSprite = new SmallMarioSlidingLeftSprite(game1.gamePlayScreen.texture, 11, 12);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.big && game1.gamePlayScreen.mario.marioState == Mario.state.standingRight)
            {
                game1.gamePlayScreen.mario.marioSprite = new LargeMarioStandingRightSprite(game1.gamePlayScreen.texture, 2, 14);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.big && game1.gamePlayScreen.mario.marioState == Mario.state.standingLeft)
            {
                game1.gamePlayScreen.mario.marioSprite = new LargeMarioStandingLeftSprite(game1.gamePlayScreen.texture, 2, 14);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.big && game1.gamePlayScreen.mario.marioState == Mario.state.runningRight)
            {
                game1.gamePlayScreen.mario.marioSprite = new LargeMarioRunningRightSprite(game1.gamePlayScreen.texture, 2, 14);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.big && game1.gamePlayScreen.mario.marioState == Mario.state.runningLeft)
            {
                game1.gamePlayScreen.mario.marioSprite = new LargeMarioRunningLeftSprite(game1.gamePlayScreen.texture, 2, 14);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.big && game1.gamePlayScreen.mario.marioState == Mario.state.jumpingRight)
            {
                game1.gamePlayScreen.mario.marioSprite = new LargeMarioJumpingRightSprite(game1.gamePlayScreen.texture, 2, 15);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.big && game1.gamePlayScreen.mario.marioState == Mario.state.jumpingLeft)
            {
                game1.gamePlayScreen.mario.marioSprite = new LargeMarioJumpingLeftSprite(game1.gamePlayScreen.texture, 2, 15);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.big && game1.gamePlayScreen.mario.marioState == Mario.state.crouchingRight)
            {
                game1.gamePlayScreen.mario.marioSprite = new LargeMarioCrouchingRightSprite(game1.gamePlayScreen.texture, 2, 15);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.big && game1.gamePlayScreen.mario.marioState == Mario.state.crouchingLeft)
            {
                game1.gamePlayScreen.mario.marioSprite = new LargeMarioCrouchingLeftSprite(game1.gamePlayScreen.texture, 2, 15);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.big && game1.gamePlayScreen.mario.marioState == Mario.state.slidingLeft)
            {
                game1.gamePlayScreen.mario.marioSprite = new LargeMarioSlidingLeftSprite(game1.gamePlayScreen.texture, 2, 15);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.big && game1.gamePlayScreen.mario.marioState == Mario.state.slidingRight)
            {
                game1.gamePlayScreen.mario.marioSprite = new LargeMarioSlidingRightSprite(game1.gamePlayScreen.texture, 2, 15);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.fire && game1.gamePlayScreen.mario.marioState == Mario.state.standingRight)
            {
                game1.gamePlayScreen.mario.marioSprite = new FireMarioStandingRightSprite(game1.gamePlayScreen.texture, 6, 16);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.fire && game1.gamePlayScreen.mario.marioState == Mario.state.standingLeft)
            {
                game1.gamePlayScreen.mario.marioSprite = new FireMarioStandingLeftSprite(game1.gamePlayScreen.texture, 6, 16);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.fire && game1.gamePlayScreen.mario.marioState == Mario.state.runningRight)
            {
                game1.gamePlayScreen.mario.marioSprite = new FireMarioRunningRightSprite(game1.gamePlayScreen.texture, 6, 16);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.fire && game1.gamePlayScreen.mario.marioState == Mario.state.runningLeft)
            {
                game1.gamePlayScreen.mario.marioSprite = new FireMarioRunningLeftSprite(game1.gamePlayScreen.texture, 6, 16);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.fire && game1.gamePlayScreen.mario.marioState == Mario.state.jumpingRight)
            {
                game1.gamePlayScreen.mario.marioSprite = new FireMarioJumpingRightSprite(game1.gamePlayScreen.texture, 6, 16);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.fire && game1.gamePlayScreen.mario.marioState == Mario.state.jumpingLeft)
            {
                game1.gamePlayScreen.mario.marioSprite = new FireMarioJumpingLeftSprite(game1.gamePlayScreen.texture, 6, 16);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.fire && game1.gamePlayScreen.mario.marioState == Mario.state.crouchingRight)
            {
                game1.gamePlayScreen.mario.marioSprite = new FireMarioCrouchingRightSprite(game1.gamePlayScreen.texture, 6, 16);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.fire && game1.gamePlayScreen.mario.marioState == Mario.state.crouchingLeft)
            {
                game1.gamePlayScreen.mario.marioSprite = new FireMarioCrouchingLeftSprite(game1.gamePlayScreen.texture, 6, 16);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.fire && game1.gamePlayScreen.mario.marioState == Mario.state.slidingLeft)
            {
                game1.gamePlayScreen.mario.marioSprite = new FireMarioSlidingLeftSprite(game1.gamePlayScreen.texture, 6, 16);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.fire && game1.gamePlayScreen.mario.marioState == Mario.state.slidingRight)
            {
                game1.gamePlayScreen.mario.marioSprite = new FireMarioSlidingRightSprite(game1.gamePlayScreen.texture, 6, 16);
            }

            if (game1.gamePlayScreen.mario.marioSize == Mario.size.dead)
            {
                game1.gamePlayScreen.mario.marioSprite = new DeadMarioSprite(game1.gamePlayScreen.texture, 5, 14);
            }
            game1.gamePlayScreen.mario.marioSprite.colorTimer = star;
        }
    }
}
