using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMaster.DLL
{
	static public class NoMagicHelper
	{
		#region Name's length
		readonly static int _minLengthName = 3;
		readonly static int _maxLengthName = 30;

		/// <summary>
		/// Gets the minimun length for a name.
		/// </summary>
		static public int MinNameLength
		{
			get { return _minLengthName; }
		}

		/// <summary>
		/// Gets the maximum length for a name.
		/// </summary>
		static public int MaxNameLength
		{
			get { return _maxLengthName; }
		}

		/// <summary>
		/// Checks if a name is between MinNameLength and MaxNameLength.
		/// </summary>
		/// <param name="name">The name of something to check.</param>
		/// <returns>True if the name's length is correct, false if not.</returns>
		static public bool CheckNameLength( string name )
		{
			if( name.Trim().Length >= _minLengthName && name.Trim().Length <= _maxLengthName ) return true;
			else return false;
		}
		#endregion

		#region Floor's size
		readonly static int _minFloorSize = 3;
		readonly static int _maxFloorSize = 100;

		/// <summary>
		/// Gets the minimum size for a Floor.
		/// </summary>
		static public int MinFloorSize
		{
			get { return _minFloorSize; }
		}

		/// <summary>
		/// Gets the maximum size for a Floor.
		/// </summary>
		static public int MaxFloorSize
		{
			get { return _maxFloorSize; }
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
		#endregion

		#region Short string's length
		readonly static int _minShortStringLength = 0;
		readonly static int _maxShortStringLength = 12;

		/// <summary>
		/// Gets the minimun length for a short string.
		/// </summary>
		static public int MinShortStringLength
		{
			get { return _minShortStringLength; }
		}

		/// <summary>
		/// Gets the maximum length for a short string.
		/// </summary>
		static public int MaxShortStringLength
		{
			get { return _maxShortStringLength; }
		}

		/// <summary>
		/// Checks if a short string is between MinShortStringLength and MaxShortStringLength.
		/// </summary>
		/// <param name="shortString">The short string to check.</param>
		/// <returns>True if the short string's length is correct, false if not.</returns>
		static public bool CheckShortStringLength( string shortString )
		{
			if( shortString.Trim().Length >= _minShortStringLength && shortString.Trim().Length <= _maxShortStringLength ) return true;
			else return false;
		}
		#endregion

		#region Long string's length
		readonly static int _minLongStringLength = 0;
		readonly static int _maxLongStringLength = 255;

		/// <summary>
		/// Gets the minimun length for a long string.
		/// </summary>
		static public int MinLongStringLength
		{
			get { return _minLongStringLength; }
		}

		/// <summary>
		/// Gets the maximum length for a long string.
		/// </summary>
		static public int MaxLongStringLength
		{
			get { return _maxLongStringLength; }
		}

		/// <summary>
		/// Checks if a long string is between MinLongStringLength and MaxLongStringLength.
		/// </summary>
		/// <param name="shortString">The long string to check.</param>
		/// <returns>True if the long string's length is correct, false if not.</returns>
		static public bool CheckLongStringLength( string longString )
		{
			if( longString.Trim().Length >= _minLongStringLength && longString.Trim().Length <= _maxLongStringLength ) return true;
			else return false;
		}
		#endregion
	}
}
