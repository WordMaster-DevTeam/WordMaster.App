using System;

namespace WordMaster.DLL
{
	public class Square
	{
		readonly Floor _floor;
		readonly int _line, _column;
		string _name, _description;
		bool _holdable;
		Square _teleportTo;

		/// <summary>
		/// Initializes a new instance of <see cref="Square"/> class.
		/// </summary>
		/// <param name="floor">Floor's reference, each Square must be in a <see cref="Floor"/>.</param>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="name">Square's names.</param>
		/// <param name="description">Square's description</param>
		/// <param name="holdable">Square's Holdable state.</param>
		/// <param name="teleportTo">Square's reference to another Square where the player should teleport, sets holdable to true if set.</param>
		internal Square( Floor floor, int line, int column, string name, string description, bool holdable, Square teleportTo)
		{
			_floor = floor;
			_line = line;
			_column = column;
			_name = name;
			_description = description;

			if( teleportTo != null ) _holdable = true;
			else _holdable = holdable;
			_teleportTo = teleportTo;
		}

		/// <summary>
		/// Gets the reference of the instance <see cref="Floor"/> class where this instance of <see cref="Square"/> class is.
		/// </summary>
		public Floor Floor
		{
			get { return _floor; }
		}

		/// <summary>
		/// Gets or sets the name of this instance of <see cref="Square"/> class.
		/// </summary>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		/// <summary>
		/// Gets or sets the description of this instance of <see cref="Square"/> class.
		/// </summary>
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		/// <summary>
		/// Gets or sets the holdable state of this instance of <see cref="Square"/> class.
		/// </summary>
		public bool Holdable
		{
			get { return _holdable; }
			set
			{
				if( value == false ) _teleportTo = null;
				_holdable = value;
			}
		}

		/// <summary>
		/// Gets or sets the "teleport to" Square's reference of this instance <see cref="Square"/> class.
		/// </summary>
		public Square TeleportTo
		{
			get { return _teleportTo; }
			set
			{
				if( value != null ) _holdable = true;
				_teleportTo = value;
			}
		}
	}
}
