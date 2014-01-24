using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject 
{
    class FireFlowerItem : IItem
    {
        public Rectangle collisionRectangle { get; set; }
        public bool bumped { get; set; }
        public Boolean itemActivated { get; set; }
        public Boolean isConsumable { get; set; }
        int xpos, ypos, speedCounter, currentFrame, itemAdjust, counter, timer;
        Texture2D item;
        SoundManager soundMgr;

        public FireFlowerItem(Texture2D texture, int x, int y, SoundManager sound)
        {
            item = texture;
            xpos = x;
            ypos = y;
            itemActivated = false;
            soundMgr = sound;
            collisionRectangle = new Rectangle(x, y, 20, 20);
            timer = 100;
        }

        public void ItemBump()
        {
            soundMgr.itemAppears.Play();
            itemActivated = true;
            isConsumable = false;
        }

        public void Update(GameTime theGameTime, List<IStatic> blocks)
        {
            if (timer > 0)
                timer--;
            else
                isConsumable = true;

            speedCounter++;
            itemAdjust = 20;
            if (itemActivated == true)
            {
                if (speedCounter % 3 == 0)
                {
                    currentFrame++;
                    if (currentFrame > 3)
                    {
                        currentFrame = 0;
                    }
                }
                if (speedCounter % 2 == 0)
                {
                    if (counter < itemAdjust)
                    {
                        ypos--;
                        counter++;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = 16;
            int frameAdjust = width * currentFrame;
            int itemHideAdjust = -6;

            Rectangle sourceRectangle = new Rectangle(0 + frameAdjust, 32, 16, 16);
            Rectangle destinationRectangle = new Rectangle(xpos, ypos + itemHideAdjust, 20, 20);
            collisionRectangle = new Rectangle(xpos, (ypos + itemHideAdjust - 22), 20, 20); 
            
            spriteBatch.Draw(item, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
