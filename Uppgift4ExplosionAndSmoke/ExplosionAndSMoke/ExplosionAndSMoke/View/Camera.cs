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

        Viewport graphics;

        Vector2 zeroCord = Vector2.Zero;

        public Camera(Viewport Graphics)
        {
            graphics = Graphics;
            setSizeOfWindow();
        }
        public Vector2 convertToVisualCoords(Vector2 coordinates) //vet inte om denna ska vara eller den undre ska testa båda imorgon, denna är dock inte min...
        {
            float visualX = coordinates.X * sizeOfWindow;
            float visualY = coordinates.Y * sizeOfWindow;

            return new Vector2(visualX, visualY);
        }
        public void setSizeOfWindow()
        {
            scaleX = graphics.Width;
            scaleY = graphics.Height;
            if (scaleX < scaleY)
            {
                sizeOfWindow = scaleX;
                zeroCord.Y = (scaleY - sizeOfWindow) / 2;
            }
            else
            {
                sizeOfWindow = scaleY;
                zeroCord.X = (scaleX - sizeOfWindow) / 2;
            }
        }
    }
}
