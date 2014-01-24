﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class FloorBlock : IBlockState
    {
        int xpos, ypos;
        Texture2D block;

        public FloorBlock(Texture2D b, int x, int y)
        {
            block = b;
            xpos = x;
            ypos = y;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(block, new Rectangle(xpos, ypos, 20, 20), new Rectangle(373, 123, 16, 16), Color.White);
        }
    }
}
