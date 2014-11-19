using System;

namespace WordMaster.DLL
{
	public class Floor
	{
		readonly Dungeon _dungeon;
		int _level;
		readonly string _name;
		readonly string _description;
		Square[,] _layout;

		/// <summary>
		/// Initializes a new instance of <see cref="Floor"/> class.
		/// </summary>
		/// <param name="dungeon">Dungeon's reference, each Floor must be in a <see cref="Dungeon"/>.</param>
		/// <param name="level"></param>
		/// <param name="name">Floor's name, <see cref="NoMagicHelper.MinNameLength"/> to <see cref="NoMagicHelper.MaxNameLength"/> characters.</param>
		/// <param name="description">Floor's description, <see cref="NoMagicHelper.MinLongStringLength"/> to <see cref="NoMagicHelper.MaxLongStringLength"/> characters.</param>
		/// <param name="numberOfLines">Floor's number of line in the layout, <see cref="NoMagicHelper.MinFloorSize"/> to <see cref="NoMagicHelper.MaxFloorSize"/> size.</param>
		/// <param name="numberOfColumns">Floor's number of column in the layout, <see cref="NoMagicHelper.MinFloorSize"/> to <see cref="NoMagicHelper.MaxFloorSize"/> size.</param>
		internal Floor( Dungeon dungeon, int level, string name, string description, int numberOfLines, int numberOfColumns )
		{
			// Checking parameters
			if( !NoMagicHelper.CheckNameLength( name ) ) throw new ArgumentException( "Floor's name must be a string of " + NoMagicHelper.MinNameLength + " to " + NoMagicHelper.MaxNameLength + " characters.", "name" );
			if( !NoMagicHelper.CheckLongStringLength( description ) ) throw new ArgumentException( "Floor's description must be a string of " + NoMagicHelper.MinLongStringLength + " to " + NoMagicHelper.MaxLongStringLength + " characters.", "description" );
			if( !NoMagicHelper.CheckFloorSize( numberOfLines ) ) throw new ArgumentException( "Floor's length must be included in " + NoMagicHelper.MinFloorSize + " to " + NoMagicHelper.MaxFloorSize + ".", "numberOfLines" );
			if( !NoMagicHelper.CheckFloorSize( numberOfColumns ) ) throw new ArgumentException( "Floor's width must be included in " + NoMagicHelper.MinFloorSize + " to " + NoMagicHelper.MaxFloorSize + ".", "numberOfColumns" );

			// Checking context
			foreach(Floor floor in dungeon.Floors)
				if(floor.Name == name)
					throw new ArgumentException( "Floor's name is already used in this Dungeon.", "name" );
			if( level < 0 || level > dungeon.NumberOfFloors )
				throw new ArgumentException( "Can not used disconnected Floor's level.", "level" );

			// Updating context
			if( level != dungeon.NumberOfFloors )
				foreach( Floor floor in dungeon.Floors )
					for( int i = level; level < dungeon.NumberOfFloors; i++ )
						floor.Level += 1;

			// Creating Floor
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
			set { _level = value; }
		}

		/// <summary>
		/// Gets the name of this instance of <see cref="Floor"/> class.
		/// </summary>
		public string Name
		{
			get { return _name; }
		}

		/// <summary>
		/// Gets the description of this instance of <see cref="Floor"/> class.
		/// </summary>
		public string Description
		{
			get { return _description; }
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
		/// Gets the layout of this instance of <see cref="Floor"/> class.
		/// </summary>
		public Square[,] Layout
		{
			get { return _layout; }
		}

		/// <summary>
		/// Sets or resets an instance of <see cref="Square"/> class in the layout of this instance of <see cref="Floor"/> class.
		/// </summary>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="name">Square's name, <see cref="NoMagicHelper.MinNameLength"/> to <see cref="NoMagicHelper.MaxNameLength"/> characters.</param>
		/// <param name="description">Square's description, <see cref="NoMagicHelper.MinLongStringLength"/> to <see cref="NoMagicHelper.MaxLongStringLength"/> characters.</param>
		/// <param name="holdable">Square's Holdable state, optional and false by default.</param>
		/// <param name="exit">Square's exit Square, optional and null by default.</param>
		/// <return>New Square's reference.</return>
		public Square SetSquare(int line, int column, string name, string description = "", bool holdable = false, Square exit = null)
		{
			// Checking parameters
			if( line < 0 || line >= _layout.GetLength( 0 ) ) throw new IndexOutOfRangeException("Horizontal parameter is out of range");
			if( column < 0 || column >= _layout.GetLength( 1 ) ) throw new IndexOutOfRangeException("Vertical parameter is out of range");

			// Adding Square in Floor
			_layout[line, column] = new Square( this, line, column, name, description, holdable, exit );
			return _layout[line, column];
		}

		/// <summary>
		/// Sets all <see cref="Square"/>s in the layout of this instance of <see cref="Floor"/> class.
		/// </summary>
		/// <param name="name">Square's name, <see cref="NoMagicHelper.MinNameLength"/> to <see cref="NoMagicHelper.MaxNameLength"/> characters.</param>
		/// <param name="description">Square's description, <see cref="NoMagicHelper.MinLongStringLength"/> to <see cref="NoMagicHelper.MaxLongStringLength"/> characters.</param>
		/// <param name="holdable">Square's Holdable state, optional and false by default.</param>
		public void SetAllSquares( string name, string description, bool holdable = false )
		{
			for( int i = 0; i < _layout.GetLength( 0 ); i++ )
				for( int j = 0; j < _layout.GetLength( 1 ); j++ )
					_layout[i, j] = new Square( this, i, j, name, description, holdable, null );
		}

		/// <summary>
		/// Sets all uninitialized <see cref="Square"/>s in the layout of this instance of <see cref="Floor"/> class.
		/// </summary>
		/// <param name="name">Square's name, <see cref="NoMagicHelper.MinNameLength"/> to <see cref="NoMagicHelper.MaxNameLength"/> characters.</param>
		/// <param name="description">Square's description, <see cref="NoMagicHelper.MinLongStringLength"/> to <see cref="NoMagicHelper.MaxLongStringLength"/> characters.</param>
		/// <param name="holdable">Square's Holdable state, optional and false by default.</param>
		public void SetAllUninitializedSquares( string name, string description, bool holdable = false )
		{
			for( int i = 0; i < _layout.GetLength( 0 ); i++ )
				for( int j = 0; j < _layout.GetLength( 1 ); j++ )
					if( !CheckSquare( i, j ) )
						_layout[i, j] = new Square( this, i, j, name, description, holdable, null );
		}

		/// <summary>
		/// Gets the reference of the instance of <see cref="Square"/> class in this instance of <see cref="Floor"/> class at the specified coordinates.
		/// </summary>
		/// <param name="line">Horizontal coordinate of the Square.</param>
		/// <param name="column">Vertical coordinate of the Square.</param>
		/// <param name="square">Square's reference to recover.</param>
		/// <returns>Return true if the Square's reference have been found, false if not.</returns>
		public bool TryGetSquare( int line, int column, out Square square )
		{
			if(_layout[line, column] != null)
			{
				square = _layout[line, column];
				return true;
			}
			else
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
		/// <returns>Return true if the Square's coordinates have been found, false if not.</returns>
		public bool TryGetCoordinates( Square square, out int line, out int column )
		{
			for( int i = 0; i < _layout.GetLength( 0 ); i++ )
				for( int j = 0; j < _layout.GetLength( 1 ); j++ )
					if( _layout[i, j].Equals( square ) )
					{
						line = i;
						column = j;
						return true;
					}
			line = -1;
			column = -1;
			return false;
		}

		/// <summary>
		/// Checks if a coordinates can position something inside this instance of <see cref="Floor"/> class' layout.
		/// </summary>
		/// <param name="line">Square's horizontal coordinate to recover.</param>
		/// <param name="column">Square's vertical coordinate to recover.</param>
		/// <returns>Return true if the coordinates are corrects, false if not.</returns>
		public bool CheckBounds( int line, int column )
		{
			if( line > 0 && line <= _layout.GetLength( 0 ) && column > 0 && column <= _layout.GetLength( 1 ) ) return true;
			else return false;
		}

		/// <summary>
		/// Checks if an instance of <see cref="Square"/> class exist and is holdable using coordinates.
		/// </summary>
		/// <param name="line">Square's horizontal coordinate to recover.</param>
		/// <param name="column">Square's vertical coordinate to recover.</param>
		/// <returns>Return true if the Square have been found and is holdable, false if not.</returns>
		public bool CheckHoldable( int line, int column )
		{
			Square square;

			if( TryGetSquare( line, column, out square ) ) return (CheckHoldable( square ));
			else return false;
		}

		/// <summary>
		/// Checks if an existing instance of <see cref="Square"/> class is holdable using his reference.
		/// </summary>
		/// <param name="square">Square's reference.</param>
		/// <returns>Return true if the Square is holdable, false if not.</returns>
		public bool CheckHoldable( Square square )
		{
			if( square.Holdable ) return true;
			else return false;
		}

		/// <summary>
		/// Checks if their is an initialized <see cref="Square"/> at specified coordinates.
		/// </summary>
		/// <param name="line">Square's horizontal coordinate to recover.</param>
		/// <param name="column">Square's vertical coordinate to recover.</param>
		/// <returns>Return true if the Square is initialized, false if not.</returns>
		public bool CheckSquare( int line, int column )
		{
			if( _layout[line, column] != null ) return true;
			else return false;
		}

		/// <summary>
		/// Checks if all instances of <see cref="Square"/>s classes of this instance of <see cref="Floor"/> class' layout are initialized.
		/// </summary>
		/// <returns>Return true if all Squares are initialized, false if not.</returns>
		public bool CheckAllSquare()
		{
			for( int i = 0; i < _layout.GetLength( 0 ); i++ )
				for( int j = 0; j < _layout.GetLength( 1 ); j++ )
					if( !CheckSquare( i, j ) )
						return false;
			return true;
		}
	}
}
