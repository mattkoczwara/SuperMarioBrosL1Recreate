using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace MarioProject
{
    public interface IItem : ICollidable
    {
        Boolean itemActivated { get; set; }
        Boolean isConsumable { get; set; }
        void ItemBump();
        void Update(GameTime theGameTime, List<IStatic> blocks);
        void Draw(SpriteBatch spriteBatch);
    }
}
