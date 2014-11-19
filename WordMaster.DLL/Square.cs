using System;

namespace WordMaster.DLL
{
	public class Square
	{
		string _name;
		string _description;
		bool _holdable;

		/// <summary>
		/// Initializes a new instance of <see cref="Square"/> class.
		/// </summary>
		/// <param name="name">Type of the Square.</param>
		/// <param name="description">Description of the Square.</param>
		/// <param name="holdable">Holdable state of the Square.</param>
		internal Square( string name, string description, bool holdable)
		{
			_name = name;
			_description = description;
			_holdable = holdable;
		}

		/// <summary>
		/// Gets or sets the type of the Square.
		/// </summary>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		/// <summary>
		/// Gets or sets the description of the Square.
		/// </summary>
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		/// <summary>
		/// Gets or sets the holdable state of the Square.
		/// </summary>
		public bool Holdable
		{
			get { return _holdable; }
			set { _holdable = value; }
		}
	}
}
