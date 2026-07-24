using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonPOE
{
    internal class GameEngine
    {
        private Level currentLevel;
        private int numberOfLevels;
        private Random random;

        private const int MIN_SIZE = 10;
        private const int MAX_SIZE = 20;

        public GameEngine(int newnumberOfLevels)
        {
            numberOfLevels = newnumberOfLevels;
            random = new Random();

            int width = random.Next(MIN_SIZE, MAX_SIZE + 1);
            int height = random.Next(MIN_SIZE, MAX_SIZE + 1);

            currentLevel = new Level(width, height);
        }

        //Attempts to move the hero in the specified direction. Returns true if the move was successful, false otherwise.
        private bool MoveHero(Direction direction)
        { 
            //None does not correspond to a valid vision index
            if (direction == Direction.None)
            {
                return false;
            }

            HeroTile hero = currentLevel.Hero;

            //Convert the direction value to the matching index of the hero's vision array
            Tile targetTile = hero.Vision[(int)direction];

            if(!(targetTile is EmptyTile))
            {
                return false;
            }

            //Swap the hero with the empty target tile
            currentLevel.SwapTiles(hero, targetTile);

            //Refresh the hero's vision after the move
            hero.UpdateVision(currentLevel);
            return true;
        }

        //Recieves movement requests from the windows form
        public void TriggerMovement(Direction direction)
        {
            MoveHero(direction);
        }
        //It will include enemies later
        // MoveHero(direction);
        public override string ToString()
        {
            return currentLevel.ToString();
        }
    }
}
