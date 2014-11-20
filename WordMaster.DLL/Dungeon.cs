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
		Square _entrance;
		Square _exit;
		
		/// <summary>
		/// Initializes a new instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="context">GlobalContext's reference, all Dungeons must be in a <see cref="GlobalContext"/>.</param>
		/// <param name="name">Dungeon's name, <see cref="NoMagicHelper.MinNameLength"/> to <see cref="NoMagicHelper.MaxNameLength"/> characters.</param>
		/// <param name="description">Dungeon's description, <see cref="NoMagicHelper.MinDescriptionLength"/> to <see cref="NoMagicHelper.MaxDescriptionLength"/> characters.</param>
		internal Dungeon( GlobalContext context, string name, string description)
		{
			// Checking parameters
			if( !NoMagicHelper.CheckNameLength( name ) ) throw new ArgumentException( "Dungeon's name must be a string of " + NoMagicHelper.MinNameLength + " to " + NoMagicHelper.MaxNameLength + " characters.", "name" );
			if( !NoMagicHelper.CheckLongStringLength( description ) ) throw new ArgumentException( "Dungeon's description must be a string of " + NoMagicHelper.MinDescriptionLength + " to " + NoMagicHelper.MaxDescriptionLength + " characters.", "description" );

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
		/// Gets the number of floors of this instance of <see cref="Dungeon"/> class.
		/// </summary>
		public int NumberOfFloors
		{
			get { return _floors.Count; }
		}

		/// <summary>
		/// Gets the entrance's <see cref="Square"/> of this instance of <see cref="Dungeon"/> class.
		/// </summary>
		public Square Entrance
		{
			get { return _entrance; }
			set { _entrance = value; }
		}

		/// <summary>
		/// Gets the exit's <see cref="Square"/> of this instance of <see cref="Dungeon"/> class.
		/// </summary>
		public Square Exit
		{
			get { return _exit; }
			set { _exit = value; }
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
		/// Adds a new instance of <see cref="Floor"/> class to this instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="level">Floor's position.</param>
		/// <param name="name">Floor's name,  <see cref="NoMagicHelper.MinNameLength"/> to <see cref="NoMagicHelper.MaxNameLength"/> characters.</param>
		/// <param name="description">Floor's description, <see cref="NoMagicHelper.MinDescriptionLength"/> to <see cref="NoMagicHelper.MaxDescriptionLength"/> characters.</param>
		/// <param name="numberOfLines">Floor's number of line in the layout, <see cref="NoMagicHelper.MinFloorSize"/> to <see cref="NoMagicHelper.MaxFloorSize"/> size.</param>
		/// <param name="numberOfColumns">Floor's number of column in the layout, <see cref="NoMagicHelper.MinFloorSize"/> to <see cref="NoMagicHelper.MaxFloorSize"/> size.</param>
		/// <returns>New Floor's reference.</returns>
		public Floor AddFloor( int level, string name, string description, int numberOfLines, int numberOfColumns )
		{
			// Checking context
			if( ExistFloor( name ) ) throw new ArgumentException( "A floor with this name already exist in this dungeon.", "name" );
			if( level < 0 || level > this._floors.Count ) throw new ArgumentException( "Can not used disconnected Floor's level.", "level" );

			// Updating Floors' level in case of insertion
			foreach( Floor aFloor in this._floors )
				if(aFloor.Level >= level) aFloor.Level += 1;

			Floor floor = new Floor( this, level, name, description, numberOfLines, numberOfColumns );
			_floors.Add(floor);
			return floor;
		}

		/// <summary>
		/// Adds a new instance of <see cref="Floor"/> class to this instance of <see cref="Dungeon"/> class.
		/// The Floor will have an empty description.
		/// </summary>
		/// <param name="level">Floor's position.</param>
		/// <param name="name">Floor's name,  <see cref="NoMagicHelper.MinNameLength"/> to <see cref="NoMagicHelper.MaxNameLength"/> characters.</param>
		/// <param name="numberOfLines">Floor's number of line in the layout, <see cref="NoMagicHelper.MinFloorSize"/> to <see cref="NoMagicHelper.MaxFloorSize"/> size.</param>
		/// <param name="numberOfColumns">Floor's number of column in the layout, <see cref="NoMagicHelper.MinFloorSize"/>
		/// <returns>New Floor's reference.</returns>
		public Floor AddFloor( int level, string name, int numberOfLines, int numberOfColumns )
		{
			return AddFloor( level, name, "", numberOfLines, numberOfColumns );
		}

		/// <summary>
		/// Adds a new instance of <see cref="Floor"/> class to this instance of <see cref="Dungeon"/> class.
		/// The Floor created will be put after the current last Floor.
		/// </summary>
		/// <param name="name">Floor's name,  <see cref="NoMagicHelper.MinNameLength"/> to <see cref="NoMagicHelper.MaxNameLength"/> characters.</param>
		/// <param name="description">Floor's description, <see cref="NoMagicHelper.MinDescritptionLength"/> to <see cref="NoMagicHelper.MaxDescritptionLength"/> characters.</param>
		/// <param name="numberOfLines">Floor's number of line in the layout, <see cref="NoMagicHelper.MinFloorSize"/> to <see cref="NoMagicHelper.MaxFloorSize"/> size.</param>
		/// <param name="numberOfColumns">Floor's number of column in the layout, <see cref="NoMagicHelper.MinFloorSize"/>
		/// <returns>New Floor's reference.</returns>
		public Floor AddFloor( string name, string description, int numberOfLines, int numberOfColumns )
		{
			return AddFloor( _floors.Count, name, description, numberOfLines, numberOfColumns );
		}

		/// <summary>
		/// Adds a new instance of <see cref="Floor"/> class to this instance of <see cref="Dungeon"/> class.
		/// The Floor created will be put after the current last Floor.
		/// The Floor will have an empty description.
		/// </summary>
		/// <param name="name">Floor's name, <see cref="NoMagicHelper.MinNameLength"/> to <see cref="NoMagicHelper.MaxNameLength"/> characters.</param>
		/// <param name="numberOfLines">Floor's number of line in the layout, <see cref="NoMagicHelper.MinFloorSize"/> to <see cref="NoMagicHelper.MaxFloorSize"/> size.</param>
		/// <param name="numberOfColumns">Floor's number of column in the layout, <see cref="NoMagicHelper.MinFloorSize"/>
		/// <returns>New Floor's reference.</returns>
		public Floor AddFloor( string name, int length, int width )
		{
			return AddFloor( _floors.Count, name, "", length, width );
		}

		/// <summary>
		/// Removes an instance of <see cref="Floor"/> class of the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="floor">Reference of the Floor to remove.</param>
		/// <returns>If the Floor has been found and removed.</returns>
		public void RemoveFloor( Floor floor )
		{
			foreach( Floor aFloor in this._floors )
				if(aFloor.Level > floor.Level) aFloor.Level -= 1;

			_floors.Remove( floor );
		}

		/// <summary>
		/// Gets the reference of the instance of <see cref="Floor"/> class in the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="name">Floor's Name.</param>
		/// <param name="floor">Floor's reference to recover.</param>
		/// <returns>If the Floor have been found.</returns>
		public bool TryGetFloor( string name, out Floor floor )
		{
			foreach( Floor aFloor in _floors )
			{
				if( aFloor.Name == name )
				{
					floor = aFloor;
					return true;
				}
			}

			floor = null;
			return false;
		}

		/// <summary>
		/// Gets the reference of the instance of <see cref="Floor"/> class in the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="level">Floor's level.</param>
		/// <param name="floor">Floor's reference to recover.</param>
		/// <returns>If the Floor have been found.</returns>
		public bool TryGetFloor( int level, out Floor floor )
		{
			foreach( Floor aFloor in _floors )
			{
				if( aFloor.Level == level )
				{
					floor = aFloor;
					return true;
				}
			}

			floor = null;
			return false;
		}

		/// <summary>
		/// Checks if a Floor's instance exist with the specified name in the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="name">Floor's name.</param>
		/// <returns>If the Floor have been found.</returns>
		public bool ExistFloor( string name )
		{
			foreach( Floor floor in _floors )
				if( floor.Name == name )
					return true;
			return false;
		}

		/// <summary>
		/// Checks if a Floor's instance exist at the specified index in the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="index">Floor's index.</param>
		/// <returns>If a Floor have been found.</returns>
		public bool ExistFloor( int level )
		{
			foreach( Floor floor in _floors )
				if( floor.Level == level )
					return true;
			return false;
		}
	}
}
