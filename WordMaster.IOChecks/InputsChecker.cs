using System;

namespace WordMaster.IOChecks
{
	static public class InputsChecker
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

		#region Description's length
		readonly static int _minDescriptionLength = 0;
		readonly static int _maxDescriptionLength = 255;

		/// <summary>
		/// Gets the minimun length for a description.
		/// </summary>
		static public int MinDescriptionLength
		{
			get { return _minDescriptionLength; }
		}

		/// <summary>
		/// Gets the maximum length for a description.
		/// </summary>
		static public int MaxDescriptionLength
		{
			get { return _maxDescriptionLength; }
		}

		/// <summary>
		/// Checks if a long string is between MinDescritptionLength and MaxDescritptionLength.
		/// </summary>
		/// <param name="description">The long string to check.</param>
		/// <returns>True if the long string's length is correct, false if not.</returns>
		static public bool CheckDescriptionLength( string description )
		{
			if( description.Trim().Length >= _minDescriptionLength && description.Trim().Length <= _maxDescriptionLength ) return true;
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
	}
}
