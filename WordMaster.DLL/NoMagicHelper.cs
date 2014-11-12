using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMaster.DLL
{
	static public class NoMagicHelper
	{
		readonly static int _minLengthName = 3;
		readonly static int _maxLengthName = 30;
		readonly static int _minFloorSize = 3;
		readonly static int _maxFloorSize = 100;

		/// <summary>
		/// Checks if a name is between MinNameLength and MaxNameLength.
		/// </summary>
		/// <param name="name">The name of something to check.</param>
		/// <returns>True if the name's length is correct, false if not.</returns>
		static public bool CheckNameLength( string name )
		{
			if( name.Length >= _minLengthName && name.Length <= _maxLengthName ) return true;
			else return false;
		}

		/// <summary>
		/// Checks if a size is between MinFloorSize and MaxFloorSize.
		/// </summary>
		/// <param name="size">The size of the Floor to check.</param>
		/// <returns>True if the size is correct, false if not.</returns>
		static public bool CheckFloorSize( int size )
		{
			if( size >= _minFloorSize && size <= _maxFloorSize ) return true;
			else return false;
		}

		/// <summary>
		/// Gets the MinNameLength's value.
		/// </summary>
		static public int MinNameLength
		{
			get { return _minLengthName; }
		}

		/// <summary>
		/// Gets the MaxNameLength's value.
		/// </summary>
		static public int MaxNameLength
		{
			get { return _maxLengthName; }
		}

		/// <summary>
		/// Gets the MinFloorSize's value
		/// </summary>
		static public int MinFloorSize
		{
			get { return _minFloorSize; }
		}

		/// <summary>
		/// Gets the MaxFloorSize's value
		/// </summary>
		static public int MaxFloorSize
		{
			get { return _maxFloorSize; }
		}
	}
}
