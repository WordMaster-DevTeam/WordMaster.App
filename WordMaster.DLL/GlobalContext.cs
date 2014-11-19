using System;
using System.Collections.Generic;

namespace WordMaster.DLL
{
	public class GlobalContext
	{
		readonly List<Character> _characters;
		readonly List<Dungeon> _dungeons;

		/// <summary>
		/// Initiliazes a new instance of <see cref="GlobalContext"/> class.
		/// </summary>
		public GlobalContext()
		{
			_characters = new List<Character>();
			_dungeons = new List<Dungeon>();
		}

		/// <summary>
		/// Gets an IEnumerable<Character> of all the instances of <see cref="Character"/> initialized in this instance of <see cref="GlobalContext"/> class.
		/// </summary>
		public IEnumerable<Character> Characters
		{
			get { return _characters; }
		}

		/// <summary>
		/// Gets an IEnumerable<Dungeon> of all the instances of <see cref="Dungeon"/> initialized in this instance of <see cref="GlobalContext"/> class.
		/// </summary>
		public IEnumerable<Dungeon> Dungeons
		{
			get { return _dungeons; }
		}

		
		public Character AddCharacter()
		{
			throw new NotImplementedException();
		}


		public Dungeon AddDungeon()
		{
			throw new NotImplementedException();
		}
	}
}
