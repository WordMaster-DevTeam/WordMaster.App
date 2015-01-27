using System;

namespace WordMaster.Gameplay
{
	/// <summary>
	/// Holds square's game's related states that differs in every game. Second layer. Serializable.
	/// </summary>
	[Serializable]
	public class Square
	{
		public readonly Floor Floor;
		public readonly SquareStructure Structure;
		bool _seen, _visited;
		Trigger _trigger;
		Monster _monster;

		/// <summary>
		/// Initialized a new instance of <see cref="Square"/>.
		/// </summary>
		/// <param name="floor"><see cref="Floor"/>'s reference.</param>
		/// <param name="structure"><see cref="SquareStructure"/>'s reference.</param>
		internal Square( Floor floor, SquareStructure structure )
		{
			Floor = floor;
			Structure = structure;
		}

		/// <summary>
		/// Gets (or sets, for this DLL) the <see cref="Trigger"/>.
		/// </summary>
		public Trigger Trigger
		{
			get { return _trigger; }
			internal set { _trigger = value; }
		}

		/// <summary>
		/// Gets (or sets, for this DLL only) the <see cref="Monster"/>.
		/// </summary>
		public Monster Monster
		{
			get { return _monster; }
			internal set { _monster = value; }
		}

		/// <summary>
		/// Gets (or sets, for this DLL only) if this instance of <see cref="Square"/> class have been seen by the <see cref="Character"/>.
		/// </summary>
		public bool Seen
		{
			get { return _seen; }
			internal set { _seen = value; }
		}

		/// <summary>
		/// Gets (or sets, for this DLL only) if this instance of <see cref="Square"/> class have been visited be the <see cref="Character"/>.
		/// </summary>
		public bool Visited
		{
			get { return _seen; }
			internal set { _visited = value; }
		}
	}
}
