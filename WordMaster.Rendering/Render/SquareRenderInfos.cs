using System;
using System.Drawing;

namespace WordMaster.Rendering
{
	public struct SquareRenderInfos
	{
		public readonly SquareRender Square;
        public readonly Rectangle RectangleSource;
        public readonly int HorizontalOffset, VerticalOffset;

		/// <summary>
		/// Initializes a new instance of <see cref="SquareRenderInfos"/> class.
		/// </summary>
		/// <param name="square">Square's reference to render.</param>
		/// <param name="rectangle">Area where the <see cref="GSquare"/> is rendered.</param>
		/// <param name="horizontalOffset">Horizontal Offset.</param>
		/// <param name="verticalOffset">Vertical Offset.</param>
		public SquareRenderInfos( SquareRender square, Rectangle rectangle, int horizontalOffset, int verticalOffset )
        {
            Square = square;
            RectangleSource = rectangle;
			HorizontalOffset = horizontalOffset;
            VerticalOffset = verticalOffset;
        }
	}
}
