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
        float X = 0.5f;
        float Y = 0.5f;
        Viewport graphics;

        Vector2 zeroCord = Vector2.Zero;

        public Camera(Viewport Graphics)
        {
            graphics = Graphics;
            setSizeOfWindow();
        }

        /* public Vector2 convertToVisualCoords(Vector2 coordinates, Explosion explosion) //vet inte om denna ska vara eller den undre ska testa båda imorgon, denna är dock inte min...
         {
             float visualX = coordinates.X * sizeOfWindow - (explosion.Width / 2) + zeroCord.X;
             float visualY = coordinates.Y * sizeOfWindow - (explosion.Height / 2) + zeroCord.Y;

             return new Vector2(visualX, visualY);
         }*/
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
