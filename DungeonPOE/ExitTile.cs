using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonPOE
{
    internal class ExitTile : Tile
    {
        public ExitTile(Position newposition) : base(newposition)
        {
        }

        public override char Display
        {
            get { return 'E'; } //needs to be the symbole but idk how 
        }
    }
}
