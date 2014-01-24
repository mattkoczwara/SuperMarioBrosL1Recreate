using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioProject
{
    class UsedBlock : IStatic
    {
        int xpos, ypos;
        Texture2D block;
        public bool state { get; set; }
        public bool isBumping { get; set; }
        public int bumped { get; set; }
        SoundManager soundMgr;
        public Rectangle collisionRectangle { get; set; }

        public UsedBlock(Texture2D b, int x, int y, SoundManager sound)
        {
            block = b;
            xpos = x;
            ypos = y;
            soundMgr = sound;
            state = true;
            isBumping = false;
            collisionRectangle = new Rectangle(xpos, ypos, 20, 20);
        }

        public void Bump()
        {
            soundMgr.marioBump.Play();
        }

        public void UnBump()
        {
            // no action
        }

        public void Update()
        {
            //no action
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            collisionRectangle = new Rectangle((int)location.X, (int)location.Y, 20, 20);
            spriteBatch.Draw(block, collisionRectangle, new Rectangle(373, 65, 16, 16), Color.White);
        }
    }
}