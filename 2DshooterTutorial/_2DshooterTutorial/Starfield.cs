using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2DshooterTutorial
{
    public class Starfield
    {
        public Texture2D texture;
        public Vector2 bgPos1, bgPos2;
        public int speed;

        // Constructor
        public Starfield()
        {
            texture = null;
            bgPos1 = new Vector2(0, 0);
            bgPos2 = new Vector2(0, -750);
            speed = 5;
        }

        // load content
        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("space");
        }

        // draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bgPos1, Color.White);
            spriteBatch.Draw(texture, bgPos2, Color.White);
        }

        // Update
        public void Update(GameTime gameTime)
        {
            bgPos1.Y = bgPos1.Y + speed;
            bgPos2.Y = bgPos2.Y + speed;

            // scrolling background (repeating)
            if (bgPos1.Y >= 750)
            {
                bgPos1.Y = 0;
                bgPos2.Y = -750;
            }
        }
    }
}
