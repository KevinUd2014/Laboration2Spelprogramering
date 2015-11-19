using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uppgiftTwo
{
    class SmokeManager
    {
        //private Smoke[] smoke;
        private List<Smoke> smokeList = new List<Smoke>();
        private Smoke smokeObject;
        public int maxParticles = 60;
        //public float lifeTime = 3f;
        public float lifetime = 0;
        private float maxTimeForSprite = 5;

        public SmokeManager(Vector2 systemModelStartPosition)
        {
            // smoke = new Smoke[maxParticles];

            if (smokeList.Count <= maxParticles)
            {
                smokeObject = new Smoke(systemModelStartPosition);//visar vart mitten är och skickar med i
                smokeList.Add(smokeObject);
            }
        }

        public SmokeManager()
        {

        }
        public void Update(float elapsedTime)
        {
            if (lifetime >= (float)maxTimeForSprite/(float)maxParticles)
            {
                //TODO:  något ska återställas här troligen Lifetime!
            }
            foreach (Smoke smoke in smokeList)
            {
                smokeObject.Update(elapsedTime);
            }

        }
        public void Draw(SpriteBatch spritebatch, Camera camera, Texture2D texture)
        {
            if (lifeOfParticle())
            {
                smokeObject.Draw(spritebatch, camera, texture);
            }

        }
        public bool lifeOfParticle()
        {
            return lifetime <= maxTimeForSprite;
        }
    }
}
