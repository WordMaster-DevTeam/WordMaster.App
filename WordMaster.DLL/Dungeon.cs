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
		/// <param name="name">The name (3 to 30 characters) of the Dungeon.</param>
		public Dungeon( string name )
		{
			if( NoMagicHelper.CheckLengthName( name ) ) throw new ArgumentException( "Dungeon's name must be a string of " + NoMagicHelper.MinLengthName + " to " + NoMagicHelper.MaxLengthName + " characters.", "name" );

			_name = name;
		}

		/// <summary>
		/// Gets the name of the Dungeon.
		/// </summary>
		public string Name
		{
			get { return _name; }
		}

		#region Add or remove Floor
		/// <summary>
		/// Adds a new instance of <see cref="Floor"/> class to the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="name">Name of the Floor to add.</param>
		/// <param name="position">Position of the Floor to add.</param>
		/// <returns>Reference of the new Floor.</returns>
		public Floor AddFloor( string name, int position )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Adds a new instance of <see cref="Floor"/> class after the last Floor to the current instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="name">Name of the Floor to add.</param>
		/// <returns>Reference of the new Floor.</returns>
		public Floor AddFloor( string name )
		{
			throw new NotImplementedException();
			//AddFloor( name, _floors.Count );
		}

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
		/// <param name="num">Number of the floor to delete.</param>
		/// <returns>True if the Floor has been found and delete.</returns>
		public bool DeleteFloor( int num )
		{
			throw new NotImplementedException();
		}
		#endregion

		#region Get current, next or previous Floor
		/// <summary>
		/// Gets a reference of an instance of <see cref="Floor"/> class, by name.
		/// </summary>
		/// <param name="name">Name of the Floor to get.</param>
		/// <returns>Reference of the Floor.</returns>
		public Floor GetFloor( string name )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets a reference of an instance of <see cref="Floor"/> class, by number.
		/// </summary>
		/// <param name="num">Number of the Floor to get (must be positive).</param>
		/// <returns>Reference of the current Floor.</returns>
		public Floor GetFloor( int num )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the reference of the next instance of <see cref="Floor"/> class, using reference of the current Floor.
		/// </summary>
		/// <param name="currentFloor">Reference of the current Floor.</param>
		/// <returns>Reference of the next Floor.</returns>
		public Floor GetNextFloor( Floor currentFloor )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the reference of the next instance of <see cref="Floor"/> class, using name of the current Floor.
		/// </summary>
		/// <param name="name">Name of the current Floor.</param>
		/// <returns>Reference of the next Floor.</returns>
		public Floor GetNextFloor( string name )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the reference of the next instance of <see cref="Floor"/> class, using number of the current Floor.
		/// </summary>
		/// <param name="num">Number of the current Floor.</param>
		/// <returns>Reference of the next Floor.</returns>
		public Floor GetNextFloor( int num )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the reference of the next instance of <see cref="Floor"/> class, using reference of the current Floor.
		/// </summary>
		/// <param name="currentFloor">Reference of the current Floor.</param>
		/// <returns>Reference of the previous Floor.</returns>
		public Floor GetPreviousFloor( Floor currentFloor )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the reference of the next instance of <see cref="Floor"/> class, using name of the current Floor.
		/// </summary>
		/// <param name="name">Name of the current Floor.</param>
		/// <returns>Reference of the previous Floor.</returns>
		public Floor GetPreviousFloor( string name )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the reference of the next instance of <see cref="Floor"/> class, using number of the current Floor.
		/// </summary>
		/// <param name="num">Number of the current Floor.</param>
		/// <returns>Reference of the previous Floor.</returns>
		public Floor GetPreviousFloor( int num )
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
