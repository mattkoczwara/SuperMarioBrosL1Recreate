using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class FireMarioCrouchingRightSprite : IMarioState
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Size { get; set; }
        private int currentFrame;
        private int totalFrames;

        public FireMarioCrouchingRightSprite(Texture2D texture, int rows, int columns)
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
            //Find position of FireMarioCrouchingRightSprite on the spritesheet
            int width = (Texture.Width) / Columns;
            int height = (Texture.Height) / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
            //int frameAdjustment = 1;

            Rectangle sourceRectangle = new Rectangle((width * column)+4, height * row, width + 1, height);
            Rectangle destinationRectangle = new Rectangle(((int)location.X)-2, ((int)location.Y)+6, width + 1, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
