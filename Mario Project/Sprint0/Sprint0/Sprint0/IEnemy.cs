using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    public interface IEnemy : ICollidable
    {
        void Update(GameTime theGameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
