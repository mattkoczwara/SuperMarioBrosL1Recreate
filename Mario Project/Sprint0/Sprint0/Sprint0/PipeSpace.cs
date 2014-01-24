using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class PipeSpace : IStatic
    {
        Vector2 currentLocation;
        public bool state { get; set; }
        public bool isBumping { get; set; }
        public int bumped { get; set; }
        public Rectangle collisionRectangle { get; set; }
        public Boolean itemActivated { get; set; }

        public PipeSpace(Vector2 location)
        {
            currentLocation = location;
            state = true;
            collisionRectangle = new Rectangle((int)location.X+30, (int)location.Y, 30, 1000);
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
            // no action
        }
    }
}