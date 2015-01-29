using System;
using System.Drawing;
using WordMaster.Gameplay;
using System.IO;

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

			if( _square != null )
			{
                // Default
                using( var wall = new Bitmap( "C:/Users/b/Documents/Visual Studio 2013/Projects/WordMaster.App/WordMaster.App/textures/wall1.png" ) )
                using( var tBrush = new TextureBrush( wall ) )
                {
				    graphic.FillRectangle( tBrush, rectangle );
                }

				if( _square.Holdable ) // Holdable
                { 
                    using( var soil = new Bitmap( "C:/Users/b/Documents/Visual Studio 2013/Projects/WordMaster.App/WordMaster.App/textures/soil1.png" ) )
                    using( var tBrush = new TextureBrush( soil ) )
                    {
                        graphic.FillRectangle( tBrush, rectangle );
                    }
                }
                if( _square.TeleportTo != null ) // Teleport
                {
                    using ( var teleporter = new Bitmap( "C:/Users/b/Documents/Visual Studio 2013/Projects/WordMaster.App/WordMaster.App/textures/teleport1.png" ) )
                    using( var tBrush = new TextureBrush( teleporter ) )
                    {
                        graphic.FillRectangle( tBrush, rectangle );
                    }
                }
				if( _square.Floor.Dungeon.Entrance != null ) // Entrance
				{
                    if ( _square.Floor.Dungeon.Entrance.Equals( this._square ) )
                        using ( var entrance = new Bitmap( "C:/Users/b/Documents/Visual Studio 2013/Projects/WordMaster.App/WordMaster.App/textures/entrance1.png" ) )   
                        using ( var tBrush = new TextureBrush( entrance ) )
                        {
                            graphic.FillRectangle( tBrush, rectangle );
                        }
				}

				if( _square.Floor.Dungeon.Exit != null ) // Exit
				{
					if( _square.Floor.Dungeon.Exit.Equals( this._square ) )
                        using ( var exit = new Bitmap( "C:/Users/b/Documents/Visual Studio 2013/Projects/WordMaster.App/WordMaster.App/textures/exit1.png" ) )
                        using ( var tBrush = new TextureBrush( exit ) )
                        {
                            graphic.FillRectangle( tBrush, rectangle );
                        }
				}

				if( _floorRender.Character != null ) // Their is a Character in this Floor
				{
					if( _floorRender.Character.Square.Equals( this._square ) ) // Player
                        using ( var character = new Bitmap( "C:/Users/b/Documents/Visual Studio 2013/Projects/WordMaster.App/WordMaster.App/textures/character1.png" ) )
                        using ( var tBrush = new TextureBrush( character ) )
                        {                            
                            graphic.FillRectangle( tBrush, rectangle );
                        }
				}
				else
				{
					graphic.FillRectangle( new SolidBrush( Color.Black ), rectangle );
				}
			}
        }
	}
}
