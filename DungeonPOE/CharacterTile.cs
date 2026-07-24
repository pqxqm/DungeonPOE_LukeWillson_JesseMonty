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

        //Updates the four tiles tiles surrounding the character
        public void UpdateVision(Level level)
        {
            //Retrieve the complete 2D array of tiles from the level
            Tile[,] levelTiles = level.Tiles;

            //Store the tile immediately above the character
            vision[0] = levelTiles[X,Y - 1];

            //Store the tile immediately to the right
            vision[1] = levelTiles[X + 1, Y];

            //Store the tile immediately below the character
            vision[2] = levelTiles[X, Y + 1];

            //Store the tile immediately to the left
            vision[3] = levelTiles[X - 1, Y];
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
