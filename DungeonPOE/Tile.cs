using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

namespace DungeonPOE
{
    internal abstract class Tile
    {
        private Position position;

        public Tile(Position newposition)
        {
            position = newposition;
        }

        public int X
        {
            get { return position.X; }
        }
        public int Y
        {
            get { return position.Y; }
        }
        public abstract char Display
        {
            get;
        }
    }
}
