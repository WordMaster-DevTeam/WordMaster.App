using System;
using System.Drawing;

namespace WordMaster.Library
{
	public partial class Square
	{
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
			SolidBrush color = ( TeleportTo != null ? new SolidBrush( Color.LightBlue ) : ( Holdable ? new SolidBrush( Color.Beige ) : new SolidBrush( Color.Gray ) ) );
			// NB: must found a way to represent the player

			graphic.FillRectangle( color, rectangle );
			rectangle.Inflate( - _floor.SquareGraphicalWidth / 12, - _floor.SquareGraphicalWidth / 12 );
        }
	}
}
