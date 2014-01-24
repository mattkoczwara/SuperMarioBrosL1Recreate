using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class FireMarioRunningLeftSprite : IMarioState
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Size { get; set; }
        private int currentFrame;
        private int totalFrames;
        private int i = 0;

        public FireMarioRunningLeftSprite(Texture2D texture, int rows, int columns)
        {
            //Initialization
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 68;
            Size = 2;
            totalFrames = Rows * Columns;
        }

        public void Update()
        {
            i++;
            if (i % 7 == 0)
            {
                currentFrame++;
                if (currentFrame > 70)
                    currentFrame = 68;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            //Find position of FireMarioRunningRightSprite on spritesheet
            int width = Texture.Bounds.Width / Columns;
            int height = Texture.Bounds.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, (height * row)-2, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);
            System.Threading.Thread.Sleep(6);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
