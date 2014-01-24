using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioProject
{
    public class HUD
    {
        private Game1 game;

        public SpriteFont HudFont { get; set; }
        public int Score { get; set; }
        public int Time { get; set; }
        public int TotalCoins { get; set; }
        public Texture2D HudCoinTexture { get; set; }

        private Vector2 marioPos = new Vector2(200, 95);
        private Vector2 marioScorePos = new Vector2(200, 108);
        private Vector2 worldPos = new Vector2(450, 95);
        private Vector2 worldNumberPos = new Vector2(462, 108);
        private Vector2 timePos = new Vector2(550, 95);
        private Vector2 timeNumberPos = new Vector2(550, 108);
        private Vector2 coinsPos = new Vector2(335, 108);
        int speedCounter, currentFrame;

        public HUD(Texture2D texture, Game1 game)
        {
            this.game = game;
            HudCoinTexture = texture;
        }


        public void Update(int score, int time, int totalCoins)
        {
            Time = time;
            CoinUpdate();
        }

        public void CoinUpdate()
        {
            speedCounter++;
            if (speedCounter % 11 == 0)
            {
                currentFrame++;

                if (currentFrame > 3)
                {
                    currentFrame = 0;
                }
            }
        }

        public void ScoreUpdate(int amount)
        {
            Score += amount;
        }

        public void CoinTotalUpdate()
        {
            TotalCoins++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = 16;
            int frameAdjust = width * currentFrame;

            spriteBatch.DrawString(HudFont, "MARIO", marioPos, Color.WhiteSmoke);
            spriteBatch.DrawString(HudFont, Score.ToString(), marioScorePos, Color.WhiteSmoke);
            spriteBatch.DrawString(HudFont, "WORLD", worldPos, Color.WhiteSmoke);
            if (game.gamePlayScreen.newLevel == false)
            {
                spriteBatch.DrawString(HudFont, "1 - 1", worldNumberPos, Color.White);
            }
            else
            {
                spriteBatch.DrawString(HudFont, "1 - 2", worldNumberPos, Color.White);
            }
            spriteBatch.DrawString(HudFont, "TIME", timePos, Color.WhiteSmoke);
            spriteBatch.DrawString(HudFont, Time.ToString(), timeNumberPos, Color.WhiteSmoke);

            Rectangle sourceRectangle = new Rectangle(0 + frameAdjust, 82, 14, 14);
            Rectangle destinationRectangle = new Rectangle(320, 108, 15, 15);
            spriteBatch.Draw(HudCoinTexture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.DrawString(HudFont, " x " + TotalCoins.ToString(), coinsPos, Color.WhiteSmoke);
        }
    }
}
