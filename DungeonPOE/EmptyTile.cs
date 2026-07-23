using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonPOE
{
    internal class EmptyTile : Tile
    {
        public EmptyTile(Position newposition) : base(newposition)
        {
        }
        public override char Display
        {
            get { return '.'; }
        }
    }
}
