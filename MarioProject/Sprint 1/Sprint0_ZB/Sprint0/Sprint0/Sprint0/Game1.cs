using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MarioProject
{
    /// <summary>
    /// This is the main type for your game
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
        IController keyboardController;
        public ICommand commandSet;
        public IMarioState mario;
        public Texture2D texture;
        Texture2D items;
        Texture2D large;
        Vector2 currentLocation = new Vector2(375, 200);
        public List<IBlockState> iBlocks = new List<IBlockState>();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            commandSet = new CommandSet();
            keyboardController = new KeyboardController();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("smb_mario_sheet");
            items = Content.Load<Texture2D>("items");
            mario = new SmallMarioStandingRightSprite(texture, 11, 12);
            iBlocks.Add(new HiddenBlock(items, 20, 20));
            iBlocks.Add(new QuestionBlock(items, 60, 20));
            iBlocks.Add(new StairBlock(items, 100, 20));
            iBlocks.Add(new FloorBlock(items, 140, 20));
            iBlocks.Add(new BrickBlock(items, 180, 20));
            iBlocks.Add(new UsedBlock(items, 220, 20));
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            //get user input
            keyboardController.Update(this);
            
            mario.Update();

            this.Draw(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            mario.Draw(spriteBatch, currentLocation);
            foreach (IBlockState block in iBlocks)
            {
                block.Draw(spriteBatch);
            }
            
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
