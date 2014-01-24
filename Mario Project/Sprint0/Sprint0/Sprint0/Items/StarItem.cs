using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class StarItem : IItem
    {
        public Rectangle collisionRectangle { get; set; }
        public Boolean itemActivated { get; set; }
        public Boolean isConsumable { get; set; }
        int speedCounter, currentFrame, counter, timer;
        Boolean groundHit;
        Boolean hasRisen = false;
        Texture2D item;
        Vector2 speed, position;

        public StarItem(Texture2D texture, int x, int y)
        {
            item = texture;
            position.X = x;
            position.Y = y;
            itemActivated = false;
            collisionRectangle = new Rectangle(x, y, 20, 20);
            timer = 70;
        }

        public void ItemBump()
        {
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
            if (speedCounter % 3 == 0)
            {
                currentFrame++;

                if (currentFrame > 3)
                {
                    currentFrame = 0;
                }
            }
            if ((speedCounter % 5 == 0)&&(itemActivated))
            {
                if (counter < 9)
                {
                    position.Y = position.Y - 3;
                }
                if (counter == 8)
                {
                    hasRisen = true;
                    speed = new Vector2(2, -3);
                }
                counter++;
            }

            if (itemActivated && hasRisen)
            {
                hasRisen = true;
            }

            if (hasRisen)
            {
                if (speedCounter % 6 == 0)
                {
                    speed.Y += 1;
                }
                speed = collide(speed, blocks);
                position += speed;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = 16;
            int frameAdjust = width * currentFrame;
            int itemHideAdjust = -6;

            Rectangle sourceRectangle = new Rectangle(0 + frameAdjust, 48, 16, 16);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y + itemHideAdjust, 20, 20);
            collisionRectangle = destinationRectangle;

            spriteBatch.Draw(item, destinationRectangle, sourceRectangle, Color.White);
        }

        private Vector2 collide(Vector2 speed, List<IStatic> blocks)
        {
            foreach (IStatic block in blocks)
            {
                Rectangle intersect = Rectangle.Intersect(block.collisionRectangle, collisionRectangle);
                if (intersect.Height <= 10 && !intersect.IsEmpty && block is FloorBlock)
                {                 
                    speed.Y = -4;
                    speed.X = 2;
                    groundHit = true;
                }
                else if ((intersect.Height <= 10 && !intersect.IsEmpty && block is Pipe))
                {
                    speed.Y = -6;
                }
                else if((intersect.Height <= 10 && !intersect.IsEmpty && (block is StairBlock)))
                {
                    speed.Y = -6;
                }
                else if (!intersect.IsEmpty)
                {
                    speed.X = speed.X * -1;
                }
                else if ((groundHit == true) && (position.Y < 360) && intersect.IsEmpty)
                {
                    speed.Y = speed.Y * -1;
                    groundHit = false;
                }
            }
            return speed;
        }
    }
}
