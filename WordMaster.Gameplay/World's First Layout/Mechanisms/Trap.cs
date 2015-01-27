using System;

namespace WordMaster.Gameplay
{
	/// <summary>
	/// Hurts the player's character. First layer. Serializable.
	/// </summary>
	[Serializable]
	public class Trap : Mechanism
	{	
		readonly bool _ignoreArmor;
		readonly int _intensity;

		/// <summary>
		/// Initializes a new instance of <see cref="Trap"/> class.
		/// </summary>
		/// <param name="holder">Square's reference, each <see cref="Mechanism"/> must be hold by a <see cref="SquareStructure"/></param>
		/// <param name="name">Trap's name.</param>
		/// <param name="description">Trap's description.</param>
		/// <param name="onlyOnceActivated">Trap's activation occurence, set to false for one shoot, true to unlimited.</param>
		/// <param name="concealed">Trap's concealment, set to false for a unconcelead trigger, true for an concelead one.</param>
		/// <param name="ignoreArmor">Trap's effect with armor, set to false to do not ignore armor, true will ignore it.</param>
		/// <param name="intensity">Trap's intensity, number of health point substract to a <see cref="Character"/> when activate.</param>
		internal Trap( SquareStructure holder, string name, string description, bool onlyOnceActivated, bool concealed, bool ignoreArmor, int intensity )
			: base( holder, name, description, onlyOnceActivated, concealed )
		{
			_ignoreArmor = ignoreArmor;
			_intensity = intensity;
		}

		/// <summary>
		/// Gets if this <see cref="Trap"/> ignore <see cref="Character"/>'s armor.
		/// </summary>
		public bool IgnoreArmor
		{
			get { return _ignoreArmor; }
		}

		/// <summary>
		/// Gets this <see cref="Trap"/>'s intensity.
		/// </summary>
		public int Intensity
		{
			get { return _intensity; }
		}

		/// <summary>
		/// Activates this instance of <see cref="Trap"/> class for a <see cref="Character"/>.
		/// </summary>
		/// <param name="trigger"><see cref="Trigger"/>'s reference, the context of use of this <see cref="Switch"/>.</param>
		/// <param name="user"><see cref="Character"/>'s reference, the user of this <see cref="Trap"/>.</param>
		internal override void Activate( Trigger trigger, Character user )
		{
			if( trigger.Active )
			{
				if( IgnoreArmor ) user.CurrentHealth -= Intensity;
				else user.CurrentHealth -= (Intensity - user.Armor);
			}
			base.Activate( trigger, user );
		}
	}
}
