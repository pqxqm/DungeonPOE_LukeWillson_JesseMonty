using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonPOE
{
    //Represents a direction in which a character can move
    //The numeric values match the indexes used by the CharacterTile.Move vision array

   public enum Direction    
    {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3,
        None = 4
    
    
    }
}
