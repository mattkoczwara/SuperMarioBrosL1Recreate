using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject 
{
    class GrenadeItem : IItem
    {
        public Rectangle collisionRectangle { get; set; }
        public bool bumped { get; set; }
        public Boolean itemActivated { get; set; }
        public Boolean isConsumable { get; set; }
        int xpos, ypos;
        Texture2D item;
        SoundManager soundMgr;

        public GrenadeItem(Texture2D texture, int x, int y, SoundManager sound)
        {
            item = texture;
            xpos = x;
            ypos = y;
            itemActivated = true;
			isConsumable = true;
            soundMgr = sound;
            collisionRectangle = new Rectangle(x, y, 20, 20);
        }

        public void ItemBump()
        {
        }

        public void Update(GameTime theGameTime, List<IStatic> blocks)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, 20, 20);
            Rectangle destinationRectangle = new Rectangle(xpos, ypos, 20, 20);
            collisionRectangle = new Rectangle(xpos, (ypos), 20, 20); 
            
            spriteBatch.Draw(item, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
