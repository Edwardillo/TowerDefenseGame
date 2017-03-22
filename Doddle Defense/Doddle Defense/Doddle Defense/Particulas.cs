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
    class Particulas
    {
        Vector2 posicion;
        Vector2 velocidad;
        Texture2D textura;
        Rectangle rectangulo;
        float size;
        Random rSize=new Random();

        public Vector2 Posicion
        {
            get { return posicion; }

        }
        
        public Particulas(Texture2D newTextura, Vector2 newPosicion, Vector2 newVelocidad)
        {

            size = (float)rSize.Next(10,20);
            textura = newTextura;
            posicion = newPosicion;
            velocidad = newVelocidad;

        }

        public void Update()
        {
            posicion += velocidad;
            rectangulo = new Rectangle((int)posicion.X, (int)posicion.Y, (int)(textura.Height/size), (int)(textura.Width/size));
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, rectangulo, Color.White);
        }
    }


}
