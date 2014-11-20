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
		Dungeon _currentDungeon;
		Floor _currentFloor;
		Square _currentSquare;
		Game _currentGame;

		/// <summary>
		/// Initializes a new instance of <see cref="Character"/> class.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Character.</param>
		/// <param name="description">Description (MinDescritptionLength to MaxDescritptionLength characters) of the Character.</param>
		/// <param name="hp">Character's health.</param>
		/// <param name="xp">Character's experience.</param>
		/// <param name="level">Character's level.</param>
		/// <param name="armor">Character's armor.</param>
		/// </summary>
		public Character( string name, string description, int hp, int xp, int level, int armor)
		{
			// Checking parameters
			if( !NoMagicHelper.CheckNameLength( name ) ) throw new ArgumentException( "Invalid Character's name length." );
			if( !NoMagicHelper.CheckLongStringLength( description ) ) throw new ArgumentException( "Invalid Character's descritpion length." );
			if( hp <= 0 ) throw new ArgumentException( "Health Point must be greater than 0." );
			if( xp < 0 ) throw new ArgumentException( "Expérience point must be greater than 0." );
			if( level <= 0 ) throw new ArgumentException( "Level must be greater than 0." );
			if( armor <= 0 ) throw new ArgumentException( "Armor must be greater than 0." );

			// Creation Character
			_name = name;
			_description = description;
			_hp = hp;
			_xp = xp;
			_level = level;
			_armor = armor;
			_book = new List<string>();
			_inventory = new List<Item>();
			_historics = new List<HistoricRecord>();
			_currentDungeon = null;
			_currentFloor = null;
			_currentSquare = null;
			_currentGame = null;
		}

		/// <summary>
		/// Initializes a new instance of <see cref="Character"/> class.
		/// Create a level 1 Character.
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Character.</param>
		/// <param name="description">Description (MinDescritptionLength to MaxDescritptionLength characters) of the Character.</param>
		public Character( string name, string description ) : this( name, description, 100, 0, 1, 10 ) { }

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
		/// Gets the list (read-write) of Item.
		/// </summary>
        public List<Item> Inventory
        {
            get { return _inventory; }
        }

		/// <summary>
		/// Gets the list (read-write) of Books.
		/// </summary>
        public List<string> Book
        {
            get { return _book; }
        }

		/// <summary>
		/// Gets the list (readonly) of HistoricRecords.
		/// </summary>
		public IEnumerable<HistoricRecord> Historics
		{
			get { return _historics; }
		}

		/// <summary>
		/// Gets or set the current <see cref="Game"/>.
		/// </summary>
		public Game Game
		{
			get { return _currentGame; }
			set { _currentGame = value; }
		}

		/// <summary>
		/// Gets the current <see cref="Dungeon"/>.
		/// </summary>
		public Dungeon Dungeon
		{
			get { return _currentDungeon; }
		}

		/// <summary>
		/// Gets the current <see cref="Floor"/>.
		/// </summary>
		public Floor Floor
		{
			get { return _currentFloor; }
		}

		/// <summary>
		/// Gets the current <see cref="Square"/>.
		/// </summary>
		public Square Square
		{
			get { return _currentSquare; }
		}

		/// <summary>
		/// Sets the current <see cref="Dungeon"/>, current <see cref="Floor"/> and current <see cref="Square"/> to the starting Dungeon's coordinate.
		/// </summary>
		/// <param name="dungeon"></param>
		/// <param name="line"></param>
		/// <param name="column"></param>
		internal void EnterDungeon( Dungeon dungeon, Game game, HistoricRecord record )
		{
			Floor floor;
			int line, column;
				
			if( dungeon.TryGetFloor( 0, out floor ) )
				if( floor.TryGetCoordinates( dungeon.Entrance, out line, out column ) )
				{
					this._currentDungeon = dungeon;
					this._currentFloor = floor;
					this._currentSquare = dungeon.Entrance;
					this._currentGame = game;
					this._historics.Add( record );
				}
				else throw new ArgumentException("No entrance.", "dungeon");
			else throw new ArgumentException("Empty Dungeon.", "dungeon");
		}

		/// <summary>
		/// Sets the current <see cref="Dungeon"/>, current <see cref="Floor"/> and current <see cref="Square"/> to null.
		/// </summary>
		internal void LeaveDungeon()
		{
			_currentDungeon = null;
			_currentFloor = null;
			_currentSquare = null;
			_currentGame = null;
		}

        /// <summary>
        /// Moves an instance of <see cref="Character"/> class to a different Square.
        /// </summary>
        /// <param name="line">Can't be null.</param>
        /// <param name="column">Can't be null.</param>
		public bool MoveTo( int line, int column )
        {
			if( _currentFloor.CheckBounds( line, column ) && _currentFloor.CheckHoldable( line, column ) )
			{
				_currentSquare = _currentFloor.Layout[line, column];
				return true;
			}
			else return false;
        }

		public bool MoveTo( Square square )
		{
			int line, column;

			if( _currentFloor.TryGetCoordinates( square, out line, out column ) ) return MoveTo( line, column );
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
