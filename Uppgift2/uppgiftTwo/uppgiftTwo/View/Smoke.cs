using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uppgiftTwo
{
    class Smoke
    {
        private int seed;
        private Vector2 systemStartPosition;
        private Vector2 position;
        private Vector2 velocity;
        private Vector2 acceleration = new Vector2(0f, -6f);
        Vector2 randomDirection;
        public float maximalSpeed = 1f;
        

        public Smoke( Vector2 systemStartPosition)
        {
            Random rand = new Random();//slumpar ut alla partiklar
            randomDirection = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.5f);
            randomDirection.Normalize();
            randomDirection = randomDirection * ((float)rand.NextDouble() * maximalSpeed);
            this.systemStartPosition = systemStartPosition;
            position = new Vector2(systemStartPosition.X, systemStartPosition.Y);//sätter start positionen
            velocity = randomDirection;
        }

        public void reset()
        {

        }
        internal void Update(float elapsedTimeInSeconds)//updaterar varje frame med en position 
        {
            position = position + velocity * elapsedTimeInSeconds;
            velocity = velocity + acceleration * elapsedTimeInSeconds;
        }
        internal void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D texture)//ritar ut texturen med farten och en färg!
        {
            spriteBatch.Draw(texture, camera.scaleParticles(position.X, position.Y), null, Color.White, 0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);//denna skalar om mina partiklar!
        }
        //public bool lifeOfParticle()
        //{
        //    return lifetime <= maxTimeForSprite;
        //}
    }
}
