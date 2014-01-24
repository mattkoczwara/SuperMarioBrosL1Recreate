using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    public class LevelManager
    {
        public List<IStatic> iStatics = new List<IStatic>();
        public List<IItem> iItems = new List<IItem>();
        public List<Enemy> iEnemies = new List<Enemy>();
        public List<IEnemy> iDead = new List<IEnemy>();
        public Bowser bowser;
        public int projectileCounter;

        public void Load(string levelFile, Game1 game)
        {
            game.gamePlayScreen.flagStage = 0;
            game.gamePlayScreen.soundMgr.Load(game);
            int pipeCount = 0;
            List<string> levelData = new List<string>();
            string data = "";
            Stream stream = TitleContainer.OpenStream(levelFile);
            StreamReader reader = new StreamReader(stream);
            int lineCount = 0;
            while (!reader.EndOfStream)
            {
                data = reader.ReadLine();
                levelData.Add(data);
            }
            int pos = levelData.Count();
            lineCount = pos;
            while (pos > 0)
            {
                int colCount = 0;
                data = levelData[pos - 1];
                foreach (char reference in data)
                {
                    if (reference == 'L')
                    {
                        iStatics.Add(new FloorBlock(game.gamePlayScreen.items, colCount * 20, (lineCount * 18)-3));
                        iStatics.Add(new FloorBlock(game.gamePlayScreen.items, colCount * 20, lineCount * 18 + 15));
                    }
                    else if (reference == 'I')
                    {
                        iStatics.Add(new HiddenBlock(game.gamePlayScreen.items, colCount * 20, lineCount * 17 + 5));
                    }
                    else if (reference == 'Q')
                    {
                        iStatics.Add(new QuestionBlock(game.gamePlayScreen.items, colCount * 20, lineCount * 17 + 5));
                    }
                    else if (reference == 'B')
                    {
                        iStatics.Add(new BrickBlock(game.gamePlayScreen.items, colCount * 20, lineCount * 17 + 5));
                    }
                    else if (reference == 'E')
                    {
                        iStatics.Add(new StairBlock(game.gamePlayScreen.items, colCount * 20, lineCount * 18 -4));
                    }
                    else if (reference == 'V')
                    {
                        iStatics.Add(new CoinBrickBlock(game.gamePlayScreen.items, colCount * 20, lineCount * 17 + 5));
                    }
                    else if (reference == 'T')
                    {
                        iStatics.Add(new StarBrickBlock(game.gamePlayScreen.items, colCount * 20, lineCount * 17 + 5));
                    }
                    else if (reference == 'M')
                    {
                        game.gamePlayScreen.mario = new Mario(game.gamePlayScreen.texture, game.gamePlayScreen.currentLocation);
                    }
                    else if (reference == '>')
                    {
                        iStatics.Add(new PipeSpace(new Vector2(colCount * 20 - 4, 0)));
                    }
                    else if (reference == '?')
                    {
                        iStatics.Add(new SidePipe(game.gamePlayScreen.items, 1, new Vector2(colCount * 20 - 4, lineCount * 17 + 7)));
                    }
                    else if (reference == 'P')
                    {
                        if (pipeCount == 0 || pipeCount == 4 || pipeCount == 5)
                        {
                            iStatics.Add(new Pipe(game.gamePlayScreen.items, 1, new Vector2(colCount * 20, lineCount * 17 + 3)));
                        }
                        else if (pipeCount == 1)
                        {
                            iStatics.Add(new Pipe(game.gamePlayScreen.items, 2, new Vector2(colCount * 20, (lineCount * 17) - 12)));
                        }
                        else if (pipeCount == 2 || pipeCount == 3)
                        {
                            iStatics.Add(new Pipe(game.gamePlayScreen.items, 3, new Vector2(colCount * 20, lineCount * 16 + 6)));
                        }
                        pipeCount++;
                    }
                    else if (reference == 'G')
                    {
                        GoombaMovingSprite goomba = new GoombaMovingSprite(game.gamePlayScreen.textureEnemy, 8, 15);
                        Rectangle goombaLocation = new Rectangle(colCount * 20, lineCount * 17, 20, 20);
                        goomba.collisionRectangle = goombaLocation;
                        iEnemies.Add(new Enemy(game.gamePlayScreen.textureEnemy, new Vector2(colCount * 20, lineCount * 17), goomba, game.gamePlayScreen.soundMgr));
                    }
                    else if (reference == 'H')
                    {
                        KoopaShellSprite shell = new KoopaShellSprite(game.gamePlayScreen.textureEnemy, 11, 12);
                        Rectangle shellLocation = new Rectangle(colCount * 20, lineCount * 17, 20, 20);
                        shell.collisionRectangle = shellLocation;
                        iEnemies.Add(new Enemy(game.gamePlayScreen.textureEnemy, new Vector2(colCount * 20, lineCount * 17), shell, game.gamePlayScreen.soundMgr));
                    }
                    else if (reference == 'K')
                    {
                        KoopaMovingLeftSprite koopaLeft = new KoopaMovingLeftSprite(game.gamePlayScreen.textureEnemy, 11, 12);
                        Rectangle koopaLeftLocation = new Rectangle(colCount * 20, lineCount * 17, 20, 20);
                        koopaLeft.collisionRectangle = koopaLeftLocation;
                        iEnemies.Add(new Enemy(game.gamePlayScreen.textureEnemy, new Vector2(colCount * 20, lineCount * 17), koopaLeft, game.gamePlayScreen.soundMgr));
                    }
                    else if (reference == 'S')
                    {
                        iItems.Add(new StarItem(game.gamePlayScreen.itemsObjects, colCount * 20, lineCount * 18));
                    }
                    else if (reference == 'C')
                    {
                        iItems.Add(new CoinsItem(game.gamePlayScreen.itemsObjects, colCount * 20, lineCount * 18, game.gamePlayScreen.soundMgr));
                    }
                    else if (reference == 'X')
                    {
                        iItems.Add(new FloatingCoin(game.gamePlayScreen.itemsObjects, colCount * 20, lineCount * 18));
                    }
                    else if (reference == 'R')
                    {
                        iItems.Add(new PowerMushroomItem(game.gamePlayScreen.itemsObjects, colCount * 20, lineCount * 18, game.gamePlayScreen.soundMgr));
                    }
                    else if (reference == 'O')
                    {
                        iItems.Add(new OneUpMushroomItem(game.gamePlayScreen.itemsObjects, colCount * 20, lineCount * 18, game.gamePlayScreen.soundMgr));
                    }
                    else if (reference == 'F')
                    {
                        iItems.Add(new FireFlowerItem(game.gamePlayScreen.itemsObjects, colCount * 20, lineCount * 18, game.gamePlayScreen.soundMgr));
                    }
                    else if (reference == 'A')
                    {
                        iItems.Add(new Castle(game.gamePlayScreen.items, colCount * 20, lineCount * 16 + 3));
                        game.gamePlayScreen.castleLocation = colCount * 20;
                    }
                    else if (reference == 'Z')
                    {
                        iItems.Add(new Flag(game.gamePlayScreen.items, colCount * 20, lineCount * 13 + 6));
                    }
                    else if (reference == '#')
                    {
                        bowser = new Bowser(game.gamePlayScreen.textureEnemy, new Vector2(colCount * 20, lineCount * 18));
                    }
                    else if (reference == '5')
                    {
                        iItems.Add(new GrenadeItem(game.gamePlayScreen.grenadeTexture, colCount * 20, lineCount * 18, game.gamePlayScreen.soundMgr));
                    }

                    else if (reference == 'U')
                    {
                        BulletBlaster bullet = new BulletBlaster(game.gamePlayScreen.deadEnemy, new Vector2(colCount * 20, lineCount * 17 + 17));
                        iStatics.Add(bullet);
                    }
                    else if (reference == '$')
                    {
                        BulletBill bulletBill = new BulletBill(game.gamePlayScreen.deadEnemy, new Vector2(colCount * 20, lineCount * 17));
                        game.gamePlayScreen.projectiles.Add(bulletBill);
                    }
                    colCount++;
                }
                pos--;
                lineCount--;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IItem item in iItems)
            {
               if(item.itemActivated)
                    item.Draw(spriteBatch);
            }
            foreach (IStatic block in iStatics)
            {
                block.Draw(spriteBatch, new Vector2(block.collisionRectangle.X, block.collisionRectangle.Y));
            }
            foreach (Enemy enemy in iEnemies)
            {
                enemy.DrawSprite(spriteBatch);
            }
            foreach (IEnemy enemy2 in iDead)
            {
                enemy2.Draw(spriteBatch, new Vector2(enemy2.collisionRectangle.X, enemy2.collisionRectangle.Y));
            }
        }
    }
    
}
