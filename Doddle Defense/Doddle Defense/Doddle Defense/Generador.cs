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
    class Generador
    {
        Texture2D texture;
        float anchodepantalla;
        float densidad;
        float timer;
        List<Particulas> particulas = new List<Particulas>();
        Random rand1,rand2;

        public Generador(Texture2D newTexture, float newTamano, float newDensidad)
        {
            rand1 = new Random();
            rand2 = new Random();
            texture = newTexture;
            anchodepantalla = newTamano;
            densidad = newDensidad;
        }

        public void Crear()
        {
            //este doble es necesario porque despues sale feo, aunque no hace nada.
            double bla = rand1.Next();
            particulas.Add(new Particulas(texture, new Vector2(
                -500 + (float)rand1.NextDouble() * anchodepantalla*3, 0),
                new Vector2(1, rand2.Next(2, 4))));

        }

        public void Update(GameTime gameTime, GraphicsDevice graphics)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            while (timer > 0)
            {
                timer -= 1f / densidad;
                Crear();
            }
            for (int i = 0; i < particulas.Count; i++)
            {
                particulas[i].Update();

                if (particulas[i].Posicion.Y > graphics.Viewport.Height)
                {
                    particulas.RemoveAt(i);
                    i--;
                }
            }
        }
        

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Particulas particula in particulas)
                particula.draw(spriteBatch);
        }
    }
}

