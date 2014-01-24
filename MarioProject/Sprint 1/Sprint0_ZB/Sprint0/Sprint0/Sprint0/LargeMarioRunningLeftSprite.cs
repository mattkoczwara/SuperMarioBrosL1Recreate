using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class LargeMarioRunningLeftSprite : IMarioState
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Size { get; set; }
        private int speedCounter = 0;
        private double currentFrame;
        private int totalFrames;

        public LargeMarioRunningLeftSprite(Texture2D texture, int rows, int columns)
        {
            //initialize values
            Texture = texture;
            Rows = rows;
            Columns = columns;
            Size = 1;
            currentFrame = 3;
            totalFrames = Rows * Columns;
        }

        public void Update()
        {
            speedCounter++;
            if (speedCounter % 7 == 0)
            {
                currentFrame++;

                if (currentFrame > 5)
                {
                    currentFrame = 3;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            //Calculate necessary values for position of MarioRunningRightSprite on the spritesheet
            int width = (Texture.Bounds.Width +3)/ Columns;
            int height = Texture.Bounds.Height / Rows - 60;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = (int)(currentFrame % Columns);

            Rectangle sourceRectangle = new Rectangle(width * column, (height * row) + 50, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X+5, (int)location.Y, width, height);
            System.Threading.Thread.Sleep(6);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
