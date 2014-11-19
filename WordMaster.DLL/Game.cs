using System;

namespace WordMaster.DLL
{
	public class Game
	{
		readonly Character _character;
		readonly Dungeon _dungeon;
		readonly HistoricRecord _historic;

		/// <summary>
		/// Initializes a new instance of <see cref="Game"/> class.
		/// </summary>
		/// <param name="character">Used Character's reference.</param>
		/// <param name="dungeon">Used Dungeon's reference.</param>
		/// <param name="historic"></param>
		internal Game( Character character, Dungeon dungeon, out HistoricRecord historic )
		{
			_character = character;
			_dungeon = dungeon;
			_historic = historic = new HistoricRecord(dungeon);
		}

		/// <summary>
		/// Gets the Game's <see cref="Character"/>.
		/// </summary>
		public Character Character
		{
			get { return _character; }
		}

		/// <summary>
		/// Gets the Game's <see cref="Dungeon"/>.
		/// </summary>
		public Dungeon Dungeon
		{
			get { return _dungeon; }
		}

		/// <summary>
		/// Gets the Game's <see cref="HistoricRecord"/>.
		/// </summary>
		public HistoricRecord Historic
		{
			get { return _historic; }
		}
	}
}
