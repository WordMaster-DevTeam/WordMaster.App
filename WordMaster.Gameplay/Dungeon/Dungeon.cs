using System;
using System.Collections.Generic;

namespace WordMaster.Gameplay
{
    [Serializable]
    public class Dungeon
    {
        
		readonly GlobalContext _globalContext;
		readonly Dictionary<string, Floor> _floors;
		string _name, _description;
		Square _entrance, _exit;

		/// <summary>
		/// Recovers an instance of <see cref="Dungeon"/> class using the [index] syntax.
		/// </summary>
		/// <param name="index">Floor's index.</param>
		/// <returns>Floor's reference.</returns>
		public Floor this[int index]
		{
			get
			{
				if( index < 0 || index >= _floors.Count ) // Checks index
					return null;
				else return GetFloor(index);
			}
		}

		/// <summary>
		/// Initializes a new instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="globalContext">GlobalContext's reference, all Dungeons must be in a <see cref="GlobalContext"/>.</param>
		/// <param name="name">Dungeon's name, must be unique in this GlobalContext.</param>
		/// <param name="description">Dungeon's description.</param>
		internal Dungeon( GlobalContext globalContext, string name, string description)
		{
			_globalContext = globalContext;
			_name = name;
			_description = description;
			_floors = new Dictionary<string, Floor>();
		}

		/// <summary>
		/// Gets the GlobalContext's reference.
		/// </summary>
		public GlobalContext GlobalContext
		{
			get { return _globalContext; }
		}

		/// <summary>
		/// Gets the name of this instance of <see cref="Dungeon"/> class.
		/// </summary>
		public string Name
		{
			get { return _name; }
			internal set { _name = value; }
		}

		/// <summary>
		/// Gets or sets the description of this instance of <see cref="Dungeon"/> class.
		/// </summary>
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		/// <summary>
		/// Gets the floors' list (read only) of this instance of <see cref="Dungeon"/> class.
		/// </summary>
		public IEnumerable<Floor> Floors
		{
			get { return _floors.Values; }
		}

		/// <summary>
		/// Gets the number of floors of this instance of <see cref="Dungeon"/> class.
		/// </summary>
		public int NumberOfFloors
		{
			get { return _floors.Count; }
		}

		/// <summary>
		/// Gets or sets the entrance's <see cref="Square"/> of this instance of <see cref="Dungeon"/> class.
		/// </summary>
		public Square Entrance
		{
			get { return _entrance; }
			set
			{
				if( Editable )
				{
					value.Holdable = true;
					_entrance = value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the exit's <see cref="Square"/> of this instance of <see cref="Dungeon"/> class.
		/// </summary>
		public Square Exit
		{
			get { return _exit; }
			set
			{
				if( Editable )
				{
					value.Holdable = true;
					_exit = value;
				}
			}
		}

		/// <summary>
		/// Checks if this instance of <see cref="Dungeon"/> class have any instance of <see cref="Character"/> class using it.
		/// </summary>
		public bool Editable
		{
			get
			{
				foreach( Character character in _globalContext.Characters ) // Any Character in it ?
					if( character.GameContext != null ) // The Character is in a Dungeon
						if( character.GameContext.Game.Dungeon.Equals( this ) )
							return false;
				return true;
			}
		}

		/// <summary>
		/// Checks if this instance of <see cref="Dungeon"/> class is finishable.
		/// NOTE: to be finishable, the Dungeon must have an entrance, an exit and all <see cref="Square"/>s must be initialized.
		/// </summary>
		public bool Finishable
		{
			get
			{
				if( Entrance == null && Exit == null) // Entrance & Exit set ?
					return false;
				else
					foreach( Floor floor in Floors ) // All Squares set ?
						if( floor.CheckAllSquares() ) 
							return false;
				return true;
			}
		}

		/// <summary>
		/// Resets the a new name for the specified instance of <see cref="Floor"/> class.
		/// WARNING: Dungeon must be editable and Floor's name must be unique.
		/// </summary>
		/// <param name="floor">Floor's reference.</param>
		/// <param name="newName">Floor's new name.</param>
		public void RenameFloor( Floor floor, string newName )
		{
			if( !Editable ) throw new InvalidOperationException( "Can not add a Floor in not editable Dungeon" );
			if( ExistFloor(newName) ) throw new ArgumentException( "A Floor with this name already exist.", "newName" );

			floor.Name = newName;
		}

		/// <summary>
		/// Resets the a new name for a specified by name instance of <see cref="Floor"/> class.
		/// WARNING: Dungeon must be editable and Floor's name must be unique.
		/// </summary>
		/// <param name="oldName">Floor's old name.</param>
		/// <param name="newName">Floor's new name.</param>
		public void RenameFloor( string oldName, string newName )
		{
			Floor floor;

			if( TryGetFloor( oldName, out floor ) )
				RenameFloor( floor, newName );
			else
				throw new ArgumentException( "No Floor with this name already exist.", "oldName" );
		}

		/// <summary>
		/// Resets the a new name for the specified instance of <see cref="Floor"/> class.
		/// </summary>
		/// <param name="floor">Floor's reference.</param>
		/// <param name="newName">Floor's new name.</param>
		/// <returns>If the Floor have been renamed.</returns>
		public bool TryRenameFloor( Floor floor, string newName )
		{
			try
			{
				RenameFloor( floor, newName );
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Resets the a new name for a specified by name instance of <see cref="Floor"/> class.
		/// </summary>
		/// <param name="oldName">Floor's old name.</param>
		/// <param name="newName">Floor's new name.</param>
		/// <returns>If the Floor have been renamed.</returns>
		public bool TryRenameFloor( string oldName, string newName )
		{
			Floor floor;

			if( _floors.TryGetValue( oldName, out floor ) )
				return TryRenameFloor( floor, newName );
			else
				return false;
		}

		/// <summary>
		/// Adds a new instance of <see cref="Floor"/> class to this instance of <see cref="Dungeon"/> class.
		/// WARNING: Dungeon must be editable, each Floor must be adjoining, Floor's name must be unique, level must be positive and the number of Square superior or equal to two.
		/// </summary>
		/// <param name="level">Floor's position, must be superior or equal to zero.</param>
		/// <param name="name">Floor's name, must be unique in this Dungeon.</param>
		/// <param name="description">Floor's description.</param>
		/// <param name="numberOfLines">Floor's number of line in the layout.</param>
		/// <param name="numberOfColumns">Floor's number of column in the layout.</param>
		/// <returns>New Floor's reference.</returns>
		public Floor AddFloor( int level, string name, string description, int numberOfLines, int numberOfColumns )
		{
			if( !Editable ) throw new InvalidOperationException( "Can not add a Floor in not editable Dungeon" );
			if( level > NumberOfFloors ) throw new InvalidOperationException( "Can not add a Floor with level because it would not be adjoining." );
			if( ExistFloor( name ) ) throw new ArgumentException( "A floor with this name already exist.", "name" );
			if( level < 0 ) throw new ArgumentException( "Floor level must be positive.", "level" );

			Floor floor = new Floor( this, level, name, description, numberOfLines, numberOfColumns );

			 // Updating Floors' level
			foreach( Floor aFloor in Floors )
				if( aFloor.Level >= level )
					aFloor.Level += 1;
			
			_floors.Add( name, floor );
			return floor;	
		}

		/// <summary>
		/// Adds a new instance of <see cref="Floor"/> class to this instance of <see cref="Dungeon"/> class.
		/// NOTE: new Floor will be put at the end of the Dungeon.
		/// WARNING: Dungeon must be editable, each Floor must be adjoining, Floor's name must be unique, level must be positive and the number of Square superior or equal to two.
		/// </summary>
		/// <param name="name">Floor's name, must be unique in this Dungeon.</param>
		/// <param name="description">Floor's description.</param>
		/// <param name="numberOfLines">Floor's number of line in the layout.</param>
		/// <param name="numberOfColumns">Floor's number of column in the layout.</param>
		/// <returns>New Floor's reference.</returns>
		public Floor AddFloor( string name, string description, int numberOfLines, int numberOfColumns )
		{
			return AddFloor( _floors.Count, name, description, numberOfLines, numberOfColumns );
		}

		/// <summary>
		/// Adds a new instance of <see cref="Floor"/> class to this instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="level">Floor's position, must be superior or equal to zero.</param>
		/// <param name="name">Floor's name, must be unique in this Dungeon.</param>
		/// <param name="description">Floor's description.</param>
		/// <param name="numberOfLines">Floor's number of line in the layout.</param>
		/// <param name="numberOfColumns">Floor's number of column in the layout.</param>
		/// <param name="floor">Floor's reference to recover.</param>
		/// <returns>If the Floor have been created and added.</returns>
		public bool TryAddFloor( int level, string name, string description, int numberOfLines, int numberOfColumns, out Floor floor )
		{
			try
			{
				floor = AddFloor( level, name, description, numberOfLines, numberOfColumns );
				return true;
			}
			catch
			{
				floor = null;
				return false;
			}
		}

		/// <summary>
		/// Adds a new instance of <see cref="Floor"/> class to this instance of <see cref="Dungeon"/> class.
		/// NOTE: new Floor will be put at the end of the Dungeon.
		/// </summary>
		/// <param name="name">Floor's name, must be unique in this Dungeon.</param>
		/// <param name="description">Floor's description.</param>
		/// <param name="numberOfLines">Floor's number of line in the layout.</param>
		/// <param name="numberOfColumns">Floor's number of column in the layout.</param>
		/// <param name="floor">Floor's reference to recover.</param>
		/// <returns>If the Floor have been created and added.</returns>
		public bool TryAddFloor( string name, string description, int numberOfLines, int numberOfColumns, out Floor floor )
		{
			return TryAddFloor( _floors.Count, name, description, numberOfLines, numberOfColumns, out floor );
		}
		
		/// <summary>
		/// Removes an instance of <see cref="Floor"/> class of the current instance of <see cref="Dungeon"/> class.
		/// WARNING: Dungeon must be editable.
		/// </summary>
		/// <param name="floor">Reference of the Floor to remove.</param>
		public void RemoveFloor( Floor floor )
		{
			if( !Editable ) throw new InvalidOperationException("Can not remove a Floor in not editable Dungeon");

			// Updating Floors' level
			foreach( Floor aFloor in Floors )
				if( aFloor.Level > floor.Level )
					aFloor.Level -= 1;

			_floors.Remove( floor.Name );
		}

		/// <summary>
		/// Removes an instance of <see cref="Floor"/> class of the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="floor">Reference of the Floor to remove.</param>
		/// <returns>If the Floor has been found and removed.</returns>
		public bool TryRemoveFloor( Floor floor )
		{
			try
			{
				RemoveFloor( floor );
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Gets the reference of the instance of <see cref="Floor"/> class in the current instance of <see cref="Dungeon"/> class.
		/// WARNING: A Floor with this name must already exist.
		/// </summary>
		/// <param name="name">Floor's name.</param>
		/// <returns>Floor's reference.</returns>
		public Floor GetFloor( string name )
		{
			Floor floor;

			if( _floors.TryGetValue( name, out floor ) )
				return floor;

			throw new ArgumentException( "Can not recover a Floor with this name." );
		}

		/// <summary>
		/// Gets the reference of the instance of <see cref="Floor"/> class in the current instance of <see cref="Dungeon"/> class.
		/// WARNING: A Floor with at this level must already exist.
		/// </summary>
		/// <param name="name">Floor's name.</param>
		/// <returns>Floor's reference.</returns>
		public Floor GetFloor( int level )
		{
			foreach( Floor floor in Floors )
				if( floor.Level == level )
					return floor;

			throw new ArgumentException( "Can not recover a Floor with at this level." );
		}

		/// <summary>
		/// Gets the reference of the instance of <see cref="Floor"/> class in the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="name">Floor's Name.</param>
		/// <param name="floor">Floor's reference to recover.</param>
		/// <returns>If the Floor have been found.</returns>
		public bool TryGetFloor( string name, out Floor floor )
		{
			return _floors.TryGetValue( name, out floor );
		}

		/// <summary>
		/// Gets the reference of the instance of <see cref="Floor"/> class in the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="level">Floor's level.</param>
		/// <param name="floor">Floor's reference to recover.</param>
		/// <returns>If the Floor have been found.</returns>
		public bool TryGetFloor( int level, out Floor floor )
		{
			foreach( Floor aFloor in Floors )
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
			return _floors.ContainsKey( name );
		}

		/// <summary>
		/// Checks if a Floor's instance exist at the specified index in the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="index">Floor's index.</param>
		/// <returns>If a Floor have been found.</returns>
		public bool ExistFloor( int level )
		{
			foreach( Floor floor in Floors )
				if( floor.Level == level )
					return true;
			return false;
		}
	}
}
