using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

namespace DungeonPOE
{
    internal abstract class Tile
    {
        //Stores the tiles current coordinates 
        private Position position;

        public Tile(Position newposition)
        {
            position = newposition;
        }

        //Gets or changes the horizontal position of the tile

        public int X
        {
            get { return position.X; }
            set { position.X = value; }
        }
        //Gets or changes the vertical position of the tile
        public int Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }
        public abstract char Display
        {
            get;
        }
    }
}
