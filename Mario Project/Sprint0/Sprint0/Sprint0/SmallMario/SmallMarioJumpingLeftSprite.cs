using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class SmallMarioJumpingLeftSprite : IMario
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        public int Size { get; set; }
        public int colorTimer { get; set; }
        public Rectangle collisionRectangle { get; set; }
        public SmallMarioJumpingLeftSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 1;
            totalFrames = Rows * Columns;
            Size = 0;
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
            int width = Texture.Bounds.Width / Columns;
            width = width - 5;
            int height = Texture.Bounds.Height / Rows;
            height = height + 2;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X+10, (int)location.Y-2, width, height);
            
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, this.getColor());
            destinationRectangle.X -= 1;
            destinationRectangle.Width -= 10;
            destinationRectangle.Y -= 2;
            destinationRectangle.Height += 1;
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