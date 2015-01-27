using System;

namespace WordMaster.Gameplay
{
	/// <summary>
	/// Represents a game, used to initiates the second layer. Serializable.
	/// </summary>
	[Serializable]
	public class GameContext
	{
		public readonly GlobalContext GlobalContext;
		public readonly Character Character;
		public readonly Dungeon Dungeon;
		public readonly HistoricRecord Historic;

		/// <summary>
		/// Initializes a new instance of <see cref="GameContext"/> class.
		/// </summary>
		/// <param name="globalContext">GlobalContext's reference.</param>
		/// <param name="character">Character's refernce.</param>
		/// <param name="structure">Dungeon's reference.</param>
		/// <param name="historicRecord">HistoricRecord's referecne to recover</param>
		internal GameContext( GlobalContext globalContext, Character character, DungeonStructure structure, out HistoricRecord historicRecord )
		{
			GlobalContext = globalContext;
			Character = character;
			Dungeon = new Dungeon( this, structure, character );
			Historic = historicRecord = new HistoricRecord( character, structure );
		}
	}
}
