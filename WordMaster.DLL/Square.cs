using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMaster.DLL
{
	public class Square
	{
		string _name;
		bool _holdable;

		/// <summary>
		/// Initializes a new instance of <see cref="Square"/> class.
		/// </summary>
		/// <param name="name">Type of the Square.</param>
		/// <param name="holdable">Holdable state of the Square.</param>
		internal Square( string name, bool holdable)
		{
			_name = name;
			_holdable = holdable;
			new Square( "stone wall", false );
		}

		/// <summary>
		/// Gets or sets the type of the Square.
		/// </summary>
		internal string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		/// <summary>
		/// Gets or sets the holdable state of the Square.
		/// </summary>
		internal bool Holdable
		{
			get { return _holdable; }
			set { _holdable = value; }
		}
	}
}
