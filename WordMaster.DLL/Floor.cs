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
		/// The floor created will be right-angled.
		/// </summary>
		/// <param name="name">Name (3 to 30 characters) of the floor.</param>
		/// <param name="length">Length of the floor, must be included in [3, 100].</param>
		/// <param name="width">width of the floor, must be included in [3, 100].</param>
		public Floor( string name, uint length, uint width )
		{
			if( name.Trim() == string.Empty || name == null ) throw new ArgumentException( "Floor's name must not be null, only filled with whitespaces or empty.", "name" );
			if( name.Length < 3 || name.Length > 30 ) throw new ArgumentException( "Floor's name must be a string of 3 to 30 characters." , "name");
			if( length < 3 || length > 100) throw new ArgumentException( "Floor's length must be included in [3, 100].", "length");
			if( width < 3 || width > 100 ) throw new ArgumentException( "Floor's width must be included in [3, 100].", "width" );
			
			_name = name;
			_layout = new Square[length, width];
		}

		/// <summary>
		/// Initializes a new instance of <see cref="Floor"/> class.
		/// The floor created will be cubic.
		/// </summary>
		/// <param name="name">Name of the floor.</param>
		/// <param name="size">Size of the floor, must be greater than zero.</param>
		public Floor( string name, uint size ) : this ( name, size, size ) {}

		public void SetSquare( uint posX, uint posY, string type, bool isHoldable )
		{
			_layout[posX, posY] = new Square( type, isHoldable );
		}

		/// <summary>
		/// Gets the name of the instance of <see cref="Floor"/> class.
		/// </summary>
		public string Name
		{
			get { return _name; }
		}
	}
}
