using System;

namespace WordMaster.Gameplay
{
    public class Item
    {
        [Serializable]
        string _name;
        string _description;

        /// <summary>
        /// Initializes a new instance of <see cref="Item"/> class.
        /// </summary>
        /// <param name="name">Item's name.</param>
        /// <param name="description">Item's description.</param>
        public Item( string name, string description )
        {
            _name = name;
            _description = description;
        }       
    }
}
