using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using WordMaster.Gameplay;

namespace WordMaster.Rendering
{
	public class FloorRender
	{
		CharacterBreed _character;
		FloorStructure _floor;
		SquareRender[,] _squaresRender;
		int _squareRenderingWidth;

		/// <summary>
		/// Recover an instance of <see cref="SquareRender"/> class using the [int, int] syntax.
		/// </summary>
		/// <param name="line">SquareRender's horizontale coordinate (same as the Square non render equivalent).</param>
		/// <param name="column">SquareRender's verticale coordinate (same as the Square non render equivalent).</param>
		/// <returns>SquareRender's reference.</returns>
		public SquareRender this[int line, int column]
		{
			get
			{
				if( _floor.CheckBounds( line, column ) ) // Inside the layout
					return _squaresRender[line, column];
				else // Outside the layout
					return null;
			}
		}

		/// <summary>
		/// Initializes a new instance of <see cref="FloorRender"/> class.
		/// </summary>
		/// <param name="character">Character's reference.</param>
		/// <param name="floor">Floor's reference.</param>
		public FloorRender( CharacterBreed character , FloorStructure floor )
		{
			_floor = floor;
			_character = character;
			_squaresRender = new SquareRender[_floor.NumberOfLines, _floor.NumberOfColumns];

			for( int i = 0; i < _floor.NumberOfLines; i++ )
				for( int j = 0; j < _floor.NumberOfColumns; j++ )
					_squaresRender[i, j] = new SquareRender( this, floor[i, j] );
		}

		/// <summary>
		/// Gets the instance of <see cref="Floor"/> class used.
		/// </summary>
		public FloorStructure Floor
		{
			get { return _floor; }
		}

		/// <summary>
		/// Gets or sets the <see cref="Character"/> used.
		/// </summary>
		public CharacterBreed Character
		{
			get { return _character; }
			set { _character = value; }
		}

		/// <summary>
		/// Gets the maximum size for rendering the current <see cref="FloorRender"/>.
		/// This is the maximum of the <see cref="FloorRender.NumberOfLines"/> and <see cref="FloorRender.NumberOfColumns"/>
		/// </summary>
		public int FloorRenderingSize
		{
			get
			{
 				if(_floor.NumberOfLines > _floor.NumberOfColumns)
					return _floor.NumberOfLines;
				else
					return _floor.NumberOfColumns;
			}

		}

		/// <summary>
		/// Gets or sets the <see cref="SquareRender"/> graphical width for rendering.
		/// This value would not be inferior to 1.
		/// </summary>
		public int SquareRenderingWidth
		{
			get
			{
				if( _squareRenderingWidth <= 0 )
					_squareRenderingWidth = 1;
				return _squareRenderingWidth;
			}
			set
			{
				if( value < 1 )
					_squareRenderingWidth = 1;
				else
					_squareRenderingWidth = value;
			}
		}

		/// <summary>
		/// Gets the <see cref="FloorRender"/> graphical width.
		/// Calculate in relation with <see cref="FloorRender.FloorRenderingSize"/> and <see cref="FloorRender.SquareRenderingWidth"/> width
		/// </summary>
		public int FloorRenderingWidth
		{
			get { return FloorRenderingSize * SquareRenderingWidth;  }
		}


        /// <summary>
		/// Gets the total area used for represent the <see cref="FloorRender"/> (in centimeters).
        /// </summary>
        public Rectangle Area
        {
            get
			{
				return new Rectangle
				(
					0,
					0,
					SquareRenderingWidth * FloorRenderingSize,
					SquareRenderingWidth * FloorRenderingSize
				);
			}
        }

		/// <summary>
		/// Gets a list (read-only) of instances of <see cref="GSquareRenderInfo"/> class that are in an instance of <see cref="Rectangle"/> class.
		/// </summary>
		/// <param name="rectangle">Area that contains the desired <see cref="SquareRender"/>.</param>
		/// <returns>A list a <see cref="SquareRenderInfos"/>.</returns>
        public IEnumerable<SquareRenderInfos> GetOverlappedSquares( Rectangle rectangle )
        {
            if( !Area.Contains( rectangle ) )
				throw new ArgumentException( "Floor area must contain the rectangle." );

            int top = rectangle.Top / _squareRenderingWidth;
            int left = rectangle.Left / _squareRenderingWidth;
            int bottom = (rectangle.Bottom - 1) / _squareRenderingWidth;
            int right = (rectangle.Right - 1) / _squareRenderingWidth;
			int offsetX = 0;
			int offsetY = 0;

            for( int i = top; i <= bottom; ++i )
            {
                for( int j = left; j <= right; ++j )
                {
                    SquareRender currentSquare = _squaresRender[i, j];
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
					// Returns one element of the list
                    yield return new SquareRenderInfos( currentSquare, rectangleIntersect, offsetX, offsetY );

                    offsetX += _squareRenderingWidth;
                }
                offsetY += _squareRenderingWidth;
            }
        }
	}
}
