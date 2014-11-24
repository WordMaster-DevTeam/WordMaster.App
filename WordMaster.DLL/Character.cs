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
		string _name, _description;
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
		/// <param name="name">Character's name.</param>
		/// <param name="description">Character's description.</param>
		/// <param name="hp">Character's health.</param>
		/// <param name="xp">Character's experience.</param>
		/// <param name="level">Character's level.</param>
		/// <param name="armor">Character's armor.</param>
		/// </summary>
		internal Character( string name, string description, int hp, int xp, int level, int armor)
		{
			if( hp <= 0 ) throw new ArgumentException( "Health Point must be greater than 0." );
			if( xp < 0 ) throw new ArgumentException( "Experience point must be positive." );
			if( level <= 0 ) throw new ArgumentException( "Level must be greater than 0." );
			if( armor <= 0 ) throw new ArgumentException( "Armor must be greater than 0." );

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
		/// Gets the Character's name.
		/// </summary>
        public string Name
        {
            get { return _name; }
			internal set { _name = value; }
        }

		/// <summary>
		/// Gets the Character's descriptions.
		/// </summary>
        public string Description
        {
            get { return _description; }
			set { _description = value; }
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
		/// <param name="dungeon">Dungeon's reference.</param>
		/// <param name="game">Game's reference.</param>
		/// <param name="record">HistoricRecord's reference.</param>
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
		/// Sets the current <see cref="Dungeon"/>, current <see cref="Floor"/> and current <see cref="Square"/> to null, effectively leaving the Dungeon
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
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="finalLocaltion">Current Character's Square at the end of the call.</param>
		/// <returns>If the Character have moved.</returns>
		public bool TryMoveTo( int line, int column, out Square finalLocaltion )
        {
			if( _currentFloor.CheckBounds( line, column ) && _currentFloor.CheckHoldable( line, column ) )
			{
				if( _currentFloor.Layout[line, column].TeleportTo != null )
					_currentSquare = _currentFloor.Layout[line, column].TeleportTo;
				else
					_currentSquare = _currentFloor.Layout[line, column];

				finalLocaltion = _currentSquare;
				return true;
			}
			else
			{
				finalLocaltion = _currentSquare;
				return false;
			}
        }

		/// <summary>
		/// Moves an instance of <see cref="Character"/> class to a different Square.
		/// </summary>
		/// <param name="desiredLocation">Square's reference.</param>
		/// <param name="finalLocaltion">Current Character's Square at the end of the call.</param>
		/// <returns>If the Character have moved.</returns>
		public bool TryMoveTo( Square desiredLocation, out Square finalLocaltion )
		{
			int line, column;

			if( _currentFloor.TryGetCoordinates( desiredLocation, out line, out column ) )
			{
				return TryMoveTo( line, column, out finalLocaltion );
			}
			else
			{
				finalLocaltion = _currentSquare;
				return false;
			}
		}   
    }
}
