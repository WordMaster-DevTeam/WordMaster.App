using System;
using System.Collections.Generic;

namespace WordMaster.Gameplay
{
	/// <summary>
	/// Global object that contains all the <see cref="CharacterBreed"/>s, <see cref="DungeonStructure"/>, <see cref="ItemType"/>s and <see cref="MonsterBreed"/>s usables.
	/// Serializable object.
	/// </summary>
	[Serializable]
	public partial class GlobalContext
	{

		readonly List<CharacterBreed> _characters;
		readonly List<DungeonStructure> _dungeons;
		readonly List<ItemType> _items;
		readonly List<MonsterBreed> _monsters;
		readonly Random _random;

		/// <summary>
		/// Initiliazes a new instance of <see cref="GlobalContext"/> class.
		/// </summary>
		/// <param name="defaultValues">If the default values are added automatically, false by default.</param>
		public GlobalContext( bool defaultValues = false )
		{
			_characters = new List<CharacterBreed>();
			_dungeons = new List<DungeonStructure>();
			_items = new List<ItemType>();
			_monsters = new List<MonsterBreed>();
			_random = new Random();

			if( defaultValues )
			{
				AddDefaultDungeon( "The Academy" );
				AddDefaultCharacter( "Oliver" );
				AddDefaultItem( "Bottle" );
				AddDefaultMonster( "Blob" );
			}
		}

		/// <summary>
		/// Gets the <see cref="Random"/> generator used.
		/// </summary>
		public Random Random
		{
			get { return _random; }
		}

		/// <summary>
		/// Removes the default Dharacter, Dungeon, Item and Monster
		/// </summary>
		public void RemoveDefaults()
		{
			DungeonStructure defaultDungeon;
			CharacterBreed defaultCharacter;
			MonsterBreed defaultMonster;

			if( TryGetDungeon( "The Academy", out defaultDungeon ) )
			{
				_dungeons.Remove( defaultDungeon );
			}

			if( TryGetCharacter( "Oliver", out defaultCharacter ) )
			{
				_characters.Remove( defaultCharacter );
			}

			if( TryGetMonster( "Blob", out defaultMonster ) )
			{
				_monsters.Remove( defaultMonster );
			}
		}

		/// <summary>
		/// Creates news instances of <see cref="Game"/> class and <see cref="HistoricRecord"/> classes.
		/// </summary>
		/// <param name="character">Character's reference.</param>
		/// <param name="dungeon">Dungeon's reference.</param>
		/// <param name="historicRecord">HistoricRecord's reference to recover</param>
		/// <returns>New GameContext's reference.</returns>
		public GameContext StartNewGame( CharacterBreed character, DungeonStructure dungeon, out HistoricRecord historicRecord )
		{
			if( dungeon.Finishable ) throw new ArgumentException( "Dungeon's entrance and exit or not set", "dungeon" );

			GameContext gameContext = new GameContext( this, character, dungeon, out historicRecord );
			character.EnterDungeon( gameContext );
			return gameContext;
		}

		/// <summary>
		/// Finishs a <see cref="Game"/>.
		/// The player have used the exit <see cref="SquareStructure"/>.
		/// </summary>
		/// <param name="character">Character's reference.</param>
		public void FinishGame( CharacterBreed character )
		{
			character.GameContext.Historic.Finished = true;
			character.LeaveDungeon();
		}

		/// <summary>
		/// Ends a <see cref="Game"/> .
		/// The player who have use the exit function.
		/// </summary>
		/// <param name="character">Character's reference.</param>
		public void CancelGame( CharacterBreed character )
		{
			character.GameContext.Historic.Cancelled = true;
			character.LeaveDungeon();
		}
	}
}
