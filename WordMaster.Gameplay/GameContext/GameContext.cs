using System;

namespace WordMaster.Gameplay
{
	[Serializable]
	public class GameContext
	{
		readonly GlobalContext _globalContext;
		readonly CharacterBreed _character;
		readonly DungeonStructure _dungeon;
		readonly HistoricRecord _historicRecord;

		/// <summary>
		/// Initializes a new instance of <see cref="GameContext"/> class.
		/// </summary>
		/// <param name="globalContext">GlobalContext's reference.</param>
		/// <param name="character">Character's refernce.</param>
		/// <param name="dungeon">Dungeon's reference.</param>
		/// <param name="historicRecord">HistoricRecord's referecne to recover</param>
		public GameContext( GlobalContext globalContext, CharacterBreed character, DungeonStructure dungeon, out HistoricRecord historicRecord )
		{
			_globalContext = globalContext;
			_character = character;
			_dungeon = dungeon;
			_historicRecord = historicRecord = new HistoricRecord( character, dungeon );
		}

		/// <summary>
		/// Gets the instance of <see cref="GlobalContext"/> used.
		/// </summary>
		public GlobalContext GlobalContext
		{
			get { return _globalContext; }
		}

		/// <summary>
		/// Gets the Game's <see cref="Character"/>.
		/// </summary>
		public CharacterBreed Character
		{
			get { return _character; }
		}

		/// <summary>
		/// Gets the Game's <see cref="Dungeon"/>.
		/// </summary>
		public DungeonStructure Dungeon
		{
			get { return _dungeon; }
		}

		/// <summary>
		/// Gets the Game's <see cref="HistoricRecord"/>.
		/// </summary>
		public HistoricRecord Historic
		{
			get { return _historicRecord; }
		}
	}
}
