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
				if( !_square.Structure.Holdable ) // Not Holdable
					using( var wall = new Bitmap( "C:/Users/Tetrapak/Documents/Visual Studio 2013/Projects/ITI.Projects/WordMaster.App/textures/wall1.png" ) )
					using( var tBrush = new TextureBrush( wall ) )
					{
						graphic.FillRectangle( tBrush, rectangle );
					}
				else // Holdable
					using( var soil = new Bitmap( "C:/Users/Tetrapak/Documents/Visual Studio 2013/Projects/ITI.Projects/WordMaster.App/textures/soil1.png" ) )
					using( var tBrush = new TextureBrush( soil ) )
					{
						graphic.FillRectangle( tBrush, rectangle );
					}
				

				// Entrance
				if( _square.Structure.FloorStructure.DungeonStructure.Entrance != null )
					if( _square.Structure.FloorStructure.DungeonStructure.Entrance.Equals( _square.Structure ) ) // Entrance
						using( var entrance = new Bitmap( "C:/Users/Tetrapak/Documents/Visual Studio 2013/Projects/ITI.Projects/WordMaster.App/textures/entrance1.png" ) )   
                        using ( var tBrush = new TextureBrush( entrance ) )
                        {
                            graphic.FillRectangle( tBrush, rectangle );
                        }

				// Exit
				if( _square.Structure.FloorStructure.DungeonStructure.Exit != null )
					if( _square.Structure.FloorStructure.DungeonStructure.Exit.Equals( _square.Structure ) ) // Exit
						using( var exit = new Bitmap( "C:/Users/Tetrapak/Documents/Visual Studio 2013/Projects/ITI.Projects/WordMaster.App/textures/exit1.png" ) )
                        using ( var tBrush = new TextureBrush( exit ) )
                        {
                            graphic.FillRectangle( tBrush, rectangle );
                        }

				/* -- Triggers -- */
				if( _square.Trigger != null )
				{
					if( _square.Trigger.Mechanism is Teleport && !_square.Trigger.Mechanism.Concealed ) // Teleport
						using( var trigger_teleport = new Bitmap( "C:/Users/Tetrapak/Documents/Visual Studio 2013/Projects/ITI.Projects/WordMaster.App/textures/teleport1.png" ) )
						using( var tBrush = new TextureBrush( trigger_teleport ) )
						{
							graphic.FillRectangle( tBrush, rectangle );
						}
					else if( _square.Trigger.Mechanism is Switch && !_square.Trigger.Mechanism.Concealed ) // Switch
						using( var trigger_switch = new Bitmap( "C:/Users/Tetrapak/Documents/Visual Studio 2013/Projects/ITI.Projects/WordMaster.App/textures/switch1.png" ) )
						using( var tBrush = new TextureBrush( trigger_switch ) )
						{
							graphic.FillRectangle( tBrush, rectangle );
						}
					else if( _square.Trigger.Mechanism is Trap && !_square.Trigger.Mechanism.Concealed ) // Trap
						using( var trigger_trap = new Bitmap( "C:/Users/Tetrapak/Documents/Visual Studio 2013/Projects/ITI.Projects/WordMaster.App/textures/switch1.png" ) )
						using( var tBrush = new TextureBrush( trigger_trap ) )
						{
							graphic.FillRectangle( tBrush, rectangle );
						}
				}

				/* -- Monsters -- */
				if( _square.Monster != null )
				{
					if( _square.Monster.Ennemy is Levy ) // Levy
					{
						using( var monster_levy = new Bitmap( "C:/Users/Tetrapak/Documents/Visual Studio 2013/Projects/ITI.Projects/WordMaster.App/textures/monster1.png" ) )
						using( var tBrush = new TextureBrush( monster_levy ) )
						{
							graphic.FillRectangle( tBrush, rectangle );
						}
					}
					else if( _square.Monster.Ennemy is Veteran ) // Veteran
					{
						using( var monster_veteran = new Bitmap( "C:/Users/Tetrapak/Documents/Visual Studio 2013/Projects/ITI.Projects/WordMaster.App/textures/monster1.png" ) )
						using( var tBrush = new TextureBrush( monster_veteran ) )
						{
							graphic.FillRectangle( tBrush, rectangle );
						}
					}
					else if( _square.Monster.Ennemy is Elite ) // Elite
					{
						using( var monster_elite = new Bitmap( "C:/Users/Tetrapak/Documents/Visual Studio 2013/Projects/ITI.Projects/WordMaster.App/textures/monster1.png" ) )
						using( var tBrush = new TextureBrush( monster_elite ) )
						{
							graphic.FillRectangle( tBrush, rectangle );
						}
					}

				}

				/* -- Characters -- */
				if( _floorRender.Character != null )
				{
					if( _floorRender.Character.Square.Equals( this._square ) ) // Player
						using( var character = new Bitmap( "C:/Users/Tetrapak/Documents/Visual Studio 2013/Projects/ITI.Projects/WordMaster.App/textures/character1.png" ) )
						using( var tBrush = new TextureBrush( character ) )
						{
							graphic.FillRectangle( tBrush, rectangle );
						}
				}

				/* -- Fog of War -- */
				if( !_square.Visited )
				{
					if( _square.Seen ) // To fix - Bugggy behavior
					{
						using( var character = new Bitmap( "C:/Users/Tetrapak/Documents/Visual Studio 2013/Projects/ITI.Projects/WordMaster.App/textures/fogTransparent125.png" ) )
						using( var tBrush = new TextureBrush( character ) )
						{
							graphic.FillRectangle( tBrush, rectangle );
						}
					}
					else
					{
						using( var sBrush = new SolidBrush( Color.Black ) )
						{
							graphic.FillRectangle( sBrush, rectangle );
						}
					}
				}

				rectangle.Inflate( -(_floorRender.SquareRenderingWidth) / 12, -(_floorRender.SquareRenderingWidth) / 12 );
			}
		}
	}
}
