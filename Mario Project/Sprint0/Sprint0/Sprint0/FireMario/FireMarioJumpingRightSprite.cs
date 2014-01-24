using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class FireMarioJumpingRightSprite : IMario
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Size { get; set; }
        public int colorTimer { get; set; }
        public Rectangle collisionRectangle { get; set; }
        private int currentFrame;
        private int totalFrames;

        public FireMarioJumpingRightSprite(Texture2D texture, int rows, int columns)
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
            int width = Texture.Bounds.Width / Columns;
            int height = Texture.Bounds.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(((width-1) * column)-3, (height * row)-2, width+5, height+5);
            Rectangle destinationRectangle = new Rectangle(((int)location.X)+2, (int)location.Y-15, width+5, height+5);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, this.getColor());
            destinationRectangle.X += 4;
            destinationRectangle.Width -= 12;
            destinationRectangle.Y -= 1;
            destinationRectangle.Height -= 3;
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
