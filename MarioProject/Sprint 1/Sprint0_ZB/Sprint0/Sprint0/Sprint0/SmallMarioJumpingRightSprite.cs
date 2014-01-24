using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class SmallMarioJumpingRightSprite : IMarioState
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        public int Size { get; set; }
        public SmallMarioJumpingRightSprite(Texture2D texture, int rows, int columns)
        {
            //initialize values
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 11;
            totalFrames = Rows * Columns;
            Size = 0;
        }

        public void Update()
        {
            //do nothing
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            //Calculate necessary values for position of MarioRunningRightSprite on the spritesheet
            int width = Texture.Bounds.Width / Columns;
            width = width - 1;
            int height = Texture.Bounds.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
