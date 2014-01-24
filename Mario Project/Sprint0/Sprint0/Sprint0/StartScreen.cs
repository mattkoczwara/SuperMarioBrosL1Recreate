using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MarioProject
{
    public class StartScreen
    {
        private Texture2D texture;
        private Game1 game;
        private KeyboardState lastState;
        public bool isActive { get; set; }

        public StartScreen(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("startScreen");
            lastState = Keyboard.GetState();
            isActive = true;
        }

        public void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Enter) && lastState.IsKeyUp(Keys.Enter))
            {
                game.DisplayLives();
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
            {
                spriteBatch.Draw(texture, new Vector2(0f, 0f), Color.White);
                spriteBatch.DrawString(game.gamePlayScreen.hud.HudFont, "Press ENTER to play\nQ to quit", new Vector2(350,300), Color.WhiteSmoke);
            }
            spriteBatch.End();
        }
    }
}
