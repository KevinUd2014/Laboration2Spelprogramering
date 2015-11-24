using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace explosionAndSmoke.Explosion
{
    class ExplosionManager
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
        private Vector2 startLocationInWindow;

        private float scaleOfSprite;
        public float timeElapsed;
        public float maxTimer = 0.5f;
        float percentAnimated;

        public int setFPS = 60;// tagen från uppgiftens sida!
        public int posFramesX = 4;
        public int posFramesY = 8;



        public ExplosionManager(SpriteBatch spritebatch, Texture2D Explosion, Camera Camera, Vector2 startInWindow, float ScaleOfSprite)
        {
            scaleOfSprite = ScaleOfSprite;
            startLocationInWindow = startInWindow;// start positionen för allt!
            timeElapsed = 0; //denna ska vara 0 när programmet startas

            camera = Camera;//så jag kan använda kameran i klassen!
            spriteBatch = spritebatch;
            explosion = Explosion;

            Width = explosion.Width / posFramesX; //delar explosionens bredd med positions framesen!
            Height = explosion.Height / posFramesY;

        }

        public void Draw(float totalSeconds)
        {
            timeElapsed += totalSeconds;

            if (timeElapsed >= maxTimer)
            {
                timeElapsed = 0;
            }

            percentAnimated = timeElapsed / maxTimer;
            frame = (int)(percentAnimated * setFPS);
            frameX = frame % posFramesX;//fick dessa från kurssidan!
            frameY = frame / posFramesY;

            frameWidth = explosion.Width / posFramesX;
            frameHeight = explosion.Height / posFramesY;

            Rectangle rectangle = new Rectangle(frameWidth * frameX, frameHeight * frameY, frameWidth, frameHeight);// denna sätter storleken på hela bilden!

            spriteBatch.Begin();
            spriteBatch.Draw(explosion, camera.convertToVisualCoords(startLocationInWindow, frameWidth, frameHeight, scaleOfSprite), rectangle, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            spriteBatch.End();
        }
    }
}
