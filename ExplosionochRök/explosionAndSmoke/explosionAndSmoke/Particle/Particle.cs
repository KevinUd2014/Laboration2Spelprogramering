﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace explosionAndSmoke.Particle
{
    class Particle
    {
        private int seed;

        private float particleLifeTime;

        private Texture2D particle;

        Camera oCamera;

        private Vector2 systemStartPosition;
        private Vector2 position;
        private Vector2 velocity;
        private Vector2 acceleration = new Vector2(0f, 10f);
        Vector2 randomDirection;

        public Particle(int Seed, Texture2D Texture, SpriteBatch Spritebatch, Camera camera, float Scale, Vector2 SystemStartPosition, float ParticleLifeTime)
        {
            particleLifeTime = ParticleLifeTime;
            particle = Texture;
            systemStartPosition = SystemStartPosition;
            oCamera = camera;

            Random rand = new Random(seed);//slumpar ut alla partiklar
            randomDirection = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.5f);
            randomDirection.Normalize();
            randomDirection = randomDirection * ((float)rand.NextDouble() * 2f);
            seed = Seed;
            
            position = new Vector2(systemStartPosition.X, systemStartPosition.Y);//sätter start positionen
            //velocity = new Vector2(0, -1);//sätter farten
            velocity = randomDirection;

        }
        internal void Update(float elapsedTimeInSeconds)//updaterar varje frame med en position
        {
            position = position + velocity * elapsedTimeInSeconds;
            velocity = velocity + acceleration * elapsedTimeInSeconds;
        }
        internal void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D texture)//ritar ut texturen med farten och en färg!
        {
            //spriteBatch.Draw(texture, camera.scaleParticles(position.X, position.Y), Color.White);
            spriteBatch.Draw(texture, camera.convertToVisualCoords(position, ), null, Color.White, 0f, Vector2.Zero, 0.1f, SpriteEffects.None, 0f);//denna skalar om mina partiklar!
        }
    }
}
