using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Partiklar.Model
{
    class Level
    {
        public const int SIZE_x = 10;
        public const int SIZE_y = 10;

        internal Vector2 getBallStartPostion()
        {
            return new Vector2(SIZE_x/2, SIZE_y/2);
        }
    }
}
