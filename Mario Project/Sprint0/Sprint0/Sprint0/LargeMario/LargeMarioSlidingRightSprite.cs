using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class LargeMarioSlidingRightSprite : IMario
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Size { get; set; }
        public int colorTimer { get; set; }
        public Rectangle collisionRectangle { get; set; }
        private int currentFrame;
        private int totalFrames;
        public Vector2 currentLocation;
        public Vector2 Position = new Vector2(0, 1);

        public LargeMarioSlidingRightSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            Size = 1;
            currentFrame = 2;
            totalFrames = Rows * Columns;
        }

        public void Update(GameTime theGameTime)
        {
            if (colorTimer > 0)
            {
                colorTimer--;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = (Texture.Width)/ Columns;
            int height = (Texture.Height) / Rows - 60;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
            currentLocation = location;

            Rectangle sourceRectangle = new Rectangle(width * column, (height * row) + 50, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y-17, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, this.getColor());
            destinationRectangle.X += 12;
            destinationRectangle.Width -= 12;
            destinationRectangle.Y += 1;
            destinationRectangle.Height -= 1;
            collisionRectangle = destinationRectangle;
        }

        private Color getColor()
        {
            if (colorTimer == 0)
            {
                return Color.White;
            }
            else if ((colorTimer / 6) % 2 == 0)
            {
                return Color.Brown;
            }
            else
            {
                return Color.Yellow;
            }
        }
    }
}
