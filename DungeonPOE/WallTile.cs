using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonPOE
{
    internal class WallTile : Tile
    {
        public WallTile(Position newposition) : base(newposition)
        {
        }

        public override char Display
        {
            get { return '█'; }
        }
    }
}
