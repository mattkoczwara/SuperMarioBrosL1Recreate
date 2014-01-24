using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioProject
{
    class BulletBill : IProjectile
    {
        
        public Texture2D Texture { get; set; }
        public Vector2 position, speed, origin;
        public Rectangle collisionRectangle { get; set; }

        public BulletBill(Texture2D texture, Vector2 location)
        {
            Texture = texture;
            position.X = location.X;
            position.Y = location.Y;
            speed = new Vector2(-2, 0);
            origin.X = 0;
            origin.Y = 0;
        }

        public void Update(List<IStatic> blocks, List<Enemy> enemies)
        {
            position += speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(284, 390, 20, 40);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y + 20, 20, 40);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White, 0, origin, SpriteEffects.None, 1);
            collisionRectangle = destinationRectangle;
        }
    }
}
