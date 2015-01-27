using System;

namespace WordMaster.Gameplay
{
	/// <summary>
	/// Teleport's the player's character in another floor. First layer. Serializable.
	/// </summary>
	[Serializable]
	public class Teleport : Mechanism
	{
		readonly SquareStructure _target;
		readonly bool _bidirectional;

		/// <summary>
		/// Initializes a new instance of <see cref="Teleport"/> class.
		/// </summary>
		/// <param name="holder">Square's reference, each <see cref="Mechanism"/> must be hold by a <see cref="SquareStructure"/></param>
		/// <param name="name">Teleport's name.</param>
		/// <param name="description">Teleport's description.</param>
		/// <param name="target">Square's reference, each Teleport must have a targeted Square to be use.</param>
		/// <param name="bidirectional">Square's direction property, automatically set the target's trigger to lead to this Trigger's holder.</param>
		internal Teleport( SquareStructure holder, string name, string description, SquareStructure target, bool bidirectional )
			: base ( holder, name, description, false, false )
		{
			_target = target;
			_bidirectional = bidirectional;

			if( bidirectional ) target.SetTeleport( name, description, holder, false );
		}

		/// <summary>
		/// Gets the targeted <see cref="SquareStructure"/> where to teleport.
		/// </summary>
		public SquareStructure Target
		{
			get { return _target; }
		}

		/// <summary>
		/// Activates this instance of <see cref="Teleport"/> class for a <see cref="Character"/>.
		/// </summary>
		/// <param name="trigger"><see cref="Trigger"/>'s reference, the context of use of this <see cref="Teleport"/>.</param>
		/// <param name="user"><see cref="Character"/>'s reference, the user of this <see cref="Teleport"/>.</param>
		internal override void Activate( Trigger trigger, Character user )
		{
			if( trigger.Active )
			{
				Square origin = user.Square;
				user.Square = trigger.Holder.Floor.Dungeon.GetEquivalent( _target );
				user.Floor = trigger.Holder.Floor.Dungeon.GetEquivalent( _target.FloorStructure ); // Change automatically the user's Floor if needed
			}
			base.Activate( trigger, user );
		}
	}
}
