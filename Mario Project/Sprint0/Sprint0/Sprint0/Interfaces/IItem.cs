using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    public interface IItem : ICollidable
    {
        void Update(GameTime theGameTime, List<IStatic> blocks);
        void Draw(SpriteBatch spriteBatch);
        void ItemBump();
        bool itemActivated { get; set;}
        Boolean isConsumable { get; set; }
    }
}
