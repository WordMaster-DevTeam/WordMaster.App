using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMaster.DLL
{
	public class Square
	{
		string _type;
		bool _isHoldable;

		/// <summary>
		/// Initializes a new instance of <see cref="Square"/> class.
		/// </summary>
		/// <param name="type">The type of the Square.</param>
		/// <param name="isHoldable">If a Character can stand or move to this Square</param>
		public Square( string type, bool isHoldable )
		{
			if( type.Trim() == string.Empty || type == null ) throw new ArgumentException( "Type must be specified.", "type" );

			_type = type;
			_isHoldable = isHoldable;
		}

		/// <summary>
		/// Gets or sets the type of the instance of <see cref="Square"/> class.
		/// </summary>
		public string Type
		{
			get { return _type; }
			set { _type = value; }
		}

        public bool Holdable
        {
            get { return _isHoldable; }
            set { _isHoldable = value; }
        }
	}
}
