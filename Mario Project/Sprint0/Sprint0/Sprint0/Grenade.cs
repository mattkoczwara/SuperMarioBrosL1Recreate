using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioProject
{
    public class Grenade : IProjectile
    {
        public Rectangle collisionRectangle { get; set; }
        public int grenadeTimer, currentFrameX, currentFrameY, currentX, currentY, counter, caseSwitch, explodeCaseSwitch, speedCounter;
        public bool explodeHit, sequenceDone;
        public float rotationAngle;
        Texture2D grenadeTexture, explosionTexture;
        Vector2 position, speed, origin;
        private Game1 mainGame;

        public Grenade(Texture2D texture, Texture2D fireTexture, int x, int y, int direction, Game1 game)
        {
            position.X = x;
            position.Y = y;
            origin.X = texture.Width / 2;
            origin.Y = texture.Height / 2;
            grenadeTexture = texture;
            explosionTexture = fireTexture;
            speed = new Vector2((2 * direction), -20);
            mainGame = game;
            grenadeTimer = 55;
        }

        public void Update(List<IStatic> blocks, List<Enemy> enemies)
        {
            speed = Collide(speed, blocks, enemies);
            position += speed;
            if (speed.Y < 5 && !explodeHit)
            {
                speed.Y++;
            }
            float elapsed = (float)mainGame.TargetElapsedTime.TotalMilliseconds/80;
            rotationAngle += elapsed;
            float circle = MathHelper.Pi * 2;
            rotationAngle = rotationAngle % circle;

            if ((speedCounter % 2 == 0) && ((explodeHit)||(grenadeTimer == 0)))
            {
               
                switch (explodeCaseSwitch)
                {
                    case 1:
                        currentX = 0;
                        currentY = 15;
                        break;
                    case 2:
                        currentX = 0;
                        currentY = 32;
                        sequenceDone = true;
                        break;
                }
                explodeCaseSwitch++;
            }
            speedCounter++;
            grenadeTimer--;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!explodeHit && grenadeTimer != 0)
            {
                Rectangle destinationRectangle = new Rectangle((int)position.X, ((int)position.Y), 20, 20);
                spriteBatch.Draw(grenadeTexture, destinationRectangle, new Rectangle(0, 0, 20, 20), Color.White, rotationAngle, origin, SpriteEffects.None, 0);
                collisionRectangle = destinationRectangle;
            }
            else
            {
                Rectangle destinationRectangle = new Rectangle((int)position.X - 2, ((int)position.Y), 90, 90);
                spriteBatch.Draw(explosionTexture, destinationRectangle, new Rectangle(113 + currentX, 145 + currentY, 17, 14), Color.White);
                collisionRectangle = destinationRectangle;
            }
        }
        
        private Vector2 Collide(Vector2 speed, List<IStatic> blocks, List<Enemy> enemies)
        {
            foreach (Enemy enemy in enemies.ToList())
            {
                Rectangle itemIntersect = Rectangle.Intersect(enemy.enemySprite.collisionRectangle, collisionRectangle);
                if (!itemIntersect.IsEmpty)
                {
                    speed.X = 0;
                    speed.Y = 0;
                    explodeHit = true;

                    int velocity, type;
                    velocity = (int)mainGame.gamePlayScreen.mario.speed.X;
                    if (enemy.enemySprite is GoombaMovingSprite)
                    {
                        type = 1;
                    }
                    else
                    {
                        type = 2;
                    }
                    mainGame.gamePlayScreen.hud.ScoreUpdate(200);
                    IEnemy dead = new SpecialDeadEnemy(mainGame.gamePlayScreen.deadEnemy, velocity, type);
                    dead.collisionRectangle = enemy.enemySprite.collisionRectangle;
                    mainGame.gamePlayScreen.levelMgr.iDead.Add(dead);
                    mainGame.gamePlayScreen.levelMgr.iEnemies.Remove(enemy);
                    mainGame.gamePlayScreen.soundMgr.marioGrenade.Play();
                }
                else if (grenadeTimer == 0)
                {
                    explodeHit = true;
                    speed.X = 0;
                    speed.Y = 0;
                    mainGame.gamePlayScreen.soundMgr.marioGrenade.Play();
                }

                if (sequenceDone)
                {
                    mainGame.gamePlayScreen.projectiles.Remove(this);
                }
            }
            return speed;
        }
    }
}

    
