using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Partiklar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Partiklar.VIew
{
    class Camera
    {
        //private float displaceX = 0;
        //private float displaceY = 0;
        public float scaleX;
        public float scaleY;

        public Camera(Viewport graphics)
        {
            scaleX = graphics.Width / Level.SIZE_x;
            scaleY = graphics.Height / Level.SIZE_y;
        }

        public Vector2 scaleParticles(float x, float y)//ger en visuell rörelse
        {
            float visualX = scaleX * x;
            float visualY = scaleY * y;

            return new Vector2(visualX, visualY);
        }
    }
}
