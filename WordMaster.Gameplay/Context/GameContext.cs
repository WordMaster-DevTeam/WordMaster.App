using System;

namespace WordMaster.Gameplay
{
	public class GameContext
	{
		readonly GlobalContext _globalContext;
		readonly Game _game;

		/// <summary>
		/// Initializes a new instance of <see cref="GameContext"/> class.
		/// </summary>
		/// <param name="globalContext">GlobalContext's reference.</param>
		/// <param name="character">Character's refernce.</param>
		/// <param name="dungeon">Dungeon's reference.</param>
		/// <param name="game">Game's reference to recover.</param>
		/// <param name="historicRecord">HistoricRecord's referecne to recover</param>
		public GameContext( GlobalContext globalContext, Character character, Dungeon dungeon, out Game game, out HistoricRecord historicRecord )
		{
			_globalContext = globalContext;
			_game = game = new Game(character, dungeon, out historicRecord);
		}

		/// <summary>
		/// Gets the instance of <see cref="GlobalContext"/> used.
		/// </summary>
		public GlobalContext GlobalContext
		{
			get { return _globalContext; }
		}

		/// <summary>
		/// Gets the instance of <see cref="Game"/> class used.
		/// </summary>
		public Game Game
		{
			get { return _game; }
		}
	}
}
