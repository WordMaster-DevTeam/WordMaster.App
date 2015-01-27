using System;

namespace WordMaster.Gameplay
{
	/// <summary>
	/// Holds default states for user's activated mechanism found in the dungeon. First layer. Serializable.
	/// </summary>
	[Serializable]
	public abstract class Mechanism
	{
		readonly SquareStructure _holder;
		string _name, _description;
		readonly bool _onlyOnceActivated;
		bool _concealed;

		/// <summary>
		/// Initializes a new instance of <see cref="Mechanism"/> class.
		/// </summary>
		/// <param name="holder">Square's reference, each <see cref="Mechanism"/> must be hold by a <see cref="SquareStructure"/></param>
		/// <param name="name">Trigger's name.</param>
		/// <param name="description">Trigger's description.</param>
		/// <param name="onlyOnceActivated">Trigger's activation occurence, set to false for one shoot, true to unlimited.</param>
		/// <param name="concealed">Trigger's concealment, set to false for a unconcelead trigger, true for an concelead one.</param>
		internal Mechanism( SquareStructure holder, string name, string description, bool onlyOnceActivated, bool concealed )
		{
			_holder = holder;
			_name = name;
			_description = description;
			_onlyOnceActivated = onlyOnceActivated;
			_concealed = concealed;
		}

		/// <summary>
		/// Gets the instance of <see cref="SquareStructure"/> class that holds this instance of <see cref="Mechanism"/> class.
		/// </summary>
		public SquareStructure Holder
		{
			get { return _holder; }
		}

		/// <summary>
		/// Gets or sets the name of this instance of <see cref="Mechanism"/> class.
		/// </summary>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		/// <summary>
		/// Gets or sets the description of this instance of <see cref="Mechanism"/> class.
		/// </summary>
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		/// <summary>
		/// Gets if this instance of <see cref="Mechanism"/> class can be use more than once.
		/// </summary>
		public bool OnlyOnceActivated
		{
			get { return _onlyOnceActivated; }
		}

		/// <summary>
		/// Gets or sets if this instance of <see cref="Mechanism"/> class should be seen.
		/// </summary>
		public bool Concealed
		{
			get { return _concealed; }
			set { _concealed = value; }
		}

		/// <summary>
		/// Activate this instance of <see cref="Mechanism"/> class for a <see cref="Character"/>.
		/// </summary>
		/// <param name="user">Character's reference, the user of this <see cref="Mechanism"/>.</param>
		internal virtual void Activate( Trigger trigger, Character user )
		{
		}
	}
}
