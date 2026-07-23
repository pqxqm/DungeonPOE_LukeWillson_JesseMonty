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

        public enum TileType // more will be added later when we work on the enum (sidenote will be called as Level.TileType in other codes)
        {
            empty
        }

        public Level(int newwidth, int newheight)
        {
            width = newwidth;
            height = newheight;
            tiles = new Tile[newwidth, newheight];
            InitialiseTiles();
        }

        private Tile CreateTile(TileType type, Position newposition) //will be changed later when we work on the enum
        {
            Tile tile = null;
            
            switch(type)
            {
                case TileType.empty:
                    tile = new EmptyTile(newposition);
                    break;
            }
            tiles[newposition.X, newposition.Y] = tile;
            return tile;
        }

        private void InitialiseTiles()
        {
            for(int newx = 0; newx < width; newx++)
            {
                for (int newy = 0; newy < height; newy++)
                {
                    CreateTile(TileType.empty, new Position(newx, newy));
                }
            }
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
