using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioProject
{
    class DeadGoomba : IEnemy
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Size { get; set; }
        private int currentFrame;
        private int totalFrames;
        public Vector2 currentLocation;
        public Rectangle collisionRectangle { get; set; }

        public DeadGoomba(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            Size = 1;
            currentFrame = 2;
            totalFrames = Rows * Columns;
        }

        public void Update(GameTime theGameTime)
        {
            //no action
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
