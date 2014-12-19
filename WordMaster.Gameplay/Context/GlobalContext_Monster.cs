using System;
using System.Collections.Generic;

namespace WordMaster.Gameplay
{
	public partial class GlobalContext
	{
		/// <summary>
		/// Gets (read only) all the instances of <see cref="Monster"/> class initialized in this instance of <see cref="GlobalContext"/> class.
		/// </summary>
		public IEnumerable<Monster> Monsters
		{
			get { return _monsters; }
		}

		/// <summary>
		/// Gets the number of instance of <see cref="Monster"/> class initialized in this instance of <see cref="GlobalContext"/> class.
		/// </summary>
		public int NumberOfMonsters
		{
			get { return _monsters.Count; }
		}

		public Monster AddDefaultMonster( string name )
		{
			if( CheckMonster( name ) ) throw new ArgumentException( "A Monster with this name already exist.", "name" );

			Monster monster = new Monster( this, name, "", 10, 10, 1, 5 );
			_monsters.Add( monster );
			return monster;
		}

		public bool CheckMonster( string name )
		{
			foreach( Monster monster in _monsters )
				if( monster.Name == name )
					return true;
			return false;
		}
	}
}
