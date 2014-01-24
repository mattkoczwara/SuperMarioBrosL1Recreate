using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MarioProject
{
    public class CommandSet : ICommand
    {
        List<Keys> lastKeysPressed = new List<Keys>();

        public int jumpCount { get; set; }
        Vector2 speed;
        int maxSpeed = 3;
        int jumpcheck = 10;
        public int projectileTimer;

        public void IComExecute(MarioProject.Game1 game1, List<Keys> keysPressed)
        {
            if (keysPressed.Contains(Keys.Space))
            {
                maxSpeed = 5;
            }
            else
            {
                maxSpeed = 3;
            }
            speed = game1.gamePlayScreen.mario.speed;
            if (keysPressed.Contains(Keys.W)  || keysPressed.Contains(Keys.Up))
            {
                moveMarioUp(game1);
            }
            else if (keysPressed.Contains(Keys.S) || keysPressed.Contains(Keys.Down))
            {
                moveMarioDown(game1);
            }
            else if (game1.gamePlayScreen.mario.marioState == Mario.state.jumpingLeft || game1.gamePlayScreen.mario.marioState == Mario.state.jumpingRight)
            {
                jumpcheck = 0;
            }
            if ((keysPressed.Contains(Keys.D) || keysPressed.Contains(Keys.Right)) && (!keysPressed.Contains(Keys.S) && !keysPressed.Contains(Keys.Down)))
            {
                moveMarioRight(game1);
            }
            else if ((keysPressed.Contains(Keys.A) || keysPressed.Contains(Keys.Left)) && (!keysPressed.Contains(Keys.S) && !keysPressed.Contains(Keys.Down)))
            {
                moveMarioLeft(game1);
            }
            else
            {
                if (speed.X > 0)
                {
                    speed.X = speed.X - (float)0.2;
                }
                else if (speed.X < 0)
                {
                    speed.X = speed.X + (float)0.2;
                }
            }
            if (keysPressed.Contains(Keys.Q))
            {
                game1.Exit();
            }
            if (keysPressed.Contains(Keys.Space))
            {
                if ((projectileTimer == 0) && (game1.gamePlayScreen.mario.marioSize == Mario.size.fire))
                {
                    game1.gamePlayScreen.soundMgr.marioFireball.Play();
                    Fireball fireball;
                    if ((int)game1.gamePlayScreen.mario.marioState % 2 == 1)
                    {
                        fireball = new Fireball(game1.gamePlayScreen.itemsObjects, (int)game1.gamePlayScreen.mario.position.X, (int)game1.gamePlayScreen.mario.position.Y, -1, game1);
                    }
                    else
                    {
                        fireball = new Fireball(game1.gamePlayScreen.itemsObjects, (int)game1.gamePlayScreen.mario.position.X + 25, (int)game1.gamePlayScreen.mario.position.Y, 1, game1);
                    }
                    game1.gamePlayScreen.projectiles.Add(fireball);
                    projectileTimer = 30;
                }
            }

            if (keysPressed.Contains(Keys.B))
            {
                if ((projectileTimer == 0) && (game1.gamePlayScreen.grenades > 0))
                {
                    game1.gamePlayScreen.grenades--;
                    game1.gamePlayScreen.soundMgr.marioFireball.Play();
                    Grenade grenade;
                    if ((int)game1.gamePlayScreen.mario.marioState % 2 == 1)
                    {
                        grenade = new Grenade(game1.gamePlayScreen.grenadeTexture, game1.gamePlayScreen.itemsObjects, (int)game1.gamePlayScreen.mario.position.X, (int)game1.gamePlayScreen.mario.position.Y, -1, game1);
                    }
                    else
                    {
                        grenade = new Grenade(game1.gamePlayScreen.grenadeTexture, game1.gamePlayScreen.itemsObjects, (int)game1.gamePlayScreen.mario.position.X + 25, (int)game1.gamePlayScreen.mario.position.Y, 1, game1);
                    }
                    game1.gamePlayScreen.projectiles.Add(grenade);
                    projectileTimer = 30;
                }
            }

            if (projectileTimer > 0)
                projectileTimer--;

            if (keysPressed.Count == 0)
            {
                if (game1.gamePlayScreen.mario.marioState != Mario.state.jumpingLeft && game1.gamePlayScreen.mario.marioState != Mario.state.jumpingRight)
                {
                    int state = (int)game1.gamePlayScreen.mario.marioState % 2;
                    if (state == 0)
                    {
                        game1.gamePlayScreen.mario.marioState = Mario.state.standingRight;
                    }
                    else
                    {
                        game1.gamePlayScreen.mario.marioState = Mario.state.standingLeft;
                    }
                }
            }
            
            if (speed.Y < 10)
            {
                speed.Y++;
            }
            lastKeysPressed = keysPressed;
            speed = game1.gamePlayScreen.collider.MarioStatic(speed);
            if (speed.Y == 11)
            {
                jumpcheck = 10;
                speed.Y = 0;
                jumpCount = 0;
            }
            game1.gamePlayScreen.mario.speed = speed;
            game1.gamePlayScreen.mario.position.X += (int)speed.X;
            game1.gamePlayScreen.mario.position.Y += (int)speed.Y;
        }
        public void moveMarioLeft(MarioProject.Game1 game1)
        {
            if (game1.gamePlayScreen.mario.marioState != Mario.state.jumpingLeft && game1.gamePlayScreen.mario.marioState != Mario.state.jumpingRight)
            {               
                game1.gamePlayScreen.mario.marioState = Mario.state.runningLeft;                
            }
            else
            {
                game1.gamePlayScreen.mario.marioState = Mario.state.jumpingLeft;
            }
            if ((game1.gamePlayScreen.mario.marioState == Mario.state.runningLeft || game1.gamePlayScreen.mario.marioState == Mario.state.runningRight) && speed.X > 0)
            {
                game1.gamePlayScreen.mario.marioState = Mario.state.slidingLeft;
            }
            if (game1.gamePlayScreen.mario.marioSize != Mario.size.dead)
            {
                if (speed.X > maxSpeed * -1)
                {
                    speed.X = speed.X - (float)0.2;
                }
                else
                {
                    speed.X = maxSpeed * -1;
                }
            }
        }

        public void moveMarioRight(MarioProject.Game1 game1)
        {
            if (game1.gamePlayScreen.mario.marioState != Mario.state.jumpingLeft && game1.gamePlayScreen.mario.marioState != Mario.state.jumpingRight)
            {
                game1.gamePlayScreen.mario.marioState = Mario.state.runningRight;
            }
            else
            {
                game1.gamePlayScreen.mario.marioState = Mario.state.jumpingRight;
            }
            if ((game1.gamePlayScreen.mario.marioState == Mario.state.runningLeft || game1.gamePlayScreen.mario.marioState == Mario.state.runningRight) && speed.X < 0)
            {
                game1.gamePlayScreen.mario.marioState = Mario.state.slidingRight;
            }
            if (game1.gamePlayScreen.mario.marioSize != Mario.size.dead)
            {
                if (speed.X < maxSpeed)
                {
                    speed.X = speed.X + (float)0.2;
                }
                else
                {
                    speed.X = maxSpeed;
                }
            }
        }

        public void moveMarioUp(MarioProject.Game1 game1)
        {

            int state = (int)game1.gamePlayScreen.mario.marioState % 2;
            if (state == 0)
            {
                game1.gamePlayScreen.mario.marioState = Mario.state.jumpingRight;
            }
            else
            {
                game1.gamePlayScreen.mario.marioState = Mario.state.jumpingLeft;
            }
            if (game1.gamePlayScreen.mario.marioSize != Mario.size.dead)
            {
                if (jumpcheck > 0)
                {
                    speed.Y -= 2;
                    jumpcheck--;
                    if (game1.gamePlayScreen.mario.marioSize == Mario.size.small)
                    {
                        game1.gamePlayScreen.soundMgr.marioSmallJumpInstance.Play();
                    }
                    else
                    {
                        game1.gamePlayScreen.soundMgr.marioBigJumpInstance.Play();
                    }
                }
            }
        }

        public void moveMarioDown(MarioProject.Game1 game1)
        {
            int state = (int)game1.gamePlayScreen.mario.marioState % 2;
            if (state == 0 && game1.gamePlayScreen.mario.marioSize != Mario.size.small)
            {
                game1.gamePlayScreen.mario.marioState = Mario.state.crouchingRight;
            }
            else if (game1.gamePlayScreen.mario.marioSize != Mario.size.small)
            {
                game1.gamePlayScreen.mario.marioState = Mario.state.crouchingLeft;
            }
            else if (state == 0)
            {
                game1.gamePlayScreen.mario.marioState = Mario.state.standingRight;
            }
            else
            {
                game1.gamePlayScreen.mario.marioState = Mario.state.standingLeft;
            }
            if (speed.X > 0)
            {
                speed.X--;
            }
            else if (speed.X < 0)
            {
                speed.X++;
            }
        }
    }
}