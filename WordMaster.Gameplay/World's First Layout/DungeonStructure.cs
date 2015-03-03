using System;
using System.Collections.Generic;

namespace WordMaster.Gameplay
{
	/// <summary>
	/// Holds the defaults states and architectures of a dungeon, that contains floor whitch theirself contains square. First layer. Serializable.
	/// </summary>
	[Serializable]
    public class DungeonStructure
    {
		public readonly GlobalContext GlobalContext;
		readonly Dictionary<string, FloorStructure> _floorStructures;
		SquareStructure _entrance, _exit;
		string _name, _description;

		/// <summary>
		/// Recovers an instance of <see cref="DungeonStructure"/> class using the [index] syntax.
		/// </summary>
		/// <param name="index">Floor's index.</param>
		/// <returns>Floor's reference.</returns>
		public FloorStructure this[int index]
		{
			get
			{
				if( index < 0 || index >= _floorStructures.Count ) // Checks index
					return null;
				else return GetFloor(index);
			}
		}

		/// <summary>
		/// Initializes a new instance of <see cref="DungeonStructure"/> class.
		/// </summary>
		/// <param name="globalContext">GlobalContext's reference, all Dungeons must be in a <see cref="GlobalContext"/>.</param>
		/// <param name="name">Dungeon's name, must be unique in this GlobalContext.</param>
		/// <param name="description">Dungeon's description.</param>
		internal DungeonStructure( GlobalContext globalContext, string name, string description)
		{
			GlobalContext = globalContext;
			_name = name;
			_description = description;
			_floorStructures = new Dictionary<string, FloorStructure>();
		}

		/// <summary>
		/// Gets or sets the name of this instance of <see cref="DungeonStructure"/> class.
		/// </summary>
		public string Name
		{
			get { return _name; }
			internal set { _name = value; }
		}

		/// <summary>
		/// Gets or sets the description of this instance of <see cref="DungeonStructure"/> class.
		/// </summary>
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		/// <summary>
		/// Gets the floors' list (read only) of this instance of <see cref="DungeonStructure"/> class.
		/// </summary>
		public IEnumerable<FloorStructure> AllFloorStructures
		{
			get { return _floorStructures.Values; }
		}

		/// <summary>
		/// Gets the number of floors of this instance of <see cref="DungeonStructure"/> class.
		/// </summary>
		public int NumberOfFloors
		{
			get { return _floorStructures.Count; }
		}

		/// <summary>
		/// Gets or sets the entrance's <see cref="SquareStructure"/> of this instance of <see cref="DungeonStructure"/> class.
		/// </summary>
		public SquareStructure Entrance
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
		/// Gets or sets the exit's <see cref="SquareStructure"/> of this instance of <see cref="DungeonStructure"/> class.
		/// </summary>
		public SquareStructure Exit
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
		/// Checks if this instance of <see cref="DungeonStructure"/> class have any instance of <see cref="Character"/> class using it.
		/// </summary>
		public bool Editable
		{
			get
			{
				foreach( Character character in GlobalContext.Characters ) // Any Character in it ?
					if( character.GameContext != null ) // The Character is in a Dungeon
						if( character.GameContext.Dungeon.Equals( this ) )
							return false;
				return true;
			}
		}

		/// <summary>
		/// Checks if this instance of <see cref="DungeonStructure"/> class is finishable.
		/// NOTE: to be finishable, the Dungeon must have an entrance, an exit and all <see cref="SquareStructure"/>s must be initialized.
		/// </summary>
		public bool Finishable
		{
			get
			{
				if( Entrance == null && Exit == null) // Entrance & Exit set ?
					return false;
				else
					foreach( FloorStructure floor in AllFloorStructures ) // All Squares set ?
						if( floor.CheckAllSquares() ) 
							return false;
				return true;
			}
		}

		#region Renames Floor methods
		/// <summary>
		/// Resets the a new name for the specified instance of <see cref="FloorStructure"/> class.
		/// WARNING: Dungeon must be editable and Floor's name must be unique.
		/// </summary>
		/// <param name="floor">Floor's reference.</param>
		/// <param name="newName">Floor's new name.</param>
		public void RenameFloor( FloorStructure floor, string newName )
		{
			if( !Editable ) throw new InvalidOperationException( "Can not add a Floor in not editable Dungeon" );
			if( ExistFloor(newName) ) throw new ArgumentException( "A Floor with this name already exist.", "newName" );

			floor.Name = newName;
		}

		/// <summary>
		/// Resets the a new name for a specified by name instance of <see cref="FloorStructure"/> class.
		/// WARNING: Dungeon must be editable and Floor's name must be unique.
		/// </summary>
		/// <param name="oldName">Floor's old name.</param>
		/// <param name="newName">Floor's new name.</param>
		public void RenameFloor( string oldName, string newName )
		{
			FloorStructure floor;

			if( TryGetFloor( oldName, out floor ) )
				RenameFloor( floor, newName );
			else
				throw new ArgumentException( "No Floor with this name already exist.", "oldName" );
		}

		/// <summary>
		/// Resets the a new name for the specified instance of <see cref="FloorStructure"/> class.
		/// </summary>
		/// <param name="floor">Floor's reference.</param>
		/// <param name="newName">Floor's new name.</param>
		/// <returns>If the Floor have been renamed.</returns>
		public bool TryRenameFloor( FloorStructure floor, string newName )
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
		/// Resets the a new name for a specified by name instance of <see cref="FloorStructure"/> class.
		/// </summary>
		/// <param name="oldName">Floor's old name.</param>
		/// <param name="newName">Floor's new name.</param>
		/// <returns>If the Floor have been renamed.</returns>
		public bool TryRenameFloor( string oldName, string newName )
		{
			FloorStructure floor;

			if( _floorStructures.TryGetValue( oldName, out floor ) )
				return TryRenameFloor( floor, newName );
			else
				return false;
		}
		#endregion

		#region Adds Floor methods
		/// <summary>
		/// Adds a new instance of <see cref="FloorStructure"/> class to this instance of <see cref="DungeonStructure"/> class.
		/// WARNING: Dungeon must be editable, each Floor must be adjoining, Floor's name must be unique, level must be positive and the number of Square superior or equal to two.
		/// </summary>
		/// <param name="level">Floor's position, must be superior or equal to zero.</param>
		/// <param name="name">Floor's name, must be unique in this Dungeon.</param>
		/// <param name="description">Floor's description.</param>
		/// <param name="numberOfLines">Floor's number of line in the layout.</param>
		/// <param name="numberOfColumns">Floor's number of column in the layout.</param>
		/// <returns>New Floor's reference.</returns>
		public FloorStructure AddFloor( int level, string name, string description, int numberOfLines, int numberOfColumns )
		{
			if( !Editable ) throw new InvalidOperationException( "Can not add a Floor in not editable Dungeon" );
			if( level > NumberOfFloors ) throw new InvalidOperationException( "Can not add a Floor with level because it would not be adjoining." );
			if( ExistFloor( name ) ) throw new ArgumentException( "A floor with this name already exist.", "name" );
			if( level < 0 ) throw new ArgumentException( "Floor level must be positive.", "level" );

			FloorStructure floor = new FloorStructure( this, level, name, description, numberOfLines, numberOfColumns );

			 // Updating Floors' level
			foreach( FloorStructure aFloor in AllFloorStructures )
				if( aFloor.Level >= level )
					aFloor.Level += 1;
			
			_floorStructures.Add( name, floor );
			return floor;	
		}

		/// <summary>
		/// Adds a new instance of <see cref="FloorStructure"/> class to this instance of <see cref="DungeonStructure"/> class.
		/// NOTE: new Floor will be put at the end of the Dungeon.
		/// WARNING: Dungeon must be editable, each Floor must be adjoining, Floor's name must be unique, level must be positive and the number of Square superior or equal to two.
		/// </summary>
		/// <param name="name">Floor's name, must be unique in this Dungeon.</param>
		/// <param name="description">Floor's description.</param>
		/// <param name="numberOfLines">Floor's number of line in the layout.</param>
		/// <param name="numberOfColumns">Floor's number of column in the layout.</param>
		/// <returns>New Floor's reference.</returns>
		public FloorStructure AddFloor( string name, string description, int numberOfLines, int numberOfColumns )
		{
			return AddFloor( _floorStructures.Count, name, description, numberOfLines, numberOfColumns );
		}

		/// <summary>
		/// Adds a new instance of <see cref="FloorStructure"/> class to this instance of <see cref="DungeonStructure"/> class.
		/// </summary>
		/// <param name="level">Floor's position, must be superior or equal to zero.</param>
		/// <param name="name">Floor's name, must be unique in this Dungeon.</param>
		/// <param name="description">Floor's description.</param>
		/// <param name="numberOfLines">Floor's number of line in the layout.</param>
		/// <param name="numberOfColumns">Floor's number of column in the layout.</param>
		/// <param name="floor">Floor's reference to recover.</param>
		/// <returns>If the Floor have been created and added.</returns>
		public bool TryAddFloor( int level, string name, string description, int numberOfLines, int numberOfColumns, out FloorStructure floor )
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
		/// Adds a new instance of <see cref="FloorStructure"/> class to this instance of <see cref="DungeonStructure"/> class.
		/// NOTE: new Floor will be put at the end of the Dungeon.
		/// </summary>
		/// <param name="name">Floor's name, must be unique in this Dungeon.</param>
		/// <param name="description">Floor's description.</param>
		/// <param name="numberOfLines">Floor's number of line in the layout.</param>
		/// <param name="numberOfColumns">Floor's number of column in the layout.</param>
		/// <param name="floor">Floor's reference to recover.</param>
		/// <returns>If the Floor have been created and added.</returns>
		public bool TryAddFloor( string name, string description, int numberOfLines, int numberOfColumns, out FloorStructure floor )
		{
			return TryAddFloor( _floorStructures.Count, name, description, numberOfLines, numberOfColumns, out floor );
		}
		#endregion

		#region Removes Floor methods
		/// <summary>
		/// Removes an instance of <see cref="FloorStructure"/> class of the current instance of <see cref="DungeonStructure"/> class.
		/// WARNING: Dungeon must be editable.
		/// </summary>
		/// <param name="floor">Reference of the Floor to remove.</param>
		public void RemoveFloor( FloorStructure floor )
		{
			if( !Editable ) throw new InvalidOperationException("Can not remove a Floor in not editable Dungeon");

			// Updating Floors' level
			foreach( FloorStructure aFloor in AllFloorStructures )
				if( aFloor.Level > floor.Level )
					aFloor.Level -= 1;

			_floorStructures.Remove( floor.Name );
		}

		/// <summary>
		/// Removes an instance of <see cref="FloorStructure"/> class of the current instance of <see cref="DungeonStructure"/> class.
		/// </summary>
		/// <param name="floor">Reference of the Floor to remove.</param>
		/// <returns>If the Floor has been found and removed.</returns>
		public bool TryRemoveFloor( FloorStructure floor )
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
		#endregion

		#region Gets Floor methods
		/// <summary>
		/// Gets the reference of the instance of <see cref="FloorStructure"/> class in the current instance of <see cref="DungeonStructure"/> class.
		/// WARNING: A Floor with this name must already exist.
		/// </summary>
		/// <param name="name">Floor's name.</param>
		/// <returns>Floor's reference.</returns>
		public FloorStructure GetFloor( string name )
		{
			FloorStructure floor;

			if( _floorStructures.TryGetValue( name, out floor ) )
				return floor;

			throw new ArgumentException( "Can not recover a Floor with this name." );
		}

		/// <summary>
		/// Gets the reference of the instance of <see cref="FloorStructure"/> class in the current instance of <see cref="DungeonStructure"/> class.
		/// WARNING: A Floor with at this level must already exist.
		/// </summary>
		/// <param name="name">Floor's name.</param>
		/// <returns>Floor's reference.</returns>
		public FloorStructure GetFloor( int level )
		{
			foreach( FloorStructure floor in AllFloorStructures )
				if( floor.Level == level )
					return floor;

			throw new ArgumentException( "Can not recover a Floor with at this level." );
		}

		/// <summary>
		/// Gets the reference of the instance of <see cref="FloorStructure"/> class in the current instance of <see cref="DungeonStructure"/> class.
		/// </summary>
		/// <param name="name">Floor's Name.</param>
		/// <param name="floor">Floor's reference to recover.</param>
		/// <returns>If the Floor have been found.</returns>
		public bool TryGetFloor( string name, out FloorStructure floor )
		{
			return _floorStructures.TryGetValue( name, out floor );
		}

		/// <summary>
		/// Gets the reference of the instance of <see cref="FloorStructure"/> class in the current instance of <see cref="DungeonStructure"/> class.
		/// </summary>
		/// <param name="level">Floor's level.</param>
		/// <param name="floor">Floor's reference to recover.</param>
		/// <returns>If the Floor have been found.</returns>
		public bool TryGetFloor( int level, out FloorStructure floor )
		{
			foreach( FloorStructure aFloor in AllFloorStructures )
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
		#endregion

		#region Checks Floor methods
		/// <summary>
		/// Checks if a Floor's instance exist with the specified name in the current instance of <see cref="DungeonStructure"/> class.
		/// </summary>
		/// <param name="name">Floor's name.</param>
		/// <returns>If the Floor have been found.</returns>
		public bool ExistFloor( string name )
		{
			return _floorStructures.ContainsKey( name );
		}

		/// <summary>
		/// Checks if a Floor's instance exist at the specified index in the current instance of <see cref="DungeonStructure"/> class.
		/// </summary>
		/// <param name="index">Floor's index.</param>
		/// <returns>If a Floor have been found.</returns>
		public bool ExistFloor( int level )
		{
			foreach( FloorStructure floor in AllFloorStructures )
				if( floor.Level == level )
					return true;
			return false;
		}
		#endregion
	}
}
