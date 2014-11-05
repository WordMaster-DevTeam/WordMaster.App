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
		readonly Dictionary<uint, Floor> _floors;

		/// <summary>
		/// Initializes a new instance of <see cref="Dungeon"/> class.
		/// </summary>
		/// <param name="name">The name (3 to 30 characters) of the Dungeon.</param>
		public Dungeon( string name )
		{
			if( name.Trim() == string.Empty || name == null ) throw new ArgumentException( "Dungeon's name must not be null, only filled with whitespaces or empty.", "name" );
			if( name.Length < 3 || name.Length > 30 ) throw new ArgumentException( "Dungeon's name must be a string of 3 to 30 characters.", "name" );

			_name = name;
		}

		/// <summary>
		/// Gets the name of the Dungeon
		/// </summary>
		public string Name
		{
			get { return _name; }
		}

		public void addFloor( string name, uint position )
		{
			throw new NotImplementedException();
		}

		public void addFloor( string name ) : this (name, _floors.Count) {}

		public Floor getFloor( string name )
		{
			throw new NotImplementedException();
		}

		public Floor getNextFloor( Floor currentFloor )
		{
			throw new NotImplementedException();
		}

		public Floor getPreviousFloor( Floor currentFloor )
		{
			throw new NotImplementedException();
		}
    }
}
