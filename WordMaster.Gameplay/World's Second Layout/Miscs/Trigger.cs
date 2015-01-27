using System;

namespace WordMaster.Gameplay
{
	/// <summary>
	/// User's activated mechanism in a dungeon, can be teleport, trap, switch or another trigger. Second layer. Serializable.
	/// </summary>
	[Serializable]
	public class Trigger
	{
		public readonly Mechanism Mechanism;
		public readonly Square Holder;
		int _numberOfActivation; 

		/// <summary>
		/// Initializes a new instance of <see cref="Trigger"/> class.
		/// </summary>
		/// <param name="mechanism"></param>
		internal Trigger( Square holder, Mechanism mechanism )
		{
			Holder = holder;
			Mechanism = mechanism;
		}

		/// <summary>
		/// Gets if this instance <see cref="Trigger"/> class should be active.
		/// </summary>
		internal bool Active
		{
			get
			{
				if( Mechanism.OnlyOnceActivated == true && _numberOfActivation >= 1 )
					return false;
				else
					return true;
			}
		}

		/// <summary>
		/// Gets the number of activation of this instance of <see cref="Trigger"/> class.
		/// </summary>
		internal int NumberOfActivation
		{
			get { return _numberOfActivation; }
		}

		/// <summary>
		/// Activates this instance of <see cref="Trigger"/> class.
		/// </summary>
		/// <param name="user"><see cref="Character"/>'s reference.</param>
		internal void Activate( Character user )
		{
			Mechanism.Concealed = false;
			Mechanism.Activate( this, user );
			_numberOfActivation++;
		}
	}
}
