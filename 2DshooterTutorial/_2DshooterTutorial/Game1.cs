///
/// Last tutorial finished: #15 12/27/2015, 8pm
///

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

namespace _2DshooterTutorial
{ 
    // main
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Random random = new Random();

        List<Asteroid> asteroidList = new List<Asteroid>();
        Player p = new Player();
        Starfield sf = new Starfield();

        // constructor 
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 750;
            this.Window.Title = "XNA - 2D Space Shooter Tutorial";
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            p.LoadContent(Content);
            sf.LoadContent(Content);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            LoadAsteroids();
            foreach (Asteroid a in asteroidList)
            {
                // check for collision
                if (a.boundingBox.Intersects(p.boundingBox))
                    a.isVisible = false;
                for (int i = 0; i < p.bulletList.Count; i++)
                {
                    if (a.boundingBox.Intersects(p.bulletList[i].boundingBox))
                    {
                        a.isVisible = false;
                        p.bulletList[i].isVisible = false;
                    }
                }
                a.Update(gameTime);
            }
            p.Update(gameTime);
            sf.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(); // begin drawing
            sf.Draw(spriteBatch);
            foreach (Asteroid a in asteroidList)
            {
                a.Draw(spriteBatch);
            }
            p.Draw(spriteBatch);
            spriteBatch.End();   // end drawing

            base.Draw(gameTime);
        }

        public void LoadAsteroids()
        {   
            // random coordinates for new asteroid
            int randX = random.Next(0,600);
            int randY = random.Next(-600, -50);

            if (asteroidList.Count < 5)
            {
                asteroidList.Add(new Asteroid(Content.Load<Texture2D>("asteroid"), new Vector2(randX, randY)));
            }

            // destroy any asteroids that have gone out of site.
            for (int i = 0; i < asteroidList.Count; i++)
            {
                if (!asteroidList[i].isVisible)
                {
                    asteroidList.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
 