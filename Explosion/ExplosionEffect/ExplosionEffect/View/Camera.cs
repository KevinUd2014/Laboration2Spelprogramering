using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExplosionEffect.View
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

        public Vector2 convertToVisualCoords(Vector2 coords, ExplosionManager explosionManager)//vet inte om denna ska vara eller den undre ska testa båda imorgon, denna är dock inte min...
        {
            float visualX = coords.X * sizeOfWindow - (explosionManager.Width / 2) + zeroCord.X;
            float visualY = coords.Y * sizeOfWindow - (explosionManager.Height / 2) + zeroCord.Y;
            return new Vector2(visualX, visualY);
        }

        public Vector2 scaleParticles(float x, float y)//ger en visuell rörelse
        {
            float visualX = scaleX * x;
            float visualY = scaleY * y;

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
