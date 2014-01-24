using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class KoopaMovingLeftSprite : IEnemy
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Size { get; set; }
        private int currentFrame;
        private int totalFrames;
        public Vector2 currentLocation;
        int speedCounter = 0;
        public Rectangle collisionRectangle { get; set; }

        public KoopaMovingLeftSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            Size = 1;
            currentFrame = 3;
            totalFrames = Rows * Columns;
        }

        public void Update(GameTime theGameTime)
        {
            speedCounter++;
            if (speedCounter % 20 == 0)
            {
                currentFrame++;

                if (currentFrame > 4)
                {
                    currentFrame = 3;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = (Texture.Width) / Columns;
            int height = (Texture.Height) / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
            currentLocation = location;

            Rectangle sourceRectangle = new Rectangle(width * column + 30, (height * row), width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);
            collisionRectangle = destinationRectangle;

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
