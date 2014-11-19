using System;

namespace WordMaster.DLL
{
	public class Game
	{
		readonly Character _character;
		readonly Dungeon _dungeon;
		readonly HistoricRecord _historic;

		public Character Character
		{
			get { return _character; }
		}

		public Dungeon Dungeon
		{
			get { return _dungeon; }
		}

		public HistoricRecord Historic
		{
			get { return _historic; }
		}
	}
}
