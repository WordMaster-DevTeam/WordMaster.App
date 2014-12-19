using System;

namespace WordMaster.Gameplay
{
	public class Floor
	{
		readonly Dungeon _dungeon;
		int _level;
		string _name, _description;
		Square[,] _layout;

		/// <summary>
		/// Recovers an instance of <see cref="Square"/> class using the [int, int] syntax.
		/// </summary>
		/// <param name="line">Square's horizontale coordinate.</param>
		/// <param name="column">Square's verticale coordinate.</param>
		/// <returns>Square's reference.</returns>
		public Square this[int line, int column]
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
		/// Initializes a new instance of <see cref="Floor"/> class.
		/// </summary>
		/// <param name="dungeon">Dungeon's reference, all Floors must be in a <see cref="Dungeon"/>.</param>
		/// <param name="level">Floor's position, must be superior or equal to zero.</param>
		/// <param name="name">Floor's name, must be unique in this Dungeon.</param>
		/// <param name="description">Floor's description.</param>
		/// <param name="numberOfLines">Floor's number of line in the layout.</param>
		/// <param name="numberOfColumns">Floor's number of column in the layout.</param>
		internal Floor( Dungeon dungeon, int level, string name, string description, int numberOfLines, int numberOfColumns )
		{
			_dungeon = dungeon;
			_level = level;
			_level = level;
			_name = name;
			_description = description;
			_layout = new Square[numberOfLines, numberOfColumns];
		}

		/// <summary>
		/// Gets the reference of the instance <see cref="Dungeon"/> class where this instance of <see cref="Floor"/> class is.
		/// </summary>
		public Dungeon Dungeon
		{
			get { return _dungeon; }
		}

		/// <summary>
		/// Gets or sets the level of this instance of <see cref="Floor"/> class in the instance of <see cref="Dungeon"/> which contains it.
		/// </summary>
		public int Level
		{
			get { return _level; }
			internal set { _level = value; }
		}

		/// <summary>
		/// Gets the name of this instance of <see cref="Floor"/> class.
		/// </summary>
		public string Name
		{
			get { return _name; }
			internal set { _name = value; }
		}

		/// <summary>
		/// Gets the description of this instance of <see cref="Floor"/> class.
		/// </summary>
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		/// <summary>
		/// Gets the number of lines of the layout in this instance of <see cref="Floor"/> class.
		/// </summary>
		public int NumberOfLines
		{
			get { return _layout.GetLength( 0 ); }
		}

		/// <summary>
		/// Gets the number of columns of the layout in this instance of <see cref="Floor"/> class.
		/// </summary>
		public int NumberOfColumns
		{
			get { return _layout.GetLength( 1 ); }
		}

		/// <summary>
		/// Getst the number of <see cref="Square"/>s in this instance of <see cref="Floor"/> class.
		/// </summary>
		public int NumberOfSquares
		{
			get { return _layout.GetLength( 0 ) * _layout.GetLength( 1 ); }
		}

		#region Generates Monsters
		public bool GenerateMonsters( int probability, int maxMonsterLevel = 0 )
		{
			if( probability < 0 || probability > 100 ) throw new ArgumentException( "Probability must be a number between 0 and 100.", "probability" );
			if( _dungeon.GlobalContext.NumberOfMonsters == 0 ) throw new InvalidOperationException( "No Monster set." );
			if( !CheckAllSquares() ) throw new InvalidOperationException( "All Squares must be set." );

			Random random = _dungeon.GlobalContext.Random;

			for( int i = 0; i < NumberOfLines; i++ )
			{
				for( int j = 0; j < NumberOfColumns; j++ )
				{
					Square square = this[i, j];
					int value = random.Next( 100 );

					if( square.Holdable )
					{
						
					}
				}
			}

			return true;
		}

		public bool TryGenerateMonsters( int probability, int maxMonsterLevel = 0 )
		{
			try
			{
				return GenerateMonsters( probability, maxMonsterLevel );
			}
			catch
			{
				return false;
			}
		}

		#endregion

		#region Creates Square (outside the layout)
		/// <summary>
		/// Initializes an instance of <see cref="Square"/> class OUTSIDE the layout of this instance of <see cref="Floor"/> class.
		/// WARNING: Line and column must be inside the layout (see <see cref="Floor.CheckBounds"/>).
		/// </summary>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="name">Square's name.</param>
		/// <param name="description">Square's description.</param>
		/// <param name="holdable">Square's Holdable state.</param>
		/// <returns>New Square's reference.</returns>
		public Square CreateSquare( int line, int column, string name, string description, bool holdable )
		{
			if( !CheckBounds( line, column ) ) throw new IndexOutOfRangeException( "Coordinates out of range." );

			return new Square( this, line, column, name, description, holdable );
		}

		/// <summary>
		/// Initializes an instance of <see cref="Square"/> class OUTSIDE the layout of this instance of <see cref="Floor"/> class.
		/// NOTE: The Square created will have an empty description and will not be holdable.
		/// WARNING: Line and column must be inside the layout (see <see cref="Floor.CheckBounds"/>).
		/// </summary>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="name">Square's name.</param>
		/// <returns>New Square's reference.</returns>
		public Square CreateSquare( int line, int column, string name )
		{
			return CreateSquare( line, column, name, "", false );
		}

		/// <summary>
		/// Initializes an instance of <see cref="Square"/> class OUTSIDE the layout of this instance of <see cref="Floor"/> class.
		/// </summary>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="name">Square's name.</param>
		/// <param name="description">Square's description.</param>
		/// <param name="holdable">Square's Holdable state.</param>
		/// <param name="square">Square's reference to recover.</param>
		/// <returns>If the Squares have been set.</returns>
		public bool TryCreateSquare( int line, int column, string name, string description, bool holdable, out Square square )
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
		/// Initializes an instance of <see cref="Square"/> class OUTSIDE the layout of this instance of <see cref="Floor"/> class.
		/// NOTE: The Square created will have an empty description and will not be holdable.
		/// </summary>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="name">Square's name.</param>
		/// <param name="square">Square's reference to recover.</param>
		/// <returns>If the Squares have been set.</returns>
		public bool TryCreateSquare( int line, int column, string name, out Square square )
		{
			return TryCreateSquare( line, column, name, "", false, out square );
		}
		#endregion

		#region Sets Square (inside the layout)
		/// <summary>
		/// Sets or resets an instance of <see cref="Square"/> class INSIDE the layout of this instance of <see cref="Floor"/> class.
		/// WARNING: Dungeon must be editable, line and column must be inside the layout (see <see cref="Floor.CheckBounds"/>).
		/// </summary>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="name">Square's name.</param>
		/// <param name="description">Square's description.</param>
		/// <param name="holdable">Square's Holdable state.</param>
		/// <returns>New Square's reference.</returns>
		public Square SetSquare( int line, int column, string name, string description, bool holdable )
		{
			if( !Dungeon.Editable ) throw new InvalidOperationException( "Can not edit a Floor in not editable Dungeon" );

			return _layout[line, column] = CreateSquare( line, column, name, description, holdable );
		}

		/// <summary>
		/// Sets or resets an instance of <see cref="Square"/> class IN the layout of this instance of <see cref="Floor"/> class.
		/// NOTE: The Square created will have an empty description and will not be holdable.
		/// WARNING: Dungeon must be editable, line and column must be inside the layout (see <see cref="Floor.CheckBounds"/>).
		/// </summary>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="name">Square's name.</param>
		/// <returns>New Square's reference.</returns>
		public Square SetSquare( int line, int column, string name )
		{
			return SetSquare( line, column, name, "", false );
		}

		/// <summary>
		/// Sets or resets an instance of <see cref="Square"/> class INSIDE the layout of this instance of <see cref="Floor"/> class.
		/// </summary>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="name">Square's name.</param>
		/// <param name="description">Square's description.</param>
		/// <param name="holdable">Square's Holdable state.</param>
		/// <param name="square">Square's reference to recover.</param>
		/// <returns>If the Squares have been set.</returns>
		public bool TrySetSquare( int line, int column, string name, string description, bool holdable, out Square square )
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
		/// Sets or resets an instance of <see cref="Square"/> class INSIDE the layout of this instance of <see cref="Floor"/> class.
		/// NOTE: The Square created will have an empty description and will not be holdable.
		/// </summary>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="name">Square's name.</param>
		/// <param name="square">Square's reference to recover.</param>
		/// <returns>If the Squares have been set.</returns>
		public bool TrySetSquare( int line, int column, string name, out Square square )
		{
			return TrySetSquare( line, column, name, "", false, out square );
		}
		#endregion

		#region Sets all and all uninitialized Squares (inside the layout)
		/// <summary>
		/// Sets all <see cref="Square"/>s INSIDE the layout of this instance of <see cref="Floor"/> class.
		/// WARNING: Dungeon must be editable.
		/// </summary>
		/// <param name="name">Squares' name.</param>
		/// <param name="description">Squares' description, optional and empty by default.</param>
		/// <param name="holdable">Squares' Holdable state, optional and false by default.</param>
		public void SetAllSquares( string name, string description = "", bool holdable = false )
		{
			if( !Dungeon.Editable ) throw new InvalidOperationException( "Can not edit a Floor in not editable Dungeon" );

			for( int i = 0; i < _layout.GetLength( 0 ); i++ )
				for( int j = 0; j < _layout.GetLength( 1 ); j++ )
					_layout[i, j] = new Square( this, i, j, name, description, holdable );
		}

		/// <summary>
		/// Sets all <see cref="Square"/>s INSIDE the layout of this instance of <see cref="Floor"/> class.
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
		/// Sets all uninitialized <see cref="Square"/>s INSIDE the layout of this instance of <see cref="Floor"/> class.
		/// Warning: Dungeon must be editable.
		/// </summary>
		/// <param name="name">Squares' name.</param>
		/// <param name="description">Squares' description, optional and empty by default.</param>
		/// <param name="holdable">Squares' Holdable state, optional and false by default.</param>
		public void SetAllUninitializedSquares( string name, string description = "", bool holdable = false )
		{
			if( !Dungeon.Editable ) throw new InvalidOperationException( "Can not edit a Floor in not editable Dungeon" );

			for( int i = 0; i < _layout.GetLength( 0 ); i++ )
				for( int j = 0; j < _layout.GetLength( 1 ); j++ )
					if( !CheckSquare( i, j ) )
						_layout[i, j] = new Square( this, i, j, name, description, holdable );
		}

		/// <summary>
		/// Sets all uninitialized <see cref="Square"/>s INSIDE the layout of this instance of <see cref="Floor"/> class.
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
		#endregion

		#region Gets Square's coordinates and checks bounds and initializations
		/// <summary>
		/// Gets the coordinates of the instance of <see cref="Square"/> class in this instance of <see cref="Floor"/> class with a specified reference.
		/// </summary>
		/// <param name="square">Square's reference.</param>
		/// <param name="line">Square's horizontal coordinate to recover.</param>
		/// <param name="column">Square's vertical coordinate to recover.</param>
		/// <returns>If the Square's coordinates have been found.</returns>
		public bool TryGetCoordinates( Square square, out int line, out int column )
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
		/// Checks if a coordinates can position something inside this instance of <see cref="Floor"/> class' layout.
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
		/// Checks if their is an initialized <see cref="Square"/> at specified coordinates.
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
		/// Checks if all instances of <see cref="Square"/>s classes of this instance of <see cref="Floor"/> class' layout are initialized.
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
	}
}
