using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExplosionAndSMoke.View
{
    class Explosion
    {
        SpriteBatch spriteBatch;
        Texture2D explosion;
        Texture2D smoke;
        Camera camera;

        public int Width;
        public int Height;

        public float timeElapsed;
        public float maxTimer = 0.5f;
        //float percentAnimated;

        /*public int setFPS = 60;// tagen från uppgiftens sida!
        public int posFramesX = 4;
        public int posFramesY = 8;*/

        Vector2 startposition = new Vector2(0.8f, 0.5f);
        ParticleSystem particleSystem;
        SmokeSystem smokeSystem;
        
        public Explosion(SpriteBatch spritebatch, Texture2D Explosion, Camera Camera, Texture2D Smoke)
        {
            timeElapsed = 0; //denna ska vara 0 när programmet startas

            camera = Camera;//så jag kan använda kameran i klassen!
            spriteBatch = spritebatch;
            explosion = Explosion;
            smoke = Smoke;

            Width = explosion.Width; // posFramesX; //delar explosionens bredd med positions framesen!
            Height = explosion.Height; // posFramesY;

            particleSystem = new ParticleSystem(startposition);
            smokeSystem = new SmokeSystem(smoke, startposition, camera);//får inte denna att fungera
        }

        public void Update(float totalseconds)
        {
            smokeSystem.Update(totalseconds);
        }
        public void Draw(float totalSeconds)
        {
            timeElapsed += totalSeconds;

            particleSystem.Update(totalSeconds);
            particleSystem.Draw(spriteBatch, camera, explosion);

           // smokeSystem.Update(totalSeconds);//får inte dessa att funka
            smokeSystem.Draw(spriteBatch);

        }
    }
}
