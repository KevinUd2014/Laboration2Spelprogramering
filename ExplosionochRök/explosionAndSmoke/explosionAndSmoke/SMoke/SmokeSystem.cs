﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace explosionAndSmoke.SMoke
{
    class SmokeSystem
    {
        private Smoke[] particels;
        private float maxLife;

        private int maxParticleCount;
        private int offset;
        //private int firstInLine;

        private float elapsedTime;
        private Texture2D texture;
        private Random r;

        public SmokeSystem(Texture2D texture)
        {
            maxParticleCount = 200;//hur många partiklar ska jag ha?
            particels = new Smoke[maxParticleCount];//lägger in alla i en array med partiklar
            elapsedTime = 0;//den gångna tiden
            offset = 0;
            //firstInLine = 0;
            maxLife = 7000;
            this.texture = texture;
            r = new Random();
        }

        public void Update(GameTime gameTime)
        {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;//sätter så at det räknas i millisekunder

            if (elapsedTime > maxLife / maxParticleCount)// om tiden är större än max livet delat på max partiklar så körs denna!
            {
                if (offset < maxParticleCount)// går in i denna om nu en partikels tid är ute
                {

                    particels[offset] = new Smoke();
                    resetParticle(particels[offset]);// kör om med samma partiklar från början

                    offset++;
                    elapsedTime = 0;// och startar om tiden för dessa!
                }
            }

            for (int i = 0; i < offset; i++)
            {
                particels[i].Update(gameTime);

                if (particels[i].age > maxLife)
                    resetParticle(particels[i]);
            }

        }

        public void Draw(SpriteBatch sb)
        {
            for (int i = 0; i < offset; i++)
            {
                particels[i].Draw(sb, texture, maxLife);
            }
        }

        private void resetParticle(Smoke smoke)// denna kommer reseta allt
        {
            Vector2 position = new Vector2(500, 500);//börjar på positionen
            float speed = 0.3f;//farten på partiklarna
            Vector2 velocity = new Vector2((float)r.NextDouble() * 2f - 1f, (float)r.NextDouble() * 2f - 1f);

            velocity.Normalize();
            velocity = velocity * speed;

            float rotation = (float)r.NextDouble() * 2f * (float)Math.PI;//denna kommer rotera partiklarna lite
            float allTheRadians = 2f * (float)Math.PI;// gör så att partiklarna roterar runt mitten av spriten
            float rotationSpeed = ((float)r.NextDouble() * allTheRadians - allTheRadians / 2f) / 300f;

            smoke.Reset(position, velocity, rotation, rotationSpeed, (float)r.NextDouble() * 20 + 10);// kommer ge allt sina värden när man ska skapa om dom!
        }
    }
}
