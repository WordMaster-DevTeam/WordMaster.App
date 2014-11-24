using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMaster.DLL
{
    public class Item
    {
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
