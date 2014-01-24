using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    // IMarioState Interface
    public interface IMarioState : IAnimatedSprite
    {
        // Updates the state
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}