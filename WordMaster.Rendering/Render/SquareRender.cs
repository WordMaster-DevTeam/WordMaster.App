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

			// Default colors (no textures yet)
			if( _square != null )
			{
				graphic.FillRectangle( new SolidBrush( Color.Gray ), rectangle );

				if( _square.Holdable ) // Holdable
					graphic.FillRectangle( new SolidBrush( Color.Beige ), rectangle );
				
				if( _square.TeleportTo != null ) // Teleport
					graphic.FillRectangle( new SolidBrush( Color.Orange ), rectangle );
				
				if( _square.Floor.Dungeon.Entrance != null ) // Entrance
				{
					if( _square.Floor.Dungeon.Entrance.Equals( this._square ) )
						graphic.FillRectangle( new SolidBrush( Color.Red ), rectangle );
				}

				if( _square.Floor.Dungeon.Exit != null ) // Exit
				{
					if( _square.Floor.Dungeon.Exit.Equals( this._square ) )
						graphic.FillRectangle( new SolidBrush( Color.Blue ), rectangle );
				}

				if( _floorRender.Character != null ) // Their is a Character in this Floor
				{
					if( _floorRender.Character.Square.Equals( this._square ) ) // Player
						color = new SolidBrush( Color.LightBlue );
				}
				else
				{
					graphic.FillRectangle( new SolidBrush( Color.Black ), rectangle );
				}
			}
			rectangle.Inflate( -(_floorRender.SquareRenderingWidth) / 12, -(_floorRender.SquareRenderingWidth) / 12 );
        }
	}
}
