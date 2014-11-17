using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMaster.DLL
{
    public class Dungeon
    {
		readonly string _name;
		readonly Dictionary<int, Floor> _floors;

		/// <summary>
		/// Initializes a new instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Dungeon.</param>
		public Dungeon( string name )
		{
			if( !NoMagicHelper.CheckNameLength( name ) ) throw new ArgumentException( "Dungeon's name must be a string of " + NoMagicHelper.MinNameLength + " to " + NoMagicHelper.MaxNameLength + " characters.", "name" );

			_name = name;
			_floors = new Dictionary<int,Floor> ();
		}

		/// <summary>
		/// Gets the name of the instance of <see cref="Dungeon"/> class.
		/// </summary>
		public string Name
		{
			get { return _name; }
		}

		/// <summary>
		/// Gets the number of floors in the instance of <see cref="Dungeon"/> class.
		/// </summary>
		public int NumberOfFloors
		{
			get { return _floors.Count; }
		}

		#region AddFloor methods (using set or not set index and cubic or right-angled constructor)
		/// <summary>
		/// Adds a new instance of <see cref="Floor"/> class to the current instance of <see cref="Dungeon"/> class.
		/// The Floor created will be right-angled.
		/// </summary>
		/// <param name="index">Position of the Floor to add.</param>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the floor.</param>
		/// <param name="length">Length (MinFloorSize to MaxFloorSize size) of the floor.</param>
		/// <param name="width">Width (MinFloorSize to MaxFloorSize size) of the floor.</param>
		/// <returns>Reference of the new Floor.</returns>
		public Floor AddFloor( int index, string name, int length, int width )
		{
			if( NoMagicHelper.CheckNameLength( name ) ) throw new ArgumentException( "Floor's name must be a string of " + NoMagicHelper.MinNameLength + " to " + NoMagicHelper.MaxNameLength + " characters.", "name" );
			if( NoMagicHelper.CheckFloorSize( length ) ) throw new ArgumentException( "Floor's length must be included in " + NoMagicHelper.MinFloorSize + " to " + NoMagicHelper.MaxFloorSize + ".", "length" );
			if( NoMagicHelper.CheckFloorSize( width ) ) throw new ArgumentException( "Floor's width must be included in " + NoMagicHelper.MinFloorSize + " to " + NoMagicHelper.MaxFloorSize + ".", "width" );

			if( TryGetFloor( name ) != null ) throw new ArgumentException( "A floor with this name already exist.", "name" );
			if( index < 0 || index > _floors.Count ) throw new ArgumentException( "Floor must be connected each others.", "index" );

			if( TryGetFloor( index ) == null )
			{
				// No index modifications needed
				_floors.Add( index, new Floor( name, length, width ) );
			}
			else
			{
				// Index modification: move the floor with corresponding index to upper level, and the next after, etc.
				
			}

			return TryGetFloor( index );
		}

		/// <summary>
		/// Adds a new instance of <see cref="Floor"/> class after the last Floor to the current instance of <see cref="Dungeon"/> class.
		/// The Floor created will be right-angled.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the floor.</param>
		/// <param name="length">Length (MinFloorSize to MaxFloorSize size) of the floor.</param>
		/// <param name="width">Width (MinFloorSize to MaxFloorSize size) of the floor.</param>
		/// <returns>Reference of the new Floor.</returns>
		public Floor AddFloor( string name, int length, int width )
		{
			return AddFloor( _floors.Count, name, length, width );
		}

		/// <summary>
		/// Adds a new instance of <see cref="Floor"/> class to the current instance of <see cref="Dungeon"/> class.
		/// The Floor created will be cubic.
		/// </summary>
		/// <param name="index">Position of the Floor to add.</param>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the floor.</param>
		/// <param name="size">Size (MinFloorSize to MaxFloorSize size) of the floor.</param>
		/// <returns>Reference of the new Floor.</returns>
		public Floor AddFloor( int index, string name, int size )
		{
			return AddFloor( index, name, size, size );
		}

		/// <summary>
		/// Adds a new instance of <see cref="Floor"/> class after the last Floor to the current instance of <see cref="Dungeon"/> class.
		/// The Floor created will be cubic.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the floor.</param>
		/// <param name="size">Size (MinFloorSize to MaxFloorSize size) of the floor.</param>
		/// <returns>Reference of the new Floor.</returns>
		public Floor AddFloor( string name, int size )
		{
			return AddFloor( _floors.Count, name, size, size );
		}
		#endregion

		#region DeleteFloor methods (using reference, name or index of the Floor to remove)
		/// <summary>
		/// Deletes an old instance of <see cref="Floor"/> class of the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="floor">Reference of the Floor to delete.</param>
		/// <returns>True if the Floor has been found and delete.</returns>
		public bool DeleteFloor( Floor floor )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Deletes an old instance of <see cref="Floor"/> class of the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="Name">Name of the floor to delete.</param>
		/// <returns>True if the Floor has been found and delete.</returns>
		public bool DeleteFloor( string Name )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Deletes an old instance of <see cref="Floor"/> class of the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="index">Index of the floor to delete.</param>
		/// <returns>True if the Floor has been found and delete.</returns>
		public bool DeleteFloor( int index )
		{
			throw new NotImplementedException();
		}
		#endregion

		#region TryGets a/next/previous Floor methods (using reference, name or index)
		/// <summary>
		/// Try to gets a reference of an instance of <see cref="Floor"/> class, by name.
		/// </summary>
		/// <param name="name">Name of the Floor to get.</param>
		/// <returns>Reference of the next Floor. Or Null if not found.</returns>
		public Floor TryGetFloor( string name )
		{
			throw new NotImplementedException();			
		}

		/// <summary>
		/// Try to gets a reference of an instance of <see cref="Floor"/> class, by index.
		/// </summary>
		/// <param name="index">Index of the Floor to get (must be positive).</param>
		/// <returns>Reference of the next Floor. Or Null if not found.</returns>
		public Floor TryGetFloor( int index )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Try to gets the reference of the next instance of <see cref="Floor"/> class, using reference of the current Floor.
		/// </summary>
		/// <param name="currentFloor">Reference of the current Floor.</param>
		/// <returns>Reference of the next Floor. Or Null if not found.</returns>
		public Floor TryGetNextFloor( Floor currentFloor )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Try to gets the reference of the next instance of <see cref="Floor"/> class, using name of the current Floor.
		/// </summary>
		/// <param name="name">Name of the current Floor.</param>
		/// <returns>Reference of the next Floor. Or Null if not found.</returns>
		public Floor TryGetNextFloor( string name )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// try of gets the reference of the next instance of <see cref="Floor"/> class, using index of the current Floor.
		/// </summary>
		/// <param name="index">Index of the current Floor.</param>
		/// <returns>Reference of the next Floor. Or Null if not found.</returns>
		public Floor GetNextFloor( int index )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Try to gets the reference of the next instance of <see cref="Floor"/> class, using reference of the current Floor.
		/// </summary>
		/// <param name="currentFloor">Reference of the current Floor.</param>
		/// <returns>Reference of the next Floor. Or Null if not found.</returns>
		public Floor TryGetPreviousFloor( Floor currentFloor )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Try to gets the reference of the next instance of <see cref="Floor"/> class, using name of the current Floor.
		/// </summary>
		/// <param name="name">Name of the current Floor.</param>
		/// <returns>Reference of the next Floor. Or Null if not found.</returns>
		public Floor TryGetPreviousFloor( string name )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Try to gets the reference of the next instance of <see cref="Floor"/> class, using index of the current Floor.
		/// </summary>
		/// <param name="index">Index of the current Floor.</param>
		/// <returns>Reference of the previous Floor.</returns>
		public Floor TryGetPreviousFloor( int index )
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
