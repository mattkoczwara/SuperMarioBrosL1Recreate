using System;
using System.Collections.Generic;
using System.Linq;
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
    public enum Screen
    {
        StartScreen,
        GamePlayScreen,
        DeadScreen
    }

    /// <summary>
    /// Group Member Names:
    /// 1.Zak Bowman
    /// 2.Nicholas Sauber
    /// 3.Jim Barker
    /// 4.Matthew Koczwara
    /// 5.Camoran Shover
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        StartScreen startScreen {get; set;}
        public DeadScreen deadScreen { get; set; }
        public GamePlayScreen gamePlayScreen { get; set; }
        public Screen currentScreen;
        public Camera camera;
        public enum collisionLocation { noCollision = 0, left, top, right, bottom };

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            startScreen = new StartScreen(this);
            gamePlayScreen = new GamePlayScreen(this);
            deadScreen = new DeadScreen(this);
            currentScreen = Screen.StartScreen;
            camera = new Camera(this.GraphicsDevice.Viewport);
            base.LoadContent();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            switch (currentScreen)
            {
                case Screen.StartScreen:
                    if (startScreen.isActive)
                        startScreen.Update();
                    break;
                case Screen.GamePlayScreen:
                    if (gamePlayScreen.isActive)
                        gamePlayScreen.Update(gameTime);
                    break;
                case Screen.DeadScreen:
                    if (deadScreen.isActive)
                        deadScreen.Update();
                    break;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            switch (currentScreen)
            {
                case Screen.StartScreen:
                    if (startScreen.isActive)
                        startScreen.Draw(spriteBatch);
                    break;
                case Screen.GamePlayScreen:
                    if (gamePlayScreen.isActive)
                        gamePlayScreen.Draw(spriteBatch);
                    break;   
                case Screen.DeadScreen:
                    if (deadScreen.isActive)
                        deadScreen.Draw(spriteBatch);
                    break;
            }
            base.Draw(gameTime);
        }

        public void StartGame()
        {
            startScreen.isActive = false;
            gamePlayScreen.isActive = true;
            deadScreen.isActive = false;
            currentScreen = Screen.GamePlayScreen;
            if (!gamePlayScreen.endgame)
            {
                gamePlayScreen.LoadLevel();
            }
            if (!gamePlayScreen.livesLEFT.isInitialized)
            {
                gamePlayScreen.livesLEFT.Lives = 3;
            }
        }

        public void DisplayLives()
        {
            startScreen.isActive = false;
            gamePlayScreen.isActive = false;
            deadScreen.isActive = true;
            currentScreen = Screen.DeadScreen;
        }
    }
}
