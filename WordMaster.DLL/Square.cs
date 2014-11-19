using System;

namespace WordMaster.DLL
{
	public class Square
	{
		readonly Floor _floor;
		readonly int _line, _column;
		readonly string _name, _description;
		bool _holdable;
		Square _exit;

		/// <summary>
		/// Initializes a new instance of <see cref="Square"/> class.
		/// </summary>
		/// <param name="floor">Floor's reference, each Square must be in a <see cref="Floor"/>.</param>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="name">Square's name, <see cref="NoMagicHelper.MinNameLength"/> to <see cref="NoMagicHelper.MaxNameLength"/> characters.</param>
		/// <param name="description">Square's description, <see cref="NoMagicHelper.MinLongStringLength"/> to <see cref="NoMagicHelper.MaxLongStringLength"/> characters.</param>
		/// <param name="holdable">Square's Holdable state, optional and false by default.</param>
		/// <param name="exit">Square's exit Square, optional and null by default.</param>
		internal Square( Floor floor, int line, int column, string name, string description, bool holdable = false, Square exit = null)
		{
			// Checking parameters
			if( line < 0 || line > floor.NumberOfLines ) throw new ArgumentException( "Square's horizontale coordinate can not be outside the Floor's layout.", "line" );
			if( column < 0 || column > floor.NumberOfColumns ) throw new ArgumentException( "Square's verticale coordinate can not be outside the Floor's layout.", "column" );
			if( !NoMagicHelper.CheckNameLength( name ) ) throw new ArgumentException( "Square's name must be a string of " + NoMagicHelper.MinNameLength + " to " + NoMagicHelper.MaxNameLength + " characters.", "name" );
			if( !NoMagicHelper.CheckLongStringLength( description ) ) throw new ArgumentException( "Square's description must be a string of " + NoMagicHelper.MinNameLength + " to " + NoMagicHelper.MaxNameLength + " characters.", "name" );
			
			// Creating Squares
			_floor = floor;
			_line = line;
			_column = column;
			_name = name;
			_description = description;
			_holdable = holdable;
			_exit = exit;
		}

		/// <summary>
		/// Gets the reference of the instance <see cref="Floor"/> class where this instance of <see cref="Square"/> class is.
		/// </summary>
		public Floor Floor
		{
			get { return _floor; }
		}

		/// <summary>
		/// Gets the name of this instance of <see cref="Square"/> class.
		/// </summary>
		public string Name
		{
			get { return _name; }
		}

		/// <summary>
		/// Gets the description of this instance of <see cref="Square"/> class.
		/// </summary>
		public string Description
		{
			get { return _description; }
		}

		/// <summary>
		/// Gets or sets the holdable state of this instance of <see cref="Square"/> class.
		/// </summary>
		public bool Holdable
		{
			get { return _holdable; }
			set { _holdable = value; }
		}

		/// <summary>
		/// Gets or sets the exit Square of this instance <see cref="Square"/> class.
		/// Exit's Square are link to another Square, maybe in another instance of <see cref="Floor"/> class than where this instance of Square is.
		/// </summary>
		public Square Exit
		{
			get { return _exit; }
			set { _exit = value; }
		}
	}
}
