using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    public class Bowser : ICollidable
    {
        public Rectangle collisionRectangle { get; set; }
        Texture2D texture;
        public Vector2 position;
        public int hits = 5;
        float xspeed = (float)-0.2, yspeed = 0;
        int originalxpos, direction = -1, sourcex, frame = 0, shootcheck, damaged = 0, movespeed, jumpcheck = 0, width = 35, height = 30;
        Random shoot;
        List<BowserFire> Fire = new List<BowserFire>();

        public Bowser(Texture2D Texture, Vector2 location)
        {
            sourcex = 120;
            shoot = new Random();
            texture = Texture;
            originalxpos = (int)location.X;
            position = location;
            collisionRectangle = new Rectangle((int)position.X, (int)position.Y, 30, 30);
        }

        public void Update(Game1 game1)
        {
            position.X += xspeed;
            if (position.X > originalxpos + 5 || position.X < originalxpos - 5)
            {
                xspeed = xspeed * -1;
            }
            position.Y += yspeed;
            if (jumpcheck == 0 && shoot.Next(50 - 5 * (5 - hits)) == 1)
            {
                yspeed = -10;
                jumpcheck = 1;
            }
            BowserBlock(game1);
            BowserMario(game1);
            FirePower(game1);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(sourcex + frame * direction * 40, 210, 35, 30);
            collisionRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
            if (hits > 0 && damaged % 2 == 0)
            {
                spriteBatch.Draw(texture, collisionRectangle, sourceRectangle, Color.White);
            }
            foreach (BowserFire fire in Fire)
            {
                fire.Draw(spriteBatch);
            }
        }

        void FirePower(Game1 game1)
        {
            if (frame == 0)
            {
                shootcheck = (int)shoot.Next(1, 40 - 4 * (5 - hits));
            }
            if (shootcheck == 1 && hits > 0)
            {
                movespeed = (movespeed + 1) % 6;
                if (movespeed == 0)
                {
                    frame++;
                }
                if (frame == 4)
                {
                    frame = 0;
                    Fire.Add(new BowserFire(texture, direction, new Vector2(position.X, position.Y + (int)shoot.Next(4 + (5 - hits)) * 5)));
                }
            }
            foreach (BowserFire fire in Fire)
            {
                fire.Update();
                int collide = game1.gamePlayScreen.mario.CollisionChecker(fire);
                if (collide != (int)Mario.collisionLocation.noCollision && game1.gamePlayScreen.damageTakenCounter == 0)
                {
                    game1.gamePlayScreen.collider.MarioDamage();
                    Fire.Remove(fire);
                    break;
                }
                else if (fire.position.X < game1.camera.position.X - 10 || fire.position.X > game1.camera.position.X + 800)
                {
                    Fire.Remove(fire);
                    break;
                }
            }
        }

        void BowserMario(Game1 game1)
        {
            if (damaged > 0)
            {
                damaged--;
            }
            if (game1.gamePlayScreen.mario.position.X < position.X)
            {
                sourcex = 120;
                direction = -1;
            }
            else if (game1.gamePlayScreen.mario.position.X > position.X)
            {
                sourcex = 160;
                direction = 1;
            }
            int collide = game1.gamePlayScreen.mario.CollisionChecker(this);
            if (collide == (int)Mario.collisionLocation.top && game1.gamePlayScreen.damageTakenCounter == 0 && damaged == 0 && hits > 0)
            {
                hits--;
                width += 7;
                height += 7;
                game1.gamePlayScreen.mario.speed.Y = -3;
                damaged = 30;
                game1.gamePlayScreen.hud.ScoreUpdate(2000 * (5 - hits));
            }
            else if (collide != (int)Mario.collisionLocation.noCollision && game1.gamePlayScreen.damageTakenCounter == 0 && damaged == 0 && hits > 0)
            {
                game1.gamePlayScreen.collider.MarioDamage();
            }
        }

        void BowserBlock(Game1 game1)
        {
            yspeed++;
            foreach (IStatic block in game1.gamePlayScreen.levelMgr.iStatics)
            {
                Rectangle intersect = Rectangle.Intersect(collisionRectangle, block.collisionRectangle);
                if (!intersect.IsEmpty)
                {
                    position.Y = block.collisionRectangle.Y - height;
                    yspeed = 0;
                    jumpcheck = 0;
                }
            }
        }
    }
}
