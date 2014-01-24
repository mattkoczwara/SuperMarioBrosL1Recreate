using System;
using Microsoft.Xna.Framework.Graphics;

// IBlockState Interface
public interface IBlockState
{
    // Updates the state
    void Update();
    void Draw(SpriteBatch spriteBatch);
}