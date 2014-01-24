using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioProject
{
    public class CoinBrickBlock : IStatic
    {
        int xpos, ypos;
        public bool state { get; set; }
        public bool hit { get; set; }
        public int bumped { get; set; }
        public bool isBumping { get; set; }
        Texture2D block;
        public Rectangle collisionRectangle { get; set;}
        public int coinCount;

        public CoinBrickBlock(Texture2D b, int x, int y)
        {
            block = b;
            xpos = x;
            ypos = y;
            state = true;
            isBumping = false;
            collisionRectangle = new Rectangle(xpos, ypos, 20, 20);
            coinCount = 56;
        }

        public void Update()
        {
            // No Action
        }

        public void Bump()
        {
            if (coinCount > 0)
            {
                Rectangle temp = this.collisionRectangle;
                temp.Y -= 3;
                this.collisionRectangle = temp;
                bumped--;
                coinCount--;
            }
        }

        public void UnBump()
        {
            Rectangle temp = this.collisionRectangle;
            temp.Y += 3;
            this.collisionRectangle = temp;
            bumped--;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            collisionRectangle = new Rectangle((int)location.X, (int)location.Y, 20, 20);
            if (state)
            {
                if(coinCount > 0)
                    spriteBatch.Draw(block, collisionRectangle, new Rectangle(373, 47, 16, 16), Color.White);
                else
                    spriteBatch.Draw(block, collisionRectangle, new Rectangle(373, 65, 16, 16), Color.White);
            }
        }
    }
}
