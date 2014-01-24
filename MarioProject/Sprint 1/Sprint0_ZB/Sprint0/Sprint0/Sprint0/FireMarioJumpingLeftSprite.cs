using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class FireMarioJumpingLeftSprite : IMarioState
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Size { get; set; }
        private int currentFrame;
        private int totalFrames;
        private int i = 0;

        public FireMarioJumpingLeftSprite(Texture2D texture, int rows, int columns)
        {
            //Initialization
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 65;
            Size = 2;
            totalFrames = Rows * Columns;
        }

        public void Update()
        {           
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            //Find position of FireMarioJumpingLeftSprite on the spritesheet
            int width = (Texture.Bounds.Width+1) / Columns;
            int height = Texture.Bounds.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle((width * column)-7, (height * row)-5, width+5, height+5);
            Rectangle destinationRectangle = new Rectangle(((int)location.X)-3, ((int)location.Y)-5, width+5, height+5);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
