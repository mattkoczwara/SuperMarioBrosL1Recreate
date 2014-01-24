using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class FireMarioCrouchingLeftSprite : IMario
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int colorTimer { get; set; }
        public int Size { get; set; }
        public Rectangle collisionRectangle { get; set; }
        private int currentFrame;
        private int totalFrames;

        public FireMarioCrouchingLeftSprite(Texture2D texture, int rows, int column)
        {
            Texture = texture;
            Rows = rows;
            Columns = column;
            currentFrame = 64;
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width + 1, height);
            Rectangle destinationRectangle = new Rectangle(((int)location.X)+5, ((int)location.Y)-10, width + 1, height);
            
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, this.getColor());
            destinationRectangle.X -= 2;
            destinationRectangle.Width -= 6;
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
