using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class HiddenBlock : IBlockState
    {
        int xpos, ypos;
        bool state = true;
        Texture2D block;

        public HiddenBlock(Texture2D b, int x, int y)
        {
            block = b;
            xpos = x;
            ypos = y;
        }

        public void Update()
        {
            state = !state;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!state)
            {
                spriteBatch.Draw(block, new Rectangle(xpos, ypos, 20, 20), new Rectangle(373, 65, 16, 16), Color.White);
            }
        }
    }
}
