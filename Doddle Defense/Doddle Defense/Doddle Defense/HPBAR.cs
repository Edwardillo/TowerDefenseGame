using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Doddle_Defense
{
    class HPBAR
    {
        int InitialHealth;
        Texture2D Base;
        Texture2D HealthBar;
        //Texture2D Tileset;
        Vector2 Position;
        Rectangle BaseRectangle;
        Rectangle HealthRectangle;
        float SizeX = 0.5f;
        float SizeY = 0.4f;
        float RemainingHelth; //Works as Size;


        public HPBAR(Texture2D newBase, Texture2D Healthb, int FullHealth)
        {
            Base = newBase;
            HealthBar = Healthb;
            InitialHealth = FullHealth;
        }

        public void Update(int ActualHealth, Vector2 ActualPos) //Actual Pos.X siempre se manda desde el centro del otro sprite.
        {
           
            if (ActualPos != Vector2.Zero)
            {
                
                Position.X = ActualPos.X - BaseRectangle.Width / 2;
                Position.Y = ActualPos.Y - BaseRectangle.Height;
            }

            if (Position == Vector2.Zero)
            {
                SizeX = 1;
                SizeY = 1;
            }

            RemainingHelth = ActualHealth / (float)InitialHealth;

            BaseRectangle = new Rectangle((int)Position.X, (int)Position.Y, (int)(Base.Width * SizeX), (int)(Base.Height * SizeY));
            HealthRectangle = new Rectangle((int)Position.X, (int)Position.Y, (int)(Base.Width * RemainingHelth * SizeX), (int)(Base.Height * SizeY));

        }

        public void Draw(SpriteBatch spriteBatch,int ItemId = -1)
        {
            spriteBatch.Draw(Base,BaseRectangle,Color.White);
            spriteBatch.Draw(HealthBar,HealthRectangle,Color.White);
        }
    }
}
