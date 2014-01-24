using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class HiddenBlock : IStatic
    {
        int xpos, ypos;
        public bool state { get; set; }
        public bool isBumping { get; set; }
        public int bumped { get; set; }
        Texture2D block;
        public Rectangle collisionRectangle { get; set; }

        public HiddenBlock(Texture2D b, int x, int y)
        {
            block = b;
            xpos = x;
            ypos = y;
            state = false;
            isBumping = false;
            collisionRectangle = new Rectangle(xpos, ypos, 20, 20);
        }

        public void Bump()
        {
            Rectangle temp = collisionRectangle;
            temp.Y -= 3;
            collisionRectangle = temp;
            bumped--;
        }

        public void UnBump()
        {
            Rectangle temp = collisionRectangle;
            temp.Y += 3;
            collisionRectangle = temp;
            isBumping = false;
            bumped--;
        }

        public void Update()
        {
            if (!state)
            {
                bumped = 10;
                this.Bump();
                state = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            collisionRectangle = new Rectangle((int)location.X, (int)location.Y, 20, 20);
            if (state)
            {
                spriteBatch.Draw(block, collisionRectangle, new Rectangle(373, 65, 16, 16), Color.White);
            }
        }
    }
}