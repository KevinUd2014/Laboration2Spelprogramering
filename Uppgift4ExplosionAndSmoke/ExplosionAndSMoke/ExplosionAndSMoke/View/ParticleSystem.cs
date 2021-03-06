﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExplosionAndSMoke.View
{
    class ParticleSystem
    {
        private Particle[] particles;
        private const int maxParticles = 100;

        public ParticleSystem(Vector2 systemModelStartPosition)
        {
            particles = new Particle[maxParticles];
            int i;
            for (i = 0; i < maxParticles; i++)
            {
                particles[i] = new Particle(i, systemModelStartPosition);//visar vart mitten är och skickar med i
            }
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
