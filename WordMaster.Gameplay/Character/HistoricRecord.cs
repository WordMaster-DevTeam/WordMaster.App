using System;

namespace WordMaster.Gameplay
{
	/// <summary>
	/// Holds game's related statistics. Serializable.
	/// </summary>
	[Serializable]
	public class HistoricRecord
	{
		readonly Character _character;
		DateTime _beginning,_end;
		readonly string _dungeonName, _dungeonDescription;
		int _monsterSlayed, _xpGained;
		bool _finished, _cancelled;

		/// <summary>
		/// Initializes a new instance of <see cref="HistoricRecors"/> class.
		/// </summary>
		/// <param name="character">Character's reference.</param>
		/// <param name="dungeon">Dungeon's reference.</param>
		internal HistoricRecord( Character character, DungeonStructure dungeon )
		{
			_character = character;
			_dungeonName = dungeon.Name;
			_dungeonDescription = dungeon.Description;
			_beginning = DateTime.Now;
		}

		/// <summary>
		/// Gets the reference to the instance of the <see cref="Character"/> used.
		/// </summary>
		public Character Character
		{
			get { return _character; }
		}

		/// <summary>
		/// Gets the name of the instance of <see cref="DungeonStructure"/> used.
		/// </summary>
		public String DungeonName
		{
			get { return _dungeonName; }
		}

		/// <summary>
		/// Gets the description of the instance of <see cref="DungeonStructure"/> used.
		/// </summary>
		public String DungeonDescription
		{
			get { return _dungeonDescription; }
		}

		/// <summary>
		/// Gets the date when the <see cref="Game"/> have begin.
		/// </summary>
		public DateTime Beginning
		{
			get { return _beginning; }
		}

		/// <summary>
		/// Gets the date when the <see cref="Game"/> have end.
		/// </summary>
		public DateTime End
		{
			get { return _end; }
		}

		/// <summary>
		/// Gets the <see cref="Game"/>'s duration.
		/// </summary>
		public TimeSpan GameDuration
		{
			get {
				if( !_end.Equals( DateTime.MinValue ) )
					return _end - _beginning;
				else
					return DateTime.Now - _beginning;
			}
		}

		/// <summary>
		/// Gets or sets (by addition or soustraction) the number of monster slayed by a <see cref="Character"/> during a <see cref="Game"/>.
		/// </summary>
		public int MonsterSlayed
		{
			get { return _monsterSlayed; }
			set { _monsterSlayed += value; }
		}

		/// <summary>
		/// Gets or sets (by addition or soustraction) the number of experience points by a <see cref="Character"/> during a <see cref="Game"/>.
		/// </summary>
		public int XPGained
		{
			get { return _xpGained; }
			set { _xpGained += value; }
		}

		/// <summary>
		/// Gets or sets the finished state for a <see cref="Game"/>.
		/// End's date is set.
		/// </summary>
		public bool Finished
		{
			get { return _finished; }
			set 
			{
				_finished = value;
				_end = DateTime.Now;
			}
		}

		/// <summary>
		/// Gets or sets the cancelled state for a <see cref="Game"/>.
		/// End's date is set.
		/// </summary>
		public bool Cancelled
		{
			get { return _cancelled; }
			set
			{
				_cancelled = value;
				_end = DateTime.Now;
			}
		}
	}
}
