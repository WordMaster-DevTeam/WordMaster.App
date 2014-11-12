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
		/// Sets a Square in the layout of the Floor.
		/// </summary>
		/// <param name="posX"></param>
		/// <param name="posY"></param>
		/// <param name="type"></param>
		/// <param name="isHoldable"></param>
		public void SetSquare( int posX, int posY, string type, bool isHoldable )
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
