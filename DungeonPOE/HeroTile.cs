using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonPOE
{
    //Represents a hero character in the game
    //HeroTile inherits from CharacterTile and can move around the level and interact with other tiles
    internal class HeroTile : CharacterTile
    {
        //The hero starts with
        //40 hit points
        //5 attack power
        public HeroTile(Position newposition)
            : base(newposition, 40, 5)
        {
        }

        //Determines which character represents the hero on the level
        public override char Display
        {
            get
            {
                //Display an x if hero has died
                if (IsDead)
                {
                    return 'x';
                }
                else
                {
                    return '▼';
                }

            }
        }
    }
}
