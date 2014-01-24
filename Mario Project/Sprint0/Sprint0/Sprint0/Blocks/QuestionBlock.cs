using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class QuestionBlock : IStatic
    {
        int xpos, ypos, draw;
        public bool state { get; set; }
        public bool isBumping { get; set; }
        public int bumped { get; set; }
        Texture2D block;
        public Rectangle collisionRectangle { get; set; }

        public QuestionBlock(Texture2D b, int x, int y)
        {
            block = b;
            xpos = x;
            ypos = y;
            state = true;
            isBumping = false;
            collisionRectangle = new Rectangle(xpos, ypos, 20, 20);
        }

        public void Bump()
        {   
            Rectangle temp = this.collisionRectangle;
            temp.Y -= 3;
            this.collisionRectangle = temp;
            bumped--;   
        }

        public void UnBump()
        {
            Rectangle temp = this.collisionRectangle;
            temp.Y += 3;
            this.collisionRectangle = temp;
            isBumping = false;
            bumped--;
        }

        public void Update()
        {
            if (draw == 0)
            {
                bumped = 10;
                this.Bump();
                draw = 1;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            collisionRectangle = new Rectangle((int)location.X, (int)location.Y, 20, 20);
            if (draw == 0)
            {
                spriteBatch.Draw(block, collisionRectangle, new Rectangle(372, 160, 16, 16), Color.White);
            }
            else
            {
                spriteBatch.Draw(block, collisionRectangle, new Rectangle(373, 65, 16, 16), Color.White);
            }
        }
    }
}
