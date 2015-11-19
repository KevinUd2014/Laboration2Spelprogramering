using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uppgiftTwo.Model;

namespace uppgiftTwo
{
    class Camera
    {
        public float scaleX;
        public float scaleY;

        public const int SIZE_x = 10;
        public const int SIZE_y = 10;

        public Camera(Viewport graphics)
        {
            scaleX = graphics.Width / SIZE_x;
            scaleY = graphics.Height / SIZE_y;
        }

        public Vector2 scaleParticles(float x, float y)//ger en visuell rörelse!
        {
            float visualX = scaleX * x;
            float visualY = scaleY * y;

            return new Vector2(visualX, visualY);
        }
    }
}
