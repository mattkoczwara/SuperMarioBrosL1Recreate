using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioProject
{
    public class LivesLeft
    {

        public SpriteFont LivesFont { get; set; }
        public int Lives { get; set; }
        public Texture2D StationaryMarioTexture { get; set; }
        private Vector2 livesPos = new Vector2(400, 300);
        private Vector2 gameOverPos = new Vector2(350, 250);
        public Boolean isInitialized { get; set; }

        public LivesLeft(Texture2D texture)
        {
            StationaryMarioTexture = texture;
            isInitialized = false;
        }


        public void Update(int lives)
        {
            Lives = lives;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            Rectangle sourceRectangle = new Rectangle(210, 0, 15, 15);
            Rectangle destinationRectangle = new Rectangle(360, 300, 15, 15);
            if (Lives >= 0)
            {
                spriteBatch.Draw(StationaryMarioTexture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.DrawString(LivesFont, " x       " + Lives.ToString(), livesPos, Color.WhiteSmoke);
            }
            else
            {
                spriteBatch.DrawString(LivesFont, " GAME OVER ", gameOverPos, Color.WhiteSmoke);
            }
        }
    }
}
