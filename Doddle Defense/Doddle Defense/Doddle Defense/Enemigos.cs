using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Doddle_Defense
{
    class Enemigos
    {
        public enum tipoEnemigo
        {
            frieza,
            kamikaze,
            minato,
            nave,
            rioma
        }

        tipoEnemigo tEnemigo;
        HPBAR barraVida;
        Vector2 posicion;
        Vector2 velocidad;
        Texture2D sprite;
        Texture2D tBarraVida;
        Texture2D tBarraVidaE;
        Rectangle colision;
        //Rectangle sourceRect;
        Point frameActual = new Point(0, 0);
        Point frameCount;
        Random random = new Random();
        bool isMoving = true;
        bool isVisible = true;
        bool golpeoTorre = false;
        float delay;
        float elapsed;
        float constante = 0.05f;
        float size = 0.3f;
        float distanciaTotal;
        int vida;
        //int dano;

        public Enemigos(tipoEnemigo newTipo, Texture2D newSprite,Texture2D newBarravida, Texture2D newBarravidaE)
        {
            tEnemigo = newTipo;
            sprite = newSprite;
            tBarraVida = newBarravida;
            tBarraVidaE = newBarravidaE;

            if (tEnemigo == tipoEnemigo.frieza)
            {
                frameCount = new Point(1, 1);
                velocidad = new Vector2(random.Next(1,4),0);
                posicion = new Vector2(700, random.Next(0, 400));
                distanciaTotal = 150;
                delay = 500;
                vida = 500;
                barraVida = new HPBAR(newBarravida, newBarravidaE, vida);
                
            }

            if (tEnemigo == tipoEnemigo.kamikaze)
            {
                frameCount = new Point(1, 1);
                velocidad = new Vector2(random.Next(15, 20), 0);
                posicion = new Vector2(900, 350);
                vida = 500;
                barraVida = new HPBAR(newBarravida, newBarravidaE, vida);
            }

            if (tEnemigo == tipoEnemigo.minato)
            {
                frameCount = new Point(1, 1);
                velocidad = new Vector2(random.Next(4, 6), 0);
                posicion = new Vector2(900, 350);
                delay = 300;
                vida = 500;
                barraVida = new HPBAR(newBarravida, newBarravidaE, vida);
            }

            if (tEnemigo == tipoEnemigo.nave)
            {
                frameCount = new Point(1, 1);
                velocidad = new Vector2(random.Next(2,7),0);
                posicion = new Vector2(900, random.Next(0,300));
                vida = 500;
                barraVida = new HPBAR(newBarravida, newBarravidaE, vida);
            }

            if (tEnemigo == tipoEnemigo.rioma)
            {
                frameCount = new Point(1, 1);
                velocidad = new Vector2(random.Next(2, 4), 0);
                posicion = new Vector2(900, 350);
                distanciaTotal = random.Next(150+sprite.Width,300);
                vida = 500;
                barraVida = new HPBAR(newBarravida, newBarravidaE, vida);
            }

        }

        public void Update(GameTime gameTime)
        {
            if (tEnemigo == tipoEnemigo.frieza)
                Frieza(gameTime);

            if (tEnemigo == tipoEnemigo.kamikaze)
                Kamikaze();

            if (tEnemigo == tipoEnemigo.minato)
                Minato(gameTime);

            if (tEnemigo == tipoEnemigo.nave)
                Nave();

            if (tEnemigo == tipoEnemigo.rioma)
                Rioma();

            barraVida.Update(vida, new Vector2(posicion.X + ((sprite.Width/2) *size) ,posicion.Y));
        }

        void Frieza(GameTime gameTime)
        {
            posicion -= velocidad;
            if (distanciaTotal > 0)
                distanciaTotal -= velocidad.X;

            if (distanciaTotal <= 0)
                isMoving = false;
            colision = new Rectangle((int)posicion.X, (int)posicion.Y, (int)((sprite.Width / frameCount.X) * size), (int)((sprite.Height / frameCount.Y) * size));
            //sourceRect = new Rectangle((sprite.Width / frameCount.X), sprite.Height / frameCount.Y, (int)((sprite.Width / frameCount.X) * size), (int)((sprite.Height / frameCount.Y) * size));
            
            if (isMoving == false)
            {
                velocidad.X = 0;
                elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                velocidad.Y += constante;

                if (elapsed > delay)
                {
                    constante *= -1;

                    elapsed = delay*-1;
                }
            }
        }

        void Kamikaze()
        {
            posicion -= velocidad;
            colision = new Rectangle((int)posicion.X, (int)posicion.Y, sprite.Width, sprite.Height);
        }

        void Minato(GameTime gameTime)
        {
            posicion -= velocidad;
            colision = new Rectangle((int)posicion.X, (int)posicion.Y, (int)((sprite.Width / frameCount.X) * size), (int)((sprite.Height / frameCount.Y) * size));
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (golpeoTorre == true)
            {
                posicion = new Vector2(700, 350);
                velocidad = Vector2.Zero;
                delay = 2000;
            }
            if (elapsed > delay && golpeoTorre == true)
            {
                golpeoTorre = false;
                velocidad = new Vector2(random.Next(4, 6), 0);
                delay = 300;
            }
            if (elapsed > delay && isVisible == true && golpeoTorre == false)
            {
                isVisible = false;
                posicion.Y = random.Next(0, 350);
                elapsed = 0;
            }
            if (elapsed > delay && isVisible == false && golpeoTorre == false)
            {
                isVisible = true;

                elapsed = 0;
            }

        }

        void Nave()
        {
            posicion -= velocidad;
            colision = new Rectangle((int)posicion.X, (int)posicion.Y, (int)((sprite.Width / frameCount.X) * size), (int)((sprite.Height / frameCount.Y) * size));

        }

        void Rioma()
        {
            posicion -= velocidad;

            if (distanciaTotal > 0)
                distanciaTotal -= velocidad.X;

            if (distanciaTotal <= 0)
                velocidad.X = 0;
            colision = new Rectangle((int)posicion.X, (int)posicion.Y, sprite.Width, sprite.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
            {
                spriteBatch.Draw(sprite, colision, Color.White);
                barraVida.Draw(spriteBatch);
            }
            //spriteBatch.Draw(sprite, colision, sourceRect, Color.White);
        }
    }
}
