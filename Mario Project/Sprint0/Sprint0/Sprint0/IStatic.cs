using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    public interface IStatic : ICollidable
    {
        bool state { get; set; }
        bool isBumping { get; set; }
        int bumped { get; set; }
        void UnBump();        
        void Bump();
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}