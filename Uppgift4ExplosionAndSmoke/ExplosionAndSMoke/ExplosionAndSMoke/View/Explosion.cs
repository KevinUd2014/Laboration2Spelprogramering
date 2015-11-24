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
        Camera camera;

        public int Width;
        public int Height;
        public int frame;
        public int frameX;
        public int frameY;
        public int frameWidth;
        public int frameHeight;

        public float timeElapsed;
        public float maxTimer = 0.5f;
        float percentAnimated;

        public int setFPS = 60;// tagen från uppgiftens sida!
        public int posFramesX = 4;
        public int posFramesY = 8;

        Vector2 startposition = new Vector2(0.5f, 0.5f);
        ParticleSystem ps;


        public Explosion(SpriteBatch spritebatch, Texture2D Explosion, Camera Camera)
        {
            timeElapsed = 0; //denna ska vara 0 när programmet startas

            camera = Camera;//så jag kan använda kameran i klassen!
            spriteBatch = spritebatch;
            explosion = Explosion;

            Width = explosion.Width; // posFramesX; //delar explosionens bredd med positions framesen!
            Height = explosion.Height; // posFramesY;
            ps = new ParticleSystem(startposition);

        }

        public void Draw(float totalSeconds)
        {
            timeElapsed += totalSeconds;

           ps.Update(totalSeconds);
           ps.Draw(spriteBatch, camera, explosion);

          /*  if (timeElapsed >= maxTimer)
            {
                timeElapsed = 0;
            }

            percentAnimated = timeElapsed / maxTimer;
            frame = (int)(percentAnimated * setFPS);
            frameX = frame % posFramesX;//fick dessa från kurssidan!
            frameY = frame / posFramesY;

            frameWidth = explosion.Width / posFramesX;
            frameHeight = explosion.Height / posFramesY;

            Rectangle rect = new Rectangle(frameWidth * frameX, frameHeight * frameY, frameWidth, frameHeight);// denna sätter storleken på hela bilden!

            spriteBatch.Begin();
            spriteBatch.Draw(explosion, camera.convertToVisualCoords(new Vector2(0.5f, 0.5f), this), rect, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            spriteBatch.End();*/
        }
    }
}
