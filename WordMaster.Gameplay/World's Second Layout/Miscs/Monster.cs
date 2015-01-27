using System;

namespace WordMaster.Gameplay
{
	/// <summary>
	/// Monster that dwell in the dungeon. Second layer. Serializable.
	/// </summary>
	[Serializable]
	public class Monster
	{
		public readonly GameContext GameContext;
		public readonly Ennemy Ennemy;
		public readonly Square Holder;
		int _curentHealth;

		/// <summary>
		/// Initializes a new instance of <see cref="Monster"/> class.
		/// </summary>
		/// <param name="gameContext"><see cref="GameContext"/>'s reference.</param>
		/// <param name="ennemy"><see cref="Ennemy"/>'s reference.</param>
		/// <param name="holder"><see cref="Square"/>'s reference</param>
		internal Monster( GameContext gameContext, Ennemy ennemy, Square holder )
		{
			GameContext = gameContext;
			Ennemy = ennemy;
			Holder = holder;
			_curentHealth = ennemy.Health;
		}

		/// <summary>
		/// Gets (or sets, this DLL only) the current health of this instance of <see cref="Monster"/> class.
		/// </summary>
		public int CurrentHealth
		{
			get { return _curentHealth; }
			internal set { _curentHealth = value; }
		}
	}
}
