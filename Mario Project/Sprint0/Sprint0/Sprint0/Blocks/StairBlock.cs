﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class StairBlock : IStatic
    {
        int xpos, ypos;
        Texture2D block;
        public bool state { get; set; }
        public bool isBumping { get; set; }
        public int bumped { get; set; }
        public Rectangle collisionRectangle { get; set; }

        public StairBlock(Texture2D b, int x, int y)
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
            // No Action
        }

        public void UnBump()
        {
            // No Action
        }

        public void Update()
        {
            // No Action
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            collisionRectangle = new Rectangle((int)location.X, (int)location.Y, 20, 20);
            spriteBatch.Draw(block, collisionRectangle, new Rectangle(373, 142, 16, 16), Color.White);
        }
    }
}