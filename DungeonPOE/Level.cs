using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonPOE
{
    internal class Level
    {
       private Tile[,] tiles;
        private int width;
        private int height;

        //Stores the hero of this level
        private HeroTile hero;
        private ExitTile exit;


        //A single Random object is shared when selectting random tiles from the level
       private static Random random = new Random();

        //Provides read-only access to the level's 2D tile array
        public Tile[,] Tiles
        { 
            get { return tiles; }
        }

        //Provides read-only access to the hero of this level
        public HeroTile Hero
        {
            get { return hero; }
        }

        private ExitTile Exit
        {
            get { return exit;  }
        }
        public enum TileType // more will be added later when we work on the enum (sidenote will be called as Level.TileType in other codes)
        {
            empty,
            wall,
            Hero,
            Exit
        }

        // Creates a level with the supplied width and height.
        // existingHero is optional. If no hero is supplied,
        // a new HeroTile will be created.
        public Level( int newwidth, int newheight, HeroTile existingHero = null)
        {
            // Store the dimensions of the level.
            width = newwidth;
            height = newheight;

            // Create the two-dimensional tile array.
            tiles = new Tile[newwidth, newheight];

            // Fill the level with empty tiles and boundary walls.
            InitialiseTiles();

            // Find a random empty position for the hero.
            Position heroPosition = GetRandomEmptyPosition();

            if (existingHero == null)
            {
                // No hero was supplied, so create a new hero.
                hero = (HeroTile)CreateTile(
                    TileType.Hero,
                    heroPosition
                );
            }
            else
            {
                // Reuse the existing hero so that its health
                // and other information carry between levels.
                hero = existingHero;

                // Update the hero's coordinates.
                hero.X = heroPosition.X;
                hero.Y = heroPosition.Y;

                // Place the existing hero in the new level.
                tiles[heroPosition.X, heroPosition.Y] = hero;
            }

            //Find empty spot for exit tile and create it
            Position exitPosition = GetRandomEmptyPosition();

            //create the exit tile and store it in the level's exit field
            exit = (ExitTile)CreateTile(TileType.Exit, exitPosition);

            // Update the hero's surrounding vision tiles.
            hero.UpdateVision(this);

            
        }


        private Tile CreateTile(TileType type, Position newposition) //will be changed later when we work on the enum
        {
        Tile tile;
            
            switch(type)
            {
            //Create an empty floor tile
                case TileType.empty:
                    tile = new EmptyTile(newposition);
                    break;

                case TileType.wall:
                    tile = new WallTile(newposition);
                    break;

                case TileType.Hero:
                tile = new HeroTile(newposition);
                break;

                case TileType.Exit:
                    tile = new ExitTile(newposition);
                    break;

            default:
                //Prevent invalid tile types from being created
                throw new ArgumentException("Invalid tile type");
        }

        //Store the new tile in the level's 2D array
        tiles[newposition.X, newposition.Y] = tile;
            return tile;
        }

        private void InitialiseTiles()
        {
            for(int newx = 0; newx < width; newx++)
            {
                for (int newy = 0; newy < height; newy++)
                {
                    bool isBoundry =
                        newx == 0 ||
                        newx == width - 1 ||
                        newy == 0 || 
                        newy == height - 1;

                    if (isBoundry)
                    {
                        CreateTile(TileType.wall, new Position(newx, newy));
                    }
                    else
                    {
                        CreateTile(TileType.empty, new Position(newx, newy));
                    }
                }
            }
        }

    //Find and return a random empty position in the level
    private Position GetRandomEmptyPosition()
    
     { 
        int randomX;
        int randomY;

        do
        {
            //Start at 1 and stop before width - 1 so that boundry wall positions are not selected
            randomX = random.Next(1, width - 1);
            randomY = random.Next(1, height - 1);

        }
        //Continue looping until an empty tile is found at the random position
        while (!(tiles[randomX, randomY] is EmptyTile));

        //Return the empty tiles coordinates as a Position object
        return new Position(randomX, randomY);
    }

        //Swaps the positions of two tiles in the level's 2D array
        public void SwapTiles(Tile firstTile, Tile secondTile)
        {
            //Store the first tile's coordinates
            int firstX = firstTile.X;
            int firstY = firstTile.Y;
            //Store the second tile's coordinates
            int secondX = secondTile.X;
            int secondY = secondTile.Y;
            //Swap the two tiles in the level's 2D array
            tiles[firstX, firstY] = secondTile;
            tiles[secondX, secondY] = firstTile;
            //Update the two tiles' coordinates
            firstTile.X = secondX;
            firstTile.Y = secondY;
            secondTile.X = firstX;
            secondTile.Y = firstY;
        }


        public override string ToString()
        {
            string result = "";

            for (int newy = 0; newy < height; newy++)
            {
                for (int newx = 0; newx < width; newx++)
                {
                    result += tiles[newx, newy].Display;
                }
                result += "\n";
            }
            
            return result;
        }
    }
}
