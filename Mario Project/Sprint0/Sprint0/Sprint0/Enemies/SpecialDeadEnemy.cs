using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class SpecialDeadEnemy : IEnemy
    {
        public Rectangle collisionRectangle { get; set; }
        //public Vector2 currentLocation;
        Texture2D Texture;
        int xspeed, yspeed, width = 20, height = 20;
        Rectangle sourceRectangle;

        public SpecialDeadEnemy(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            xspeed = rows;
            yspeed = -5;
            int xpos, ypos;
            if (columns == 1)
            {
                xpos = 125;
                ypos = 520;
            }
            else
            {
                xpos = 115;
                ypos = 550;
            }
            sourceRectangle = new Rectangle(xpos, ypos, width, height);
        }

        public void Update(GameTime theGameTime)
        {
            yspeed++;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            /*currentLocation = location;
            currentLocation.Y += yspeed;
            currentLocation.X += xspeed;*/
            Rectangle temp = collisionRectangle;
            temp.X = (int)location.X + xspeed;
            temp.Y = (int)location.Y + yspeed;
            collisionRectangle = temp;

            Rectangle destinationRectangle = new Rectangle(collisionRectangle.X, collisionRectangle.Y, width, height);
        
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
