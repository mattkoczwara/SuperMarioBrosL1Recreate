using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioProject
{
    public class Fireball : IProjectile
    {
        public Rectangle collisionRectangle { get; set; }
        //public Boolean hasHit { get; set; }
        public int currentFrameX, currentFrameY, currentX, currentY, counter, caseSwitch, explodeCaseSwitch, speedCounter;
        public bool explodeHit, enemyHit, sequenceDone;
        Texture2D fireballTexture;
        Vector2 position;
        Vector2 speed;
        private Game1 mainGame;

        public Fireball(Texture2D texture, int x, int y, int direction, Game1 game)
        {
            position.X = x;
            position.Y = y;
            fireballTexture = texture;
            speed = new Vector2(4 * direction, 1);
            mainGame = game;
        }

        public void Update(List<IStatic> blocks, List<Enemy> enemies)
        {
            AnimationUpdate();
            speed = Collide(speed, blocks, enemies);
            position += speed;
            if (speed.Y < 5 && !explodeHit)
            {
                speed.Y++;
            }
        }

        private void AnimationUpdate()
        {
            if ((speedCounter % 4 == 0) && (!explodeHit))
            {
                caseSwitch = counter % 4;
                switch (caseSwitch)
                {
                    case 0:
                        currentFrameX = 0;
                        currentFrameY = 0;
                        break;
                    case 1:
                        currentFrameX = 8;
                        currentFrameY = 0;
                        break;
                    case 2:
                        currentFrameX = 0;
                        currentFrameY = 8;
                        break;
                    case 3:
                        currentFrameX = 8;
                        currentFrameY = 8;
                        break;
                }
                counter++;
            }
            else if (speedCounter % 4 == 0)
            {
                switch (explodeCaseSwitch)
                {
                    case 1:
                        currentX = 0;
                        currentY = 16;
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
        }

        public void Draw(SpriteBatch spriteBatch)
        {           
            if (!explodeHit)
            {
                Rectangle destinationRectangle = new Rectangle((int)position.X, ((int)position.Y), 8, 8);
                spriteBatch.Draw(fireballTexture, destinationRectangle, new Rectangle(96 + currentFrameX, 144 + currentFrameY, 8, 8), Color.White);
                collisionRectangle = destinationRectangle;
            }
            else
            {
                Rectangle destinationRectangle = new Rectangle((int)position.X - 2, ((int)position.Y), 16, 16);
                spriteBatch.Draw(fireballTexture, destinationRectangle, new Rectangle(112 + currentX, 144 + currentY, 16, 16), Color.White);
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
                    mainGame.gamePlayScreen.projectiles.Remove(this);             
                }
            }
            foreach (IStatic block in blocks.ToList())
            {
                  Rectangle intersect = Rectangle.Intersect(block.collisionRectangle, collisionRectangle);
                    if (intersect.Height <= 7 && !intersect.IsEmpty)
                    {
                        speed.Y = -5;
                        //position.Y = position.Y - speed.Y; 
                    }
                    else if (!intersect.IsEmpty)
                    {
                        speed.X = 0;
                        speed.Y = 0;
                        explodeHit = true;
                        if(sequenceDone)
                            mainGame.gamePlayScreen.projectiles.Remove(this);
                    }
                }
                return speed;
        }
    }
}
