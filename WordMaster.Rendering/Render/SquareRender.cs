using System;
using System.Drawing;
using WordMaster.Gameplay;

namespace WordMaster.Rendering
{
	public class SquareRender
	{
		readonly FloorRender _floorRender;
		readonly Square _square;

		/// <summary>
		/// Initializes a new instance of <see cref="SquareRender"/> class.
		/// </summary>
		/// <param name="floorRender">FloorRender's reference, encapsulate this instance of SquareRender.</param>
		/// <param name="square">Square'reference, object to render.</param>
		internal SquareRender( FloorRender floorRender, Square square )
		{
			_floorRender = floorRender;
			_square = square;
		}

		/// <summary>
		/// Gets the instance of <see cref="FloorRender"/> class where this instance of <see cref="SquareRender"/> is.
		/// </summary>
		public FloorRender FloorRender
		{
			get { return _floorRender; }
		}

		/// <summary>
		/// Gets an Area witch indicates where this instance of <see cref="SquareRender"/> class representation is and witch size it is.
		/// </summary>
        public Rectangle Area
        {
            get
            {
                return new Rectangle
				(
					_square.Column * _floorRender.SquareRenderingWidth,
					_square.Line * _floorRender.SquareRenderingWidth,
					_floorRender.SquareRenderingWidth,
					_floorRender.SquareRenderingWidth 
				);
            }
        }

		/// <summary>
		/// Draws this instance of <see cref="SquareRender"/> class.
		/// </summary>
		/// <param name="graphic">Graphic used.</param>
		/// <param name="rectangleSource">Rectangle source (for optimisation purpose).</param>
		/// <param name="scaleFactor">Scale facter (for optimisation purpose).</param>
        public virtual void Draw( Graphics graphic, Rectangle rectangleSource, float scaleFactor )
        {
			Rectangle rectangle = new Rectangle( 0, 0, _floorRender.SquareRenderingWidth, _floorRender.SquareRenderingWidth );
			SolidBrush color;

			// Default color (no textures yet)
			if( _floorRender.Character.Square == _square )      color = new SolidBrush( Color.LightBlue );
			else if( _square.TeleportTo != null )               color = new SolidBrush( Color.Orange );
			else if( _square.Holdable )                         color = new SolidBrush( Color.Beige );
			else                                                color = new SolidBrush( Color.Gray );

			graphic.FillRectangle( color, rectangle );
			rectangle.Inflate( - (_floorRender.SquareRenderingWidth) / 12, - (_floorRender.SquareRenderingWidth) / 12 );
        }
	}
}
