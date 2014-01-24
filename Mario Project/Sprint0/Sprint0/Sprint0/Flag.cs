using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    public class Flag : IItem
    {
        int xpos, ypos;
        Texture2D item;
        public Rectangle collisionRectangle { get; set; }
        public Boolean isConsumable { get; set; }
        public Boolean itemActivated { get; set; }

        public Flag(Texture2D texture, int x, int y)
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
            Rectangle sourceRectangle = new Rectangle(250, 44, 33, 185);
            Rectangle destinationRectangle = new Rectangle(xpos, ypos , 33, 185);
            
            spriteBatch.Draw(item, destinationRectangle, sourceRectangle, Color.White);
            destinationRectangle.X += 5;
            collisionRectangle = destinationRectangle;
        }
    }
}
