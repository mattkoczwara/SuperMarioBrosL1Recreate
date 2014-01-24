using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioProject
{
    class BulletBlaster : IStatic
    {
        Texture2D Texture;
        Vector2 currentLocation, origin;
        public bool state { get; set; }
        public bool isBumping { get; set; }
        public int bumped { get; set; }
        public Rectangle collisionRectangle { get; set; }
        public Boolean itemActivated { get; set; }

        public BulletBlaster(Texture2D texture, Vector2 location)
        {
            currentLocation = location;
            Texture = texture;
            state = true;
            collisionRectangle = new Rectangle((int)location.X, (int)location.Y, 30, 30);
            origin.X = 0;
            origin.Y = 0;
        }

        public void Bump()
        {
            // no action
        }

        public void UnBump()
        {
            // no action
        }

        public void Update()
        {
            // no action
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            currentLocation = location;
            Rectangle sourceRectangle = new Rectangle(259, 387, 20, 40);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 20, 40);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White, 0, origin, SpriteEffects.None,0);
            collisionRectangle = destinationRectangle;
        }
    }
}
