using System;

namespace WordMaster.Gameplay
{
	public abstract class Trigger
	{
		readonly Square _holder;
		string _name, _description;
		readonly bool _onlyOnceActivated, _proximityActivated;
		bool _hidden, _active;
		int _count; 

		/// <summary>
		/// Initializes a new instance of <see cref="Trigger"/> class.
		/// </summary>
		/// <param name="holder">Square's reference, each <see cref="Trigger"/> must be hold by a <see cref="Square"/></param>
		/// <param name="name">Trigger's name.</param>
		/// <param name="description">Trigger's description.</param>
		/// <param name="onlyOnceActivated">Trigger's activation occurence, set to false for one shoot, true to unlimited.</param>
		/// <param name="proximityActivated">Trigger's activation mechanisme, set to false for one position activation, true to neighbors activation additionally.</param>
		/// <param name="hidden">Trigger's concealment, set to false for a unconcelead trigger, true for an concelead one.</param>
		internal Trigger( Square holder, string name, string description, bool onlyOnceActivated, bool proximityActivated, bool hidden )
		{
			_holder = holder;
			_name = name;
			_description = description;
			_onlyOnceActivated = onlyOnceActivated;
			_proximityActivated = proximityActivated;
			_hidden = hidden;
			_active = true;
		}

		/// <summary>
		/// Gets the instance of <see cref="Square"/> class that holds this instance of <see cref="Trigger"/> class.
		/// </summary>
		public Square Holder
		{
			get { return _holder; }
		}

		/// <summary>
		/// Gets or sets the name of this instance of <see cref="Trigger"/> class.
		/// </summary>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		/// <summary>
		/// Gets or sets the description of this instance of <see cref="Trigger"/> class.
		/// </summary>
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		/// <summary>
		/// Gets if this instance of <see cref="Trigger"/> class can be use more than once.
		/// </summary>
		public bool OnlyOnceActivated
		{
			get { return _onlyOnceActivated; }
		}

		/// <summary>
		/// Gets if this instance of <see cref="Trigger"/> class must be activate when holder's neighbors are visited.
		/// </summary>
		public bool ProximityActivated
		{
			get { return _proximityActivated; }
		}

		/// <summary>
		/// Gets or sets (inheritors only) if this instance of <see cref="Trigger"/> class is revealed.
		/// </summary>
		public bool Hidden
		{
			get { return _hidden; }
			protected set {_hidden = value; }
		}

		/// <summary>
		/// Gets or sets if this instance of <see cref="Trigger"/> class can be activate.
		/// NB: if this Trigger have already been used and can only be activated once, it CAN NOT be reactivate by this mean.
		/// </summary>
		public bool Active
		{
			get
			{
				if( _onlyOnceActivated && _count >= 1 ) _active = false;
				return _active;
			}
			set { _active = value; }
		}

		/// <summary>
		/// Gets the number of times this instance of <see cref="Trigger"/> class have been use.
		/// </summary>
		public int NumberOfUses
		{
			get { return _count; }
		}

		/// <summary>
		/// Activate this instance of <see cref="Trigger"/> class for a <see cref="Character"/>.
		/// </summary>
		/// <param name="user">Character's reference, the user of this <see cref="Trigger"/>.</param>
		internal virtual void Activate( Character user )
		{
			Hidden = false;
			_count++;
		}
	}
}
