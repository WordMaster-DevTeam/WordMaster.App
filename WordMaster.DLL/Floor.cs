using System;

namespace WordMaster.DLL
{
	public class Floor
	{
		readonly string _name;
		string _description;
		Square[,] _layout;

		/// <summary>
		/// Initializes a new instance of <see cref="Floor"/> class.
		/// Floor created will be rigle-angled.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Floor.</param>
		/// <param name="description">Description (MinLongStringLength to MaxLongStringLength characters) of the Floor.</param>
		/// <param name="length">Length (MinFloorSize to MaxFloorSize size) of the Floor.</param>
		/// <param name="width">Width (MinFloorSize to MaxFloorSize size) of the Floor.</param>
		internal Floor( string name, string description, int length, int width )
		{
			_name = name;
			_description = description;
			_layout = new Square[length, width];
		}

		/// <summary>
		/// Gets or sets the name of the instance of <see cref="Floor"/> class.
		/// </summary>
		public string Name
		{
			get { return _name; }
		}

		/// <summary>
		/// Gets or sets the description of the instance of <see cref="Floor"/> class.
		/// </summary>
		public string Description
		{
			get { return _description; }
			set
			{
				if( NoMagicHelper.CheckLongStringLength( value ) ) _description = value;
				else throw new ArgumentException( "Floor's description must be a string of " + NoMagicHelper.MinLongStringLength + " to " + NoMagicHelper.MaxLongStringLength + " characters.", "value" );
			}
		}

		/// <summary>
		/// Gets the Length of the Floor's layout.
		/// </summary>
		public int Length
		{
			get { return _layout.GetLength( 0 ); }
		}

		/// <summary>
		/// Gets the Width of the Floor's layout.
		/// </summary>
		public int Width
		{
			get { return _layout.GetLength( 1 ); }
		}

		/// <summary>
		/// Sets (or reset) a Square in the layout of the Floor.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Square.</param>
		/// <param name="description">Descitpion (MinLongStringLength to MaxLongStringLength characters) of the Square</param>
		/// <param name="holdable">Holdable state of the Square.</param>
		/// <param name="lin">Horizontal coordinate of the Square.</param>
		/// <param name="col">Vertical coordinate of the Square.</param>
		/// <return>Reference of the new Square.</return>
		public Square SetSquare( string name, string description, bool holdable, int lin, int col )
		{
			// Checking parameters
			if( !NoMagicHelper.CheckNameLength( name ) ) throw new ArgumentException( "Square's name must be a string of " + NoMagicHelper.MinNameLength + " to " + NoMagicHelper.MaxNameLength + " characters.", "name" );
			if( !NoMagicHelper.CheckLongStringLength( description ) ) throw new ArgumentException( "Square's description must be a string of " + NoMagicHelper.MinNameLength + " to " + NoMagicHelper.MaxNameLength + " characters.", "name" );
			if( lin < 0 || lin >= _layout.GetLength( 0 ) ) throw new IndexOutOfRangeException("Horizontal parameter is out of range");
			if( col < 0 || col >= _layout.GetLength( 1 ) ) throw new IndexOutOfRangeException("Vertical parameter is out of range");

			// Adding Square in Floor
			_layout[lin, col] = new Square( name, description, holdable );
			return _layout[lin, col];
		}

		/// <summary>
		/// Sets (or reset) a Square in the layout of the Floor.
		/// Square created with not be holdable.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Square.</param>
		/// <param name="description">Descitpion (MinLongStringLength to MaxLongStringLength characters) of the Square</param>
		/// <param name="lin">Horizontal coordinate of the Square.</param>
		/// <param name="col">Vertical coordinate of the Square.</param>
		/// <return>Reference of the new Square.</return>
		public Square SetSquare( string name, string description, int lin, int col )
		{
			return SetSquare( name, description, false, lin, col );
		}

		/// <summary>
		/// Sets (or reset) a Square in the layout of the Floor.
		/// Square will not have a description.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Square.</param>
		/// <param name="holdable">Holdable state of the Square.</param>
		/// <param name="lin">Horizontal coordinate of the Square.</param>
		/// <param name="col">Vertical coordinate of the Square.</param>
		/// <return>Reference of the new Square.</return>
		public Square SetSquare( string name, bool holdable, int lin, int col )
		{
			return SetSquare( name, "", holdable, lin, col );
		}

		/// <summary>
		/// Sets (or reset) a Square in the layout of the Floor.
		/// Square will not have a description.
		/// Square created with not be holdable.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Square.</param>
		/// <param name="lin">Horizontal coordinate of the Square.</param>
		/// <param name="col">Vertical coordinate of the Square.</param>
		/// <return>Reference of the new Square.</return>
		public Square SetSquare( string name, int lin, int col )
		{
			return SetSquare( name, "", false, lin, col );
		}

		/// <summary>
		/// Sets all Squares in the layout of the Floor.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Square.</param>
		/// <param name="description">Descitpion (MinLongStringLength to MaxLongStringLength characters) of the Square</param>
		/// <param name="holdable">Holdable state of the Square.</param>
		public void SetAllSquares( string name, string description, bool holdable )
		{
			for( int i = 0; i < _layout.GetLength( 0 ); i++ )
				for( int j = 0; j < _layout.GetLength( 1 ); j++ )
					_layout[i, j] = new Square( name, description, holdable );
		}

		/// <summary>
		/// Sets all Squares in the layout of the Floor.
		/// Squares created with not be holdable.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Square.</param>
		/// <param name="description">Descitpion (MinLongStringLength to MaxLongStringLength characters) of the Square</param>
		public void SetAllSQuare( string name, string description)
		{
			SetAllSquares( name, description, false );
		}

		/// <summary>
		/// Sets all Squares in the layout of the Floor.
		/// Squares will not have a description.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Square.</param>
		/// <param name="holdable">Holdable state of the Square.</param>
		public void SetAllSquares( string name, bool holdable )
		{
			SetAllSquares( name, "", holdable );
		}

		/// <summary>
		/// Sets all Squares in the layout of the Floor.
		/// Squares will not have a description.
		/// Square created with not be holdable.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Square.</param>
		public void SetAllSquares( string name )
		{
			SetAllSquares( name );
		}

		/// <summary>
		/// Sets all uninitialized Squares in the layout of the Floor.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Square.</param>
		/// <param name="description">Descitpion (MinLongStringLength to MaxLongStringLength characters) of the Square</param>
		/// <param name="holdable">Holdable state of the Square.</param>
		public void SetAllUninitializedSquares( string name, string description, bool holdable )
		{
			for( int i = 0; i < _layout.GetLength( 0 ); i++ )
				for( int j = 0; j < _layout.GetLength( 1 ); j++ )
					if( !CheckSquare( i, j ) )
						_layout[i, j] = new Square( name, description, holdable );
		}

		/// <summary>
		/// Sets all uninitialized Squares in the layout of the Floor.
		/// Squares created with not be holdable.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Square.</param>
		/// <param name="description">Descitpion (MinLongStringLength to MaxLongStringLength characters) of the Square</param>
		public void SetAllUninitializedSquares( string name, string description )
		{
			SetAllUninitializedSquares( name, description, false );
		}

		/// <summary>
		/// Sets all uninitialized Squares in the layout of the Floor.
		/// Squares will not have a description.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Square.</param>
		/// <param name="holdable">Holdable state of the Square.</param>
		public void SetAllUninitializedSquares( string name, bool holdable )
		{
			SetAllUninitializedSquares( name, "", holdable );
		}

		/// <summary>
		/// Sets all uninitialized Squares in the layout of the Floor.
		/// Squares will not have a description.
		/// Square created with not be holdable.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Square.</param>
		public void SetAllUninitializedSquares( string name )
		{
			SetAllUninitializedSquares( name );
		}

		/// <summary>
		/// Gets the reference of the instance of <see cref="square"/> class in the current instance of <see cref="Floor"/> class.
		/// </summary>
		/// <param name="lin">Horizontal coordinate of the Square.</param>
		/// <param name="col">Vertical coordinate of the Square.</param>
		/// <param name="square">Square's reference.</param>
		/// <returns>True if the Square have been found, false if not.></returns>
		public bool TryGetSquare( int lin, int col, out Square square )
		{
			if(_layout[lin, col] != null)
			{
				square = _layout[lin, col];
				return true;
			}
			else
			{
				square = null;
				return false;
			}

		}

		/// <summary>
		/// Checks if the specified Square of the current Floor's instance is initialized.
		/// </summary>
		/// <param name="lin">Horizontal coordinate of the Square.</param>
		/// <param name="col">Vertical coordinate of the Square.</param>
		/// <returns>True if the Square have been initialized. False if not.</returns>
		public bool CheckSquare( int lin, int col )
		{
			if( _layout[lin, col] != null ) return true;
			else return false;
		}

		/// <summary>
		/// Checks if all Squares of the current Floor's instance are initialized.
		/// </summary>
		/// <returns>True if all Squares have been initialized. False if not.</returns>
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
