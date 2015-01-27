using System;

namespace WordMaster.Gameplay
{
	/// <summary>
	/// Holds the defaulst states and architecture of a single square in a dungeon. First layer. Serializable.
	/// </summary>
	[Serializable]
	public class SquareStructure
	{
		public readonly FloorStructure FloorStructure;
		Mechanism _mechanism;
		string _name, _description;
		readonly int _line, _column;
		bool _holdable;

		/// <summary>
		/// Initializes a new instance of <see cref="SquareStructure"/> class.
		/// </summary>
		/// <param name="floor"><see cref="FloorStructure"/>'s reference, each <see cref="SquareStructure"/> must be in a <see cref="FloorStructure"/>.</param>
		/// <param name="line"><see cref="SquareStructure"/>'s horizontal coordinate.</param>
		/// <param name="column"><see cref="SquareStructure"/>'s vertical coordinate.</param>
		/// <param name="name"><see cref="SquareStructure"/>'s names.</param>
		/// <param name="description"><see cref="SquareStructure"/>'s description</param>
		/// <param name="holdable"><see cref="SquareStructure"/>'s Holdable state.</param>
		internal SquareStructure( FloorStructure floor, int line, int column, string name, string description, bool holdable )
		{
			FloorStructure = floor;
			_line = line;
			_column = column;
			_name = name;
			_description = description;
			_holdable = holdable;
		}

		/// <summary>
		/// Gets the horizontal coordinate of this instance of <see cref="SquareStructure"/> in an instance of <see cref="Floor"/> class.
		/// </summary>
		public int Line
		{
			get { return _line; }
		}

		/// Gets the vertical coordinate of this instance of <see cref="SquareStructure"/> in an instance of <see cref="Floor"/> class.
		public int Column
		{
			get { return _column; }
		}

		/// <summary>
		/// Gets or sets the name of this instance of <see cref="SquareStructure"/> class.
		/// </summary>
		public string Name
		{
			get { return _name; }
			set { if( FloorStructure.DungeonStructure.Editable ) _name = value; }
		}

		/// <summary>
		/// Gets or sets the description of this instance of <see cref="SquareStructure"/> class.
		/// </summary>
		public string Description
		{
			get { return _description; }
			set { if( FloorStructure.DungeonStructure.Editable ) _description = value; }
		}

		/// <summary>
		/// Gets or sets the holdable state of this instance of <see cref="SquareStructure"/> class.
		/// </summary>
		public bool Holdable
		{
			get { return _holdable; }
			set { if( FloorStructure.DungeonStructure.Editable ) _holdable = value; }
		}

		/// <summary>
		/// Gets the current instance of <see cref="Mechanism"/> used in this instance of <see cref="SquareStructure"/> class.
		/// </summary>
		public Mechanism Mechanism
		{
			get { return _mechanism; }
		}

		#region Sets Triggers (Switch, Teleport, Trap, ...) methods
		/// <summary>
		/// Initializes a new instance of <see cref="Switch"/> class within this instance of <see cref="SquareStructure"/> class.
		/// NB: A Switch is a <see cref="Mechanism"/>, their can be only ONE Trigger for each Square. An unholdable Square holding a not proximity activated Trigger become holdable.
		/// WARNING: Dungeon must be editable, exchanged Square must be initialize.
		/// </summary>
		/// <param name="name">Switch's name.</param>
		/// <param name="description">Switch's description.</param>
		/// <param name="onlyOnceActivated">Switch's activation occurence, set to false for one shoot, true to unlimited.</param>
		/// <param name="concealed">Switch's concealment, set to false for a unconcelead trigger, true for an concelead one.</param>
		/// <param name="newSquare">Switch's replacement, or Switch's target if use a second time (if possible).</param>
		/// <returns>New Switch's reference.</returns>
		public Switch SetSwitch( string name, string description, bool onlyOnceActivated, bool concealed, SquareStructure exchanged )
		{
			if( !FloorStructure.DungeonStructure.Editable ) throw new InvalidOperationException( "Can not edit a Square in not editable Dungeon" );
			if( exchanged == null ) throw new ArgumentException( "Changed can not be null", "changed" );

			_holdable = true;
			_mechanism = new Switch( this, name, description, onlyOnceActivated, concealed, exchanged );
			return (Switch)_mechanism;
		}

		/// <summary>
		/// Initializes a new instance of <see cref="Teleport"/> class within this instance of <see cref="SquareStructure"/> class.
		/// NB: A Teleport is a <see cref="Mechanism"/>, their can be only ONE Trigger for each Square. An unholdable Square holding a not proximity activated Trigger become holdable.
		/// WARNING: Dungeon must be editable, target must be initialize.
		/// </summary>
		/// <param name="name">Teleport's name.</param>
		/// <param name="description">Teleport's description.</param>
		/// <param name="target">Square's reference, each Teleport must have a targeted Square to be use.</param>
		/// <param name="bidirectional">Square's direction property, automatically set the target's trigger to lead to this Trigger's holder.</param>
		/// <returns>New Teleport's reference.</returns>
		public Teleport SetTeleport( string name, string description, SquareStructure target, bool bidirectional )
		{
			if( !FloorStructure.DungeonStructure.Editable ) throw new InvalidOperationException( "Can not edit a Square in not editable Dungeon" );
			if( target == null ) throw new ArgumentNullException( "Target can not be null", "target" );

			_holdable = true;
			_mechanism = new Teleport( this, name, description, target, bidirectional );
			return (Teleport)_mechanism;
		}

		/// <summary>
		/// Initializes a new intance of <see cref="Trap"/> class within this instance of <see cref="SquareStructure"/> class.
		/// NB: A Trap is a <see cref="Mechanism"/>, their can be only ONE Trigger for each Square. An unholdable Square holding a not proximity activated Trigger become holdable.
		/// WARNING: Dungeon must be editable.
		/// </summary>
		/// <param name="name">Trap's name.</param>
		/// <param name="description">Trap's description.</param>
		/// <param name="onlyOnceActivated">Trap's activation occurence, set to false for one shoot, true to unlimited.</param>
		/// <param name="concealed">Trap's concealment, set to false for a unconcelead trigger, true for an concelead one.</param>
		/// <param name="ignoreArmor">Trap's effect with armor, set to false to do not ignore armor, true will ignore it.</param>
		/// <param name="intensity">Trap's intensity, number of health point substract to a <see cref="Character"/> when activate.</param>
		/// <returns>New Trap's reference.</returns>
		public Trap SetTrap( string name, string description, bool onlyOnceActivated, bool concealed, bool ignoreArmor, int intensity )
		{
			if( !FloorStructure.DungeonStructure.Editable ) throw new InvalidOperationException( "Can not edit a Square in not editable Dungeon" );

			_holdable = true;
			_mechanism = new Trap( this, name, description, onlyOnceActivated, concealed, ignoreArmor, intensity );
			return (Trap)_mechanism;
		}
		#endregion
	}
}
