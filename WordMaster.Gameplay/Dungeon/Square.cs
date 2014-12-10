using System;

namespace WordMaster.Gameplay
{
	public class Square
	{
		readonly Floor _floor;
		readonly int _line, _column;
		string _name, _description;
		bool _holdable;
		Trigger _trigger;

		#region - DEPRECATED -
		Square _targetTeleport;

		/// <summary>
		/// DEPRECATED - Initializes a new instance of <see cref="Square"/> class.
		/// </summary>
		/// <param name="floor">Floor's reference, each Square must be in a <see cref="Floor"/>.</param>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="name">Square's names.</param>
		/// <param name="description">Square's description</param>
		/// <param name="holdable">Square's Holdable state.</param>
		/// <param name="targetTeleport">Square's reference to another Square where the player should teleport, sets holdable to true if set.</param>
		internal Square( Floor floor, int line, int column, string name, string description, bool holdable, Square targetTeleport)
		{
			_floor = floor;
			_line = line;
			_column = column;
			_name = name;
			_description = description;

			if( targetTeleport != null ) _holdable = true;
			else _holdable = holdable;

			_targetTeleport = targetTeleport;
		}

		/// <summary>
		/// DEPRECATED - Gets or sets the "teleport to" Square's reference of this instance of <see cref="Square"/> class.
		/// </summary>
		public Square TargetTeleport
		{
			get { return _targetTeleport; }
			set
			{
				if( value != null ) _holdable = true;
				_targetTeleport = value;
			}
		}
		#endregion

		/// <summary>
		/// Initializes a new instance of <see cref="Square"/> class.
		/// </summary>
		/// <param name="floor">Floor's reference, each Square must be in a <see cref="Floor"/>.</param>
		/// <param name="line">Square's horizontal coordinate.</param>
		/// <param name="column">Square's vertical coordinate.</param>
		/// <param name="name">Square's names.</param>
		/// <param name="description">Square's description</param>
		/// <param name="holdable">Square's Holdable state.</param>
		internal Square( Floor floor, int line, int column, string name, string description, bool holdable )
		{
			_floor = floor;
			_line = line;
			_column = column;
			_name = name;
			_description = description;
			_holdable = holdable;
		}

		/// <summary>
		/// Gets the reference of the instance <see cref="Floor"/> class where this instance of <see cref="Square"/> class is.
		/// </summary>
		public Floor Floor
		{
			get { return _floor; }
		}

		/// <summary>
		/// Gets the horizontal coordinate of this instance of <see cref="Square"/> in an instance of <see cref="Floor"/> class.
		/// </summary>
		public int Line
		{
			get { return _line; }
		}

		/// Gets the vertical coordinate of this instance of <see cref="Square"/> in an instance of <see cref="Floor"/> class.
		public int Column
		{
			get { return _column; }
		}

		/// <summary>
		/// Gets or sets the name of this instance of <see cref="Square"/> class.
		/// </summary>
		public string Name
		{
			get { return _name; }
			set { if( Floor.Dungeon.Editable ) _name = value; }
		}

		/// <summary>
		/// Gets or sets the description of this instance of <see cref="Square"/> class.
		/// </summary>
		public string Description
		{
			get { return _description; }
			set { if( Floor.Dungeon.Editable ) _description = value; }
		}

		/// <summary>
		/// Gets or sets the holdable state of this instance of <see cref="Square"/> class.
		/// </summary>
		public bool Holdable
		{
			get { return _holdable; }
			set { if( Floor.Dungeon.Editable ) _holdable = value;	}
		}

		/// <summary>
		/// Gets the current instance of <see cref="Trigger"/> used in this instance of <see cref="Square"/> class.
		/// </summary>
		public Trigger Trigger
		{
			get { return _trigger; }
		}

		/// <summary>
		/// Initializes a new instance of <see cref="Switch"/> class within this instance of <see cref="Square"/> class.
		/// NB: A Switch is a <see cref="Trigger"/>, their can be only ONE Trigger for each Square.
		/// </summary>
		/// <param name="name">Switch's name.</param>
		/// <param name="description">Switch's description.</param>
		/// <param name="onlyOnceActivated">Switch's activation occurence, set to false for one shoot, true to unlimited.</param>
		/// <param name="proximityActivated">Switch's activation mechanisme, set to false for one position activation, true to neighbors activation additionally.</param>
		/// <param name="hidden">Switch's concealment, set to false for a unconcelead trigger, true for an concelead one.</param>
		/// <param name="newSquare">Switch's replacement, or Switch's target if use a second time (if possible).</param>
		/// <returns>New Switch's reference.</returns>
		public Switch SetSwitch( string name, string description, bool onlyOnceActivated, bool proximityActivated, bool hidden, int targetLine, int targetColumn, string newName, string newDescription, bool holdable )
		{
			if( !Floor.Dungeon.Editable ) throw new InvalidOperationException( "Can not edit a Square in not editable Dungeon" );
			if( !Floor.CheckBounds(targetLine, targetColumn) ) throw new IndexOutOfRangeException( "Coordinates out of range." );

			_trigger = new Switch( this, name, description, onlyOnceActivated, proximityActivated, hidden, new Square(this.Floor, targetLine, targetColumn, newName, newDescription, holdable) );
			return (Switch)_trigger;
		}

		/// <summary>
		/// Initializes a new instance of <see cref="Teleport"/> class within this instance of <see cref="Square"/> class.
		/// NB: A Teleport is a <see cref="Trigger"/>, their can be only ONE Trigger for each Square.
		/// </summary>
		/// <param name="name">Teleport's name.</param>
		/// <param name="description">Teleport's description.</param>
		/// <param name="target">Square's reference, each Teleport must have a targeted Square to be use.</param>
		/// <param name="bidirectional">Square's direction property, automatically set the target's trigger to lead to this Trigger's holder.</param>
		/// <returns>New Teleport's reference.</returns>
		public Teleport SetTeleport( string name, string description, Square target, bool bidirectional )
		{
			if( !Floor.Dungeon.Editable ) throw new InvalidOperationException( "Can not edit a Square in not editable Dungeon" );
			if( target == null ) throw new ArgumentException( "Target can not be null", "target" );

			_holdable = true; // A Square with a Teleport must alway be holdable
			_trigger = new Teleport(this, name, description, target, bidirectional);
			return (Teleport)_trigger;
		}

		/// <summary>
		/// Initializes a new intance of <see cref="Trap"/> class within this instance of <see cref="Square"/> class.
		/// NB: A Trap is a <see cref="Trigger"/>, their can be only ONE Trigger for each Square.
		/// </summary>
		/// <param name="name">Trap's name.</param>
		/// <param name="description">Trap's description.</param>
		/// <param name="onlyOnceActivated">Trap's activation occurence, set to false for one shoot, true to unlimited.</param>
		/// <param name="proximityActivated">Trap's activation mechanisme, set to false for one position activation, true to neighbors activation additionally.</param>
		/// <param name="hidden">Trap's concealment, set to false for a unconcelead trigger, true for an concelead one.</param>
		/// <param name="ignoreArmor">Trap's effect with armor, set to false to do not ignore armor, true will ignore it.</param>
		/// <param name="intensity">Trap's intensity, number of health point substract to a <see cref="Character"/> when activate.</param>
		/// <returns>New Trap's reference.</returns>
		public Trap SetTrap( string name, string description, bool onlyOnceActivated, bool proximityActivated, bool hidden, bool ignoreArmor, int intensity )
		{
			if( !Floor.Dungeon.Editable ) throw new InvalidOperationException( "Can not edit a Square in not editable Dungeon" );

			_trigger = new Trap( this, name, description, onlyOnceActivated, proximityActivated, hidden, ignoreArmor, intensity );
			return (Trap)_trigger;
		}
	}
}
