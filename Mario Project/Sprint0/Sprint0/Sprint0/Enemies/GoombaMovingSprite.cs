﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class GoombaMovingSprite : IEnemy
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Size { get; set; }
        private int currentFrame;
        private int totalFrames;
        public Vector2 currentLocation;
        int speedCounter = 0;
        public Rectangle collisionRectangle { get; set; }

        public GoombaMovingSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            Size = 1;
            currentFrame = 0;
            totalFrames = Rows * Columns;
        }

        public void Update(GameTime theGameTime)
        {
            speedCounter++;
            if (speedCounter % 20 == 0)
            {
                currentFrame++;

                if (currentFrame > 1)
                {
                    currentFrame = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {            
            int width = (Texture.Width) / Columns;
            int height = (Texture.Height) / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
            currentLocation = location;

            Rectangle sourceRectangle = new Rectangle(width * column, (height * row), width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);
        
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            destinationRectangle.Width -= 12;
            destinationRectangle.Height -= 12;
            collisionRectangle = destinationRectangle;
        }
    }
}
