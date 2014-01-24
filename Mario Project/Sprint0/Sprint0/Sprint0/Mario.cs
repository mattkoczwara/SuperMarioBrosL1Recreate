using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    public class Mario 
    {
        public IMario marioSprite;
        Texture2D texture;
        public Vector2 position;
        public Rectangle collisionRectangle;
        public enum size { small = 0, big, fire, dead }
        public enum state { standingRight = 0, standingLeft, runningRight, runningLeft, jumpingRight, jumpingLeft, crouchingRight, crouchingLeft, slidingRight, slidingLeft }
        public size marioSize;
        public state marioState;
        public Vector2 speed;
        
        public Mario(Texture2D Texture, Vector2 location)
        {
            position = location;
            texture = Texture;
            marioSprite = new SmallMarioStandingRightSprite(texture, 11, 12);
            marioSize = size.small;
            marioState = state.standingRight;
        }

        public enum collisionLocation { noCollision = 0, left, top, right, bottom };

        public int CollisionChecker (ICollidable objectSprite)
        {
            collisionRectangle = marioSprite.collisionRectangle;
            Rectangle intersect = Rectangle.Intersect(collisionRectangle, objectSprite.collisionRectangle);
	        if (intersect.IsEmpty)
            {
		        return (int)collisionLocation.noCollision;
	        }
            else if (intersect.Height <= 10)
	        {
                if (Math.Abs(intersect.Y - collisionRectangle.Y) < .05)
                    return (int)collisionLocation.bottom;
                else return (int)collisionLocation.top;
            }
	        else
            {
		        if (intersect.X == collisionRectangle.X) return (int)collisionLocation.right;
                else return (int)collisionLocation.left;
            }
        }

       
        public void Draw(SpriteBatch spriteBatch)
        {
            marioSprite.Draw(spriteBatch, position);
        }
    }
}
