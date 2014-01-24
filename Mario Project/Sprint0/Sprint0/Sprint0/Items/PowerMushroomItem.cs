using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MarioProject
{
    class PowerMushroomItem : IItem
    {
        public Rectangle collisionRectangle { get; set; }
        public Boolean itemActivated { get; set; }
        public Boolean isConsumable { get; set; }
        Boolean hasRisen;
        public int speedCounter, counter, timer;
        Texture2D item;
        Vector2 speed, position;
        SoundManager soundMgr;

        public PowerMushroomItem(Texture2D texture, int x, int y, SoundManager sound)
        {
            item = texture;
            position.X = x;
            position.Y = y;
            itemActivated = false;
            timer = 70;
            soundMgr = sound;
            collisionRectangle = new Rectangle(x, y, 20, 20);
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

            if (speedCounter % 4 == 0 && itemActivated)
            {
                if (counter < 8)
                {
                    position.Y = position.Y - 3;
                }
                if (counter == 7)
                {
                    hasRisen = true;
                    speed = new Vector2(3, 0);
                }
                counter++;
            }         
            if (hasRisen)
            {
                if(speedCounter % 6 == 0)
                {
                    speed.Y += 1;
                }

                speed = collide(speed, blocks);
                position += speed;     
            }
            speedCounter++;
      
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int itemHideAdjust = -6;
            Rectangle destinationRectangle = new Rectangle((int)position.X, ((int)position.Y + itemHideAdjust), 20, 20);
            spriteBatch.Draw(item, destinationRectangle, new Rectangle(0, 0, 16, 16), Color.White);
            collisionRectangle = destinationRectangle; ;
        }

        private Vector2 collide(Vector2 speed, List<IStatic> blocks)
        {
            foreach (IStatic block in blocks)
            {
                Rectangle intersect = Rectangle.Intersect(block.collisionRectangle, collisionRectangle);
                if (intersect.Height <= 5 && !intersect.IsEmpty)
                {
                    speed.Y = 0;
                }
                else if (!intersect.IsEmpty)
                {
                    speed.X = speed.X * -1;
                }
            }
            return speed;
        }
    }
}
