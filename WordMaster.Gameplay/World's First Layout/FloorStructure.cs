using System;

namespace WordMaster.Gameplay
{
	/// <summary>
	/// Holds the defaults states and architecture of a floor in a dungeon. First layer. Serializable.
	/// </summary>
	[Serializable]
	public class FloorStructure
	{
		public readonly DungeonStructure DungeonStructure;
		readonly SquareStructure[,] _layout;
		string _name, _description;
		int _level, _monsterDensity, _monsterMinLevel, _monsterMaxLevel;

		/// <summary>
		/// Recovers an instance of <see cref="SquareStructure"/> class using the [int, int] syntax.
		/// </summary>
		/// <param name="line"><see cref="SquareStructure"/>'s horizontale coordinate.</param>
		/// <param name="column"><see cref="SquareStructure"/>'s verticale coordinate.</param>
		/// <returns>New <see cref="SquareStructure"/>'s reference.</returns>
		public SquareStructure this[int line, int column]
		{
			get
			{
				if( CheckBounds( line, column ) ) // Inside the layout
					return _layout[line, column];
				else // Outside the layout
					return null;
			}
			internal set
			{
				if( CheckBounds( line, column ) ) // Inside the layout
					_layout[line, column] = value;
			}
		}

		/// <summary>
		/// Initializes a new instance of <see cref="FloorStructure"/> class.
		/// </summary>
		/// <param name="dungeon"><see cref="Upper"/>'s reference, all <see cref="FloorStructure"/>s must be in a <see cref="Upper"/>.</param>
		/// <param name="level"><see cref="FloorStructure"/>'s position, must be superior or equal to zero.</param>
		/// <param name="name"><see cref="FloorStructure"/>'s name, must be unique in this Dungeon.</param>
		/// <param name="description"><see cref="FloorStructure"/>'s description.</param>
		/// <param name="numberOfLines"><see cref="FloorStructure"/>'s number of line in the layout.</param>
		/// <param name="numberOfColumns"><see cref="FloorStructure"/>'s number of column in the layout.</param>
		internal FloorStructure( DungeonStructure dungeon, int level, string name, string description, int numberOfLines, int numberOfColumns )
		{
			DungeonStructure = dungeon;
			_level = level;
			_level = level;
			_name = name;
			_description = description;
			_layout = new SquareStructure[numberOfLines, numberOfColumns];
		}

		/// <summary>
		/// Gets the level of this instance of <see cref="FloorStructure"/> class in the instance of <see cref="Upper"/> which contains it.
		/// </summary>
		public int Level
		{
			get { return _level; }
			internal set { _level = value; }
		}

		/// <summary>
		/// Gets the name of this instance of <see cref="FloorStructure"/> class.
		/// </summary>
		public string Name
		{
			get { return _name; }
			internal set { _name = value; }
		}

		/// <summary>
		/// Gets or sets the description of this instance of <see cref="FloorStructure"/> class.
		/// </summary>
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		/// <summary>
		/// Gets the number of lines of the layout in this instance of <see cref="FloorStructure"/> class.
		/// </summary>
		public int NumberOfLines
		{
			get { return _layout.GetLength( 0 ); }
		}

		/// <summary>
		/// Gets the number of columns of the layout in this instance of <see cref="FloorStructure"/> class.
		/// </summary>
		public int NumberOfColumns
		{
			get { return _layout.GetLength( 1 ); }
		}

		/// <summary>
		/// Gets the number of <see cref="SquareStructure"/>s in this instance of <see cref="FloorStructure"/> class.
		/// </summary>
		public int NumberOfSquares
		{
			get { return _layout.GetLength( 0 ) * _layout.GetLength( 1 ); }
		}

		/// <summary>
		/// Gets the <see cref="Monster"/> density for this <see cref="FloorStructure"/>.
		/// </summary>
		public int MonsterDensity
		{
			get { return _monsterDensity; }
		}

		/// <summary>
		/// Gets the <see cref="Monster"/> minimum level for this <see cref="FloorStructure"/>.
		/// </summary>
		public int MonsterMinLevel
		{
			get { return _monsterMinLevel; }
		}

		/// <summary>
		/// Gets the <see cref="Monster"/> maximum level for this <see cref="FloorStructure"/>.
		/// </summary>
		public int MonsterMaxLevel
		{
			get { return _monsterMaxLevel; }
		}

		#region Square management methods
		/// <summary>
		/// Initializes an instance of <see cref="SquareStructure"/> class OUTSIDE the layout of this instance of <see cref="FloorStructure"/> class.
		/// WARNING: Line and column must be inside the layout (see <see cref="FloorStructure.CheckBounds"/>).
		/// </summary>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="name">Square's name.</param>
		/// <param name="description">Square's description.</param>
		/// <param name="holdable">Square's Holdable state.</param>
		/// <returns>New Square's reference.</returns>
		public SquareStructure CreateSquare( int line, int column, string name, string description, bool holdable )
		{
			if( !CheckBounds( line, column ) ) throw new IndexOutOfRangeException( "Coordinates out of range." );

			return new SquareStructure( this, line, column, name, description, holdable );
		}

		/// <summary>
		/// Initializes an instance of <see cref="SquareStructure"/> class OUTSIDE the layout of this instance of <see cref="FloorStructure"/> class.
		/// NOTE: The Square created will have an empty description and will not be holdable.
		/// WARNING: Line and column must be inside the layout (see <see cref="FloorStructure.CheckBounds"/>).
		/// </summary>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="name">Square's name.</param>
		/// <returns>New Square's reference.</returns>
		public SquareStructure CreateSquare( int line, int column, string name )
		{
			return CreateSquare( line, column, name, "", false );
		}

		/// <summary>
		/// Initializes an instance of <see cref="SquareStructure"/> class OUTSIDE the layout of this instance of <see cref="FloorStructure"/> class.
		/// </summary>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="name">Square's name.</param>
		/// <param name="description">Square's description.</param>
		/// <param name="holdable">Square's Holdable state.</param>
		/// <param name="square">Square's reference to recover.</param>
		/// <returns>If the Squares have been set.</returns>
		public bool TryCreateSquare( int line, int column, string name, string description, bool holdable, out SquareStructure square )
		{
			try
			{
				square = CreateSquare( line, column, name, description, holdable );
				return true;
			}
			catch
			{
				square = null;
				return false;
			}
		}

		/// <summary>
		/// Initializes an instance of <see cref="SquareStructure"/> class OUTSIDE the layout of this instance of <see cref="FloorStructure"/> class.
		/// NOTE: The Square created will have an empty description and will not be holdable.
		/// </summary>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="name">Square's name.</param>
		/// <param name="square">Square's reference to recover.</param>
		/// <returns>If the Squares have been set.</returns>
		public bool TryCreateSquare( int line, int column, string name, out SquareStructure square )
		{
			return TryCreateSquare( line, column, name, "", false, out square );
		}

		/// <summary>
		/// Sets or resets an instance of <see cref="SquareStructure"/> class INSIDE the layout of this instance of <see cref="FloorStructure"/> class.
		/// WARNING: Dungeon must be editable, line and column must be inside the layout (see <see cref="FloorStructure.CheckBounds"/>).
		/// </summary>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="name">Square's name.</param>
		/// <param name="description">Square's description.</param>
		/// <param name="holdable">Square's Holdable state.</param>
		/// <returns>New Square's reference.</returns>
		public SquareStructure SetSquare( int line, int column, string name, string description, bool holdable )
		{
			if( !DungeonStructure.Editable ) throw new InvalidOperationException( "Can not edit a Floor in not editable Dungeon" );

			return _layout[line, column] = CreateSquare( line, column, name, description, holdable );
		}

		/// <summary>
		/// Sets or resets an instance of <see cref="SquareStructure"/> class IN the layout of this instance of <see cref="FloorStructure"/> class.
		/// NOTE: The Square created will have an empty description and will not be holdable.
		/// WARNING: Dungeon must be editable, line and column must be inside the layout (see <see cref="FloorStructure.CheckBounds"/>).
		/// </summary>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="name">Square's name.</param>
		/// <returns>New Square's reference.</returns>
		public SquareStructure SetSquare( int line, int column, string name )
		{
			return SetSquare( line, column, name, "", false );
		}

		/// <summary>
		/// Sets or resets an instance of <see cref="SquareStructure"/> class INSIDE the layout of this instance of <see cref="FloorStructure"/> class.
		/// </summary>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="name">Square's name.</param>
		/// <param name="description">Square's description.</param>
		/// <param name="holdable">Square's Holdable state.</param>
		/// <param name="square">Square's reference to recover.</param>
		/// <returns>If the Squares have been set.</returns>
		public bool TrySetSquare( int line, int column, string name, string description, bool holdable, out SquareStructure square )
		{
			try
			{
				square = SetSquare( line, column, name, description, holdable );
				return true;
			}
			catch
			{
				square = null;
				return false;
			}
		}

		/// <summary>
		/// Sets or resets an instance of <see cref="SquareStructure"/> class INSIDE the layout of this instance of <see cref="FloorStructure"/> class.
		/// NOTE: The Square created will have an empty description and will not be holdable.
		/// </summary>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="name">Square's name.</param>
		/// <param name="square">Square's reference to recover.</param>
		/// <returns>If the Squares have been set.</returns>
		public bool TrySetSquare( int line, int column, string name, out SquareStructure square )
		{
			return TrySetSquare( line, column, name, "", false, out square );
		}

		/// <summary>
		/// Sets all <see cref="SquareStructure"/>s INSIDE the layout of this instance of <see cref="FloorStructure"/> class.
		/// WARNING: Dungeon must be editable.
		/// </summary>
		/// <param name="name">Squares' name.</param>
		/// <param name="description">Squares' description, optional and empty by default.</param>
		/// <param name="holdable">Squares' Holdable state, optional and false by default.</param>
		public void SetAllSquares( string name, string description = "", bool holdable = false )
		{
			if( !DungeonStructure.Editable ) throw new InvalidOperationException( "Can not edit a Floor in not editable Dungeon" );

			for( int i = 0; i < _layout.GetLength( 0 ); i++ )
				for( int j = 0; j < _layout.GetLength( 1 ); j++ )
					_layout[i, j] = new SquareStructure( this, i, j, name, description, holdable );
		}

		/// <summary>
		/// Sets all <see cref="SquareStructure"/>s INSIDE the layout of this instance of <see cref="FloorStructure"/> class.
		/// </summary>
		/// <param name="name">Squares' name.</param>
		/// <param name="description">Squares' description, optional and empty by default.</param>
		/// <param name="holdable">Squares' Holdable state, optional and false by default.</param>
		/// <returns>If the Squares have been set.</returns>
		public bool TrySetAllSquares( string name, string description = "", bool holdable = false )
		{
			try
			{
				SetAllSquares( name, description, holdable );
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Sets all uninitialized <see cref="SquareStructure"/>s INSIDE the layout of this instance of <see cref="FloorStructure"/> class.
		/// Warning: Dungeon must be editable.
		/// </summary>
		/// <param name="name">Squares' name.</param>
		/// <param name="description">Squares' description, optional and empty by default.</param>
		/// <param name="holdable">Squares' Holdable state, optional and false by default.</param>
		public void SetAllUninitializedSquares( string name, string description = "", bool holdable = false )
		{
			if( !DungeonStructure.Editable ) throw new InvalidOperationException( "Can not edit a Floor in not editable Dungeon" );

			for( int i = 0; i < _layout.GetLength( 0 ); i++ )
				for( int j = 0; j < _layout.GetLength( 1 ); j++ )
					if( !CheckSquare( i, j ) )
						_layout[i, j] = new SquareStructure( this, i, j, name, description, holdable );
		}

		/// <summary>
		/// Sets all uninitialized <see cref="SquareStructure"/>s INSIDE the layout of this instance of <see cref="FloorStructure"/> class.
		/// </summary>
		/// <param name="name">Squares' name.</param>
		/// <param name="description">Squares' description, optional and empty by default..</param>
		/// <param name="holdable">Squares' Holdable state, optional and false by default.</param>
		/// <returns>If the Squares have been set.</returns>
		public bool TrySetAllUninitializedSquares( string name, string description = "", bool holdable = false )
		{
			try
			{
				SetAllUninitializedSquares( name, description, holdable );
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Gets the coordinates of the instance of <see cref="SquareStructure"/> class in this instance of <see cref="FloorStructure"/> class with a specified reference.
		/// </summary>
		/// <param name="square">Square's reference.</param>
		/// <param name="line">Square's horizontal coordinate to recover.</param>
		/// <param name="column">Square's vertical coordinate to recover.</param>
		/// <returns>If the Square's coordinates have been found.</returns>
		public bool TryGetCoordinates( SquareStructure square, out int line, out int column )
		{
			if( square != null )
			{
				for( int i = 0; i < _layout.GetLength( 0 ); i++ )
				{
					for( int j = 0; j < _layout.GetLength( 1 ); j++ )
					{
						if( _layout[i, j].Equals( square ) )
						{
							line = i;
							column = j;
							return true;
						}
					}
				}
			}

			line = -1;
			column = -1;
			return false;
		}

		/// <summary>
		/// Checks if a coordinates can position something inside this instance of <see cref="FloorStructure"/> class' layout.
		/// </summary>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <returns>If the coordinates are corrects.</returns>
		public bool CheckBounds( int line, int column )
		{
			if( line >= 0 && line < _layout.GetLength( 0 ) && column >= 0 && column < _layout.GetLength( 1 ) )
				return true;
			else
				return false;
		}

		/// <summary>
		/// Checks if their is an initialized <see cref="SquareStructure"/> at specified coordinates.
		/// </summary>
		/// <param name="line">Square's horizontal coordinate to recover.</param>
		/// <param name="column">Square's vertical coordinate to recover.</param>
		/// <returns>If the Square is initialized.</returns>
		public bool CheckSquare( int line, int column )
		{
			if( CheckBounds( line, column ) )
				if( _layout[line, column] != null )
					return true;
			return false;
		}

		/// <summary>
		/// Checks if all instances of <see cref="SquareStructure"/>s classes of this instance of <see cref="FloorStructure"/> class' layout are initialized.
		/// </summary>
		/// <returns>If all Squares are initialized.</returns>
		public bool CheckAllSquares()
		{
			for( int i = 0; i < _layout.GetLength( 0 ); i++ )
				for( int j = 0; j < _layout.GetLength( 1 ); j++ )
					if( !CheckSquare( i, j ) )
						return false;
			return true;
		}
		#endregion

		#region Monsters managament methods
		/// <summary>
		/// Sets the <see cref="Monster"/> number and strenght in this <see cref="FloorStructure"/>.
		/// WARNING: parameters must be positives.
		/// </summary>
		/// <param name="monsterDensity"><see cref="Monster"/>'s number, must be superior or equal to zero.</param>
		/// <param name="monsterMinLevel"><see cref="Monster"/>'s minimum strength, must be superior or equal to zero.</param>
		/// <param name="monsterMaxLevel"><see cref="Monster"/>'s maximum strength, must be superior or equal to zero, must be superior to previous parameter.</param>
		public void SetMonsterAppearance( int monsterDensity, int monsterMinLevel, int monsterMaxLevel )
		{
			if( monsterDensity < 0 || monsterDensity > 100 ) throw new ArgumentException( "Monster's density must be in [0, 100]", "monsterDensity" );
			if( monsterMinLevel < 0 ) throw new ArgumentException( "Monster's minimum level must be superior or equal to zero", "monsterMaxLevel" );
			if( monsterMaxLevel < 0 ) throw new ArgumentException( "Monster's maximum level must be superior or equal to zero", "monsterMaxLevel" );
			if( monsterMaxLevel < monsterMinLevel ) throw new ArgumentException( "Monster's maximum level must be superior or equal to Monster's minimum level", "monsterMaxLevel" );

			_monsterDensity = monsterDensity;
			_monsterMinLevel = monsterMinLevel;
			_monsterMaxLevel = monsterMaxLevel;
		}

		/// <summary>
		/// Sets the <see cref="Monster"/> number and strenght in this <see cref="FloorStructure"/>.
		/// NB: parameters must be positives.
		/// </summary>
		/// <param name="monsterDensity"><see cref="Monster"/>'s number, must be superior or equal to zero.</param>
		/// <param name="monsterMinLevel"><see cref="Monster"/>'s minimum strength, must be superior or equal to zero.</param>
		/// <param name="monsterMaxLevel"><see cref="Monster"/>'s maximum strength, must be superior or equal to zero, must be superior to previous parameter.</param>
		/// <returns>If the <see cref="Monster"/>'s parameters have been set.</returns>
		public bool TrySetMonsterAppearance( int monsterDensity, int monsterMinLevel, int monsterMaxLevel )
		{
			try
			{
				SetMonsterAppearance( monsterDensity, monsterMinLevel, monsterMaxLevel );
				return true;
			}
			catch
			{
				return false;
			}
		}
		#endregion
	}
}
