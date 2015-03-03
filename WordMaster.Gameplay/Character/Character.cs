using System;
using System.Collections.Generic;

namespace WordMaster.Gameplay
{
	/// <summary>
	/// User's character. Second layer. Serializable.
	/// </summary>
	[Serializable]
	public class Character
	{
		public readonly GlobalContext GlobalContext;
		string _name, _description;
		int _maxHealth, _currentHealth, _experience, _level, _armor;
		readonly List<Item> _inventory;
		readonly List<HistoricRecord> _historics;
		GameContext _gameContext;
		Dungeon _dungeon;
		Floor _floor;
		Square _square;
		bool _inCombat;
		Monster _opponent;

		internal Character( GlobalContext globalContext, string name, string description, int health, int experience, int level, int armor )
		{
			GlobalContext = globalContext;
			_name = name;
			_description = description;
			_maxHealth = _currentHealth = health;
			_experience = experience;
			_level = level;
			_armor = armor;
			_inventory = new List<Item>();
			_historics = new List<HistoricRecord>();
		}

		#region 1. Character's characteristics properties
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
		public int CurrentHealth
		{
			get { return _currentHealth; }
			internal set { _currentHealth = value; }
		}

		/// <summary>
		/// Gets if this <see cref="Character"/> is alive.
		/// </summary>
		public bool Alive
		{
			get { return _currentHealth > 0; }
		}

		/// <summary>
		/// Get if this <see cref="Character"/> is dead.
		/// </summary>
		public bool Dead
		{
			get { return _currentHealth <= 0; }
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
		#endregion

		#region 2. Character's position properties
		/// <summary>
		/// Gets or sets (this DLL only) the used instance of <see cref="Dungeon"/> class.
		/// </summary>
		public Dungeon Dungeon
		{
			get { return _dungeon; }
			internal set { _dungeon = value; }
		}

		/// <summary>
		/// Gets or sets (this DLL only) the used instance of <see cref="Floor"/> class.
		/// </summary>
		public Floor Floor
		{
			get { return _floor; }
			internal set { _floor = value; }
		}

		/// <summary>
		/// Gets or sets (this DLL only) the used instance of <see cref="Square"/> class.
		/// </summary>
		public Square Square
		{
			get { return _square; }
			internal set { _square = value; }
		}
		#endregion

		#region 3. Character's inventory related properties
		/// <summary>
		/// Gets the list (read-only) of <see cref="Item"/> of this instance of <see cref="Character"/>.
		/// </summary>
		public IEnumerable<Item> Inventory
		{
			get { return _inventory; }
		}

		/// <summary>
		/// Gets the number of <see cref="Item"/> of this instance of <see cref="Character"/>.
		/// </summary>
		public int NumberOfItems
		{
			get { return _inventory.Count; }
		}
		#endregion

		#region 4. Character's combat related properties
		/// <summary>
		/// Gets if this instance of <see cref="Character"/> class is fighting.
		/// </summary>
		public bool InCombat
		{
			get { return _inCombat; }
			set { _inCombat = value; }
		}

		/// <summary>
		/// Gets the <see cref="Monster"/>'s fight.
		/// </summary>
		public Monster Opponent
		{
			get { return _opponent; }
			set { _opponent = value; }
		}
		#endregion

		#region 5. Character's game related properties
		/// <summary>
		/// Gets the current instance of <see cref="GameContext"/> class.
		/// </summary>
		public GameContext GameContext
		{
			get { return _gameContext; }
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
					return _gameContext.Historic;
				else
					return null;
			}
		}
		#endregion

		#region A] Character's combat methods
		#endregion

		#region B] Character's movements methods
		/// <summary>
		/// Moves an instance of <see cref="Character"/> class to a different Square.
		/// This method will change Character's <see cref="Floor"/> if the targeted <see cref="Square"/> teleport to another Floor.
		/// It will also end or cancel the <see cref="Game"/> if the Character steps to the entrance's square or to the exit's square.
		/// </summary>
		/// <param name="target">Target Square's reference.</param>
		/// <param name="final">Final Character's Square at the end of the call.</param>
		/// <returns>If the Character has moved.</returns>
		public bool TryMoveTo( Square target )
		{
			if( this.Alive ) // Only alive Character can move
			{
				if( target != null ) // Target set
				{
					if( target.Structure.Holdable ) // Target holdable
					{
						if( target.Floor.Dungeon.GetEquivalent(target.Floor.Dungeon.Structure.Entrance).Equals( target ) ) // Dungeon's entrance found -> Cancel the Game
						{
							_gameContext.GlobalContext.CancelGame( this );
						}
						else if( target.Floor.Dungeon.GetEquivalent(target.Floor.Dungeon.Structure.Exit).Equals( target ) ) // Dungeon's exit found -> Finish the Game
						{
							_gameContext.GlobalContext.FinishGame( this );
						}
						else if( target.Trigger != null ) // Trigger found -> Activation
						{
							_square = target;
							target.Trigger.Activate( this );
							UpdateFogOfWar( _square );
						}
						else if ( target.Monster != null ) // Monster found -> Fight
						{
							_inCombat = true;
							_opponent = target.Monster;
						}
						else
						{
							_square = target;
							UpdateFogOfWar( _square );
						}

						return true;
					}
				}
			}
			else // Dead Character, restart Game
			{
				this._currentHealth = _maxHealth;
				this.GoToTheEntrance();
				return true;
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
		#endregion

		#region C] Character's Game methods
		/// <summary>
		/// Sets the current <see cref="Dungeon"/>, current <see cref="Floor"/> and current <see cref="Square"/> to the starting Dungeon's coordinate.
		/// </summary>
		/// <param name="gameContext">GameContext's reference.</param>
		internal void EnterDungeon( GameContext gameContext )
		{
			if( gameContext.Dungeon.Structure.Entrance == null ) throw new ArgumentException( "No entrance.", "dungeon" );
			if( gameContext.Dungeon.Structure.Exit == null ) throw new ArgumentException( "No exit.", "dungeon" );

			_historics.Add( gameContext.Historic );
			_dungeon = gameContext.Dungeon;
			_floor = gameContext.Dungeon.GetEquivalent(gameContext.Dungeon.Structure.Entrance).Floor;
			_square = gameContext.Dungeon.GetEquivalent(gameContext.Dungeon.Structure.Entrance);
			_gameContext = gameContext;

			UpdateFogOfWar( _square );
		}

		/// <summary>
		/// Sets the current <see cref="Floor"/> and current <see cref="Square"/> to the starting values.
		/// </summary>
		internal void GoToTheEntrance()
		{
			if( _gameContext == null ) throw new InvalidOperationException( "This Character is not in a Game." );

			_floor = GameContext.Dungeon.GetEquivalent( GameContext.Dungeon.Structure.Entrance ).Floor;
			_square = GameContext.Dungeon.GetEquivalent( GameContext.Dungeon.Structure.Entrance );
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
		/// Updates adjacent <see cref="Square"/>.
		/// </summary>
		/// <param name="square"><see cref="Square"/>'s reference.</param>
		private void UpdateFogOfWar(Square square)
		{
			square.Visited = square.Seen = true;
			square.Floor[square.Structure.Line-1, square.Structure.Column-1].Seen = true;
			square.Floor[square.Structure.Line-1, square.Structure.Column].Seen = true;
			square.Floor[square.Structure.Line-1, square.Structure.Column+1].Seen = true;
			square.Floor[square.Structure.Line, square.Structure.Column-1].Seen = true;
			square.Floor[square.Structure.Line, square.Structure.Column+1].Seen = true;
			square.Floor[square.Structure.Line+1, square.Structure.Column-1].Seen = true;
			square.Floor[square.Structure.Line+1, square.Structure.Column].Seen = true;
			square.Floor[square.Structure.Line+1, square.Structure.Column+1].Seen = true;
		}
		#endregion
	}
}
