using explosionAndSmoke.Explosion;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace explosionAndSmoke
{
    class Camera
    {
        private int sizeOfField;
        int windowSizeX;
        int windowSizeY;
        //Vector2 offput = Vector2.Zero;
        Viewport port;
        public Camera(Viewport Port)
        {
            port = Port;
            setSizeOfField();
        }
        public void setSizeOfField()
        {
            windowSizeX = port.Width;
            windowSizeY = port.Height;
            if (windowSizeX < windowSizeY)
            {
                sizeOfField = windowSizeX;
                //offput.Y = (windowSizeY - sizeOfField) / 2;
            }
            else
            {
                sizeOfField = windowSizeY;
                //offput.X = (windowSizeX - sizeOfField) / 2;
            }
        }

        public Vector2 convertToVisualCoords(Vector2 coords, float Width, float Height, float scale)
        {
            float visualX = coords.X * sizeOfField - (Width / 2) * scale;
            float visualY = coords.Y * sizeOfField - (Height / 2) * scale;
            return new Vector2(visualX, visualY);
        }
    }
}
