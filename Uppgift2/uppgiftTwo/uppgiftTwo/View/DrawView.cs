using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uppgiftTwo.Model;

namespace uppgiftTwo.View
{
    class DrawView
    {
        private Camera camera;
        private SpriteBatch spritebatch;
        Texture2D particle;
        private SmokeManager smokeManager;

        public DrawView(SpriteBatch spritebatch, ContentManager Content, Camera camera)// en konstruktor som laddar in först i klassen!
        {
            this.spritebatch = spritebatch;
            this.camera = camera;
            particle = Content.Load<Texture2D>("particlesmokee");//laddar in smoke //detta görs bara en gång!

            timerForNewParticles();
        }

        public void timerForNewParticles()
        {
            Vector2 particleSystemStartPosition = new Vector2(Camera.SIZE_x / 2, Camera.SIZE_y / 2);// räknar ut mitten av skärmen!
            smokeManager = new SmokeManager(particleSystemStartPosition);
        }

        public void Draw(float elapsedTime)
        {
            smokeManager.Update(elapsedTime);

            spritebatch.Begin();
            smokeManager.Draw(spritebatch, camera, particle);
            spritebatch.End();
        }
    }
}
