using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace WordMaster.Library
{
	public partial class Floor
	{
		readonly int _floorGraphicalSize, _floorGraphicalWidth;
        int _squareGraphicalWidth;

		/// <summary>
		/// Gets the maximum size for rendering the current <see cref="Floor"/>.
		/// This is the maximum of the <see cref="Floor.NumberOfLines"/> and <see cref="Floor.NumberOfColumns"/>
		/// </summary>
		public int FloorGraphicalSize
		{
			get
			{
 				if(NumberOfLines > NumberOfColumns)
					return NumberOfLines;
				else
					return NumberOfLines;
			}

		}

		/// <summary>
		/// Gets or sets the <see cref="Square"/> graphical width for rendering.
		/// This value can not be inferior to 1.
		/// </summary>
		public int SquareGraphicalWidth
		{
			get { return _squareGraphicalWidth; }
			set
			{
				if( value < 1 )
					_squareGraphicalWidth = 1;
				else
					_squareGraphicalWidth = value;
			}
		}

		/// <summary>
		/// Gets the <see cref="Floor"/> graphical width.
		/// Calculate in relation with <see cref="Floor.FloorGraphicalSize"/> and <see cref="Floor.SquareGraphicalWidth"/> width
		/// </summary>
		public int FloorGraphicalWidth
		{
			get { return FloorGraphicalSize * SquareGraphicalWidth;  }
		}


        /// <summary>
		/// Gets the total area used for represent the <see cref="Floor"/> (in centimeters).
        /// </summary>
        public Rectangle Area
        {
            get
			{
				return new Rectangle
				(
					0,
					0,
					_squareGraphicalWidth * _floorGraphicalSize,
					_squareGraphicalWidth * _floorGraphicalSize
				);
			}
        }

		/// <summary>
		/// Gets a list (read-only) of instances of <see cref="GSquareRenderInfo"/> class that are in a Rectangle (usually the view port)
		/// </summary>
		/// <param name="rectangle">Area that contains the desired <see cref="GSquare"/>.</param>
		/// <returns>A list a <see cref="SquareRenderInfos"/>.</returns>
        public IEnumerable<SquareRenderInfos> GetOverlappedSquares( Rectangle rectangle )
        {
            if( !Area.Contains( rectangle ) )
				throw new ArgumentException( "Floor area must contain the rectangle." );

            int top = rectangle.Top / _squareGraphicalWidth;
            int left = rectangle.Left / _squareGraphicalWidth;
            int bottom = (rectangle.Bottom - 1) / _squareGraphicalWidth;
            int right = (rectangle.Right - 1) / _squareGraphicalWidth;
			int offsetX = 0;
			int offsetY = 0;

            for( int i = top; i <= bottom; ++i )
            {
                for( int j = left; j <= right; ++j )
                {
                    Square currentSquare = _layout[i, j];
                    Debug.Assert( currentSquare.Area.IntersectsWith( rectangle ) );
                    Rectangle rectangleIntersect = rectangle;
                    rectangleIntersect.Intersect( currentSquare.Area );
                    rectangleIntersect.Offset( -currentSquare.Area.Left, -currentSquare.Area.Top );

                    if( j == left )
                    {
                        if( i == top )
                        {
                            offsetY = -rectangleIntersect.Y;
                        }
                        offsetX = -rectangleIntersect.X;
                    }
					// Returns one element of the list.
                    yield return new SquareRenderInfos( currentSquare, rectangleIntersect, offsetX, offsetY );

                    offsetX += _squareGraphicalWidth;
                }
                offsetY += _squareGraphicalWidth;
            }
        }
	}
}
