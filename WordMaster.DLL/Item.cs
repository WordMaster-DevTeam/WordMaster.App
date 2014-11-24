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
        bool _equipable;
        bool _isEquiped;

        /// <summary>
        /// Initializes a new instance of <see cref="Item"/> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="equipable"></param>
        /// <param name="equiped"></param>
        public Item(string name, string description, bool equipable, bool equiped)
        {
			if( !NoMagicHelper.CheckNameLength( name ) ) throw new ArgumentException( "Name can't be empty or null." );
			if( !NoMagicHelper.CheckLongStringLength( description ) ) throw new ArgumentException( "Description can't be null" );

            _name = name;
            _description = description;
            _equipable = equipable;
            _isEquiped = equiped;
        }       
    }
}
