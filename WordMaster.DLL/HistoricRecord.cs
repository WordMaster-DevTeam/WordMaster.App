using System;

namespace WordMaster.DLL
{
	public class HistoricRecord
	{
		readonly Dungeon _dungeon;
		int _monsterSlayed;
		int _xpGained;
		bool _finished;
		bool _cancelled;

		/// <summary>
		/// Initializes a new instance of <see cref="HistoricRecors"/> class.
		/// </summary>
		/// <param name="character">Character's reference.</param>
		/// <param name="dungeon">Dungeon's reference.</param>
		public HistoricRecord( Dungeon dungeon )
		{
			_dungeon = dungeon;
		}

		/// <summary>
		/// Gets the reference to the instance of the <see cref="Dungeon"/> played.
		/// </summary>
		public Dungeon Dungeon
		{
			get { return _dungeon; }
		}

		/// <summary>
		/// Gets or sets (by addition/soustraction only) the number of monster slayed by a <see cref="Character"/> during a <see cref="Game"/>.
		/// </summary>
		public int MonsterSlayed
		{
			get { return _monsterSlayed; }
			set { _monsterSlayed += value; }
		}

		/// <summary>
		/// Gets or sets (by addition/soustraction only) the number of experience points by a <see cref="Character"/> during a <see cref="Game"/>.
		/// </summary>
		public int XPGained
		{
			get { return _xpGained; }
			set { _xpGained += value; }
		}

		/// <summary>
		/// Gets or sets the finished state of a <see cref="Game"/>.
		/// i.e.: a game is finished when the <see cref="Character"/> kill the final boss and/or exit the <see cref="Dungeon"/> by the exit.
		/// </summary>
		public bool Finished
		{
			get { return _finished; }
			set { _finished = value; }
		}

		/// <summary>
		/// Gets or sets the cancelled state of a <see cref="Game"/>.
		/// i.e.: a game is cancelled when the <see cref="Character"/> leave the dungeon by the entrance or withdraw from <see cref="Dungeon"/>.
		/// </summary>
		public bool Cancelled
		{
			get { return _cancelled; }
			set { _cancelled = value; }
		}
	}
}
