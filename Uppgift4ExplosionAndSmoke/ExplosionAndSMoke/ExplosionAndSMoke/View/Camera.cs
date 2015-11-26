using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExplosionAndSMoke.View
{
    class Camera
    {
        public float scaleX;
        public float scaleY;
        private float sizeOfWindow;
        int sizeOfTile = 64;

        Viewport graphics;

        Vector2 zeroCord = Vector2.Zero;

        public Camera(Viewport Graphics)
        {
            graphics = Graphics;
            setSizeOfWindow();
        }
        public Vector2 convertToVisualCoords(Vector2 coordinates) //fick lite hjälp med denna!
        {
            float visualX = coordinates.X * scaleX;
            float visualY = coordinates.Y * scaleY;

            return new Vector2(visualX, visualY);
        }

        public float scaleOfField(float height, float width)
        {
            float scale = (sizeOfTile / height) + (sizeOfTile / width);
            scale = scale / 2;
            return scale;
        }

        public void setSizeOfWindow()
        {
            scaleX = graphics.Width;
            scaleY = graphics.Height;

            if (scaleX < scaleY)
            {
                sizeOfWindow = scaleX;
            }
            else
            {
                sizeOfWindow = scaleY;
            }
        }
    }
}
