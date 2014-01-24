using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    public interface IProjectile : ICollidable
    {
        void Update(List<IStatic> blocks, List<Enemy> enemies);
        void Draw(SpriteBatch spriteBatch);
    }
}
