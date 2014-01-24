using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class BowserFire : ICollidable
    {
        public Rectangle collisionRectangle { get; set; }
        public Vector2 position;
        Texture2D texture;
        int frame = 0, sourcex, change;
        float xspeed;

        public BowserFire(Texture2D Texture, int direction, Vector2 Position)
        {
            position = Position;
            texture = Texture;
            if (direction == 1)
            {
                sourcex = 160;
                xspeed = (float)1.5;
            }
            else
            {
                sourcex = 100;
                xspeed = (float)-1.5;
            }
        }

        public void Update()
        {
            change = (change + 1) % 6;
            if (change == 0)
            {
                frame = (frame + 1) % 2;
            }
            position.X += xspeed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(sourcex + frame * 30, 250, 25, 10);
            collisionRectangle = new Rectangle((int)position.X, (int)position.Y, 25, 10);
            spriteBatch.Draw(texture, collisionRectangle, sourceRectangle, Color.White);
        }
    }
}
