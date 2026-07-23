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

        public override string ToString()
        {
            return currentLevel.ToString();
        }
    }
}
