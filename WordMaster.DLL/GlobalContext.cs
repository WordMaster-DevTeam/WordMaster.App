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
		/// Adds an instance of <see cref="Character"/> class in this instance of <see cref="GlobalContext"/> class.
		/// </summary>
		/// <param name="name">Character's name, <see cref="NoMagicHelper.MinNameLength"/> to <see cref="NoMagicHelper.MaxNameLength"/> characters.</param>
		/// <param name="description">Character's description, <see cref="NoMagicHelper.MinDescriptionLength"/> to <see cref="NoMagicHelper.MaxDescriptionLength"/> characters, optional and empty by default.</param>
		/// <param name="hp">Character's health.</param>
		/// <param name="xp">Character's< experience./param>
		/// <param name="level">Character's level.</param>
		/// <param name="armor">Character's armor value.</param>
		/// <returns>New Character's reference.</returns>
		public Character AddCharacter( string name, string description = "", int hp = 100, int xp = 0, int level = 1, int armor = 10 )
		{
			Character character = new Character( name, description, hp, xp, level, armor ) ;
			_characters.Add( character );
			return character;
		}

		/// <summary>
		/// Gets the reference of the instance of <see cref="Character"/> class in the current instance of <see cref="GlobalContext"/> class.
		/// </summary>
		/// <param name="name">Character's name, <see cref="NoMagicHelper.MinNameLength"/> to <see cref="NoMagicHelper.MaxNameLength"/> characters.</param>
		/// <param name="dungeon">Character's reference to recover.</param>
		/// <returns>If the Character have been found.</returns>
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
		/// <param name="name">Dungeon's name, <see cref="NoMagicHelper.MinNameLength"/> to <see cref="NoMagicHelper.MaxNameLength"/> characters.</param>
		/// <param name="description">Dungeon's description, <see cref="NoMagicHelper.MinDescriptionLength"/> to <see cref="NoMagicHelper.MaxDescriptionLength"/> characters, optional and empty by default.</param>
		/// <returns>New Dungeon's reference.</returns>
		public Dungeon AddDungeon(string name, string description = "" )
		{
			Dungeon dungeon = new Dungeon( this, name, description );
			_dungeons.Add( dungeon );
			return dungeon;
		}

		/// <summary>
		/// Gets the reference of the instance of <see cref="Dungeon"/> class in the current instance of <see cref="GlobalContext"/> class.
		/// </summary>
		/// <param name="name">Dungeon's name, <see cref="NoMagicHelper.MinNameLength"/> to <see cref="NoMagicHelper.MaxNameLength"/> characters.</param>
		/// <param name="dungeon">Dungeon's reference to recover.</param>
		/// <returns>If the Dungeon have been found.</returns>
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

		/// <summary>
		/// Creates news instances of <see cref="Game"/> class and <see cref="HistoricRecord"/> classes.
		/// </summary>
		/// <param name="character">Character's reference.</param>
		/// <param name="dungeon">Dungeon's reference.</param>
		/// <returns>New Game's reference.</returns>
		public Game StartNewGame( Character character, Dungeon dungeon)
		{
			if( dungeon.Entrance == null || dungeon.Exit == null ) throw new ArgumentException( "Dungeon's entrance and exit or not set", "dungeon" );

			HistoricRecord record;
			Game game = new Game( character, dungeon, out record );
			character.EnterDungeon( dungeon , game, record );

			return game;
		}

		/// <summary>
		/// Finishs a <see cref="Game"/>.
		/// The player have used the exit <see cref="Square"/>.
		/// </summary>
		/// <param name="character">Character's reference.</param>
		public void FinishGame( Character character )
		{
			character.Game.Historic.Finished = true;
			character.LeaveDungeon();
		}

		/// <summary>
		/// Ends a <see cref="Game"/> .
		/// The player who have use the exit function.
		/// </summary>
		/// <param name="character">Character's reference.</param>
		public void EndGame( Character character )
		{
			character.Game.Historic.Cancelled = true;
			character.LeaveDungeon();
		}
	}
}
