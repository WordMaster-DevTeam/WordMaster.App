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
				if( line < 0 || line >= NumberOfLines || column < 0 || column >= NumberOfLines ) // Outside the layout
					return null;
				else return _layout[line, column]; // Inside the layout
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

		/// <summary>
		/// Gets the layout of this instance of <see cref="Floor"/> class.
		/// </summary>
		public Square[,] Layout
		{
			get { return _layout; }
		}

		/// <summary>
		/// Sets or resets an instance of <see cref="Square"/> class in the layout of this instance of <see cref="Floor"/> class.
		/// WARNING: Dungeon must be editable, line and column must be inside the layout (see <see cref="Floor.CheckBounds"/>).
		/// </summary>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="name">Square's name.</param>
		/// <param name="description">Square's description.</param>
		/// <param name="holdable">Square's Holdable state.</param>
		/// <param name="teleportTo">Square's teleport to Square.</param>
		/// <returns>New Square's reference.</returns>
		public Square SetSquare(int line, int column, string name, string description, bool holdable, Square teleportTo)
		{
			if( !Dungeon.Editable ) throw new InvalidOperationException( "Can not edit a Floor in not editable Dungeon" );
			if( !CheckBounds( line, column ) ) throw new IndexOutOfRangeException( "Coordinates out of range." );

			_layout[line, column] = new Square( this, line, column, name, description, holdable, teleportTo );
			return _layout[line, column];
		}

		/// <summary>
		/// Sets or resets an instance of <see cref="Square"/> class in the layout of this instance of <see cref="Floor"/> class.
		/// NOTE: The Square created will have an empty description, will not be holdable and will not teleport to another Square.
		/// WARNING: Dungeon must be editable, line and column must be inside the layout (see <see cref="Floor.CheckBounds"/>).
		/// </summary>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="name">Square's name.</param>
		/// <returns>New Square's reference.</returns>
		public Square SetSquare( int line, int column, string name )
		{
			return SetSquare( line, column, name, "", false, null );
		}

		/// <summary>
		/// Sets or resets an instance of <see cref="Square"/> class in the layout of this instance of <see cref="Floor"/> class.
		/// </summary>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="name">Square's name.</param>
		/// <param name="description">Square's description.</param>
		/// <param name="holdable">Square's Holdable state.</param>
		/// <param name="teleportTo">Square's teleport to Square.</param>
		/// <param name="square">Square's reference to recover.</param>
		/// <returns>If the Squares have been set.</returns>
		public bool TrySetSquare(int line, int column, string name, string description, bool holdable, Square teleportTo, out Square square)
		{
			try
			{
				square = SetSquare(line, column, name, description, holdable, teleportTo);
				return true;
			}
			catch
			{
				square = null;
				return false;
			}
		}

		/// <summary>
		/// Sets or resets an instance of <see cref="Square"/> class in the layout of this instance of <see cref="Floor"/> class.
		/// NOTE: The Square created will have an empty description, will not be holdable and will not teleport to another Square.
		/// </summary>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="name">Square's name.</param>
		/// <param name="square">Square's reference to recover.</param>
		/// <returns>If the Squares have been set.</returns>
		public bool TrySetSquare( int line, int column, string name, out Square square )
		{
			return TrySetSquare( line, column, name, "", false, null, out square );
		}

		/// <summary>
		/// Sets all <see cref="Square"/>s in the layout of this instance of <see cref="Floor"/> class.
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
					_layout[i, j] = new Square( this, i, j, name, description, holdable, null );
		}

		/// <summary>
		/// Sets all <see cref="Square"/>s in the layout of this instance of <see cref="Floor"/> class.
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
		/// Sets all uninitialized <see cref="Square"/>s in the layout of this instance of <see cref="Floor"/> class.
		/// Warning: Dungeon must be editable.
		/// </summary>
		/// <param name="name">Squares' name.</param>
		/// <param name="description">Squares' description, optional and empty by default.</param>
		/// <param name="holdable">Squares' Holdable state, optional and false by default.</param>
		public void SetAllUninitializedSquares(string name, string description = "", bool holdable = false) 
		{
			if( !Dungeon.Editable ) throw new InvalidOperationException( "Can not edit a Floor in not editable Dungeon" );

			for( int i = 0; i < _layout.GetLength( 0 ); i++ )
						for( int j = 0; j < _layout.GetLength( 1 ); j++ )
							if( !CheckSquare( i, j ) )
								_layout[i, j] = new Square( this, i, j, name, description = "", holdable, null );
		}

		/// <summary>
		/// Sets all uninitialized <see cref="Square"/>s in the layout of this instance of <see cref="Floor"/> class.
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
		/// Gets the reference of the instance of <see cref="Square"/> class in this instance of <see cref="Floor"/> class at the specified coordinates.
		/// WARNING: Coordinates must be inside the layout.
		/// </summary>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <returns>Square's reference.</returns>
		public Square GetSquare( int line, int column )
		{
			if( !CheckBounds( line, column ) ) throw new IndexOutOfRangeException( "Coordinates out of range." );

			return _layout[line, column];
		}

		/// <summary>
		/// Gets the reference of the instance of <see cref="Square"/> class in this instance of <see cref="Floor"/> class at the specified coordinates.
		/// </summary>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="square">Square's reference to recover.</param>
		/// <returns>If the Square's reference have been found.</returns>
		public bool TryGetSquare( int line, int column, out Square square )
		{
			try
			{
				square = GetSquare( line, column );
				return true;
			}
			catch
			{
				square = null;
				return false;
			}
		}

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
				if( _layout[line, column] != null)
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
	}
}
