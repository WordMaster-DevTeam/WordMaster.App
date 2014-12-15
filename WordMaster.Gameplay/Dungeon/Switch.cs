using System;

namespace WordMaster.Gameplay
{
	public class Switch : Trigger
	{
		readonly Square _oldSquare;
		readonly Square _newSquare;

		/// <summary>
		/// Initializes a new instance of <see cref="Switch"/> class.
		/// </summary>
		/// <param name="holder">Square's reference, each <see cref="Trigger"/> must be hold by a <see cref="Square"/></param>
		/// <param name="name">Switch's name.</param>
		/// <param name="description">Switch's description.</param>
		/// <param name="onlyOnceActivated">Switch's activation occurence, set to false for one shoot, true to unlimited.</param>
		/// <param name="proximityActivated">Switch's activation mechanisme, set to false for one position activation, true to neighbors activation additionally.</param>
		/// <param name="hidden">Switch's concealment, set to false for a unconcelead trigger, true for an concelead one.</param>

		internal Switch( Square holder, string name, string description, bool onlyOnceActivated, bool proximityActivated, bool hidden, Square square)
			: base( holder, name, description, onlyOnceActivated, proximityActivated, hidden )
		{
			_newSquare = square;
			_oldSquare = holder.Floor[square.Line, square.Column];
		}

		/// <summary>
		/// Gets the Switch's target, or Switch's replacement if use a second time (if possible).
		/// </summary>
		public Square OldSquare
		{
			get { return _oldSquare; }
		}

		/// <summary>
		/// Gets the Switch's replacement, or Switch's target if use a second time (if possible).
		/// </summary>
		public Square NewSquare
		{
			get { return _newSquare; }
		}

		/// <summary>
		/// Activate this instance of <see cref="Switch"/> class for a <see cref="Character"/>.
		/// </summary>
		/// <param name="user">Character's reference, the user of this <see crefe="Trigger"/>.</param>
		internal override void Activate( Character user )
		{
			base.Activate(user);

			if( this.Active )
			{
				Square temp;

				if( NumberOfUses % 2 == 0 ) // Second activation and even activation only
					temp = _oldSquare;
				else // First activation and odd activation only
					temp = _newSquare;

				Holder.Floor[temp.Line, temp.Column] = temp;

				if( !user.Square.Floor.Equals( user.Floor ) )
					user.Floor = user.Square.Floor;
			}

		}
	}
}
