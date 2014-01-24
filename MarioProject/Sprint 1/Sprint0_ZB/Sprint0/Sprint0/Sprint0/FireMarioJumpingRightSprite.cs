using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class FireMarioJumpingRightSprite : IMarioState
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Size { get; set; }
        private int currentFrame;
        private int totalFrames;

        public FireMarioJumpingRightSprite(Texture2D texture, int rows, int columns)
        {
            //Initialization
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 79;
            Size = 2;
            totalFrames = Rows * Columns;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            //Find position of FireMarioJumpingRightSprite on the spritesheet
            int width = Texture.Bounds.Width / Columns;
            int height = Texture.Bounds.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(((width-1) * column)-3, (height * row)-2, width+5, height+5);
            Rectangle destinationRectangle = new Rectangle(((int)location.X)+2, (int)location.Y, width+5, height+5);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
