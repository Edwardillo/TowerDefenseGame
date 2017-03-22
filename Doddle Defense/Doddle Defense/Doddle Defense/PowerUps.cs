using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Doddle_Defense
{
    class PowerUps
    {
        public enum tipoPowerUp
        {
            caja,
            cochebombaBalas,
            goku,
            ichigo,
            lanzallamasBalas,
            luffy,
            metralletaBalas,
            misilesBalas,
            Paracaidas,
            sasuke,
            yagami
        }
        bool enPiso = false;
        float size = 0.5f;
        tipoPowerUp powerupSeleccionado = tipoPowerUp.caja;
        Texture2D sprite;
        TimeSpan TiempoInicial;
        TimeSpan deltaT;
        Rectangle colision;
        Random random = new Random();
        Vector2 velocidad;
        //es batante lento, pero simula que tiene un paracaidas
        Vector2 aceleracion = new Vector2(0, 0.0000001f);
        Vector2 posicionInicial;
        Vector2 posicionFinal
        {
            get
            {
                return new Vector2(
                    posicionInicial.X +
                    (float)(velocidad.X * deltaT.TotalMilliseconds) +
                    (float)((aceleracion.X * deltaT.TotalMilliseconds * deltaT.TotalMilliseconds) / 2),
                    posicionInicial.Y +
                    (float)(velocidad.Y * deltaT.TotalMilliseconds) +
                    (float)((aceleracion.Y * deltaT.TotalMilliseconds * deltaT.TotalMilliseconds) / 2));
            }
        }
        

        public PowerUps(Texture2D newSprite, tipoPowerUp newTipo)
        {
            velocidad = new Vector2(0, 0);
            sprite = newSprite;
            posicionInicial = new Vector2(random.Next(0, 800 - sprite.Width), 0-sprite.Height);
            powerupSeleccionado = newTipo;
            //TiempoInicial = newTiempoInicial;
        }

        public void Update(GameTime gametime)
        {
            
            deltaT = TiempoInicial - gametime.TotalGameTime;
            if(enPiso == false)
                posicionInicial = posicionFinal;
            if (posicionInicial.Y >= 300)
                enPiso = true;
            colision = new Rectangle((int)posicionInicial.X, (int)posicionInicial.Y, (int)(sprite.Width * size), (int)(sprite.Height * size));

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(sprite, colision, Color.White);

        }
    }
}
