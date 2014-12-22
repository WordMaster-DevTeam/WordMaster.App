using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMaster.Gameplay
{
	[Serializable]
	public class Teleport : Trigger
	{
		readonly SquareStructure _target;
		readonly bool _bidirectional;

		/// <summary>
		/// Initializes a new instance of <see cref="Teleport"/> class.
		/// </summary>
		/// <param name="holder">Square's reference, each <see cref="Trigger"/> must be hold by a <see cref="SquareStructure"/></param>
		/// <param name="name">Teleport's name.</param>
		/// <param name="description">Teleport's description.</param>
		/// <param name="target">Square's reference, each Teleport must have a targeted Square to be use.</param>
		/// <param name="bidirectional">Square's direction property, automatically set the target's trigger to lead to this Trigger's holder.</param>
		internal Teleport( SquareStructure holder, string name, string description, SquareStructure target, bool bidirectional )
			: base ( holder, name, description, false, false, false )
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
		/// Activate this instance of <see cref="Teleport"/> class for a <see cref="CharacterBreed"/>.
		/// </summary>
		/// <param name="user">Character's reference, the user of this <see cref="Trigger"/>.</param>
		internal override void Activate( CharacterBreed user )
		{
			SquareStructure origin = user.Square;
			user.Square = _target;

			if( !user.Square.Equals( _target.Floor ) ) // Change automatically the user's Floor if needed
				user.Floor = _target.Floor;

			base.Activate( user );
		}
	}
}
