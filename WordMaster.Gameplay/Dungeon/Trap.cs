using System;

namespace WordMaster.Gameplay
{
	public class Trap : Trigger
	{	
		readonly bool _ignoreArmor;
		readonly int _intensity;

		/// <summary>
		/// Initializes a new instance of <see cref="Trap"/> class.
		/// </summary>
		/// <param name="holder">Square's reference, each <see cref="Trigger"/> must be hold by a <see cref="Square"/></param>
		/// <param name="name">Trap's name.</param>
		/// <param name="description">Trap's description.</param>
		/// <param name="onlyOnceActivated">Trap's activation occurence, set to false for one shoot, true to unlimited.</param>
		/// <param name="proximityActivated">Trap's activation mechanisme, set to false for one position activation, true to neighbors activation additionally.</param>
		/// <param name="hidden">Trap's concealment, set to false for a unconcelead trigger, true for an concelead one.</param>
		/// <param name="ignoreArmor">Trap's effect with armor, set to false to do not ignore armor, true will ignore it.</param>
		/// <param name="intensity">Trap's intensity, number of health point substract to a <see cref="Character"/> when activate.</param>
		internal Trap( Square holder, string name, string description, bool onlyOnceActivated, bool proximityActivated, bool hidden, bool ignoreArmor, int intensity )
			: base( holder, name, description, onlyOnceActivated, proximityActivated, hidden )
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
		/// Activate this instance of <see cref="Trap"/> class for a <see cref="Character"/>.
		/// </summary>
		/// <param name="user">Character's reference, the user of this <see crefe="Trigger"/>.</param>
		internal override void Activate( Character user )
		{
			if( this.Active )
			{
				if( IgnoreArmor ) user.Health -= Intensity;
				else user.Health -= (Intensity - user.Armor);
			}
			base.Activate( user );
		}
	}
}
