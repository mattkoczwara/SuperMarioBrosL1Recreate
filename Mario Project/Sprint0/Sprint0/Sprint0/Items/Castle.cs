using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    public class Castle : IItem
    {
        int xpos, ypos;
        Texture2D item;
        public Rectangle collisionRectangle { get; set; }
        public Boolean isConsumable { get; set; }
        public Boolean itemActivated { get; set; }

        public Castle(Texture2D texture, int x, int y)
        {
            item = texture;
            xpos = x;
            ypos = y;
            itemActivated = true;
            isConsumable = false;
        }

        public void Update(GameTime theGameTime, List<IStatic> blocks)
        {
            //do nothing
        }

        public void ItemBump()
        {
            //do nothing
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(270, 220, 80, 80);
            Rectangle destinationRectangle = new Rectangle(xpos, ypos , 80, 80);
            collisionRectangle = destinationRectangle;

            spriteBatch.Draw(item, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
