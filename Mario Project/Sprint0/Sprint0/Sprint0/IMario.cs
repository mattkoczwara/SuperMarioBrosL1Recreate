using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    public interface IMario : IAnimatedSprite
    {
        int colorTimer { get; set; }
        Rectangle collisionRectangle { get; set; }
    }
}