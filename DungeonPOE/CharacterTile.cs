using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;

namespace DungeonPOE
{
    //CharacterTile is the base class for characters in the game
    //Classes that inherit from CharacterTile will be able to move around the level and interact with other tiles
    internal abstract class CharacterTile: Tile
    {
        // The character's current health
        private int hitPoints;

        //Stores the character's origanal maximum health
        private int maximumHitPoints;

        //Stores how much damage the character can deal
        private int attackPower;

        //Stores the four tiles around the character immediately (up, down, left, and right)

        private Tile[] vision;

        // The character's current position on the level
        public CharacterTile(Position newposition, int newHitPoints, int newAttackPower) : base(newposition)
        {
            hitPoints = newHitPoints;
            maximumHitPoints = newHitPoints;
            attackPower = newAttackPower;
            vision = new Tile[4];
        }

        //Gives the GameEngine access to the character's vision
        public Tile[] Vision
        {
            get { return vision; }
        }

        // Updates the four tiles surrounding the character
        public void UpdateVision(Level level)
        {
            // Retrieve the full tile array from the level
            Tile[,] levelTiles = level.Tiles;

            // Store the dimensions of the array
            int width = levelTiles.GetLength(0);
            int height = levelTiles.GetLength(1);

            // Tile above the character.
            if (Y - 1 >= 0)
            {
                vision[0] = levelTiles[X, Y - 1];
            }
            else
            {
                vision[0] = null;
            }

            // Tile to the right of the character
            if (X + 1 < width)
            {
                vision[1] = levelTiles[X + 1, Y];
            }
            else
            {
                vision[1] = null;
            }

            // Tile below the character
            if (Y + 1 < height)
            {
                vision[2] = levelTiles[X, Y + 1];
            }
            else
            {
                vision[2] = null;
            }

            // Tile to the left of the character.
            if (X - 1 >= 0)
            {
                vision[3] = levelTiles[X - 1, Y];
            }
            else
            {
                vision[3] = null;
            }
        }
        

        //Reduces the character's hit points by the damage recieved
        public void TakeDamage(int damage)
        {
            hitPoints = hitPoints - damage;

            //Hit points cannot be less than zero
            if (hitPoints < 0)
            {
                hitPoints = 0;
            }
        }

        //Attacks another character using the character's attack power
        public void Attack(CharacterTile target)
        {
            //Tell the target character to take damage equal to the attack power of this character
            target.TakeDamage(attackPower);
        }

        //Returns true when the character has no hit points remaining
        public bool IsDead
        {
            get
            {
                if(hitPoints > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }
    }
}
