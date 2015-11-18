using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Partiklar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Partiklar.VIew
{
    class drawView
    {
        Texture2D box;
        private Camera camera;
        private SpriteBatch spritebatch;
        Texture2D particle;
        private ParticleSystem particleSystem;
        float timer;

        public drawView(SpriteBatch spritebatch, ContentManager Content, Camera camera)// en konstruktor som laddar in först i klassen!
        {
            timer = 0;
            this.spritebatch = spritebatch;
            this.camera = camera;
            particle = Content.Load<Texture2D>("spark");//laddar in spark //detta görs bara en gång!

            timerForNewParticles();
        }

        public void timerForNewParticles()
        {
            Vector2 particleSystemStartPosition = new Vector2(Level.SIZE_x / 2, Level.SIZE_y / 2);// räknar ut mitten av skärmen!
            particleSystem = new ParticleSystem(particleSystemStartPosition);
        }

        public void Draw(float elapsedTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Vector2 particleSystemStartPosition = new Vector2(Level.SIZE_x / 2, Level.SIZE_y / 2);// räknar ut mitten av skärmen!
                particleSystem = new ParticleSystem(particleSystemStartPosition);
                timer = 0;
            }
            timer += elapsedTime;
            if (timer > 2)
            {
                timerForNewParticles();
                timer = 0;
            }

            particleSystem.Update(elapsedTime);

            spritebatch.Begin();
            particleSystem.Draw(spritebatch, camera, particle);
            //spriteBatch.Draw(box, camera.GetGameWindow(), Color.Black);/// ritar ut boxen eller snarare kvadraten!
            //particleSystem.Draw(particle, camera, null, Color.White, 0f, Vector2.Zero, 0.1f, SpriteEffects.None, 0f);
            spritebatch.End();
        }
    }
}
