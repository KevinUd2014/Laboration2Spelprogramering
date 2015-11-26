using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExplosionAndSMoke.View
{
    class Particle
    {
        private int seed;
        private Vector2 systemStartPosition;
        private Vector2 position;
        private Vector2 velocity;
        private Vector2 acceleration = new Vector2(0f, 3f);
        Vector2 randomDirection;

        public Particle(int seed, Vector2 systemStartPosition)
        {
            Random rand = new Random(seed);//slumpar ut alla partiklar
            randomDirection = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.10f);// denna sätter snabheten på partiklarna!
            randomDirection.Normalize();
            randomDirection = randomDirection * ((float)rand.NextDouble() * 1.5f);// denna sätter vilken spridning partiklarna får 2f är ganska bra!
            this.seed = seed;
            this.systemStartPosition = systemStartPosition;
            position = new Vector2(systemStartPosition.X, systemStartPosition.Y);//sätter start positionen
            velocity = randomDirection;

        }
        public void Update(float elapsedTimeInSeconds)//updaterar varje frame med en position
        {
            position = position + velocity * elapsedTimeInSeconds;
            velocity = velocity + acceleration * elapsedTimeInSeconds;
        }
        public void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D texture)//ritar ut texturen med farten och en färg!
        {
            //spriteBatch.Draw(texture, camera.scaleParticles(position.X, position.Y), Color.White);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, camera.convertToVisualCoords(new Vector2(position.X, position.Y)), null, Color.White, 0f, Vector2.Zero, 0.1f, SpriteEffects.None, 0f);//denna skalar om mina partiklar!
            spriteBatch.End();
        }
    }
}
