using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MarioProject
{
    class FlagAnimation
    {
        public LevelManager levelMgr;
        public void Update(MarioProject.Game1 game1, GameTime gameTime)
        {
            levelMgr = new LevelManager();
            MediaPlayer.Pause();
            game1.gamePlayScreen.endgame = false;
            if (game1.gamePlayScreen.flagStage == 1)
            {
                if (game1.gamePlayScreen.mario.collisionRectangle.X < game1.gamePlayScreen.flagCollide.X - 7)
                {
                    game1.gamePlayScreen.mario.position.X += game1.gamePlayScreen.mario.speed.X;
                    game1.gamePlayScreen.mario.collisionRectangle.X = (int)game1.gamePlayScreen.mario.position.X;
                }
                else
                {
                    game1.gamePlayScreen.flagStage = 2;
                    game1.gamePlayScreen.soundMgr.marioFlagSlideInstance.Play();
                }
            }
            else if (game1.gamePlayScreen.flagStage == 2)
            {
                if (game1.gamePlayScreen.mario.collisionRectangle.Y < game1.gamePlayScreen.flagCollide.Y + game1.gamePlayScreen.flagCollide.Height - 45)
                {
                    game1.gamePlayScreen.mario.position.Y += (float)2;
                    game1.gamePlayScreen.mario.collisionRectangle.Y = (int)game1.gamePlayScreen.mario.position.Y;
                    game1.gamePlayScreen.hud.ScoreUpdate(20);
                }
                else
                {
                    game1.gamePlayScreen.mario.position.Y = game1.gamePlayScreen.flagCollide.Y + game1.gamePlayScreen.flagCollide.Height - 45;
                    game1.gamePlayScreen.mario.collisionRectangle.Y = (int)game1.gamePlayScreen.mario.position.Y;
                    game1.gamePlayScreen.flagStage = 3;
                    game1.gamePlayScreen.soundMgr.marioFlagSlideInstance.Pause();
                }
            }
            else if (game1.gamePlayScreen.flagStage == 3)
            {
                game1.gamePlayScreen.mario.marioState = Mario.state.jumpingLeft;
                game1.gamePlayScreen.mario.position.X += 20;
                game1.gamePlayScreen.mario.collisionRectangle.X = (int)game1.gamePlayScreen.mario.position.X;
                game1.gamePlayScreen.flagStage = 4;
                game1.gamePlayScreen.factory.getMario(game1);
            }
            else if (game1.gamePlayScreen.flagStage == 4)
            {
                game1.gamePlayScreen.soundMgr.marioStageClear.Play();
                game1.gamePlayScreen.mario.marioState = Mario.state.runningRight;
                game1.gamePlayScreen.mario.position.X += 10;
                game1.gamePlayScreen.mario.position.Y += 12;
                game1.gamePlayScreen.flagStage = 5;
                game1.gamePlayScreen.factory.getMario(game1);
            }
            else if (game1.gamePlayScreen.flagStage == 5)
            {
                game1.gamePlayScreen.mario.marioSprite.Update(gameTime);
                game1.gamePlayScreen.mario.position.X += (float)0.5;
                game1.gamePlayScreen.mario.collisionRectangle.X += (int)game1.gamePlayScreen.mario.position.X;
                if (game1.gamePlayScreen.mario.position.X >= game1.gamePlayScreen.castleLocation + 22)
                {
                    game1.gamePlayScreen.flagStage = 6;
                }
            }
            else if (game1.gamePlayScreen.flagStage == 6)
            {
                game1.gamePlayScreen.hud.Time -= 1;
                game1.gamePlayScreen.hud.ScoreUpdate(10);
                if (game1.gamePlayScreen.hud.Time == 0)
                {
                    game1.gamePlayScreen.flagStage = 7;
                    game1.gamePlayScreen.oldstate = (int)game1.gamePlayScreen.mario.marioSize;
                    if (game1.gamePlayScreen.newLevel == true)
                    {
                        game1.Exit();
                    }
                    game1.gamePlayScreen.newLevel = true;
                }
            }
        }
    }
}
