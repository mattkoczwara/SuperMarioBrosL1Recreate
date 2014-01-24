using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class FireMarioRunningRightSprite : IMario
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Size { get; set; }
        public int colorTimer { get; set; }
        public Rectangle collisionRectangle { get; set; }
        private int currentFrame;
        int i = 0;

        public FireMarioRunningRightSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 75;
            Size = 2;
        }

        public void Update(GameTime theGameTime)
        {
            i++;
            if(i % 7 == 0)
            {
                currentFrame--;
                if (currentFrame < 73)
                    currentFrame = 75;
            }
            if (colorTimer > 0)
            {
                colorTimer--;
        }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = (Texture.Bounds.Width) / Columns;
            int height = (Texture.Bounds.Height) / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle((width * column)+5, (height * row)-2, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y-15, width, height);
            System.Threading.Thread.Sleep(6);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, this.getColor());
            destinationRectangle.X += 6;
            destinationRectangle.Width -= 7;
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
