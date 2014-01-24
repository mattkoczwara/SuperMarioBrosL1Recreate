using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MarioProject
{
    public class DeadScreen
    {
        private Texture2D texture;
        private Game1 game;
        private KeyboardState lastState;
        public bool isActive { get; set; }
        public Mario mario;
        public Texture2D itemsObjects;
        public Texture2D stationaryMario;
        public Texture2D grenadeTexture;
        HUD hud;
        SpriteBatch hudSpriteBatch;
        SpriteBatch livesSpriteBatch;
        int timer = 0;
        public DeadScreen(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("black_screen");
            itemsObjects = game.Content.Load<Texture2D>("itemsObjects");
            stationaryMario = game.Content.Load<Texture2D>("smb_mario_sheet");
            grenadeTexture = game.Content.Load<Texture2D>("grenade");

            lastState = Keyboard.GetState();
            isActive = true;

            hudSpriteBatch = new SpriteBatch(game.GraphicsDevice);
            hud = new HUD(itemsObjects,game);
            hud.HudFont = game.Content.Load<SpriteFont>("hudFont");

            livesSpriteBatch = new SpriteBatch(game.GraphicsDevice);
            game.gamePlayScreen.livesLEFT.LivesFont = game.Content.Load<SpriteFont>("hudFont");
        }

        public void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            timer++;
            if (timer == 80)
            {
                timer = 0;
                if (game.gamePlayScreen.lives < 0)
                {
                    game.Exit();
                }
                game.StartGame();
            }
            if (keyboardState.IsKeyDown(Keys.Q) && lastState.IsKeyUp(Keys.Q))
            {
                game.Exit();
            }

            lastState = keyboardState;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if (texture != null)
                spriteBatch.Draw(texture, new Vector2(0f, 0f), Color.White);
            spriteBatch.End();

            hudSpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            hud.Draw(hudSpriteBatch);
            hudSpriteBatch.End();

            livesSpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            game.gamePlayScreen.livesLEFT.Draw(livesSpriteBatch);
            livesSpriteBatch.End();
        }
    }
}