using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MarioProject
{
    public class Collision
    {
        private MarioProject.Game1 game;
        public int itemTransition = 0;
        public int enemyTransition = 0;
        public Boolean itemActivated = false;
        enum collisionLocation { noCollision = 0, left, top, right, bottom };

        public Collision(MarioProject.Game1 gameRef)
        {
            game = gameRef;
        }
        public Vector2 MarioStatic(Vector2 speed)
        {
            Rectangle CheckPos = game.gamePlayScreen.mario.marioSprite.collisionRectangle;
            CheckPos.X += (int)speed.X;
            CheckPos.Y += (int)speed.Y;
            game.gamePlayScreen.mario.marioSprite.collisionRectangle = CheckPos;

            foreach (IProjectile projectile in game.gamePlayScreen.projectiles.ToList())
            {
                int collideSide = game.gamePlayScreen.mario.CollisionChecker(projectile);
                if (projectile is BulletBill)
                {
                    if (collideSide == (int)collisionLocation.top)
                    {
                        game.gamePlayScreen.mario.speed.Y = 0;
                        game.gamePlayScreen.projectiles.Remove(projectile);
                        game.gamePlayScreen.soundMgr.marioBrickSmash.Play();
                    }
                    else if (collideSide != (int)collisionLocation.noCollision)
                    {
                        MarioDamage();
                    }
                }
            }
            foreach (IStatic block in game.gamePlayScreen.levelMgr.iStatics.ToList())
            {
                int collideSide = game.gamePlayScreen.mario.CollisionChecker(block);
                if (collideSide == (int)collisionLocation.bottom)
                {
                    MarioBlockBottom(collideSide, block, out speed);
                    collideSide = game.gamePlayScreen.mario.CollisionChecker(block);
                }
                else if (collideSide == (int)collisionLocation.top )
                {
                    speed.Y = 11;
                    if (game.gamePlayScreen.mario.marioSize == Mario.size.small)
                    {
                        game.gamePlayScreen.mario.position.Y = block.collisionRectangle.Y - game.gamePlayScreen.mario.marioSprite.collisionRectangle.Height;
                    }
                    else
                    {
                        game.gamePlayScreen.mario.position.Y = block.collisionRectangle.Y - 17;
                    }
                    if (game.gamePlayScreen.mario.marioState == Mario.state.jumpingLeft || game.gamePlayScreen.mario.marioState == Mario.state.jumpingRight)
                    {
                        int state = (int)game.gamePlayScreen.mario.marioState % 2;
                        if (state == 0)
                        {
                            game.gamePlayScreen.mario.marioState = Mario.state.standingRight;
                        }
                        else
                        {
                            game.gamePlayScreen.mario.marioState = Mario.state.standingLeft;
                        }
                    }
                    collideSide = game.gamePlayScreen.mario.CollisionChecker(block);
                }
                if (collideSide == (int)collisionLocation.left )
                {
                    speed.X = 0;
                    if (game.gamePlayScreen.mario.marioSize == Mario.size.small)
                    {
                        game.gamePlayScreen.mario.position.X = block.collisionRectangle.X - 26;
                    }
                    else
                    {
                        game.gamePlayScreen.mario.position.X = block.collisionRectangle.X - 23;
                    }
                }
                else if (collideSide == (int)collisionLocation.right )
                {
                    speed.X = 0;
                    if (game.gamePlayScreen.mario.marioSize == Mario.size.small)
                    {
                        game.gamePlayScreen.mario.position.X = block.collisionRectangle.X + 16;
                    }
                    else
                    {
                        game.gamePlayScreen.mario.position.X = block.collisionRectangle.X + 24;
                    }
                }
            }
            return speed;
        }

        private void MarioBlockBottom(int side, IStatic block, out Vector2 speed)
        {
            speed = game.gamePlayScreen.mario.speed;
            if (block is CoinBrickBlock && game.gamePlayScreen.mario.speed.Y < 0)
            {
                CoinBrickBlock coinBlock;
                coinBlock = block as CoinBrickBlock;
                if (coinBlock.coinCount > 0)
                {
                    game.gamePlayScreen.levelMgr.iItems.Add(new CoinsItem(game.gamePlayScreen.itemsObjects, coinBlock.collisionRectangle.X, coinBlock.collisionRectangle.Y, game.gamePlayScreen.soundMgr));
                }
                else
                {
                    game.gamePlayScreen.soundMgr.marioBump.Play();
                }
                block.bumped = 10;
            }

            else if (block is StarBrickBlock && game.gamePlayScreen.mario.speed.Y < 0)
            {
                StarBrickBlock starBlock;
                starBlock = block as StarBrickBlock;
                if (!starBlock.hit)
                {
                    game.gamePlayScreen.soundMgr.itemAppears.Play();
                    game.gamePlayScreen.levelMgr.iItems.Add(new StarItem(game.gamePlayScreen.itemsObjects, starBlock.collisionRectangle.X, starBlock.collisionRectangle.Y));
                }
                block.bumped = 10;
            }

            if (!(game.gamePlayScreen.mario.marioSize == Mario.size.small && block is BrickBlock) && game.gamePlayScreen.mario.speed.Y < 0)
            {
                foreach (Enemy enemy in game.gamePlayScreen.levelMgr.iEnemies.ToList())
                {
                    BlockEnemy(block, enemy);
                }
                if (block is BrickBlock)
                {
                    game.gamePlayScreen.hud.ScoreUpdate(50);
                    game.gamePlayScreen.soundMgr.marioBrickSmash.Play();
                    game.gamePlayScreen.levelMgr.iStatics.Remove(block);                    
                    return;
                }
                block.Update();
            }
            else if (game.gamePlayScreen.mario.speed.Y < 0)
            {
                game.gamePlayScreen.soundMgr.marioBump.Play();
                block.bumped = 10;
                block.isBumping = true;
                block.Bump();
            }

            if (block.state)
            {
                if (game.gamePlayScreen.mario.marioSize == Mario.size.small)
                {
                    speed.Y = 3;
                    game.gamePlayScreen.soundMgr.marioBump.Play();

                }
                else
                {
                    game.gamePlayScreen.mario.position.Y = block.collisionRectangle.Y + 35;
                    speed.Y = 0;
                }
            }
        }

        public void MarioEnemy(GameTime gameTime, Camera camera)
        {
            foreach (IEnemy dead in game.gamePlayScreen.levelMgr.iDead)
            {
                dead.Update(gameTime);
                if (dead.collisionRectangle.Y > 750)
                {
                    game.gamePlayScreen.levelMgr.iDead.Remove(dead);
                    break;
                }
            }
            foreach (Enemy enemy in game.gamePlayScreen.levelMgr.iEnemies)
            {
                if (enemy.position.X < game.camera.position.X - 30)
                {
                    game.gamePlayScreen.levelMgr.iEnemies.Remove(enemy);
                    break;
                }
                if (enemy.enemySprite is DeadGoomba)
                {
                    enemy.deadCount--;
                    if (enemy.deadCount == 0)
                    {
                        game.gamePlayScreen.levelMgr.iEnemies.Remove(enemy);
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (enemy.position.X < camera.position.X + camera.viewPort.Width + 30)
                {
                    enemy.UpdateSprite(gameTime, game.gamePlayScreen.mario, game.gamePlayScreen.levelMgr.iStatics, game.gamePlayScreen.levelMgr.iEnemies, game.gamePlayScreen.levelMgr.iDead, game.gamePlayScreen.deadEnemy);
                }
                int collideSide = game.gamePlayScreen.mario.CollisionChecker(enemy.enemySprite);
                if (enemy.enemySprite is KoopaShellSprite)
                {
                    int check = game.gamePlayScreen.levelMgr.iEnemies.Count;
                    enemy.speed = enemy.shellCollide(enemy.speed, game.gamePlayScreen.mario, game.gamePlayScreen.levelMgr.iStatics, game.gamePlayScreen.levelMgr.iEnemies, game.gamePlayScreen.levelMgr.iDead, game.gamePlayScreen.deadEnemy);


                    if (check != game.gamePlayScreen.levelMgr.iEnemies.Count)
                    {
                        game.gamePlayScreen.hud.ScoreUpdate(100 * enemy.killCount);
                        break;
                    }
                }
                if (game.gamePlayScreen.damageTakenCounter == 0)
                {
                    if ((collideSide != (int)collisionLocation.noCollision) && (game.gamePlayScreen.mario.marioSprite.colorTimer > 0))
                    {
                        game.gamePlayScreen.soundMgr.marioKick.Play();
                        int speed, type;
                        speed = (int)game.gamePlayScreen.mario.speed.X;
                        if (enemy.enemySprite is GoombaMovingSprite)
                        {
                            type = 1;
                        }
                        else
                        {
                            type = 2;
                        }
                        IEnemy dead = new SpecialDeadEnemy(game.gamePlayScreen.deadEnemy, speed, type);
                        dead.collisionRectangle = enemy.enemySprite.collisionRectangle;
                        game.gamePlayScreen.levelMgr.iDead.Add(dead);
                        game.gamePlayScreen.levelMgr.iEnemies.Remove(enemy);
                        game.gamePlayScreen.hud.ScoreUpdate(200);
                        break;
                    }
                    else if (collideSide == (int)collisionLocation.top)
                    {
                        game.gamePlayScreen.commandSet.jumpCount += 1;
                        if (game.gamePlayScreen.commandSet.jumpCount > 6)
                        {
                            game.gamePlayScreen.soundMgr.itemOneUp.Play();
                            game.gamePlayScreen.lives++;
                        }
                        if (enemy.enemySprite is KoopaMovingLeftSprite || enemy.enemySprite is KoopaMovingRightSprite || enemy.enemySprite is KoopaRevive)
                        {
                            game.gamePlayScreen.soundMgr.marioStomp.Play();
                            Rectangle temp = enemy.enemySprite.collisionRectangle;
                            enemy.enemySprite = new KoopaShellSprite(game.gamePlayScreen.textureEnemy, 11, 12);
                            enemy.enemySprite.collisionRectangle = temp;
                            enemy.speed.X = 0;
                            enemy.deadCount = 1000;
                            game.gamePlayScreen.mario.speed.Y = -6;
                            game.gamePlayScreen.hud.ScoreUpdate(200 * game.gamePlayScreen.commandSet.jumpCount);
                        }
                        else if (enemy.enemySprite is KoopaShellSprite)
                        {
                            enemy.speed.X = 0;
                            game.gamePlayScreen.hud.ScoreUpdate(200 * game.gamePlayScreen.commandSet.jumpCount);
                        }
                        else
                        {
                            game.gamePlayScreen.soundMgr.marioStomp.Play();
                            Enemy goomba = new Enemy(game.gamePlayScreen.textureEnemy, new Vector2(enemy.enemySprite.collisionRectangle.X, enemy.enemySprite.collisionRectangle.Y), new DeadGoomba(game.gamePlayScreen.textureEnemy, 8, 15), game.gamePlayScreen.soundMgr);
                            goomba.enemySprite.collisionRectangle = enemy.enemySprite.collisionRectangle;
                            goomba.deadCount = 4;
                            game.gamePlayScreen.levelMgr.iEnemies.Add(goomba);
                            game.gamePlayScreen.levelMgr.iEnemies.Remove(enemy);
                            game.gamePlayScreen.mario.speed.Y = -6;
                            game.gamePlayScreen.hud.ScoreUpdate(200 * game.gamePlayScreen.commandSet.jumpCount);
                            break;

                        }
                    }
                    else if (!(collideSide == (int)collisionLocation.noCollision) && enemy.speed.X != 0 && enemy.canKill == 0)
                    {
                        MarioDamage();
                    }
                }
                else
                {
                    game.gamePlayScreen.damageTakenCounter--;
                }
            }
        }

        public void MarioDamage()
        {
            if (game.gamePlayScreen.mario.marioSize == Mario.size.fire)
            {
                game.gamePlayScreen.soundMgr.marioPipePowerLoss.Play();
                enemyTransition = 31;
                game.gamePlayScreen.mario.marioSize = Mario.size.small;
                game.gamePlayScreen.factory.getMario(game);
                game.gamePlayScreen.damageTakenCounter = 2000;
            }
            else if (game.gamePlayScreen.mario.marioSize == Mario.size.big)
            {
                game.gamePlayScreen.soundMgr.marioPipePowerLoss.Play();
                enemyTransition = 31;
                game.gamePlayScreen.mario.marioSize = Mario.size.small;
                game.gamePlayScreen.factory.getMario(game);
                game.gamePlayScreen.damageTakenCounter = 2000;
            }
            else
            {
                game.gamePlayScreen.mario.marioSize = Mario.size.dead;
                game.gamePlayScreen.factory.getMario(game);
            }
        }

        public void MarioItem(GameTime gameTime)
        {
            foreach (IItem item in game.gamePlayScreen.levelMgr.iItems.ToList())
            {
                int star = game.gamePlayScreen.mario.marioSprite.colorTimer;
                int collision = game.gamePlayScreen.mario.CollisionChecker(item);
                if (collision != (int)collisionLocation.noCollision && item is Flag)
                {
                    game.gamePlayScreen.flagStage = 1;
                    game.gamePlayScreen.flagCollide = item.collisionRectangle;
                    return;
                }
                if (collision == (int)collisionLocation.bottom && !item.itemActivated)
                {
                    item.ItemBump();
                }
                else if ((collision != (int)collisionLocation.noCollision) && item.itemActivated && item.isConsumable && (game.gamePlayScreen.mario.speed.Y > 0))
                {
                    if ((item is FloatingCoin) && !(game.gamePlayScreen.mario.marioSize == Mario.size.dead))
                    {
                        game.gamePlayScreen.hud.CoinTotalUpdate();
                        game.gamePlayScreen.hud.ScoreUpdate(200);
                        game.gamePlayScreen.soundMgr.itemCoin.Play();
                        game.gamePlayScreen.levelMgr.iItems.Remove(item);
                    }
                }
                else if ((collision != (int)collisionLocation.noCollision) && item.itemActivated && item.isConsumable && !(game.gamePlayScreen.mario.speed.Y > 0))
                {
                    if ((item is FireFlowerItem) && !(game.gamePlayScreen.mario.marioSize == Mario.size.dead))
                    {
                        if ((int)game.gamePlayScreen.mario.marioSize < 2)
                        {
                            itemTransition = 31;
                        }
                        game.gamePlayScreen.soundMgr.itemPowerUp.Play();
                        if (game.gamePlayScreen.mario.marioSize == Mario.size.small)
                        {
                            game.gamePlayScreen.mario.marioSize = Mario.size.big;
                        }
                        else
                        {
                            game.gamePlayScreen.mario.marioSize = Mario.size.fire;
                        }
                        game.gamePlayScreen.factory.getMario(game);
                        game.gamePlayScreen.mario.marioSprite.colorTimer = star;
                        game.gamePlayScreen.hud.ScoreUpdate(1000);
                    }
                    else if ((item is GrenadeItem) && !(game.gamePlayScreen.mario.marioSize == Mario.size.dead))
                    {
                        game.gamePlayScreen.grenades++;
                        game.gamePlayScreen.soundMgr.itemPowerUp.Play();
                        game.gamePlayScreen.hud.ScoreUpdate(1000);
                    }
                    else if ((item is PowerMushroomItem) && !(game.gamePlayScreen.mario.marioSize == Mario.size.fire) && !(game.gamePlayScreen.mario.marioSize == Mario.size.dead))
                    {
                        if ((int)game.gamePlayScreen.mario.marioSize < 1)
                        {
                            itemTransition = 31;
                        }
                        game.gamePlayScreen.soundMgr.itemPowerUp.Play();
                        game.gamePlayScreen.mario.marioSize = Mario.size.big;
                        game.gamePlayScreen.factory.getMario(game);
                        game.gamePlayScreen.mario.marioSprite.colorTimer = star;
                        game.gamePlayScreen.hud.ScoreUpdate(1000);
                    }
                    else if ((item is OneUpMushroomItem) && !(game.gamePlayScreen.mario.marioSize == Mario.size.dead))
                    {
                        game.gamePlayScreen.soundMgr.itemOneUp.Play();
                        game.gamePlayScreen.lives++;
                        game.gamePlayScreen.hud.ScoreUpdate(1000);
                    }
                    else if ((item is CoinsItem || item is FloatingCoin) && !(game.gamePlayScreen.mario.marioSize == Mario.size.dead))
                    {
                        game.gamePlayScreen.hud.CoinTotalUpdate();
                        game.gamePlayScreen.hud.ScoreUpdate(200);
                    }
                    else if ((item is StarItem) && !(game.gamePlayScreen.mario.marioSize == Mario.size.dead))
                    {
                        MediaPlayer.Pause();
                        MediaPlayer.Play(game.gamePlayScreen.soundMgr.marioStarpower);
                        game.gamePlayScreen.mario.marioSprite.colorTimer = 1000;
                        game.gamePlayScreen.hud.ScoreUpdate(1000);
                    }
                    item.itemActivated = false;
                    game.gamePlayScreen.levelMgr.iItems.Remove(item);
                }
                item.Update(gameTime, game.gamePlayScreen.levelMgr.iStatics);
            }
        }

        public void MarioScreen(GameTime gameTime)
        {
            if (game.gamePlayScreen.mario.position.X < game.camera.position.X - 10)
            {
                game.gamePlayScreen.mario.position.X = game.camera.position.X - 10;
            }
        }

        public void BlockEnemy(IStatic block, Enemy enemy)
        {
            Rectangle temp = new Rectangle((int)enemy.position.X, (int)enemy.position.Y, 20, 20);

            if (block.collisionRectangle.Intersects(enemy.enemySprite.collisionRectangle))
            {
                game.gamePlayScreen.soundMgr.marioBrickSmash.Play();
                int speed, type;
                speed = (int)game.gamePlayScreen.mario.speed.X;
                if (enemy.enemySprite is GoombaMovingSprite)
                {
                    type = 1;
                }
                else
                {
                    type = 2;
                }
                IEnemy dead = new SpecialDeadEnemy(game.gamePlayScreen.deadEnemy, speed, type);
                dead.collisionRectangle = enemy.enemySprite.collisionRectangle;
                game.gamePlayScreen.levelMgr.iDead.Add(dead);
                game.gamePlayScreen.levelMgr.iEnemies.Remove(enemy);
                game.gamePlayScreen.hud.ScoreUpdate(200);
            }
        }
    }
}

