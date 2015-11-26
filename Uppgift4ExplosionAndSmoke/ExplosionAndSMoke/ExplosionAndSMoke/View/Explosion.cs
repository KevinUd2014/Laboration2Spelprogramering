using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExplosionAndSMoke.View
{
    class Explosion
    {
        SpriteBatch spriteBatch;
        Texture2D particle;
        Texture2D smoke;
        Texture2D bangExplosion;
        Camera camera;

        public int Width;
        public int Height;

        public float timeElapsed;
        public float maxTimer = 0.5f;

        Vector2 startposition = new Vector2(0.5f, 0.5f);
        ParticleSystem particleSystem;
        SmokeSystem smokeSystem;
        ExplosionManager explosionManager;
        
        public Explosion(SpriteBatch spritebatch, Texture2D Particle, Camera Camera, Texture2D Smoke, Texture2D BangExplosion)
        {
            timeElapsed = 0; //denna ska vara 0 när programmet startas

            camera = Camera;//så jag kan använda kameran i klassen!
            spriteBatch = spritebatch;
            particle = Particle;
            bangExplosion = BangExplosion;
            smoke = Smoke;

            Width = particle.Width; // posFramesX; //delar explosionens bredd med positions framesen!
            Height = particle.Height; // posFramesY;

            particleSystem = new ParticleSystem(startposition);
            smokeSystem = new SmokeSystem(smoke, startposition, camera);//får inte denna att fungera
            explosionManager = new ExplosionManager(spriteBatch, BangExplosion, camera, startposition);
        }

        public void Update(float totalseconds)
        {
            smokeSystem.Update(totalseconds);
        }
        public void Reset(float totalSeconds)
        {
            particleSystem = new ParticleSystem(startposition);
            smokeSystem = new SmokeSystem(smoke, startposition, camera);//får inte denna att fungera
            explosionManager = new ExplosionManager(spriteBatch, bangExplosion, camera, startposition);
            timeElapsed = 0;
        }
        public void Draw(float totalSeconds)
        {
            timeElapsed += totalSeconds;

            particleSystem.Update(totalSeconds);
            particleSystem.Draw(spriteBatch, camera, particle);
            
            smokeSystem.Draw(spriteBatch);
            explosionManager.Draw(totalSeconds);

        }
    }
}
