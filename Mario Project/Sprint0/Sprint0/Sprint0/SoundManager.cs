using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace MarioProject
{
    public class SoundManager
    {
        public SoundEffect marioSmallJump, marioBigJump, marioBump, marioStomp, marioKick, marioBrickSmash, marioDied;
        public SoundEffect marioPause, marioGameOver, marioFireball, marioFirework, marioFlagSlide, marioPipePowerLoss, marioGrenade;
        public SoundEffect marioStageClear;
        public SoundEffect itemAppears, itemCoin, itemPowerUp, itemOneUp;
        public SoundEffectInstance marioSmallJumpInstance, marioKickInstance, marioBigJumpInstance, marioFlagSlideInstance;
        public Song marioOverworld, marioUnderworld, hurryOverworld, hurryUnderworld, marioStarpower;

        public void Load(Game game)
        {
            marioOverworld = game.Content.Load<Song>("Sounds/overworldMT");
            marioUnderworld = game.Content.Load<Song>("Sounds/underworldMT");
            hurryOverworld = game.Content.Load<Song>("Sounds/overworldHurry");
            hurryUnderworld = game.Content.Load<Song>("Sounds/underworldHurry");
            marioStarpower = game.Content.Load<Song>("Sounds/starpowerMT");
            marioPause = game.Content.Load<SoundEffect>("Sounds/marioPause");
            marioGameOver = game.Content.Load<SoundEffect>("Sounds/marioGameOver");
            marioFirework = game.Content.Load<SoundEffect>("Sounds/marioFirework");
            marioFlagSlide = game.Content.Load<SoundEffect>("Sounds/marioFlagSlide");
            marioStageClear = game.Content.Load<SoundEffect>("Sounds/marioStageClear");
            marioPipePowerLoss = game.Content.Load<SoundEffect>("Sounds/marioPipePowerLoss");

            marioSmallJump = game.Content.Load<SoundEffect>("Sounds/marioSmallJump");
            marioBigJump = game.Content.Load<SoundEffect>("Sounds/marioBigJump");
            marioBump = game.Content.Load<SoundEffect>("Sounds/marioBump");
            marioBrickSmash = game.Content.Load<SoundEffect>("Sounds/marioBrickSmash");
            marioStomp = game.Content.Load<SoundEffect>("Sounds/marioStomp");
            marioKick = game.Content.Load<SoundEffect>("Sounds/marioKick");
            marioDied = game.Content.Load<SoundEffect>("Sounds/marioDied");
            marioFireball = game.Content.Load<SoundEffect>("Sounds/marioFireball");
            marioGrenade = game.Content.Load<SoundEffect>("Sounds/grenadeExplosion");

            itemAppears = game.Content.Load<SoundEffect>("Sounds/itemAppears");
            itemCoin = game.Content.Load<SoundEffect>("Sounds/itemCoin");
            itemOneUp = game.Content.Load<SoundEffect>("Sounds/itemOneUp");
            itemPowerUp = game.Content.Load<SoundEffect>("Sounds/itemPowerUp");

            marioSmallJumpInstance = marioSmallJump.CreateInstance();
            marioBigJumpInstance = marioBigJump.CreateInstance();
            marioKickInstance = marioKick.CreateInstance();
            marioFlagSlideInstance = marioFlagSlide.CreateInstance();
        }
    }
}