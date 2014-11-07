using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMaster.DLL
{
    public class Item
    {
        #region Attributes
        string _name;
        string _description;
        bool _equipable;
        bool _isEquiped;
        #endregion

        /// <summary>
        /// Initialize a new instance of <see cref="Item"/>, base builder.
        /// </summary>
        /// <param name="name">Can't be null, whitespace or empty.</param>
        /// <param name="description">Can't be null.</param>
        /// <param name="equipable"></param>
        /// <param name="equiped"></param>
        public Item(string name, string description, bool equipable, bool equiped)
        {
            #region Exception management
            if ( name == string.Empty || name == null || name == " " ) throw new ArgumentException( "Name can't be empty or null." );
            if ( description == null ) throw new ArgumentException( "Description can't be null" );
            #endregion

            #region Assignation
            _name = name;
            _description = description;
            _equipable = equipable;
            _isEquiped = equiped;
            #endregion
        }       
    }
}
