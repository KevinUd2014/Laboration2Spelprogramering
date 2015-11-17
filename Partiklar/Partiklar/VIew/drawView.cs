using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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

        public drawView(SpriteBatch spritebatch, ContentManager Content, Camera camera)// en konstruktor som laddar in först i klassen!
        {
            this.spritebatch = spritebatch;
            this.camera = camera;
            particle = Content.Load<Texture2D>("spark");//laddar in spark //detta görs bara en gång!
            
            Vector2 particleSystemStartPosition = new Vector2(Level.SIZE_x / 2, Level.SIZE_y / 2);// räknar ut mitten av skärmen!
            particleSystem = new ParticleSystem(particleSystemStartPosition);
        }

        public void Draw(float elapsedTime)
        {
            particleSystem.Update(elapsedTime);

            spritebatch.Begin();
            particleSystem.Draw(spritebatch, camera, particle);
            //spriteBatch.Draw(box, camera.GetGameWindow(), Color.Black);/// ritar ut boxen eller snarare kvadraten!
            //spriteBatch.Draw(particle, camera.returnPositionOfField(-0, -0), null, Color.White, 0f, Vector2.Zero, 0.1f, SpriteEffects.None, 0f);
            spritebatch.End();
        }
    }
}
