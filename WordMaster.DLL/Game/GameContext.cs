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
		/// <param name="currentGame">Game's reference.</param>
		public GameContext( GlobalContext globalContext, Game game )
		{
			_globalContext = globalContext;
			_game = game;
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
