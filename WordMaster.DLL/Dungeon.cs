using System;
using System.Collections.Generic;

namespace WordMaster.DLL
{
    public class Dungeon
    {
		GlobalContext _context;
		readonly string _name;
		readonly string _description;
		List<Floor> _floors;
		
		/// <summary>
		/// Initializes a new instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="context">Reference of GlobalContext, the container of the Dungeons.</param>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Dungeon.</param>
		/// <param name="description">Description (MinLongStringLength to MaxLongStringLength characters) of the Dungeon.</param>
		internal Dungeon( GlobalContext context, string name, string description = "")
		{
			// Checking parameters
			if( !NoMagicHelper.CheckNameLength( name ) ) throw new ArgumentException( "Dungeon's name must be a string of " + NoMagicHelper.MinNameLength + " to " + NoMagicHelper.MaxNameLength + " characters.", "name" );
			if( !NoMagicHelper.CheckLongStringLength( description ) ) throw new ArgumentException( "Dungeon's description must be a string of " + NoMagicHelper.MinLongStringLength + " to " + NoMagicHelper.MaxLongStringLength + " characters.", "description" );

			// Creating Dungeon
			_context = context;
			_name = name;
			_description = description;
			_floors = new List<Floor>();
		}

		/// <summary>
		/// Gets the name of this instance of <see cref="Dungeon"/> class.
		/// </summary>
		public string Name
		{
			get { return _name; }
		}

		/// <summary>
		/// Gets the description of this instance of <see cref="Dungeon"/> class.
		/// </summary>
		public string Description
		{
			get { return _description; }
		}

		/// <summary>
		/// Gets the floors' list (read only) of this instance of <see cref="Dungeon"/> class.
		/// </summary>
		public IEnumerable<Floor> Floors
		{
			get { return _floors; }
		}

		/// <summary>
		/// Gets the number of floors in the instance of <see cref="Dungeon"/> class.
		/// </summary>
		public int NumberOfFloors
		{
			get { return _floors.Count; }
		}

		/// <summary>
		/// Checks if the <see cref="Dungeon"/> have <see cref="Character"/> using it.
		/// </summary>
		public bool Editable
		{
			get
			{
				foreach( Character character in _context.Characters )
					if( character.Game.Dungeon.Equals( this ) )
						return false;
				return true;
			}
		}

		/// <summary>
		/// Adds a new instance of <see cref="Floor"/> class to the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="level">Position of the Floor to add.</param>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Floor.</param>
		/// <param name="description">Description (MinLongStringLength to MaxLongStringLength characters) of the Floor.</param>
		/// <param name="numberOfLines">Length (MinFloorSize to MaxFloorSize size) of the Floor.</param>
		/// <param name="numberOfColumns">Width (MinFloorSize to MaxFloorSize size) of the Floor.</param>
		/// <returns>Reference of the new Floor.</returns>
		public Floor AddFloor( int level, string name, string description, int numberOfLines, int numberOfColumns )
		{
			Floor floor;

			// Checking context
			if( ExistFloor( name ) ) throw new ArgumentException( "A floor with this name already exist.", "name" );
			if( level < 0 || level > _floors.Count ) throw new ArgumentException( "Floors must be connected each others.", "index" );

			// Adding Floor in Dungeon
			floor = new Floor( this, level, name, description, numberOfLines, numberOfColumns ) );
			_floors.Add(floor);
			return floor;
		}

		/// <summary>
		/// Adds a new instance of <see cref="Floor"/> class to the current instance of <see cref="Dungeon"/> class.
		/// The Floor will not have a description.
		/// </summary>
		/// <param name="index">Position of the Floor to add.</param>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Floor.</param>
		/// <param name="length">Length (MinFloorSize to MaxFloorSize size) of the Floor.</param>
		/// <param name="width">Width (MinFloorSize to MaxFloorSize size) of the Floor.</param>
		/// <returns>Reference of the new Floor.</returns>
		public Floor AddFloor( int index, string name, string description, int size )
		{
			return AddFloor( index, name, description, size, size );
		}

		/// <summary>
		/// Adds a new instance of <see cref="Floor"/> class to the current instance of <see cref="Dungeon"/> class.
		/// The Floor created will be cubic.
		/// </summary>
		/// <param name="index">Position of the Floor to add.</param>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Floor.</param>
		/// <param name="description">Description (MinLongStringLength to MaxLongStringLength characters) of the Floor.</param>
		/// <param name="size">Size (MinFloorSize to MaxFloorSize size) of the Floor.</param>
		/// <returns>Reference of the new Floor.</returns>
		public Floor AddFloor( int index, string name , int length, int width  )
		{
			return AddFloor( index, name, "", length, width );
		}

		/// <summary>
		/// Adds a new instance of <see cref="Floor"/> class to the current instance of <see cref="Dungeon"/> class.
		/// The Floor will not have a description.
		/// The Floor created will be cubic.
		/// </summary>
		/// <param name="index">Position of the Floor to add.</param>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Floor.</param>
		/// <param name="size">Size (MinFloorSize to MaxFloorSize size) of the Floor.</param>
		/// <returns>Reference of the new Floor.</returns>
		public Floor AddFloor( int index, string name, int size )
		{
			return AddFloor( index, name, "", size, size );
		}

		/// <summary>
		/// Adds a new instance of <see cref="Floor"/> class after the last Floor to the current instance of <see cref="Dungeon"/> class.
		/// The Floor created will be put after the current last Floor.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Floor.</param>
		/// <param name="description">Description (MinLongStringLength to MaxLongStringLength characters) of the Floor.</param>
		/// <param name="length">Length (MinFloorSize to MaxFloorSize size) of the Floor.</param>
		/// <param name="width">Width (MinFloorSize to MaxFloorSize size) of the Floor.</param>
		/// <returns>Reference of the new Floor.</returns>
		public Floor AddFloor( string name, string description, int length, int width )
		{
			return AddFloor( _floors.Count, name, description, length, width );
		}

		/// <summary>
		/// Adds a new instance of <see cref="Floor"/> class after the last Floor to the current instance of <see cref="Dungeon"/> class.
		/// The Floor created will be put after the current last Floor.
		/// The Floor created will be cubic.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Floor.</param>
		/// <param name="description">Description (MinLongStringLength to MaxLongStringLength characters) of the Floor.</param>
		/// <param name="size">Size (MinFloorSize to MaxFloorSize size) of the Floor.</param>
		/// <returns>Reference of the new Floor.</returns>
		public Floor AddFloor( string name, string description, int size )
		{
			return AddFloor( _floors.Count, name, description, size );
		}

		/// <summary>
		/// Adds a new instance of <see cref="Floor"/> class after the last Floor to the current instance of <see cref="Dungeon"/> class.
		/// The Floor created will be put after the current last Floor.
		/// The Floor will not have a description.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Floor.</param>
		/// <param name="length">Length (MinFloorSize to MaxFloorSize size) of the Floor.</param>
		/// <param name="width">Width (MinFloorSize to MaxFloorSize size) of the Floor.</param>
		/// <returns>Reference of the new Floor.</returns>
		public Floor AddFloor( string name, int length, int width )
		{
			return AddFloor( _floors.Count, name, "", length, width );
		}

		/// <summary>
		/// Adds a new instance of <see cref="Floor"/> class after the last Floor to the current instance of <see cref="Dungeon"/> class.
		/// The Floor created will be put after the current last Floor.
		/// The Floor will not have a description.
		/// The Floor created will be cubic.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Floor.</param>
		/// <param name="size">Size (MinFloorSize to MaxFloorSize size) of the Floor.</param>
		/// <returns>Reference of the new Floor.</returns>
		public Floor AddFloor( string name, int size )
		{
			return AddFloor( _floors.Count, name, "", size, size );
		}

		/// <summary>
		/// Removes an instance of <see cref="Floor"/> class of the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="floor">Reference of the Floor to remove.</param>
		/// <returns>True if the Floor has been found and remove. False if not.</returns>
		public bool RemoveFloor( Floor floor )
		{
			int index;

			if( TryGetIndex( floor, out index ) )
			{
				if( index == _floors.Count ) // No index modifications needed
				{
					_floors.Remove( index );
					return true;
				}
				else // Index modification needed (removing Floor between others Floors)
				{
					SortedList<int, Floor> floors = new SortedList<int, Floor>();
					for( int i = 0; i <= index; i++ )
					{
						Floor f;
						if( _floors.TryGetValue( i, out f ) ) floors.Add( i, f );
						else break;
					}
					floors.Remove( index );
					for( int i = index; i < _floors.Count; i++ )
					{
						Floor f;
						if( _floors.TryGetValue( i + 1, out f ) ) floors.Add( i, f );
						else break;
					}
					_floors = floors;
					return true;
				}
			}
			else return false;
		}

		/// <summary>
		/// Removes an instance of <see cref="Floor"/> class of the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="name">Name of the floor to remove.</param>
		/// <returns>True if the Floor has been found and remove.</returns>
		public bool RemoveFloor( string name )
		{
			Floor floor;

			if( TryGetFloor( name, out floor ) ) return RemoveFloor( floor );
			else return false;
		}

		/// <summary>
		/// Removes an instance of <see cref="Floor"/> class of the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="index">Index of the floor to remove.</param>
		/// <returns>True if the Floor has been found and remove.</returns>
		public bool RemoveFloor( int index )
		{
			Floor floor;

			if( TryGetFloor( index, out floor ) ) return RemoveFloor( floor );
			else return false;
		}

		/// <summary>
		/// Gets the index of <see cref="Floor"/> class of the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="name">Floor's name.</param>
		/// <param name="index">Floor's index.</param>
		/// <returns>True if the Floor have been found, false if not.</returns>
		public bool TryGetIndex(string name, out int index)
		{
			foreach( KeyValuePair<int, Floor> pair in _floors )
			{
				if( pair.Value.Name == name )
				{
					index = pair.Key;
					return true;
				}
			}

			index = -1;
			return false;
		}

		/// <summary>
		/// Gets the index of <see cref="Floor"/> class of the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="reference">Floor's reference.</param>
		/// <param name="index">Floor's index.</param>
		/// <returns>True if the Floor have been found, false if not.</returns>
		public bool TryGetIndex( Floor reference, out int index )
		{
			return TryGetIndex( reference.Name, out index );
		}

		/// <summary>
		/// Gets the reference of the instance of <see cref="Floor"/> class in the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="name">Floor's Name.</param>
		/// <param name="floor">Floor's reference.</param>
		/// <returns>True if the Floor have been found, false if not.</returns>
		public bool TryGetFloor( string name, out Floor floor )
		{
			foreach( KeyValuePair<int, Floor> pair in _floors )
			{
				if( pair.Value.Name == name )
				{
					floor = pair.Value;
					return true;
				}
			}

			floor = null;
			return false;
		}

		/// <summary>
		/// Gets the reference of the instance of <see cref="Floor"/> class in the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="index">Floor's index.</param>
		/// <param name="floor">Floor's reference.</param>
		/// <returns>True if the Floor have been found, false if not.</returns>
		public bool TryGetFloor( int index, out Floor floor )
		{
			return _floors.TryGetValue( index, out floor );
		}

		/// <summary>
		/// Checks if a Floor's instance exist with the specified name in the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="name">Floor's name.</param>
		/// <returns>True if the Floor have been found, false if not.</returns>
		public bool ExistFloor( string name )
		{
			foreach( KeyValuePair<int, Floor> pair in _floors )
			{
				if( pair.Value.Name == name )
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Checks if a Floor's instance exist at the specified index in the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="index">Floor's index.</param>
		/// <returns>True if a Floor have been found, false if not.</returns>
		public bool ExistFloor( int index )
		{
			return _floors.ContainsKey( index );
		}
	}
}
