﻿using System;

namespace WordMaster.Gameplay
{
    [Serializable]
    public abstract class Item
    {
        
        string _name;
        string _description;
        Character _character;

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

        abstract public void Activate();
    }
}
