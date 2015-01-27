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
					_square.Structure.Column * _floorRender.SquareRenderingWidth,
					_square.Structure.Line * _floorRender.SquareRenderingWidth,
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

			if( _square != null )
			{
				/* -- Square -- */
				if( _square.Structure.Holdable ) // Holdable
					graphic.FillRectangle( new SolidBrush( Color.Beige ), rectangle );
				else // Not Holdable
					graphic.FillRectangle( new SolidBrush( Color.Gray ), rectangle );

				if( _square.Structure.FloorStructure.DungeonStructure.Entrance != null )
					if( _square.Structure.FloorStructure.DungeonStructure.Entrance.Equals( _square.Structure ) ) // Entrance
						graphic.FillEllipse( new SolidBrush( Color.DarkCyan ), rectangle );

				if( _square.Structure.FloorStructure.DungeonStructure.Exit != null )
					if( _square.Structure.FloorStructure.DungeonStructure.Exit.Equals( _square.Structure ) ) // Exit
						graphic.FillEllipse( new SolidBrush( Color.DarkBlue ), rectangle );

				/* -- Triggers -- */
				if( _square.Trigger != null )
				{
					if( _square.Trigger.Mechanism is Teleport && !_square.Trigger.Mechanism.Concealed ) // Teleport
						graphic.FillEllipse( new SolidBrush( Color.Yellow ), rectangle );
					else if( _square.Trigger.Mechanism is Switch && !_square.Trigger.Mechanism.Concealed ) // Switch
						graphic.FillEllipse( new SolidBrush( Color.Orange ), rectangle );
					else if( _square.Trigger.Mechanism is Trap && !_square.Trigger.Mechanism.Concealed ) // Trap
						graphic.FillEllipse( new SolidBrush( Color.Red ), rectangle );
				}

				/* -- Monsters -- */
				if( _square.Monster != null )
				{
					if( _square.Monster.Ennemy is Levy ) // Levy
					{
						graphic.FillEllipse( new SolidBrush( Color.Black ), rectangle );
						graphic.FillEllipse( new SolidBrush( Color.White ), new Rectangle(8, 8, _floorRender.SquareRenderingWidth - 16, _floorRender.SquareRenderingWidth - 16));
					}
					else if( _square.Monster.Ennemy is Veteran ) // Veteran
					{
						graphic.FillEllipse( new SolidBrush( Color.Black ), rectangle );
						graphic.FillEllipse( new SolidBrush( Color.White ), new Rectangle(4, 4, _floorRender.SquareRenderingWidth - 8, _floorRender.SquareRenderingWidth - 8));
					}
					else if( _square.Monster.Ennemy is Elite ) // Elite
					{
						graphic.FillEllipse( new SolidBrush( Color.Black ), rectangle );
						graphic.FillEllipse( new SolidBrush( Color.White ), new Rectangle(2, 2, _floorRender.SquareRenderingWidth - 4, _floorRender.SquareRenderingWidth - 4));
					}

				}

				/* -- Characters -- */
				if( _floorRender.Character != null )
				{
					if( _floorRender.Character.Square.Equals( this._square ) ) // Player
						graphic.FillEllipse( new SolidBrush( Color.LightBlue ), rectangle );
				}
			}

			rectangle.Inflate( -(_floorRender.SquareRenderingWidth) / 12, -(_floorRender.SquareRenderingWidth) / 12 );
		}
	}
}
