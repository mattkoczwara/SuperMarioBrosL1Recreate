using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class LargeMarioRunningRightSprite : IMario
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Size { get; set; }
        public int colorTimer { get; set; }
        public Rectangle collisionRectangle { get; set; }
        private int speedCounter = 0;
        private double currentFrame;
        private int totalFrames;

        public LargeMarioRunningRightSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            Size = 1;
            currentFrame = 10;
            totalFrames = Rows * Columns;
        }

        public void Update(GameTime theGameTime)
        {
            speedCounter++;
            if (speedCounter % 7 == 0)
            {
                currentFrame--;

                if (currentFrame < 8)
                {
                    currentFrame = 10;
                }
            }
            if (colorTimer > 0)
            {
                colorTimer--;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = (Texture.Bounds.Width +3)/ Columns;
            int height = Texture.Bounds.Height / Rows - 60;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = (int)(currentFrame % Columns);

            Rectangle sourceRectangle = new Rectangle(width * column, (height * row) + 50, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X+5, (int)location.Y-17, width, height);
            System.Threading.Thread.Sleep(6);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, this.getColor());
            destinationRectangle.X += 9;
            destinationRectangle.Width -= 12;
            destinationRectangle.Y += 2;
            destinationRectangle.Height -= 2;
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
