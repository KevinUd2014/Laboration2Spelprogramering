using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uppgiftTwo.View
{
    class ParticleSystem
    {
        private Particles[] particels;
        private float maxLife;

        private int maxParticleCount;
        private int offset;
        //private int firstInLine;

        private float elapsedTime;
        private Texture2D texture;
        private Random r;

        public ParticleSystem(Texture2D texture)
        {
            maxParticleCount = 200;
            particels = new Particles[maxParticleCount];
            elapsedTime = 0;
            offset = 0;
            //firstInLine = 0;
            maxLife = 7000;
            this.texture = texture;
            r = new Random();
        }

        public void Update(GameTime gameTime)
        {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (elapsedTime > maxLife / maxParticleCount)
            {
                if (offset < maxParticleCount)
                {

                    particels[offset] = new Particles();
                    resetParticle(particels[offset]);

                    offset++;
                    elapsedTime = 0;
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

        private void resetParticle(Particles particle)
        {
            Vector2 position = new Vector2(500, 500);
            float speed = 0.3f;
            Vector2 velocity = new Vector2((float)r.NextDouble() * 2f - 1f, (float)r.NextDouble() * 2f - 1f);

            velocity.Normalize();
            velocity = velocity * speed;

            float rotation = (float)r.NextDouble()*2f*(float)Math.PI;
            float allTheRadians = 2f * (float)Math.PI;
            float rotationSpeed = ((float)r.NextDouble() * allTheRadians - allTheRadians / 2f) / 300f;

            particle.Reset(position, velocity, rotation, rotationSpeed, (float)r.NextDouble()*20+10);
        }
    }
}
