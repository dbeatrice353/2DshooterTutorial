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
    public class Asteroid
    {
        public Texture2D texture;
        public Vector2 origin;
        public Vector2 position;
        public Rectangle boundingBox;
        public float rotationAngle;
        public int speed;

        public bool isVisible;
        Random random;
        public float randX, randY;

        // Constructor
        public Asteroid(Texture2D newTexture, Vector2 newPosition)
        {
            position = newPosition;
            texture = newTexture;
            speed = 4;
            random = new Random();
            randX = random.Next(0,600);
            randY = random.Next(-600,-50);
            isVisible = true;
        }

        // Load content
        public void LoadContent(ContentManager Content)
        {
        }

        public void Update(GameTime gameTime)
        {
            // set bounding box for collision
            boundingBox = new Rectangle((int)position.X, (int)position.Y, 45, 45);

            // update origin
            origin.X = texture.Width / 2;
            origin.Y = texture.Height / 2;


            //Update movement
            position.Y = position.Y + speed;

            // Rotate Asteroid
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            rotationAngle += elapsed;
            float circle = MathHelper.Pi * 2;
            rotationAngle = rotationAngle % circle;

            if (position.Y > 750)
                isVisible = false;
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
                spriteBatch.Draw(texture, position, null, Color.White, rotationAngle, origin, 1.0f, SpriteEffects.None, 0f);
        }
    }
}
