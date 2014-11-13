﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMaster.DLL
{
    [Serializable]
    public class Character
    {
        readonly string _name;
        readonly string _description;
        int _hp;
        int _xp;
        int _level;
        List<string> _book;
        List<Item> _inventory;
        int _armor;
        Dungeon _currentdungeon;
        Floor _currentfloor;
        Square _currentsquare;

        public string Name
        {
            get { return _name; }
        }

        public string Descritption
        {
            get { return _description; }
        }

        public int Health
        {
            get { return _hp; }
            set { _hp = value; }
        }

        public int Experience
        {
            get { return _xp; }
            set { _xp = value; }
        }

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public int Armor
        {
            get { return _armor; }
            set { _armor = value; }
        }   
     
        public List<Item> Inventory
        {
            get { return _inventory; }
        }

        public List<string> Book
        {
            get { return _book; }
        }

        /// <summary>
        /// Initialize a new instance of <see cref="Character"/>, base massive builder.
        /// </summary>
        /// <param name="name">Can't be empty or null.</param>
        /// <param name="descript">CAN be empty but not null.</param>
        /// <param name="hp">Must be greater than 0.</param>
        /// <param name="xp">Must be equal or greater than 0.</param>
        /// <param name="lvl">Must be greater than 0.</param>
        /// <param name="invent">Can't be null.</param>
        /// <param name="armor">Must be greater than 0.</param>
        /// <param name="posX">Can't be null.</param>
        /// <param name="posY">Can't be null.</param>
        public Character(string name, string descript, int hp, int xp, int lvl,List<string> book, List<Item> invent, int armor, Dungeon currentdungeon, Floor currentfloor, Square currentsquare)
        {
            if (name == string.Empty || name == null || name== " " ) throw new ArgumentException("Name can't be empty or null.");
            if ( NoMagicHelper.CheckNameLength( name ) != true ) throw new ArgumentException( "Invalid name length" );
            if (descript == null) throw new ArgumentException("Description can't be null");
            if (hp <= 0) throw new ArgumentException("Health Point must be greater than 0.");
            if (xp < 0) throw new ArgumentException("Expérience point can't be negative.");
            if (lvl <= 0) throw new ArgumentException("Level must be greater than 0.");
            if (invent == null) throw new ArgumentException("Inventory can't be null.");
            if (armor <= 0) throw new ArgumentException("Armor must be greater than 0.");      

            _name = name;
            _description = descript;
            _hp = hp;
            _xp = xp;
            _level = lvl;
            _book = book;
            _inventory = invent;
            _armor = armor;            
            _currentdungeon = currentdungeon;
            _currentfloor = currentfloor;
            _currentsquare = currentsquare;

        }

        /// <summary>
        /// Initialize a new instance of <see cref="Character"/> class, create a level 1 character.
        /// </summary>
        /// <param name="name">Can't be empty or null.</param>
        /// <param name="descript">CAN be empty but not null.</param>
        /// <param name="invent">Can't be null.</param>
        /// <param name="posX">Can't be null.</param>
        /// <param name="posY">Can't be null.</param>
        public Character( string name, string descript, Dungeon currentdungeon, Floor currentfloor, Square currentsquare )
            : this( name, descript, 100, 0, 1, new List<string>( ), new List<Item>( ), 10, currentdungeon,currentfloor,currentsquare )
        {
        }

        /// <summary>
        /// Move <see cref="Character"/> to a different square.
        /// </summary>
        /// <param name="posX">Can't be null.</param>
        /// <param name="posY">Can't be null.</param>
        public void MoveTo( int posX, int posY )
        {
            if ( _currentfloor.Layout[ posX, posY ].Holdable != true ) throw new InvalidOperationException( "Moving to a non-holdable Square." );

            _currentsquare = _currentfloor.Layout[ posX, posY ];
        }   

        /// <summary>
        /// Use an item from the inventory.
        /// </summary>
        public void UseItem()
        {
            throw new NotImplementedException( );
        }

        /// <summary>
        /// Make the Character attack.
        /// </summary>
        public void Attack()
        {
            throw new NotImplementedException();
        }       
    }
}
