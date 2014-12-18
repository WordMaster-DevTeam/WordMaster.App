using System;
using System.Collections.Generic;

namespace WordMaster.Gameplay
{
    [Serializable]
    public class Character
    {
		readonly GlobalContext _globalContext;
		string _name, _description;
		int _maxHealth, _health, _experience, _level, _armor;
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
		internal Character( GlobalContext globalContext, string name, string description, int health, int experience, int level, int armor)
		{
			_globalContext = globalContext;
			_name = name;
			_description = description;
			_maxHealth = health;
			_health = health;
			_experience = experience;
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
		/// Gets or sets (this DLL only) the <see cref="Character"/>'s name.
		/// </summary>
        public string Name
        {
            get { return _name; }
			internal set { _name = value; }
        }

		/// <summary>
		/// Gets or sets the <see cref="Character"/>'s description.
		/// </summary>
        public string Description
        {
            get { return _description; }
			set { _description = value; }
        }

		/// <summary>
		/// Gets or sets (this DLL only) the <see cref="Character"/>'s maximum health points.
		/// </summary>
		public int MaxHealth
		{
			get { return _maxHealth; }
			internal set { _maxHealth = value; }
		}

		/// <summary>
		/// Gets or sets (this DLL only) the <see cref="Character"/>'s health points.
		/// </summary>
        public int Health
        {
            get { return _health; }
            internal set { _health = value; }
        }

		/// <summary>
		/// Gets or sets the <see cref="Character"/>'s experience points.
		/// </summary>
        public int Experience
        {
            get { return _experience; }
            internal set { _experience = value; }
        }

		/// <summary>
		/// Gets or sets the <see cref="Character"/>'s level.
		/// </summary>
        public int Level
        {
            get { return _level; }
            internal set { _level = value; }
        }

		/// <summary>
		/// Gets or sets the <see cref="Character"/>'s armor.
		/// </summary>
        public int Armor
        {
            get { return _armor; }
			internal set { _armor = value; }
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
		/// Gets or sets (this DLL only) the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		public Dungeon Dungeon
		{
			get { return _dungeon; }
			internal set { _dungeon = value; }
		}

		/// <summary>
		/// Gets or sets (this DLL only) the current instance of <see cref="Floor"/> class.
		/// </summary>
		public Floor Floor
		{
			get { return _floor; }
			internal set { _floor = value; }
		}

		/// <summary>
		/// Gets or sets (this DLL only) the current instance of <see cref="Square"/> class.
		/// </summary>
		public Square Square
		{
			get { return _square; }
			internal set { _square = value; }
		}

		/// <summary>
		/// Gets the current instance of <see cref="GameContext"/> class.
		/// </summary>
		public GameContext GameContext
		{
			get { return _gameContext; }
		}

		/// <summary>
		/// Gets if this <see cref="Charecter"/> is alive.
		/// </summary>
		public bool Alive
		{
			get { return _health > 0; }
		}

		/// <summary>
		/// Set this <see cref="Character"/> class by giving him his maximum of health
		/// </summary>
		public bool Resurrect
		{
			set { _health = _maxHealth; }
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
		/// Sets the current <see cref="Floor"/> and current <see cref="Square"/> to the starting values.
		/// </summary>
		internal void RetryDungeon()
		{
			if( _gameContext == null ) throw new InvalidOperationException( "This Character is not in a Game." );
			
			_square = Dungeon.Entrance;
			_floor = _dungeon.Entrance.Floor;
		}

		/// <summary>
		/// Sets the current <see cref="Dungeon"/>, current <see cref="Floor"/> and current <see cref="Square"/> to null, effectively leaving the Dungeon.
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
		public bool TryMoveTo( Square target )
		{
			if( this.Alive ) // Dead Character can not move
			{
				if( target != null ) // Target set
				{
					if( target.Holdable ) // Target holdable
					{
						_square = target;

						if( target.Floor.Dungeon.Entrance.Equals( target ) ) // Dungeon's entrance found -> Cancel the Game
						{
							_gameContext.GlobalContext.CancelGame( this );
						}
						else if( target.Floor.Dungeon.Exit.Equals( target ) ) // Dungeon's exit found -> Finish the Game
						{
							_gameContext.GlobalContext.FinishGame( this );
						}
						else if( target.Trigger != null ) // Trigger found -> Activation
						{
							target.Trigger.Activate( this );
						}

						return true;
					}
				}
			}
			
			return false;
		}

        /// <summary>
        /// Moves an instance of <see cref="Character"/> class to a different Square.
        /// </summary>
		/// <param name="line">Target Square's horizontal coordinate.</param>
		/// <param name="column">Target Square's vertical coordinate.</param>
		/// <returns>If the Character have moved.</returns>
		public bool TryMoveTo( int line, int column )
        {
			Square square = _floor[line, column];

			if( square != null )
			{
				return TryMoveTo( square );
			}
			else
			{
				return false;
			}
        }
    }
}
