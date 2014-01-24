using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioProject
{
    class CoinsItem :IItem
    {
        public Rectangle collisionRectangle { get; set; }
        Boolean top = false;
        Boolean coinsCollected, coinDrop;
        public Boolean isConsumable { get; set; }
        public Boolean itemActivated { get; set; }
        SoundManager soundMgr;
        int xpos, ypos, counter, speedCounter, itemAdjust, currentFrame;
        Texture2D item;

        public CoinsItem(Texture2D texture, int x, int y, SoundManager sound)
        {
            item = texture;
            xpos = x;
            ypos = y;
            itemActivated = false;
            soundMgr = sound;
            collisionRectangle = new Rectangle(x, y, 20, 20);
            isConsumable = false;
        }

        public void ItemBump()
        {
            soundMgr.itemCoin.Play();
            itemActivated = true;
            isConsumable = true;   
        }

        public void Update(GameTime theGameTime, List<IStatic> blocks)
        {
            speedCounter++;
            itemAdjust = 12;

            if (speedCounter % 5 == 0)
            {
                if (currentFrame > 3)
                {
                    currentFrame = 0;
                }
                currentFrame++;
            }
            if (speedCounter % 2 == 0)
            {
                if (itemActivated == true && (counter < itemAdjust) && top == false)
                {
                    ypos = ypos - 5;
                    counter++;
                    if (counter == itemAdjust)
                        top = true;
                }
                else if (counter > 0)
                {
                    ypos = ypos + 2;
                    counter--;
                    if (counter == 0)
                    {
                        coinsCollected = true;
                    }
                }
                if (coinDrop)
                {
                    ypos = ypos + 20;
                }               
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            int width = 16;
            int frameAdjust = width * currentFrame;
            int itemHideAdjust = -6;

            Rectangle sourceRectangle = new Rectangle(0 + frameAdjust, 96, 14, 16);
            Rectangle destinationRectangle = new Rectangle(xpos, ypos + itemHideAdjust, 20, 20);
            collisionRectangle = destinationRectangle;

            if (!coinsCollected)
            {
                spriteBatch.Draw(item, destinationRectangle, sourceRectangle, Color.White);
            }
            else
            {
                coinDrop = true;
                collisionRectangle = new Rectangle(xpos, ypos, 1500, 1500);
            }
        }
    }
}
