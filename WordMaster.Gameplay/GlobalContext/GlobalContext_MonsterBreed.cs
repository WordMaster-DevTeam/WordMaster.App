using System;
using System.Collections.Generic;

namespace WordMaster.Gameplay
{
	/// <summary>
	/// Encapsulated <see cref="monster"/>s management properties and methods.
	/// </summary>
	public partial class GlobalContext
	{
		/// <summary>
		/// Gets (read only) all the instances of <see cref="MonsterBreed"/> class initialized in this instance of <see cref="GlobalContext"/> class.
		/// </summary>
		public IEnumerable<MonsterBreed> Monsters
		{
			get { return _monsters; }
		}

		/// <summary>
		/// Gets the number of instance of <see cref="MonsterBreed"/> class initialized in this instance of <see cref="GlobalContext"/> class.
		/// </summary>
		public int NumberOfMonsters
		{
			get { return _monsters.Count; }
		}

		/// <summary>
		/// Adds an instance of <see cref="MonsterBreed"/> class in this instance of <see cref="GlobalContext"/> class.
		/// WARNING: Dungeon's name must be unique.
		/// </summary>
		/// <param name="name">Monster's name, must be unique in this GlobalContext.</param>
		/// <returns>The default Monster.</returns>
		internal MonsterBreed AddDefaultMonster( string name )
		{
			if( CheckMonster( name ) ) throw new ArgumentException( "A Monster with this name already exist.", "name" );

			MonsterBreed monster = new MonsterBreed( this, name, "", 10, 10, 1, 5 );
			_monsters.Add( monster );
			return monster;
		}

		#region Adds Monster
		#endregion

		#region Removes Monster
		#endregion

		#region Rename Monster
		#endregion

		#region Gets ands Check Monster
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public MonsterBreed GetMonster(string name)
		{
			foreach( MonsterBreed monster in _monsters )
				if( monster.Name == name )
					return monster;

			return null;
		}

		/// <summary>
		/// Tr
		/// </summary>
		/// <param name="name"></param>
		/// <param name="monster"></param>
		/// <returns></returns>
		public bool TryGetMonster( string name, out MonsterBreed monster )
		{
			if( (monster = GetMonster( name )) == null )
				return true;
			else
				return false;
		}

		/// <summary>
		/// Checks if an instance of <see cref="MonsterBreed"/> exist in the current instance of <see cref="GlobalContext"/> class.
		/// </summary>
		/// <param name="name"><see cref="MonsterBreed"/>'s name.</param>
		/// <returns>If the <see cref="MonsterBreed"/> have been found.</returns>
		public bool CheckMonster( string name )
		{
			foreach( MonsterBreed monster in _monsters )
				if( monster.Name == name )
					return true;
			return false;
		}
		#endregion
	}
}
