using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMaster.DLL
{
    [Serializable]
    public class Character
    {
		readonly string _name, _description;
		int _hp, _xp, _level, _armor;
		readonly List<string> _book;
		readonly List<Item> _inventory;
		readonly List<HistoricRecord> _historics;
		Game _currentGame;
		Dungeon _currentDungeon;
		Floor _currentFloor;
		Square _currentSquare;

		/// <summary>
		/// Initializes a new instance of <see cref="Character"/> class.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="description"></param>
		/// <param name="hp"></param>
		/// <param name="xp"></param>
		/// <param name="level"></param>
		/// <param name="book"></param>
		/// <param name="inventory"></param>
		/// <param name="armor"></param>
		/// <param name="currentdungeon"></param>
		/// <param name="currentfloor"></param>
		/// <param name="currentsquare"></param>
		public Character( string name, string description, int hp, int xp, int level, 
			List<string> book, List<Item> inventory, int armor, Dungeon currentDungeon, Floor currentFloor, Square currentSquare )
		{
			if( !NoMagicHelper.CheckNameLength( name ) ) throw new ArgumentException( "Invalid Character's name length." );
			if( !NoMagicHelper.CheckLongStringLength( description ) ) throw new ArgumentException( "Invalid Character's descritpion length." );
			if( hp <= 0 ) throw new ArgumentException( "Health Point must be greater than 0." );
			if( xp < 0 ) throw new ArgumentException( "Expérience point must be greater than 0." );
			if( level <= 0 ) throw new ArgumentException( "Level must be greater than 0." );
			if( armor <= 0 ) throw new ArgumentException( "Armor must be greater than 0." );

			_name = name;
			_description = description;
			_hp = hp;
			_xp = xp;
			_level = level;
			_book = book;
			_inventory = inventory;
			_armor = armor;
			_currentDungeon = currentDungeon;
			_currentFloor = currentFloor;
			_currentSquare = currentSquare;
			_historics = new List<HistoricRecord>();
		}

		/// <summary>
		/// Initializes a new instance of <see cref="Character"/> class
		/// Create a level 1 character.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="description"></param>
		/// <param name="currentDungeon"></param>
		/// <param name="currentFloor"></param>
		/// <param name="currentSquare"></param>
		public Character( string name, string description, Dungeon currentDungeon, Floor currentFloor, Square currentSquare )
			: this( name, description, 100, 0, 1, new List<string>(), new List<Item>(), 10, currentDungeon, currentFloor, currentSquare ) { }

		/// <summary>
		/// Gets the Character's name.
		/// </summary>
        public string Name
        {
            get { return _name; }
        }

		/// <summary>
		/// Gets the Character's descriptions.
		/// </summary>
        public string Description
        {
            get { return _description; }
        }

		/// <summary>
		/// Gets or sets the Character's health points (HP).
		/// </summary>
        public int Health
        {
            get { return _hp; }
            set { _hp = value; }
        }

		/// <summary>
		/// Gets or sets the Character's experience points.
		/// </summary>
        public int Experience
        {
            get { return _xp; }
            set { _xp = value; }
        }

		/// <summary>
		/// Gets or sets the Character's level.
		/// </summary>
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

		/// <summary>
		/// Gets or sets the Character's armor.
		/// </summary>
        public int Armor
        {
            get { return _armor; }
            set { _armor = value; }
        }   
     
		/// <summary>
		/// Get the List of Item.
		/// </summary>
        public List<Item> Inventory
        {
            get { return _inventory; }
        }

		/// <summary>
		/// Gets the list of Books.
		/// </summary>
        public List<string> Book
        {
            get { return _book; }
        }

		/// <summary>
		/// Gets or sets the current <see cref="Game"/>.
		/// </summary>
		public Game Game
		{
			get { return _currentGame; }
			set { _currentGame = value; }
		}

		/// <summary>
		/// Gets or sets the current <see cref="Dungeon"/>.
		/// </summary>
		public Dungeon Dungeon
		{
			get { return _currentDungeon; }
			set { _currentDungeon = value; }
		}

		/// <summary>
		/// Gets or sets the current <see cref="Floor"/>.
		/// </summary>
		public Floor Floor
		{
			get { return _currentFloor; }
			set { _currentFloor = value; }
		}

		/// <summary>
		/// Gets or sets the current <see cref="Square"/>.
		/// </summary>
		public Square Square
		{
			get { return _currentSquare; }
			set { _currentSquare = value; }
		}

        /// <summary>
        /// Moves an instance of <see cref="Character"/> class to a different Square.
        /// </summary>
        /// <param name="lin">Can't be null.</param>
        /// <param name="col">Can't be null.</param>
		public bool MoveTo( int lin, int col )
        {
			if( _currentFloor.CheckBounds( lin, col ) && _currentFloor.CheckHoldable( lin, col ) )
			{
				_currentSquare = _currentFloor.Layout[lin, col];
				return true;
			}
			else return false;
        }

		public bool MoveTo( Square square )
		{
			int lin, col;

			if( _currentFloor.TryGetPositions( square, out lin, out col ) ) return MoveTo( lin, col );
			else return false;
		}

        /// <summary>
        /// Uses an Item from the inventory.
        /// </summary>
        public void UseItem()
        {
            throw new NotImplementedException( );
        }

        /// <summary>
        /// Makes the Character attack.
        /// </summary>
        public void Attack()
        {
            throw new NotImplementedException();
        }       
    }
}
