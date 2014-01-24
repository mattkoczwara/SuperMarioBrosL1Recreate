using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    public interface ICommand
    {
        // Executes the command
        void IComExecute(MarioProject.Game1 game1, int command);
    }
}