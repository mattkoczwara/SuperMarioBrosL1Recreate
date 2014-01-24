using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    public interface IController
    {
        List<Keys> Update(MarioProject.Game1 game1);
    }
}
