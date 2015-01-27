using System;
using System.Collections.Generic;

namespace WordMaster.Gameplay
{
	/// <summary>
	/// Holds floor's game's related states that differs in every game. Second layer. Serializable.
	/// </summary>
	[Serializable]
	public class Floor
	{
		public readonly Dungeon Dungeon;
		public readonly FloorStructure Structure;
		readonly Square[,] _layout;
		bool _visited;

		/// <summary>
		/// Recovers an instance of <see cref="Square"/> class using the [int, int] syntax.
		/// </summary>
		/// <param name="line"><see cref="Square"/>'s horizontale coordinate.</param>
		/// <param name="column"><see cref="Square"/>'s verticale coordinate.</param>
		/// <returns>New <see cref="Square"/>'s reference.</returns>
		public Square this[int line, int column]
		{
			get
			{
				if( Structure.CheckBounds( line, column ) ) // Inside the layout
					return _layout[line, column];
				else // Outside the layout
					return null;
			}
			internal set
			{
				if( Structure.CheckBounds( line, column ) ) // Inside the layout
					_layout[line, column] = value;
			}
		}

		/// <summary>
		/// Initializes a new instance of <see cref="Floor"/> class.
		/// </summary>
		/// <param name="dungeon"><see cref="Dungeon"/>'s reference.</param>
		/// <param name="structure"><see cref="FloorStructure"/>'s reference.</param>
		internal Floor( Dungeon dungeon, FloorStructure structure )
		{
			Dungeon = dungeon;
			Structure = structure;
			_layout = new Square[structure.NumberOfLines, structure.NumberOfColumns];

			for (int i = 0; i < structure.NumberOfLines; i++)
			{
				for(int j = 0; j < structure.NumberOfColumns; j++)
				{
					_layout[i, j] = new Square( this, structure[i, j] );
					if( structure[i, j].Mechanism != null )
					{
						_layout[i, j].Trigger = new Trigger( _layout[i, j], structure[i, j].Mechanism );
					}
				}
			}
		}

		/// <summary>
		/// Gets (or sets, this DLL only) if this instance of <see cref="Floor"/> class have been seen by the <see cref="Character"/>.
		/// </summary>
		public bool Visited
		{
			get { return _visited; }
			internal set { _visited = value; }
		}

		/// <summary>
		/// Recreates an instance of <see cref="Square"/> class using a new instance of <see cref="SquareStructure"/> class but keepong the states of the old.
		/// </summary>
		/// <param name="squareStructure"><see cref="SquareStructure"/>'s reference.</param>
		/// <returns>The new <see cref="Square"/>'s reference.</returns>
		internal Square ReprepareSquare( SquareStructure squareStructure )
		{
			Square oldSquare = Dungeon.GetEquivalent(squareStructure.FloorStructure)[squareStructure.Line, squareStructure.Column];
			Square newSquare = new Square( this, squareStructure );
			newSquare.Seen = oldSquare.Seen;
			newSquare.Visited = oldSquare.Visited;

			this[squareStructure.Line, squareStructure.Column] = newSquare;

			return newSquare;
		}

		/// <summary>
		/// Fills this instance of <see cref="Floor"/> class with <see cref="Monster"/>s.
		/// </summary>
		internal void FillWithMonster()
		{
			for( int i = 0; i < Structure.NumberOfLines; i++ )
			{
				for( int j = 0; j < Structure.NumberOfColumns; j++ )
				{
					if( this[i, j].Structure.Holdable
						&&  this[i, j].Trigger == null // Exclude Trigger's holder
						&& !this[i, j].Structure.Equals(this[i, j].Structure.FloorStructure.DungeonStructure.Entrance) // Exclude Entrance
						&& !this[i, j].Structure.Equals(this[i, j].Structure.FloorStructure.DungeonStructure.Exit) // Exclude Exit
					  )
					{
						if( Dungeon.GameContext.GlobalContext.Random.Next(1, 100) <= Structure.MonsterDensity )
						{
							Ennemy sample = null;
							double value = 0;
							double test = 0;

							foreach( Ennemy monster in Dungeon.GameContext.GlobalContext.Monsters )
							{
								test = Dungeon.GameContext.GlobalContext.Random.NextDouble();
								if( test > value )
								{
									value = test;
									sample = monster;
								}
							}


							if( sample != null ) // Checks if their is a Monster available 
								this[i, j].Monster = new Monster( Dungeon.GameContext, sample, this[i, j] );					
						}
					}
				}
			}
		}
	}
}
