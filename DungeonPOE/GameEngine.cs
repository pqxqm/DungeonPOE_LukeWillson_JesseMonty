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

        //stores what level the player is currently on. Starts at 1 because the first level is level 1
        private int currentLevelNumber;

        //Stores whether the game is in progress, complete, or over
        private GameState gameState;

        private const int MIN_SIZE = 10;
        private const int MAX_SIZE = 20;

        public GameEngine(int newnumberOfLevels)
        {
            numberOfLevels = newnumberOfLevels;

            //the first level is level 1, not level 0
            currentLevelNumber = 1;
            
            //Player has not completed the game yet
            gameState = GameState.InProgress;
            random = new Random();

            int width = random.Next(MIN_SIZE, MAX_SIZE + 1);
            int height = random.Next(MIN_SIZE, MAX_SIZE + 1);

            currentLevel = new Level(width, height);
        }
        //Creates the next level while carrying the same hero forward.
        private void NextLevel()
        {
            //increases level number being played
            currentLevelNumber++;

            //temporarily stores the hero from the current level so it can be passed to the next level
            HeroTile existingHero = currentLevel.Hero;

            //Randomly generates the size of the next level
            int width = random.Next(MIN_SIZE, MAX_SIZE + 1);
            int height = random.Next(MIN_SIZE, MAX_SIZE + 1);

            //Creates the next level with the existing hero
            currentLevel = new Level(width, height, existingHero);
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

            if(targetTile is ExitTile)
            {
               if (currentLevelNumber == numberOfLevels)
                {
                    gameState = GameState.Complete;

                    //no Tile swap occurs because the game is complete
                    return false;
                }

                //More levels remain, so the game continues and the player is moved to the next level
                NextLevel();

                return true;
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
            if (gameState == GameState.InProgress)
            {
                MoveHero(direction);
            }
        }
        
        //It will include enemies later
        // MoveHero(direction);
        public override string ToString()
        {

            //Display completion message if the game is complete
            if (gameState == GameState.Complete)
            {
                return "Congratulations! You have completed the game!";
            }

            //GameOver will be implemented later when enemies are added

        if (gameState == GameState.GameOver)
            {
                return "Game Over! You have been defeated!";
            }

            return currentLevel.ToString();
        }
    }
}
