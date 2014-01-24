using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioProject
{
    class FloatingCoin : IItem
    {
        public Rectangle collisionRectangle { get; set; }
        public Boolean isConsumable { get; set; }
        public Boolean itemActivated { get; set; }
        int xpos, ypos, speedCounter, currentFrame;
        Texture2D item;

        public FloatingCoin(Texture2D texture, int x, int y)
        {
            item = texture;
            xpos = x;
            ypos = y;
            itemActivated = true;
            collisionRectangle = new Rectangle(x, y, 20, 20);
            isConsumable = true;
        }

        public void Update(GameTime theGameTime, List<IStatic> blocks)
        {
            speedCounter++;
            if (speedCounter % 11 == 0)
            {
                currentFrame++;

                if (currentFrame > 3)
                {
                    currentFrame = 0;
                }
            }
        }

        public void ItemBump()
        {
            //itemActivated = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = 16;
            int frameAdjust = width * currentFrame;

            Rectangle destinationRectangle = new Rectangle(xpos, ypos, 14, 14);
            Rectangle sourceRectangle = new Rectangle(0 + frameAdjust, 82, 14, 14);
            collisionRectangle = destinationRectangle;
            spriteBatch.Draw(item, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
