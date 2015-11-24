using explosionAndSmoke.Explosion;
using explosionAndSmoke.Particle;
using explosionAndSmoke.shockWave;
using explosionAndSmoke.SMoke;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace explosionAndSmoke
{
    class DrawView
    {

        private Texture2D particleSprite;
        private Texture2D smokeSprite;
        private Texture2D shockWaveSprite;
        private Texture2D explosionSprite;

        private ParticleSystem particleSystem;
        private SmokeSystem smokeSystem;
        private ExplosionManager explosion;
        private ShockWave shockwave;
        private Camera camera;

        private ContentManager content;
        private SpriteBatch spriteBatch;

        public DrawView(SpriteBatch spritebatch, ContentManager Content, Camera oCamera, Vector2 startLoc, float scale)// en konstruktor som laddar in först i klassen!
        {
            content = Content;
            camera = oCamera;
            spriteBatch = spritebatch;

            particleSprite = content.Load<Texture2D>("Spark");
            newParticle = new ParticleSystem();

        }
        public void Update()
        {

        }
        public void Draw(float elapsedTime)
        {
            
        }
    }
}
