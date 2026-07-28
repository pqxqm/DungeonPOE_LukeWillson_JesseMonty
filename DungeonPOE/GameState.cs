using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonPOE
{
    //Represents the current state of the game.
    internal enum GameState
    {
        //The player is stillpregressing through the levels
        InProgress,

        //The player has reached the exit on the final level
        Complete,

        //This state will be used later when the hero dies
        GameOver
    }
}
