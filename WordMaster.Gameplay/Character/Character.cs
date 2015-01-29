using System;
using System.Collections.Generic;

namespace WordMaster.Gameplay
{
    [Serializable]
    public class Character
    {
		readonly GlobalContext _globalContext;
		string _name, _description;
		int _hp, _xp, _level, _armor;
		readonly List<Item> _inventory;
		readonly List<HistoricRecord> _historics;
		Dungeon _dungeon;
		Floor _floor;
		Square _square;
		GameContext _gameContext;

		/// <summary>
		/// Initializes a new instance of <see cref="Character"/> class.
		/// </summary>
		/// <param name="globalContext">GlobalContext's reference, all Characters must be in a <see cref="GlobalContext"/>.</param>
		/// <param name="name">Character's name, must be unique in this GlobalContext.</param>
		/// <param name="description">Character's description.</param>
		/// <param name="hp">Character's health.</param>
		/// <param name="xp">Character's experience.</param>
		/// <param name="level">Character's level.</param>
		/// <param name="armor">Character's armor.</param>
		/// </summary>
		internal Character( GlobalContext globalContext, string name, string description, int hp, int xp, int level, int armor)
		{
			_globalContext = globalContext;
			_name = name;
			_description = description;
			_hp = hp;
			_xp = xp;
			_level = level;
			_armor = armor;
			_inventory = new List<Item>();
			_historics = new List<HistoricRecord>();
		}

		/// <summary>
		/// Gets the current instance of <see cref="GlobalContext"/> class.
		/// </summary>
		public GlobalContext GlobalContext 
		{
			get { return _globalContext; }
		}

		/// <summary>
		/// Gets the <see cref="Character"/>'s name.
		/// </summary>
        public string Name
        {
            get { return _name; }
			internal set { _name = value; }
        }

		/// <summary>
		/// Gets the <see cref="Character"/>'s descriptions.
		/// </summary>
        public string Description
        {
            get { return _description; }
			set { _description = value; }
        }

		/// <summary>
		/// Gets or sets the <see cref="Character"/>'s health points (HP).
		/// </summary>
        public int Health
        {
            get { return _hp; }
            set { _hp = value; }
        }

		/// <summary>
		/// Gets or sets the <see cref="Character"/>'s experience points.
		/// </summary>
        public int Experience
        {
            get { return _xp; }
            set { _xp = value; }
        }

		/// <summary>
		/// Gets or sets the <see cref="Character"/>'s level.
		/// </summary>
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

		/// <summary>
		/// Gets or sets the <see cref="Character"/>'s armor.
		/// </summary>
        public int Armor
        {
            get { return _armor; }
            set { _armor = value; }
        }   
     
		/// <summary>
		/// Gets the list (read-write) of <see cref="Item"/>.
		/// </summary>
        public List<Item> Inventory
        {
            get { return _inventory; }
        }

		/// <summary>
		/// Gets the list (read only) of instances of<see cref="HistoricRecord"/>s class.
		/// </summary>
		public IEnumerable<HistoricRecord> Historics
		{
			get { return _historics; }
		}

		/// <summary>
		/// Gets the current instance of <see cref="HistoricRecords"/> class used in the current instance of <see cref="Game"/> class.
		/// </summary>
		public HistoricRecord Historic
		{
			get
			{
				if( _gameContext != null )
					return _gameContext.Game.Historic;
				else
					return null;
			}
		}

		/// <summary>
		/// Gets the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		public Dungeon Dungeon
		{
			get { return _dungeon; }
		}

		/// <summary>
		/// Gets the current instance of <see cref="Floor"/> class.
		/// </summary>
		public Floor Floor
		{
			get { return _floor; }
		}

		/// <summary>
		/// Gets the current instance of <see cref="Square"/> class.
		/// </summary>
		public Square Square
		{
			get { return _square; }
		}

		/// <summary>
		/// Gets the current instance of <see cref="GameContext"/> class.
		/// </summary>
		public GameContext GameContext
		{
			get { return _gameContext; }
		}

        public Game Game
        {
            get
            {
                throw new System.NotImplementedException( );
            }
            set
            {
            }
        }

        public HistoricRecord HistoricRecord
        {
            get
            {
                throw new System.NotImplementedException( );
            }
            set
            {
            }
        }

        public GameContext GameContext1
        {
            get
            {
                throw new System.NotImplementedException( );
            }
            set
            {
            }
        }

        public Item Item
        {
            get
            {
                throw new System.NotImplementedException( );
            }
            set
            {
            }
        }

		/// <summary>
		/// Sets the current <see cref="Dungeon"/>, current <see cref="Floor"/> and current <see cref="Square"/> to the starting Dungeon's coordinate.
		/// </summary>
		/// <param name="gameContext">GameContext's reference.</param>
		internal void EnterDungeon( GameContext gameContext )
		{
			if( gameContext.Game.Dungeon.Entrance == null ) throw new ArgumentException( "No entrance.", "dungeon" );
			if( gameContext.Game.Dungeon.Exit == null ) throw new ArgumentException( "No exit.", "dungeon" );

			_historics.Add( gameContext.Game.Historic );
			_dungeon = gameContext.Game.Dungeon;
			_floor = gameContext.Game.Dungeon.Entrance.Floor;
			_square = gameContext.Game.Dungeon.Entrance;
			_gameContext = gameContext;
		}

		/// <summary>
		/// Sets the current <see cref="Dungeon"/>, current <see cref="Floor"/> and current <see cref="Square"/> to null, effectively leaving the Dungeon
		/// </summary>
		internal void LeaveDungeon()
		{
			_dungeon = null;
			_floor = null;
			_square = null;
			_gameContext = null;
		}

		/// <summary>
		/// Moves an instance of <see cref="Character"/> class to a different Square.
		/// This method will change Character's <see cref="Floor"/> if the targeted <see cref="Square"/> teleport to another Floor.
		/// It will also end or cancel the <see cref="Game"/> if the Character steps to the entrance's square or to the exit's square.
		/// </summary>
		/// <param name="target">Target Square's reference.</param>
		/// <param name="final">Final Character's Square at the end of the call.</param>
		/// <returns>If the Character have moved.</returns>
		public bool TryMoveTo( Square target, out Square final )
		{
			if( target == null ) // Target not set
			{
				final = _square;
				return false;
			}
			else if( target.Holdable == false ) // Target not holdable
			{
					final = _square;
					return false;
			}
			else
			{
				if( target.Floor.Dungeon.Entrance.Equals( target ) ) // Cancel the Game (exit the Dungeon by the entrance)
				{
					_gameContext.GlobalContext.CancelGame( this );
					final = null;
				}
				else if( target.Floor.Dungeon.Exit.Equals( target ) ) // Finish the Game (exit the Dungeon by the exit)
				{
					_gameContext.GlobalContext.FinishGame( this );
					final = null;
				}
				else if( target.TeleportTo == null ) // No teleport allocates to the target
				{
					final = target;
					_square = final;
				}
				else // Teleport to the target should automatically teleport to target's target
				{
					final = target.TeleportTo;
					_floor = final.Floor;
					_square = final;
				}
				return true;
			}
		}

        /// <summary>
        /// Moves an instance of <see cref="Character"/> class to a different Square.
        /// </summary>
		/// <param name="line">Target Square's horizontal coordinate.</param>
		/// <param name="column">Target Square's vertical coordinate.</param>
		/// <param name="final">Final Character's Square at the end of the call.</param>
		/// <returns>If the Character have moved.</returns>
		public bool TryMoveTo( int line, int column, out Square final )
        {
			Square square;

			if( _floor.TryGetSquare( line, column, out square ) )
			{
				return TryMoveTo( square, out final );
			}
			else
			{
				final = _square;
				return false;
			}
        }
    }
}
