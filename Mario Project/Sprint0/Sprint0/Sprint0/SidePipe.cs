using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class SidePipe : IStatic
    {
        Texture2D Texture;
        int Height;
        Vector2 currentLocation;
        public bool state { get; set; }
        public bool isBumping { get; set; }
        public int bumped { get; set; }
        public Rectangle collisionRectangle { get; set; }
        public Boolean itemActivated { get; set; }

        public SidePipe(Texture2D texture, int height, Vector2 location)
        {
            currentLocation = location;
            Texture = texture;
            Height = height;
            state = true;
            collisionRectangle = new Rectangle((int)location.X, (int)location.Y, 30, 30 + Height * 15);
        }

        public void Bump()
        {
            // no action
        }

        public void UnBump()
        {
            // No Action
        }

        public void Update()
        {
            //do nothing
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            currentLocation = location;
            Rectangle sourceRectangle = new Rectangle(573, 100, 30, 32);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 30, 30);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

            Rectangle srcRectangle = new Rectangle(609, 100, 30, 34);
            Rectangle destRectangle = new Rectangle((int)location.X + 28, (int)location.Y, 34, 32);
            spriteBatch.Draw(Texture, destRectangle, srcRectangle, Color.White);

            Rectangle sourceRectangleAdded = new Rectangle();
            Rectangle destinationRectangleAdded = new Rectangle();

            int i = 1;
            while (i < 22)
            {
                sourceRectangleAdded = new Rectangle(614, 85, 32, 13);
                destinationRectangleAdded = new Rectangle((int)location.X + 34, (int)location.Y + 2 -15 * i, 30, 15);

                spriteBatch.Draw(Texture, destinationRectangleAdded, sourceRectangleAdded, Color.White);

                i++;
            }
            destinationRectangleAdded.Height += (destRectangle.Height + i*destinationRectangleAdded.Height);
            destinationRectangle.Width += destRectangle.Width;
            collisionRectangle = new Rectangle(destinationRectangle.X, destinationRectangle.Y, destinationRectangle.Width, destinationRectangleAdded.Height);
        }
    }
}