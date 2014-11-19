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
		/// Gets all the instances of <see cref="Character"/> initialized in this instance of <see cref="GlobalContext"/> class.
		/// </summary>
		public IEnumerable<Character> Characters
		{
			get { return _characters; }
		}

		/// <summary>
		/// Gets all the instances of <see cref="Dungeon"/> initialized in this instance of <see cref="GlobalContext"/> class.
		/// </summary>
		public IEnumerable<Dungeon> Dungeons
		{
			get { return _dungeons; }
		}

		/// <summary>
		/// Creates news instances of <see cref="Game"/> class and <see cref="HistoricRecord"/> classes.
		/// </summary>
		/// <param name="character">Used Character's reference.</param>
		/// <param name="dungeon">Used Dungeon's reference.</param>
		/// <param name="historic">Historic's reference.</param>
		/// <returns>The reference of the Game created.</returns>
		public Game StartNewGame( Character character, Dungeon dungeon)
		{
			HistoricRecord record;

			Game game = new Game( character, dungeon, out record );
			character.Historics.Add( record );
			character.

			return game;
		}


		public void EndGame( Character character )
		{
			character.LeaveDungeon();
		}


		public Character AddCharacter(string name, string description = "")
		{
			Character character;

			_characters.Add( new Character( name, description,  ) );
			if( TryGetCharacter( name, out character ) ) return character;
			else return null;
		}

		/// <summary>
		/// Gets the reference of the instance of <see cref="Character"/> class in the current instance of <see cref="GlobalContext"/> class.
		/// </summary>
		/// <param name="name">Character's name.</param>
		/// <param name="dungeon">Character's reference.</param>
		/// <returns>True if the Character have been found, false if not.</returns>
		public bool TryGetCharacter( string name, out Character character )
		{
			foreach( Character aCharacter in _characters )
			{
				if( aCharacter.Name == name )
				{
					character = aCharacter;
					return true;
				}
			}
			character = null;
			return false;
		}

		/// <summary>
		/// Adds an instance of <see cref="Dungeon"/> class in this instance of <see cref="GlobalContext"/> class.
		/// </summary>
		/// <param name="name">Dungeon's name.</param>
		/// <param name="description">(Optional) Dungeon's description. Empty by default.</param>
		/// <returns>Dungeon's reference.</returns>
		public Dungeon AddDungeon(string name, string description = "")
		{
			Dungeon dungeon;

			_dungeons.Add( new Dungeon( this, name, description ) );
			if( TryGetDungeon( name, out dungeon ) ) return dungeon;
			else return null;
		}

		/// <summary>
		/// Gets the reference of the instance of <see cref="Dungeon"/> class in the current instance of <see cref="GlobalContext"/> class.
		/// </summary>
		/// <param name="name">Dungeon's name.</param>
		/// <param name="dungeon">Dungeon's reference.</param>
		/// <returns>True if the Dungeon have been found, false if not.</returns>
		public bool TryGetDungeon( string name, out Dungeon dungeon )
		{
			foreach( Dungeon aDungeon in _dungeons )
			{
				if( aDungeon.Name == name )
				{
					dungeon = aDungeon;
					return true;
				}
			}
			dungeon = null;
			return false;
		}
	}
}
