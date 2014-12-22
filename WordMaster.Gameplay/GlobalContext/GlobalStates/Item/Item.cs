using System;

namespace WordMaster.Gameplay
{
	[Serializable]
	public abstract class ItemType
    {
        string _name;
        string _description;

        /// <summary>
        /// Initializes a new instance of <see cref="ItemType"/> class.
        /// </summary>
        /// <param name="name">Item's name.</param>
        /// <param name="description">Item's description.</param>
        public ItemType( string name, string description )
        {
            _name = name;
            _description = description;
        }

    }
}
