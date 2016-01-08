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
        public Texture2D bulletTexture;
        public Vector2 position;
        public int speed;
        public float bulletDelay;

        // collision variables
        public Rectangle boundingBox;
        public bool isColliding;
        public List<Bullet> bulletList;

        // constructor
        public Player()
        {
            bulletList = new List<Bullet>();
            texture = null;
            position = new Vector2(300, 300);
            speed = 10;
            isColliding = false;
            bulletDelay = 5;
        }

        // Load content
        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("ship");
            bulletTexture = Content.Load<Texture2D>("playerbullet");
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
            foreach (Bullet b in bulletList)
                b.Draw(spriteBatch);
        }

        // Update
        public void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();

            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            // fire bullets
            if (keyState.IsKeyDown(Keys.Space))
                Shoot();

            UpdateBullets();

            // Ship controls
            if (keyState.IsKeyDown(Keys.W))
                position.Y = position.Y - speed;

            if (keyState.IsKeyDown(Keys.A))
                position.X = position.X - speed;

            if (keyState.IsKeyDown(Keys.S))
                position.Y = position.Y + speed;

            if (keyState.IsKeyDown(Keys.D))
                position.X = position.X + speed;
        
            // keep player ship in screen bounds

            if (position.X <= 0)
                position.X = 0;

            if (position.X >= 600 - texture.Width)
                position.X = 600 - texture.Width;

            if (position.Y <= 0)
                position.Y = 0;

            if (position.Y >= 750 - texture.Height)
                position.Y = 750 - texture.Height;

        }

        // shoot method
        public void Shoot()
        {
            if (bulletDelay <= 0 && bulletList.Count() < 20) 
            {
                Bullet newBullet = new Bullet(bulletTexture);
                newBullet.position = new Vector2(position.X + 32 - newBullet.texture.Width / 2, position.Y + 30);
                newBullet.isVisible = true;
                bulletList.Add(newBullet);

                if (bulletDelay <= 0)
                    bulletDelay = 5;
            }
        }

        public void UpdateBullets()
        {
            if (bulletDelay >= 0)
                bulletDelay--;

            foreach (Bullet b in bulletList)
            {
                b.boundingBox = new Rectangle((int)b.position.X, (int)b.position.Y, b.texture.Width, b.texture.Height);
                b.position.Y = b.position.Y - b.speed;

                if (b.position.Y <= 0)
                    b.isVisible = false;
            }

            for(int i = 0; i < bulletList.Count; i++)
            {
                if (!bulletList[i].isVisible)
                {
                    bulletList.RemoveAt(i);
                    i--;
                }
            }
        }
	}
}
