using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    public class Camera
    {
        Matrix viewMatrix;
        public Vector2 position;
        public readonly Viewport viewPort;
        private Rectangle? limits;
        private Vector2 previousPosition;

        public Camera(Viewport vport)
        {
            viewPort = vport;
        }

        public Rectangle? Limits
        {
            get { return limits; }
            set
            {
                if (value != null)
                {
                    limits = new Rectangle
                    {
                        X = value.Value.X,
                        Y = value.Value.Y,
                        Width = System.Math.Max(viewPort.Width, value.Value.Width),
                        Height = System.Math.Max(viewPort.Height, value.Value.Height)
                    };

                    Position = Position;
                }
                else
                {
                    limits = null;
                }
            }
        }

        public Vector2 Position
        {
            get { return position; }
            set
            {
                position = value;

                
                if (Limits != null)
                {
                    position.X = MathHelper.Clamp(position.X, Limits.Value.X, Limits.Value.X + Limits.Value.Width - viewPort.Width);
                    position.Y = MathHelper.Clamp(position.Y, Limits.Value.Y, Limits.Value.Y + Limits.Value.Height - viewPort.Height);
                }
            }
        }

        public Matrix ViewMatrix
        {
            get { return viewMatrix; }
        }

        public void Update(Vector2 playerPosition)
        {
            if (playerPosition.X - (viewPort.Width / 2) < 0)
            {
                position.X = 0;
            }
            else
            {
                position.X = playerPosition.X - (viewPort.Width / 2);
            }
            
            position.Y = viewPort.Height/2;

            if (position.X < previousPosition.X)
            {
                position.X = previousPosition.X;
            }

            previousPosition = position;
            viewMatrix = Matrix.CreateTranslation(new Vector3(-position, 0));
        }
    }
}
