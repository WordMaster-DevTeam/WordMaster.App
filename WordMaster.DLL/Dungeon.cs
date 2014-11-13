using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMaster.DLL
{
    public class Dungeon
    {
		string _name;
		string _description;
		SortedDictionary<int, Floor> _floors;
		
		/// <summary>
		/// Initializes a new instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Dungeon.</param>
		/// <param name="description">Description (MinLongStringLength to MaxLongStringLength characters) of the Dungeon.</param>
		public Dungeon( string name, string description)
		{
			// Checking parameters
			if( !NoMagicHelper.CheckNameLength( name ) ) throw new ArgumentException( "Dungeon's name must be a string of " + NoMagicHelper.MinNameLength + " to " + NoMagicHelper.MaxNameLength + " characters.", "name" );
			if( !NoMagicHelper.CheckLongStringLength( description ) ) throw new ArgumentException( "Dungeon's description must be a string of " + NoMagicHelper.MinLongStringLength + " to " + NoMagicHelper.MaxLongStringLength + " characters.", "description" );

			// Creating Dungeon
			_name = name;
			_description = description;
			_floors = new SortedDictionary<int, Floor>();
		}

		/// <summary>
		/// Initializes a new instance of <see cref="Dungeon"/> class.
		/// Dungeon's description will be empty.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Dungeon.</param>
		public Dungeon( string name ) : this( name, "" ) { }

		/// <summary>
		/// Gets or sets the name of the instance of <see cref="Dungeon"/> class.
		/// </summary>
		public string Name
		{
			get { return _name; }
			set
			{
				if( NoMagicHelper.CheckNameLength( value ) ) _name = value;
				else throw new ArgumentException( "Floor's name must be a string of " + NoMagicHelper.MinNameLength + " to " + NoMagicHelper.MaxNameLength + " characters.", "value" );
			}
		}

		/// <summary>
		/// Gets or sets the description of the instance of <see cref="Dungeon"/> class.
		/// </summary>
		public string Description
		{
			get { return _description; }
			set
			{
				if( NoMagicHelper.CheckLongStringLength( value ) ) _name = value;
				else throw new ArgumentException( "Floor's description must be a string of " + NoMagicHelper.MinLongStringLength + " to " + NoMagicHelper.MaxLongStringLength + " characters.", "value" );
			}
		}

		/// <summary>
		/// Gets the number of floors in the instance of <see cref="Dungeon"/> class.
		/// </summary>
		public int NumberOfFloors
		{
			get { return _floors.Count; }
		}

		/// <summary>
		/// Adds a new instance of <see cref="Floor"/> class to the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="index">Position of the Floor to add.</param>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Floor.</param>
		/// <param name="length">Length (MinFloorSize to MaxFloorSize size) of the Floor.</param>
		/// <param name="width">Width (MinFloorSize to MaxFloorSize size) of the Floor.</param>
		/// <returns>Reference of the new Floor.</returns>
		public Floor AddFloor( int index, string name, int length, int width )
		{
			Floor floor;

			// Checking parameters
			if( !NoMagicHelper.CheckNameLength( name ) ) throw new ArgumentException( "Floor's name must be a string of " + NoMagicHelper.MinNameLength + " to " + NoMagicHelper.MaxNameLength + " characters.", "name" );
			if( !NoMagicHelper.CheckFloorSize( length ) ) throw new ArgumentException( "Floor's length must be included in " + NoMagicHelper.MinFloorSize + " to " + NoMagicHelper.MaxFloorSize + ".", "length" );
			if( !NoMagicHelper.CheckFloorSize( width ) ) throw new ArgumentException( "Floor's width must be included in " + NoMagicHelper.MinFloorSize + " to " + NoMagicHelper.MaxFloorSize + ".", "width" );

			// Checking context
			if( ExistFloor( name ) ) throw new ArgumentException( "A floor with this name already exist.", "name" );
			if( index < 0 || index > _floors.Count ) throw new ArgumentException( "Floors must be connected each others.", "index" );

			// Adding Floor in Dungeon
			if( !ExistFloor( index ) ) // No index modifications needed
			{
				_floors.Add( index, new Floor( name, length, width ) );
			}
			else // Index modification needed (inserting Floor between others Floors)
			{
				SortedDictionary<int, Floor> floors = new SortedDictionary<int, Floor>();
				int i; Floor f;
				
				for( i = 0; i < index; i++ )
				{
					if( _floors.TryGetValue( i, out f ) ) floors.Add( i, f );
					else throw new IndexOutOfRangeException( "No Floor found will recreating the Dungeon (before the Floor inserted)." );
				}
				floors.Add( index, new Floor( name, length, width ) );
				for( i = index; i < _floors.Count; i++ )
				{
					if( _floors.TryGetValue( i, out f ) ) floors.Add( i + 1, f );
					else throw new IndexOutOfRangeException( "No Floor found will recreating the Dungeon (after the Floor inserted)." );
				}
				_floors = floors;
			}

			if( TryGetFloor( index, out floor ) ) return floor;
			else return null;
		}

		/// <summary>
		/// Adds a new instance of <see cref="Floor"/> class after the last Floor to the current instance of <see cref="Dungeon"/> class.
		/// The Floor created will be put after the current last Floor.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Floor.</param>
		/// <param name="length">Length (MinFloorSize to MaxFloorSize size) of the Floor.</param>
		/// <param name="width">Width (MinFloorSize to MaxFloorSize size) of the Floor.</param>
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
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Floor.</param>
		/// <param name="size">Size (MinFloorSize to MaxFloorSize size) of the Floor.</param>
		/// <returns>Reference of the new Floor.</returns>
		public Floor AddFloor( int index, string name, int size )
		{
			return AddFloor( index, name, size, size );
		}

		/// <summary>
		/// Adds a new instance of <see cref="Floor"/> class after the last Floor to the current instance of <see cref="Dungeon"/> class.
		/// The Floor created will be put after the current last Floor.
		/// The Floor created will be cubic.
		/// </summary>
		/// <param name="name">Name (MinNameLength to MaxNameLength characters) of the Floor.</param>
		/// <param name="size">Size (MinFloorSize to MaxFloorSize size) of the Floor.</param>
		/// <returns>Reference of the new Floor.</returns>
		public Floor AddFloor( string name, int size )
		{
			return AddFloor( _floors.Count, name, size, size );
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
					SortedDictionary<int, Floor> floors = new SortedDictionary<int, Floor>();
					int i; Floor f;

					for( i = 1; i < index; i++ )
					{
						if( _floors.TryGetValue( i, out f ) ) floors.Add( i, f );
						else throw new IndexOutOfRangeException( "No Floor found will recreating the Dungeon (before the Floor removed)." );
					}
					floors.Remove( index );
					for( i = index + 1; i < _floors.Count; i++ )
					{
						if( _floors.TryGetValue( i, out f ) ) floors.Add( i, f );
						else throw new IndexOutOfRangeException( "No Floor found will recreating the Dungeon (after the Floor removed)." );
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
			foreach(KeyValuePair<int, Floor> pair in _floors) if( pair.Value.Name == name ) return true;
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
