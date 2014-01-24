using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class LargeMarioStandingRightSprite : IMarioState
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Size { get; set; }
        private int currentFrame;
        private int totalFrames;
        public Vector2 currentLocation;
        public Vector2 Position = new Vector2(0, 1);

        public LargeMarioStandingRightSprite(Texture2D texture, int rows, int columns)
        {
            //initialize values
            Texture = texture;
            Rows = rows;
            Columns = columns;
            Size = 1;
            currentFrame = 7;
            totalFrames = Rows * Columns;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            //Calculate necessary values for position of LargeMarioStandingLeftSprite on the spritesheet
            int width = (Texture.Width)/ Columns;
            int height = (Texture.Height) / Rows - 60;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
            currentLocation = location;

            Rectangle sourceRectangle = new Rectangle(width * column, (height * row) + 50, width + 2, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width+2, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
