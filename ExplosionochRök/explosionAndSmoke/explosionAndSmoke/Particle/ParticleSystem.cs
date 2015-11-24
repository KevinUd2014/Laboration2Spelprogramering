using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace explosionAndSmoke.Particle
{
    class ParticleSystem
    {
        private float ageTimer = 5f;
        private float Timer = 0;
        private Particle[] particles;
        private const int maxParticles = 100;

        public ParticleSystem(Texture2D spark, SpriteBatch spriteBatch, Camera camera, float scale, Vector2 startLocation)
        {
            //particles = new Particle[maxParticles];
            int i = 0;
            if (particles.Length < maxParticles)//det ska inte vara length här men vet inte annars!
            {

            }
            //for (i = 0; i < maxParticles; i++)
            //{
            //    particles[i] = new Particle(i, systemModelStartPosition);//visar vart mitten är och skickar med i
            //}
        }
        public void Update(float elapsedTime)
        {
            int i;
            for (i = 0; i < maxParticles; i++)
            {
                particles[i].Update(elapsedTime);
            }
        }
        public void Draw(SpriteBatch spritebatch, Camera camera, Texture2D texture)
        {
            int i;
            for (i = 0; i < maxParticles; i++)
            {
                particles[i].Draw(spritebatch, camera, texture);
            }
        }
    }
}
