using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class FireMarioRunningRightSprite : IMarioState
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Size { get; set; }
        private int currentFrame;
        int i = 0;

        public FireMarioRunningRightSprite(Texture2D texture, int rows, int columns)
        {
            //Initialization
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 75;
            Size = 2;
        }

        public void Update()
        {
            i++;
            if(i % 7 == 0)
            {
                currentFrame--;
                if (currentFrame < 73)
                    currentFrame = 75;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            //Find position of FireMarioRunningRightSprite on the spritesheet
            int width = (Texture.Bounds.Width) / Columns;
            int height = (Texture.Bounds.Height) / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle((width * column)+5, (height * row)-2, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);
            System.Threading.Thread.Sleep(6);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
