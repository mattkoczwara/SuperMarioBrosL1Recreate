using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class KoopaStandingLeftSprite : IEnemy
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Size { get; set; }
        private int currentFrame;
        private int totalFrames;
        public Vector2 currentLocation;
        public Rectangle collisionRectangle { get; set; }

        public KoopaStandingLeftSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            Size = 1;
            currentFrame = 4;
            totalFrames = Rows * Columns;
        }

        public void Update(GameTime theGameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = (Texture.Width) / Columns;
            int height = (Texture.Height) / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
            currentLocation = location;

            Rectangle sourceRectangle = new Rectangle(width * column + 36, (height * row), width - 9, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width - 9, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            destinationRectangle.Width -= 11;
            destinationRectangle.Height += 1;
            collisionRectangle = destinationRectangle;
        }
    }
}
