using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMaster.DLL
{
	public class Floor
	{
		readonly string _name;
		readonly Square[,] _layout;

		/// <summary>
		/// Initializes a new instance of <see cref="Floor"/> class.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the floor.</param>
		/// <param name="length">Length (MinFloorSize to MaxFloorSize size) of the floor.</param>
		/// <param name="width">Width (MinFloorSize to MaxFloorSize size) of the floor.</param>
		internal Floor( string name, int length, int width )
		{
			_name = name;
			_layout = new Square[length, width];
		}

		/// <summary>
		/// Gets the name of the instance of <see cref="Floor"/> class.
		/// </summary>
		public string Name
		{
			get { return _name; }
		}

		/// <summary>
		/// Sets (or reset) a Square in the layout of the Floor.
		/// </summary>
		/// <param name="lin">Horizontal coordinate of the Square.</param>
		/// <param name="col">Vertical coordinate of the Square.</param>
		/// <param name="name">Name of the Squre.</param>
		/// <param name="holdable">Holdable state of the Square.</param>
		public void SetSquare( int lin, int col, string name, bool holdable )
		{
			
			// Checking parameters
			if( lin <= 0 || lin >= _layout.GetLength( 0 ) ) throw new IndexOutOfRangeException("Horizontal parameter is out of range");
			if( col <= 0 || col >= _layout.GetLength( 1 ) ) throw new IndexOutOfRangeException("Vertical parameter is out of range");
			if( !NoMagicHelper.CheckNameLength( name ) )  throw new ArgumentException( "Square's name must be a string of " + NoMagicHelper.MinNameLength + " to " + NoMagicHelper.MaxNameLength + " characters.", "name");

			// Adding Square in Floor
			_layout[lin, col] = new Square( name, holdable );
		}

		/// <summary>
		/// Sets (or reset) a Square in the layout of the Floor.
		/// Square created with not be holdable.
		/// </summary>
		/// <param name="lin">Horizontal coordinate of the Square.</param>
		/// <param name="col">Vertical coordinate of the Square.</param>
		/// <param name="name">Name of the Squre.</param>
		public void SetSquare( int lin, int col, string name )
		{
			SetSquare( lin, col, name, false );
		}

		/// <summary>
		/// Gets the holdable 
		/// </summary>
		/// <param name="lin">Horizontal coordinate of the Square.</param>
		/// <param name="col">Vertical coordinate of the Square.</param>
		/// <returns></returns>
		public bool HoldableSquare( int lin, int col )
		{
			return _layout[lin, col].Holdable;
		}
	}
}
