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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //Enemigos frieza;
        Generador lluvia;
        PowerUps testPu;
        const float Tdensidad = 20;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {

            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            lluvia = new Generador(Content.Load<Texture2D>("Meteorito"), graphics.GraphicsDevice.Viewport.Width, Tdensidad);
            //frieza = new Enemigos(Enemigos.tipoEnemigo.rioma, Content.Load<Texture2D>("test"), Content.Load<Texture2D>("HealthBar"), Content.Load<Texture2D>("Elife"));
            testPu = new PowerUps(Content.Load <Texture2D>("Box"), PowerUps.tipoPowerUp.caja);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {

            lluvia.Update(gameTime, GraphicsDevice);
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            testPu.Update(gameTime);
            //frieza.Update(gameTime);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            lluvia.Draw(spriteBatch);
            testPu.Draw(spriteBatch);

            
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
