using System;
using System.Drawing;

namespace WordMaster.Library
{
	public struct SquareRenderInfos
	{
		public readonly Square Square;
        public readonly Rectangle RectangleSource;
        public readonly int HorizontalOffset, VerticalOffset;

		/// <summary>
		/// Initializes a new instance of <see cref="GSquareRenderInfo"/> class.
		/// </summary>
		/// <param name="square">Square's reference to render.</param>
		/// <param name="rectangle">Area where the <see cref="GSquare"/> is rendered.</param>
		/// <param name="horizontalOffset">Horizontal Offset.</param>
		/// <param name="vrticalOffset">Vertical Offset.</param>
		public SquareRenderInfos( Square square, Rectangle rectangle, int horizontalOffset, int vrticalOffset )
        {
            Square = square;
            RectangleSource = rectangle;
			HorizontalOffset = horizontalOffset;
            VerticalOffset = vrticalOffset;
        }
	}
}
