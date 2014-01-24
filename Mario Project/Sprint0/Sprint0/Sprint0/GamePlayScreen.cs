using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;

namespace MarioProject
{
    public class GamePlayScreen
    {
        private Game1 game;

        IController keyboardController;
        public ICommand commandSet;
        public Mario mario;
        public Texture2D texture;
        public Texture2D items;
        public Texture2D itemsObjects;
        public Texture2D textureEnemy;
        public Texture2D deadEnemy;
        public Texture2D background;
        public Texture2D grenadeTexture;
        public SpriteFactory factory = new SpriteFactory();
        public Collision collider;
        public Stopwatch stopwatch = new Stopwatch();
        public Vector2 currentLocation = new Vector2(100, 510);
        public List<Keys> keysPressed = new List<Keys>();
        public int damageTakenCounter = 0;
        public int score = 0;
        public int time;
        public int totalCoins;
        public Rectangle flagCollide;
        int newSize = 0;
        bool playing = false;
        bool underWorld = false;
        public bool endgame = false;
        public bool newLevel = false;
        public bool isActive { get; set; }
        public int oldstate;
       

        public int lives = 3;
        public LivesLeft livesLEFT;

        public HUD hud;
        SpriteBatch hudSpriteBatch;
        KeyboardState OldKeyState;
        Boolean pause = false;
        public int flagStage = 0;
        public int castleLocation;
        FlagAnimation ending;

        public List<IProjectile> projectiles = new List<IProjectile>();
        public LevelManager levelMgr;
        public SoundManager soundMgr;

        public int grenades;

        public GamePlayScreen(Game1 game)
        {
            this.game = game;
            collider = new Collision(game);
            levelMgr = new LevelManager();
            soundMgr = new SoundManager();
            commandSet = new CommandSet();
            keyboardController = new KeyboardController();

            texture = game.Content.Load<Texture2D>("smb_mario_sheet");
            items = game.Content.Load<Texture2D>("items");
            itemsObjects = game.Content.Load<Texture2D>("itemsObjects");
            grenadeTexture = game.Content.Load<Texture2D>("grenade");
            textureEnemy = game.Content.Load<Texture2D>("enemies");
            deadEnemy = game.Content.Load<Texture2D>("deadenemy");
            background = game.Content.Load<Texture2D>("1-1");
            
            MediaPlayer.IsRepeating = true;

            hudSpriteBatch = new SpriteBatch(game.GraphicsDevice);
            hud = new HUD(itemsObjects,game);
            hud.HudFont = game.Content.Load<SpriteFont>("hudFont");

            livesLEFT = new LivesLeft(texture);
            livesLEFT.Lives = lives;
            stopwatch.Start();

            ending = new FlagAnimation();
        }

        public void Update(GameTime gameTime)
        {
            if (flagStage > 0 && flagStage < 7)
            {
                ending.Update(game, gameTime);
                return;
            }
            if (flagStage == 7)
            {
                LoadLevel();
            }
            KeyboardState NewKeyState = Keyboard.GetState();
            if (NewKeyState.IsKeyDown(Keys.P) && OldKeyState.IsKeyUp(Keys.P))
            {
                soundMgr.marioPause.Play();
                if (pause)
                {
                    MediaPlayer.Resume();
                    pause = false;
                    stopwatch.Start();
                }
                else
                {
                    MediaPlayer.Pause();
                    pause = true;
                    stopwatch.Stop();
                }
            }
            else if (NewKeyState.IsKeyDown(Keys.Down) && OldKeyState.IsKeyUp(Keys.Down) && (mario.position.X < 1005 && mario.position.X > 985) && (mario.position.Y < 507 && mario.position.Y > 497))
            {
                soundMgr.marioPipePowerLoss.Play();
                underWorld = true;
                playing = false;

                oldstate = (int)mario.marioSize;

                game.DisplayLives();
                LoadLevel();
            }
            else if (NewKeyState.IsKeyDown(Keys.Right) && OldKeyState.IsKeyUp(Keys.Right) && (mario.position.X < 375 && mario.position.X > 365) && (mario.position.Y < 571 && mario.position.Y > 561) && underWorld)
            {
                soundMgr.marioPipePowerLoss.Play();
                underWorld = false;
                playing = false;

                oldstate = (int)mario.marioSize;

                game.DisplayLives();
                LoadLevel();

            }
           
            OldKeyState = NewKeyState;
            if (pause)
            {
                return;
            }

            int prevSize = (int)mario.marioSize;
            int tempSize = prevSize;
            TimeSpan ts = stopwatch.Elapsed;
            time = 400 - ts.Seconds - ts.Minutes * 60;
            if (time == 100)
            {
                playing = false;
            }
            hud.Update(score, time, totalCoins);
            collisionCheck(gameTime);

            foreach (IProjectile projectile in projectiles.ToList())
            {
                projectile.Update(levelMgr.iStatics, levelMgr.iEnemies);
                livesLEFT.Update(lives);
            }

            if (time == 0)
            {
                mario.marioSize = Mario.size.dead;
                lives--;
            }

            if (mario.marioSize == Mario.size.dead || (mario.position.Y - game.camera.viewPort.Height) > game.camera.viewPort.Height)
            {
                stopwatch.Stop();
                stopwatch.Reset();
                score = 0;
                lives--;
                livesLEFT.Update(lives);
                if (lives < 0)
                {
                    soundMgr.marioGameOver.Play();
                }
                else
                {
                    soundMgr.marioDied.Play();
                }
                underWorld = false;
                endgame = false;
                oldstate = (int)Mario.size.small;
                Unload();
                LoadLevel();
                game.DisplayLives();
                stopwatch.Start();
            }
            if (!(levelMgr.bowser == null))
            {
                levelMgr.bowser.Update(game);
            }
            if (time > 100 && !playing && !underWorld)
            {
                MediaPlayer.Pause();
                MediaPlayer.Play(soundMgr.marioOverworld);
                playing = true;
            }
            else if (time < 100 && !playing && !underWorld)
            {
                MediaPlayer.Pause();
                MediaPlayer.Play(soundMgr.hurryOverworld);
                playing = true;
            }
            else if (time > 100 && !playing && underWorld)
            {
                MediaPlayer.Pause();
                MediaPlayer.Play(soundMgr.marioUnderworld);
                playing = true;
            }
            else if (time < 100 && !playing && underWorld)
            {
                MediaPlayer.Pause();
                MediaPlayer.Play(soundMgr.hurryUnderworld);
                playing = true;
            }
            else if (mario.marioSprite.colorTimer == 1)
            {
                MediaPlayer.Pause();
                MediaPlayer.Play(soundMgr.marioOverworld);
            }
        }

        public void collisionCheck(GameTime gameTime)
        {
            int prevSize = (int)mario.marioSize;
            int tempSize = prevSize;

            if (collider.itemTransition == 0 && collider.enemyTransition == 0)
            {
                keysPressed = keyboardController.Update(game);
                int prevState = (int)mario.marioState;
                foreach (IStatic block in levelMgr.iStatics)
                {
                    if (block.bumped > 5)
                    {
                        block.Bump();
                    }
                    else if (block.bumped > 0)
                    {
                        block.UnBump();
                    }
                }
                commandSet.IComExecute(game, keysPressed);

                if (prevState != (int)mario.marioState || prevSize != (int)mario.marioSize)
                {
                    factory.getMario(game);
                }
                if (mario.position.Y > 700)
                {
                    mario.marioSize = Mario.size.dead;
                }
                mario.marioSprite.Update(gameTime);
                game.camera.Limits = new Rectangle(0, 0, game.camera.viewPort.X, 600);
                game.camera.Update(mario.position);
                collider.MarioEnemy(gameTime, game.camera);                
                collider.MarioItem(gameTime);
                collider.MarioScreen(gameTime);
                if (mario.marioSize == Mario.size.dead)
                {
                    collider.enemyTransition = 3;
                }
            }
            else if (collider.itemTransition % 3 == 0)
            {

                if (newSize == 0)
                {
                    mario.marioSize = Mario.size.small;
                    newSize = tempSize;
                }
                else if (newSize == 1)
                {
                    mario.marioSize = Mario.size.big;
                    newSize = tempSize;
                }
                else if (newSize == 2)
                {
                    mario.marioSize = Mario.size.fire;
                    newSize = 1;
                }

                factory.getMario(game);
            }
            else if (collider.enemyTransition % 3 == 0)
            {
                if (newSize == 0)
                {
                    mario.marioSize = Mario.size.small;
                    newSize = tempSize;
                }
                else if (newSize == 1)
                {
                    mario.marioSize = Mario.size.big;
                    newSize = tempSize;
                }
                else if (newSize == 2)
                {
                    mario.marioSize = Mario.size.fire;
                    newSize = 1;
                }

                factory.getMario(game);
            }

            if (collider.itemTransition > 0)
            {
                collider.itemTransition--;
            }
            else if (collider.enemyTransition > 0)
            {
                collider.enemyTransition--;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (underWorld || newLevel)
            {
                background = game.Content.Load<Texture2D>("black_screen");
                game.GraphicsDevice.Clear(Color.Black);
            }
            else
            {
                background = game.Content.Load<Texture2D>("1-1");
                game.GraphicsDevice.Clear(Color.CornflowerBlue);
            }

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, game.camera.ViewMatrix);
            spriteBatch.Draw(background, new Vector2(0, 330), null, Color.White, 0f, Vector2.Zero, 2.1f, SpriteEffects.None, 0f);
            levelMgr.Draw(spriteBatch);

            if (damageTakenCounter % 2 == 0 && flagStage < 6)
            {
                mario.Draw(spriteBatch);
            }

            foreach (IProjectile projectile in projectiles)
                projectile.Draw(spriteBatch);

            if (!(levelMgr.bowser == null))
            {
                levelMgr.bowser.Draw(spriteBatch);
            }

            spriteBatch.End();

            hudSpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            hud.Draw(hudSpriteBatch);
            hudSpriteBatch.End();
        }

        public void Unload()
        {
            levelMgr.iEnemies = new List<Enemy>();
            levelMgr.iItems = new List<IItem>();
            levelMgr.iStatics = new List<IStatic>();
            levelMgr.iDead = new List<IEnemy>();
            MediaPlayer.Stop();
            playing = false;
        }

        public void LoadLevel()
        {
            game.camera = new Camera(game.GraphicsDevice.Viewport);

            if (endgame)
            {
                    Unload();
                    underWorld = false;
                    levelMgr.Load("EndGame.txt", game);
                    if (oldstate == (int)Mario.size.fire)
                    {
                        mario.marioSize = Mario.size.fire;
                    }
                    else if (oldstate == (int)Mario.size.big)
                    {
                        mario.marioSize = Mario.size.big;
                    }
            }
            else if (underWorld)
            {
                Unload();
                endgame = true;
                levelMgr.Load("UndergroundLevel.txt", game);
                if (oldstate == (int)Mario.size.fire)
                {
                    mario.marioSize = Mario.size.fire;
                }
                else if (oldstate == (int)Mario.size.big)
                {
                    mario.marioSize = Mario.size.big;
                }
            }
            else if (newLevel)
            {
                Unload();
                stopwatch.Restart();
                levelMgr.Load("CustomLevel2.txt", game);
                if (oldstate == (int)Mario.size.fire)
                {
                    mario.marioSize = Mario.size.fire;
                }
                else if (oldstate == (int)Mario.size.big)
                {
                    mario.marioSize = Mario.size.big;
                }
                factory.getMario(game);
            }
            else
            {
                Unload();
                levelMgr.Load("TestLevel.txt", game);
            }
    }
}
}
