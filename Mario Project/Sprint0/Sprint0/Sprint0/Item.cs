using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace MarioProject
{
    public class Item
    {
        public IItem itemSprite;
        Vector2 speed, position;
        Texture2D texture;

        public Item(Texture2D Texture, Vector2 Position, IItem item)
        {
            texture = Texture;
            position = Position;
            itemSprite = item;
            speed = new Vector2(-1, 0);
        }

        public void Update(GameTime theGameTime, Mario mario, List<IStatic> blocks)
        {
            if (!((itemSprite is FireFlowerItem) || (itemSprite is CoinsItem)))
            {
                speed.Y += 1;
                speed = collide(speed, mario, blocks);
                position += speed;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            itemSprite.Draw(spriteBatch);
        }
        
        public void ItemBump()
        {
        }


        private Vector2 collide(Vector2 speed, Mario mario, List<IStatic> blocks)
        {
            foreach (IStatic block in blocks)
            {
                Rectangle intersect = Rectangle.Intersect(block.collisionRectangle, itemSprite.collisionRectangle);
                if(intersect.Height <= 10 && !intersect.IsEmpty)
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
