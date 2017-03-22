using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Doddle_Defense
{
    class Effect
    {

        Texture2D Sprite;
        Vector2 Position;
        Rectangle Source;


        int Delay = 30;
        float Elapsed = 0;
        int FrameAct = 0;
        int FrameCount;

        public bool AnimationDone = false;

        float Size = 1f;

        SpriteEffects Facing = SpriteEffects.None;


        public Effect(Texture2D spr, Vector2 Pos, int FrameC)
        {
            Sprite = spr;
            FrameCount = FrameC;
            Position = new Vector2(Pos.X, Pos.Y);

        }

        public Effect(Texture2D spr, Vector2 Pos, float size, int PFacing, int FrameC)
        {
            Sprite = spr;
            Position = new Vector2(Pos.X, Pos.Y);
            if (PFacing == -1)
            {
                Facing = SpriteEffects.FlipHorizontally;
                Position.X -= 15;
            }
            FrameCount = FrameC;
            Size = size;
        }

        public void Update(GameTime gameTime)
        {
            Elapsed += (float)gameTime.ElapsedGameTime.Milliseconds;
            if (Elapsed > Delay)
            {
                FrameAct++;
                if (FrameAct >= FrameCount)
                {
                    AnimationDone = true;
                    FrameAct = 0;
                }

                Elapsed = 0;
            }

            Source = new Rectangle((int)(FrameAct * (Sprite.Width / FrameCount)), 0, Sprite.Width / FrameCount, Sprite.Height);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, new Rectangle((int)Position.X, (int)Position.Y, (int)(Sprite.Width / FrameCount * Size), (int)(Sprite.Height * Size)), Source, Color.White, 0f, new Vector2(Sprite.Width / (FrameCount * 2), Sprite.Height / 2), Facing, 0);
        }

    }
}