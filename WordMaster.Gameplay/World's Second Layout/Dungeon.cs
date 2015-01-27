using System;
using System.Collections.Generic;

namespace WordMaster.Gameplay
{
	/// <summary>
	/// Holds dungeon's game's related states that differs in every game. Second layer. Serializable.
	/// </summary>
	[Serializable]
	public class Dungeon
	{
		public readonly GameContext GameContext;
		public readonly DungeonStructure Structure;
		public readonly Character User;
		readonly List<Floor> _floors;

		/// <summary>
		/// Initializes a new instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="gameContext"><see cref="GlobalContext"/>'s reference.</param>
		/// <param name="dungeonStructure"><see cref="Structure"/>'s reference.</param>
		/// <param name="user"><see cref="Character"/>'s reference.</param>
		internal Dungeon( GameContext gameContext, DungeonStructure dungeonStructure, Character user )
		{
			GameContext = gameContext;
			Structure = dungeonStructure;
			User = user;
			_floors = new List<Floor>();

			foreach( FloorStructure floorStructure in Structure.AllFloorStructures )
				_floors.Add( new Floor( this, floorStructure ) );

			foreach( Floor floor in _floors )
				floor.FillWithMonster();
		}

		/// <summary>
		/// Gets the game's used equivalent object. <see cref="Square"/> version.
		/// </summary>
		/// <param name="structure"><see cref="SquareStructure"/>'s reference.</param>
		/// <returns>Equivalent <see cref="Square"/>'s reference.</returns>
		internal Square GetEquivalent( SquareStructure structure )
		{
			foreach( Floor floor in _floors )
				if( floor.Structure.Level == structure.FloorStructure.Level )
					return floor[structure.Line, structure.Column];

			return null;
		}

		/// <summary>
		/// Gets the game's used equivalent object. <see cref="Floor"/> version.
		/// </summary>
		/// <param name="structure"><see cref="FloorStructure"/>'s reference.</param>
		/// <returns>Equivalent <see cref="Floor"/>'s reference.</returns>
		internal Floor GetEquivalent( FloorStructure structure )
		{
			foreach( Floor floor in _floors )
				if( floor.Structure.Level == structure.Level )
					return floor;
			return null;
		}
	}
}
