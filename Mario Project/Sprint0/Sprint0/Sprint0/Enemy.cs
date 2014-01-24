using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MarioProject
{
    public class Enemy : IEnemy
    {
        public IEnemy enemySprite;
        public Vector2 speed;
        public Vector2 position;
        public int deadCount { get; set; }
        public int canKill;
        public int killCount;
        public Rectangle collisionRectangle { get; set; }
        Texture2D texture;
        SoundManager soundMgr;

        public Enemy(Texture2D Texture, Vector2 Position, IEnemy enemy, SoundManager sound)
        {
            texture = Texture;
            position = Position;
            collisionRectangle = enemy.collisionRectangle;
            enemySprite = enemy;
            soundMgr = sound;
            killCount = 0;

            if (!(enemy is KoopaShellSprite))
            {
                speed = new Vector2(-1, 0);
            }
            else
            {
                deadCount = 1000;
            }
        }

        public void Update(GameTime gameTime)
        {
            enemySprite.Update(gameTime);
        }

        public void UpdateSprite(GameTime theGameTime, Mario mario, List<IStatic> blocks, List<Enemy> enemies, List<IEnemy> deadEnemies, Texture2D textureDead)
        {
            Update(theGameTime);
            if (speed.X == 0)
            {
                canKill = 10;
            }
            else if (canKill > 0)
            {
                canKill--;
            }
            if (!(enemySprite is KoopaShellSprite) && !(enemySprite is KoopaRevive))
            {
                if (speed.Y < 10)
                {
                    speed.Y++;
                }
                speed = collide(speed, mario, blocks, enemies, deadEnemies, textureDead);
            }
            else if (speed.X == 0)
            {
                deadCount--;
                if (deadCount == 0)
                {
                    Rectangle temp = enemySprite.collisionRectangle;
                    enemySprite = new KoopaMovingLeftSprite(texture, 11, 12);
                    speed.X = -1;
                    enemySprite.collisionRectangle = temp;
                }
                else if (deadCount == 200)
                {
                    Rectangle temp = enemySprite.collisionRectangle;
                    enemySprite = new KoopaRevive(texture, 11, 12);
                    enemySprite.collisionRectangle = temp;
                }
            }
            else
            {
                deadCount = 1000;
            }
            position += speed;
        }

        public void DrawSprite(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, position);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            enemySprite.Draw(spriteBatch, position);
        }

        private Vector2 collide(Vector2 speed, Mario mario, List<IStatic> blocks, List<Enemy> enemies, List<IEnemy> deadEnemies, Texture2D textureDead)
        {
            if (enemySprite.collisionRectangle.Intersects(mario.collisionRectangle))
            {
                speed.X = speed.X * -1;
                if (enemySprite is KoopaMovingLeftSprite)
                {
                    Rectangle temp = enemySprite.collisionRectangle;
                    enemySprite = new KoopaMovingRightSprite(texture, 11, 12);
                    enemySprite.collisionRectangle = temp;
                }
                else if (enemySprite is KoopaMovingRightSprite)
                {
                    Rectangle temp = enemySprite.collisionRectangle;
                    enemySprite = new KoopaMovingLeftSprite(texture, 11, 12);
                    enemySprite.collisionRectangle = temp;
                }
            }
            foreach (IStatic block in blocks)
            {
                Rectangle intersect = Rectangle.Intersect(block.collisionRectangle, enemySprite.collisionRectangle);
                if (!intersect.IsEmpty && block.isBumping)
                {
                    if (mario.marioSize == Mario.size.small)
                    {
                        speed.X = speed.X * -1;
                        speed.Y = -8;
                    }
                    else
                    {
                        int type = 1;
                        int speed2 = (int)speed.X;
                        IEnemy dead = new SpecialDeadEnemy(textureDead, speed2, type);
                        dead.collisionRectangle = enemySprite.collisionRectangle;
                        deadEnemies.Add(dead);
                        enemies.Remove(this);
                        break;
                    }
                    block.isBumping = false;
                }
                else if (intersect.Height <= 15 && !intersect.IsEmpty) // top and bottom of item
                {
                    speed.Y = 0;
                }
                else if (!intersect.IsEmpty)//left and right of item
                {
                    speed.X = speed.X * -1;
                    if (enemySprite is KoopaMovingLeftSprite)
                    {
                        Rectangle temp = enemySprite.collisionRectangle;
                        enemySprite = new KoopaMovingRightSprite(texture, 11, 12);
                        enemySprite.collisionRectangle = temp;
                    }
                    else if (enemySprite is KoopaMovingRightSprite)
                    {
                        Rectangle temp = enemySprite.collisionRectangle;
                        enemySprite = new KoopaMovingLeftSprite(texture, 11, 12);
                        enemySprite.collisionRectangle = temp;
                    }
                }
            }
            foreach (Enemy enemy in enemies)
            {
                if (enemy.enemySprite != enemySprite && enemySprite.collisionRectangle.Intersects(enemy.enemySprite.collisionRectangle))
                {
                    speed.X = speed.X * -1;
                    if (enemySprite is KoopaMovingLeftSprite)
                    {
                        Rectangle temp = enemySprite.collisionRectangle;
                        enemySprite = new KoopaMovingRightSprite(texture, 11, 12);
                        enemySprite.collisionRectangle = temp;
                    }
                    else if (enemySprite is KoopaMovingRightSprite)
                    {
                        Rectangle temp = enemySprite.collisionRectangle;
                        enemySprite = new KoopaMovingLeftSprite(texture, 11, 12);
                        enemySprite.collisionRectangle = temp;
                    }
                }
            }
            return speed;
        }

        public Vector2 shellCollide(Vector2 speed, Mario mario, List<IStatic> blocks, List<Enemy> enemies, List<IEnemy> deadEnemies, Texture2D textureDead)
        {
            if (enemySprite.collisionRectangle.Intersects(mario.collisionRectangle))
            {
                if (mario.marioSprite.colorTimer > 0)
                {
                    enemies.Remove(this);
                    return speed;
                }
                else
                {
                    Rectangle intersect = Rectangle.Intersect(mario.collisionRectangle, enemySprite.collisionRectangle);
                    if (speed.X == 0)
                    {
                        soundMgr.marioKick.Play();

                        if (enemySprite.collisionRectangle.X == intersect.X) speed.X = 5;
                        else speed.X = -5;
                    }
                    else if (intersect.Height <= 10 && intersect.Y == enemySprite.collisionRectangle.Y)
                    {
                        speed.X = 0;
                    }
                    Rectangle temp = enemySprite.collisionRectangle;
                    enemySprite = new KoopaShellSprite(texture, 11, 12);
                    enemySprite.collisionRectangle = temp;
                }
            }
            foreach (IStatic block in blocks)
            {
                Rectangle intersect = Rectangle.Intersect(block.collisionRectangle, enemySprite.collisionRectangle);
                if (intersect.Height <= 10 && !intersect.IsEmpty)
                {
                    speed.Y = 0;
                }
                else if (!intersect.IsEmpty)
                {
                    if (speed.X > 0)
                    {
                        position.X = block.collisionRectangle.X - enemySprite.collisionRectangle.Width;
                    }
                    else
                    {
                        position.X = block.collisionRectangle.X + block.collisionRectangle.Width;
                    }
                    speed.X = speed.X * -1;
                }
            }
            foreach (Enemy enemy in enemies)
            {
                if (enemy.enemySprite != enemySprite && enemySprite.collisionRectangle.Intersects(enemy.enemySprite.collisionRectangle) && speed.X != 0)
                {
                    soundMgr.marioKick.Play();

                    int type;
                    int speed2 = (int)speed.X;
                    if (enemy.enemySprite is GoombaMovingSprite)
                    {
                        type = 1;
                    }
                    else
                    {
                        type = 2;
                    }                 
                    
                    IEnemy dead = new SpecialDeadEnemy(textureDead, speed2, type);
                    dead.collisionRectangle = enemy.enemySprite.collisionRectangle;
                    deadEnemies.Add(dead);
                    enemies.Remove(enemy);
                    killCount++;
                    break;
                }
            }
            return speed;
        }
    }
}
