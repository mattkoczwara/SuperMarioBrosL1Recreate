using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class FireMarioCrouchingRightSprite : IMario
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Size { get; set; }
        public int colorTimer { get; set; }
        public Rectangle collisionRectangle { get; set; }
        private int currentFrame;
        private int totalFrames;

        public FireMarioCrouchingRightSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 79;
            Size = 2;
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
            int width = (Texture.Width) / Columns;
            int height = (Texture.Height) / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
            //int frameAdjustment = 1;

            Rectangle sourceRectangle = new Rectangle((width * column)+4, height * row, width + 1, height);
            Rectangle destinationRectangle = new Rectangle(((int)location.X), ((int)location.Y)-10, width + 1, height);
            collisionRectangle = destinationRectangle;

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle,this.getColor());
            destinationRectangle.X += 9;
            destinationRectangle.Width -= 7;
            destinationRectangle.Y += 1;
            destinationRectangle.Height -= 7;
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
