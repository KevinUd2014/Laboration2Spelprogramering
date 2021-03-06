﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExplosionAndSMoke.View
{
    class ExplosionManager
    {
        SpriteBatch spriteBatch;
        Texture2D texture;
        Camera camera;

        private Vector2 systemStartPosition;
        private Vector2 position;

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

        public ExplosionManager(SpriteBatch spritebatch, Texture2D Texture, Camera Camera, Vector2 SystemStartPosition)
        {
            timeElapsed = 0; //denna ska vara 0 när programmet startas

            camera = Camera;//så jag kan använda kameran i klassen!
            spriteBatch = spritebatch;
            texture = Texture;

            systemStartPosition = SystemStartPosition;
            position = new Vector2(SystemStartPosition.X, SystemStartPosition.Y);//sätter start positionen

            Width = texture.Width / posFramesX; //delar explosionens bredd med positions framesen!
            Height = texture.Height / posFramesY;
        }

        public void Draw(float totalSeconds)
        {
            timeElapsed += totalSeconds;

            percentAnimated = timeElapsed / maxTimer;
            frame = (int)(percentAnimated * setFPS);
            frameX = frame % posFramesX;//fick dessa från kurssidan!
            frameY = frame / posFramesY;

            frameWidth = texture.Width / posFramesX;
            frameHeight = texture.Height / posFramesY;

            Rectangle rect = new Rectangle(frameWidth * frameX, frameHeight * frameY, frameWidth, frameHeight);// denna sätter storleken på hela bilden!

            spriteBatch.Begin();
            spriteBatch.Draw(texture, camera.convertToVisualCoords(new Vector2(position.X, position.Y)), rect, Color.White, 0, new Vector2(frameWidth/2, frameHeight/2), 1, SpriteEffects.None, 0);
            spriteBatch.End();
        }
    }
}
