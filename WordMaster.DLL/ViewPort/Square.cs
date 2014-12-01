using System;
using System.Drawing;

namespace WordMaster.Library
{
	public partial class Square
	{
		// For tests purpose only
		static SolidBrush _unholdableSquareDefault = new SolidBrush( Color.Gray );
		static SolidBrush _holdableSquareDefault = new SolidBrush( Color.Beige );
		static SolidBrush _teleportSquareDefault = new SolidBrush( Color.Orange );
		static SolidBrush _playerDefault = new SolidBrush( Color.LightBlue );
		static Random _random = new Random();
		// ----------------------------

		/// <summary>
		/// Gets an Area witch indicates where this instance of <see cref="Square"/> class representation is and witch size it is.
		/// </summary>
        public Rectangle Area
        {
            get
            {
                return new Rectangle
				( 
					_column * _floor.SquareGraphicalWidth,
					_line * _floor.SquareGraphicalWidth,
					_floor.SquareGraphicalWidth,
					_floor.SquareGraphicalWidth 
				);
            }
        }

		/// <summary>
		/// Draws this instance of <see cref="Square"/> class.
		/// </summary>
		/// <param name="graphic">Graphic used.</param>
		/// <param name="rectangleSource">Rectangle source (for optimisation purpose).</param>
		/// <param name="scaleFactor">Scale facter (for optimisation purpose).</param>
        public virtual void Draw( Graphics graphic, Rectangle rectangleSource, float scaleFactor )
        {
            Rectangle rectangle = new Rectangle( 0, 0, _floor.SquareGraphicalWidth, _floor.SquareGraphicalWidth );

			// For tests purpose only
			SolidBrush _color;
			if( _random.Next( 100 ) == 1 ) // Player location
				_color = _playerDefault;
			else
				if( _random.Next( 100 ) < 3 ) // Teleport to Square
					_color = _teleportSquareDefault;
				else
					if( _random.Next( 100 ) < 30 ) // Holdable Square
						_color = _unholdableSquareDefault;
					else // Unholdable Square
						_color = _holdableSquareDefault;
			// ----------------------------

			graphic.FillRectangle( _color, rectangle );
			rectangle.Inflate( - _floor.SquareGraphicalWidth / 12, - _floor.SquareGraphicalWidth / 12 );
        }
	}
}
