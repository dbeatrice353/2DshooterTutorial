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
	public class Player
	{
        public Texture2D texture;
        public Vector2 position;
        public int speed;

        // collision variables
        public Rectangle boundingBox;
        public bool isColliding;

        // constructor
        public Player()
        { }

        // Load content
        public void LoadContent(ContentManager Content)
        { }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        { }

        // Update
        public void Update(GameTime gameTime)
        { }
	}
}
