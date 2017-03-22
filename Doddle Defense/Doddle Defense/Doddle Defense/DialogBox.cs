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
    class DialogBox
    {
        Texture2D Sprite;
        Vector2 Position;
        SpriteFont Dafont;

        string texto;
        public string Texto
        {
            get
            {
                return texto;
            }
        }

        public bool IsActive = true;

        public DialogBox(Texture2D spr, GraphicsDeviceManager graphics, SpriteFont Font)
        {
            Sprite = spr;
            Position = new Vector2(graphics.PreferredBackBufferWidth / 2 - Sprite.Width / 2, graphics.PreferredBackBufferHeight / 2 - Sprite.Height / 2);
            Dafont = Font;
            IsActive = true;
        }

        public void ModifyText(string newText)
        {
            texto = newText;
            for (int i = 37; i < texto.Count(); i += 36)
            {
                texto = texto.Insert(i, "\n");
                i += 2;
            }
            texto += "\nPresione Enter para Continuar...";
            IsActive = true; //Asi se activa Automaticamente ^^
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                IsActive = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsActive)
            {
                spriteBatch.Draw(Sprite, Position, Color.White);
                spriteBatch.DrawString(Dafont, texto, new Vector2(Position.X + 25, Position.Y + 25), Color.Black);

            }
        }




    }
}

