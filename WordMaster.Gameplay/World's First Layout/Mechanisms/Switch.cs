using System;

namespace WordMaster.Gameplay
{
	/// <summary>
	/// User's activated floor's modifier. First layer. Serializable.
	/// </summary>
	[Serializable]
	public class Switch : Mechanism
	{
		readonly SquareStructure _oldSquare;
		readonly SquareStructure _newSquare;

		/// <summary>
		/// Initializes a new instance of <see cref="Switch"/> class.
		/// </summary>
		/// <param name="holder">Square's reference, each <see cref="Mechanism"/> must be hold by a <see cref="SquareStructure"/></param>
		/// <param name="name">Switch's name.</param>
		/// <param name="description">Switch's description.</param>
		/// <param name="onlyOnceActivated">Switch's activation occurence, set to false for one shoot, true to unlimited.</param>
		/// <param name="concealed">Switch's concealment, set to false for a unconcelead trigger, true for an concelead one.</param>
		/// <param name="square">Substitute Square's reference.</param>
		internal Switch( SquareStructure holder, string name, string description, bool onlyOnceActivated, bool concealed, SquareStructure square)
			: base( holder, name, description, onlyOnceActivated, concealed )
		{
			_newSquare = square;
			_oldSquare = holder.FloorStructure[square.Line, square.Column];
		}

		/// <summary>
		/// Gets the Switch's target, or Switch's replacement if use a second time (if possible).
		/// </summary>
		public SquareStructure OldSquare
		{
			get { return _oldSquare; }
		}

		/// <summary>
		/// Gets the Switch's replacement, or Switch's target if use a second time (if possible).
		/// </summary>
		public SquareStructure NewSquare
		{
			get { return _newSquare; }
		}

		/// <summary>
		/// Activates this instance of <see cref="Switch"/> class for a <see cref="Character"/>.
		/// </summary>
		/// <param name="trigger"><see cref="Trigger"/>'s reference, the context of use of this <see cref="Switch"/>.</param>
		/// <param name="user"><see cref="Character"/>'s reference, the user of this <see cref="Switch"/>.</param>
		internal override void Activate( Trigger trigger, Character user )
		{
			if( trigger.Active )
			{
				if( trigger.NumberOfActivation % 2 == 0 ) // First activation and odd activation only
					trigger.Holder.Floor.ReprepareSquare( _newSquare );
				else // Second activation and even activation only
					trigger.Holder.Floor.ReprepareSquare( _oldSquare );
			}
			base.Activate( trigger, user );
		}
	}
}
