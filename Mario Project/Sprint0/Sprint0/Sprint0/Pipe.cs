using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class Pipe : IStatic
    {
        Texture2D Texture;
        int Height;
        Vector2 currentLocation;
        public bool state { get; set; }
        public bool isBumping { get; set; }
        public int bumped { get; set; }
        public Rectangle collisionRectangle { get; set; }
        public Boolean itemActivated { get; set; }

        public Pipe(Texture2D texture, int height, Vector2 location)
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
            //no action
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            currentLocation = location;
            Rectangle sourceRectangle = new Rectangle(614, 46, 32, 30);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 30, 30);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

            int i = 0;
            while (i < Height)
            {
                Rectangle sourceRectangleAdded = new Rectangle(614, 85, 32, 13);
                Rectangle destinationRectangleAdded = new Rectangle((int)location.X, (int)location.Y + 30 + 15 * i, 30, 15);

                spriteBatch.Draw(Texture, destinationRectangleAdded, sourceRectangleAdded, Color.White);

                i++;
            }
            destinationRectangle.Height += 15 * Height;
            collisionRectangle = destinationRectangle;
        }
    }
}
