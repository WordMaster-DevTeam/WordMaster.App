using System;
using System.Collections.Generic;

namespace WordMaster.Gameplay
{
	public partial class GlobalContext
	{
		readonly List<Dungeon> _dungeons = new List<Dungeon>();
		readonly List<Character> _characters = new List<Character>();
		readonly List<Monster> _monsters = new List<Monster>();
		readonly Random _random = new Random();

		/// <summary>
		/// Initiliazes a new instance of <see cref="GlobalContext"/> class.
		/// </summary>
		public GlobalContext()
		{
			AddDefaultDungeon( "The Academy" );
			AddDefaultCharacter( "Oliver" );
			AddDefaultMonster( "Blob" );
		}

		/// <summary>
		/// Gets an instance of <see = "Random"/> class (random generator).
		/// </summary>
		public Random Random
		{
			get { return _random; }
		}

		/// <summary>
		/// Creates news instances of <see cref="Game"/> class and <see cref="HistoricRecord"/> classes.
		/// </summary>
		/// <param name="character">Character's reference.</param>
		/// <param name="dungeon">Dungeon's reference.</param>
		/// <returns>New Game's reference.</returns>
		public GameContext StartNewGame( Character character, Dungeon dungeon, out Game game, out HistoricRecord historicRecord )
		{
			if( dungeon.Finishable ) throw new ArgumentException( "Dungeon's entrance and exit or not set", "dungeon" );

			GameContext gameContext = new GameContext( this, character, dungeon, out game, out historicRecord );
			character.EnterDungeon( gameContext );
			return gameContext;
		}

		/// <summary>
		/// Finishs a <see cref="Game"/>.
		/// The player have used the exit <see cref="Square"/>.
		/// </summary>
		/// <param name="character">Character's reference.</param>
		public void FinishGame( Character character )
		{
			character.GameContext.Game.Historic.Finished = true;
			character.LeaveDungeon();
		}

		/// <summary>
		/// Ends a <see cref="Game"/> .
		/// The player who have use the exit function.
		/// </summary>
		/// <param name="character">Character's reference.</param>
		public void CancelGame( Character character )
		{
			character.GameContext.Game.Historic.Cancelled = true;
			character.LeaveDungeon();
		}
	}
}
