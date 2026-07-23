using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonPOE
{
    internal class Position //allows us to store the XY - coordinates of a single tile
    {
        private int x;
        private int y;

        public Position(int newx, int newy)
        {
            x = newx;
            y = newy;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}