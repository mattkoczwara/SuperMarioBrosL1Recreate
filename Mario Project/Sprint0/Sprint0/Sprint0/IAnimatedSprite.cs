using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    public interface IAnimatedSprite
    {
        void Update(GameTime theGameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
