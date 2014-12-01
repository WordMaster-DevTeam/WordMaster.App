using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WordMaster.Library
{
	public class ViewPort
	{
		readonly Floor _floor;
		readonly int _minDisplayWidth;
		Rectangle _viewPortArea;
		double _userZoomFactor;
		int _maxClientSize;
		float _clientScaleFactor;

		/// <summary>
		/// Initializes a new instance of <see cref="ViewPort"/> class.
		/// </summary>
		/// <param name="floor">Floor's reference to display.</param>
		/// <param name="minDisplayMeters">Minimum display width (in meters).</param>
		public ViewPort( Floor floor, int minDisplayMeters )
		{
			_floor = floor;
			_viewPortArea = floor.Area;
			_userZoomFactor = 0.0;
			_minDisplayWidth = minDisplayMeters * 100;
		}

		/// <summary>
		/// Gets the current instance of <see cref="Floor"/> class displayed.
		/// </summary>
		public Floor Floor
		{
			get { return _floor; }
		}

		/// <summary>
		/// Gets if the horizontal scroll is usable.
		/// </summary>
		public bool HorizontalScrollEnabled
		{
			get { return _viewPortArea.Width < _floor.FloorGraphicalWidth; }
		}

		/// <summary>
		/// Gets if the vertical scroll is usable.
		/// </summary>
		public bool VerticalScrollEnabled
		{
			get { return _viewPortArea.Height < Floor.Area.Height; }
		}

		/// <summary>
		/// Gets the minimum zoom factor (in relation with minimum display width and graphical floor's size).
		/// </summary>
		public double MinActualZoomFactor
		{
			get { return (double)_minDisplayWidth / (double)_floor.FloorGraphicalWidth; }
		}

		/// <summary>
		/// Gets the zoom factor between <see cref="MinActualZoomFactor"/> (closest) and 1.0 (seeing the whole map).
		/// </summary>
		public double ZoomFactor
		{
			get { return (double)Math.Max( _viewPortArea.Width, _viewPortArea.Height ) / (double)_floor.FloorGraphicalWidth; }
		}

		/// <summary>
		/// Gets the current area of this ViewPort (in centimeters).
		/// </summary>
		public Rectangle Area
		{
			get { return _viewPortArea; }
		}

		/// <summary>
		/// Fires whenever <see cref="Area"/> has changed.
		/// </summary>
		public event EventHandler AreaChanged;

		/// <summary>
		/// Gets or sets the zoom factor from 0.0 (seeing the whole map) to 1.0 (closest).
		/// This is the reverse of the <see cref="ZoomFactor"/> and in the range [0.0, 1.0].
		/// </summary>
		public double UserZoomFactor
		{
			get { return _userZoomFactor; }
			set
			{
				if( value <= 0 )
				{
					_userZoomFactor = 0.0;
					SetZoomFactor( 1.0 );
				}
				else if( value >= 1.0 )
				{
					_userZoomFactor = 1.0;
					SetZoomFactor( MinActualZoomFactor );
				}
				else
				{
					_userZoomFactor = value;
					SetZoomFactor( (1.0 - value) * (1.0 - MinActualZoomFactor) + MinActualZoomFactor );
				}
			}
		}

		/// <summary>
		/// Gets the client scale factor.
		/// </summary>
		public float ClientScaleFactor
		{
			get { return _clientScaleFactor; }

		}

		/// <summary>
		/// Sets width, height and scale factor and move this instance of <see cref="ViewPort"/> class.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		bool SetZoomFactor( double value )
		{
			Debug.Assert( _floor.Area.Contains( _viewPortArea ) );

			// Check the value parameter, can not be superior to zero, or inferior to the minimun zoom factor, or inferior not equal to the smaller positive double 
			if( value > 1.0 )
				value = 1.0;
			else if( value < MinActualZoomFactor )
				value = MinActualZoomFactor;
			if( Math.Abs( value - ZoomFactor ) <= Double.Epsilon )
				return false;

			// Check the width, can not be inferior to minimun display width
			double grow = value / ZoomFactor;
			int newWidth = (int)Math.Round( _viewPortArea.Width * grow );
			if( newWidth < _minDisplayWidth )
				newWidth = _minDisplayWidth;

			// Check the height, can not be inferior to minimun display width too
			int newHeight = (int)Math.Round( _viewPortArea.Height * grow );
			if( newHeight < _minDisplayWidth )
				newHeight = _minDisplayWidth;

			// Check if a movement have occur using deltas
			int deltaW = (newWidth - _viewPortArea.Width) / 2;
			int deltaH = (newHeight - _viewPortArea.Height) / 2;
			if( deltaW == 0 && deltaH == 0 )
				return false;

			// Set new width and height for the view port, move, and set new client scale factor
			_viewPortArea.Width = newWidth;
			_viewPortArea.Height = newHeight;
			Move( ref _viewPortArea, -deltaW, -deltaW );
			Debug.Assert( _floor.Area.Contains( _viewPortArea ) );
			_clientScaleFactor = (float)_maxClientSize / (float)Math.Max( _viewPortArea.Width, _viewPortArea.Height );

			// ???
			var h = AreaChanged;
			if( h != null )
				h( this, EventArgs.Empty );

			return true;
		}

		/// <summary>
		/// Move using deltas
		/// </summary>
		/// <param name="deltaX">Horizontal delta.</param>
		/// <param name="deltaY"></param>
		public void MoveDelta( int deltaX, int deltaY )
		{
			if( Move( ref _viewPortArea, deltaX, deltaY ) )
			{
				var h = AreaChanged;
				if( h != null )
					h( this, EventArgs.Empty );
			}
		}

		/// <summary>
		/// Move using coordinates.
		/// </summary>
		/// <param name="line">Horizontal coordinate.</param>
		/// <param name="column">Vertical coordinate.</param>
		public void MoveCoordinates( int line, int column )
		{
			MoveDelta( line - _viewPortArea.X, column - _viewPortArea.Y );
		}

		/// <summary>
		/// ...
		/// </summary>
		/// <param name="rectangle"></param>
		/// <param name="deltaX"></param>
		/// <param name="deltaY"></param>
		/// <returns></returns>
		bool Move( ref Rectangle rectangle, int deltaX, int deltaY )
		{
			int previousX = rectangle.X;
			int previousY = rectangle.Y;
			rectangle.Offset( deltaX, deltaY );

			if( rectangle.X < 0 )
				rectangle.X = 0;
			else
			{
				int overflow = rectangle.Right - _floor.FloorGraphicalWidth;
				if( overflow > 0 )
				{
					rectangle.X -= overflow;
					if( rectangle.X < 0 )
					{
						rectangle.X = 0;
						rectangle.Width = _floor.FloorGraphicalWidth;
					}
				}
			}

			if( rectangle.Y < 0 )
				rectangle.Y = 0;
			else
			{
				int overflow = rectangle.Bottom - _floor.FloorGraphicalWidth;
				if( overflow > 0 )
				{
					rectangle.Y -= overflow;
					if( rectangle.Y < 0 )
					{
						rectangle.Y = 0;
						rectangle.Height = _floor.FloorGraphicalWidth;
					}
				}
			}

			Debug.Assert( _floor.Area.Contains( rectangle ) );
			return previousX != rectangle.X || previousY != rectangle.Y;
		}

		/// <summary>
		/// Sets the client's size.
		/// </summary>
		/// <param name="client">Current client's size.</param>
		internal void SetClientSize( Size client )
		{
			Debug.Assert( _floor.Area.Contains( _viewPortArea ) );
			_maxClientSize = Math.Max( client.Width, client.Height );
			Rectangle newViewPort = _viewPortArea;
			bool keepHeight = _viewPortArea.Height > _viewPortArea.Width || (_viewPortArea.Height == _viewPortArea.Width && client.Height > client.Width);

			if( keepHeight )
			{
				_clientScaleFactor = (float)_maxClientSize / (float)_viewPortArea.Height;
				newViewPort.Width = (int)Math.Ceiling( _viewPortArea.Height * client.Width / (double)_maxClientSize );

				if( newViewPort.Width < _minDisplayWidth )
					newViewPort.Width = _minDisplayWidth;
				if( newViewPort.Right > _floor.FloorGraphicalWidth )
					Move( ref newViewPort, _floor.FloorGraphicalWidth - newViewPort.Right, 0 );
			}
			else
			{
				_clientScaleFactor = (float)_maxClientSize / (float)_viewPortArea.Width;
				newViewPort.Height = (int)Math.Ceiling( _viewPortArea.Width * client.Height / (double)_maxClientSize );

				if( newViewPort.Height < _minDisplayWidth )
					newViewPort.Height = _minDisplayWidth;
				if( newViewPort.Bottom > _floor.Area.Height )
					Move( ref newViewPort, 0, _floor.Area.Height - newViewPort.Bottom );
			}

			Debug.Assert( _floor.Area.Contains( newViewPort ) );
			_viewPortArea = newViewPort;
			_clientScaleFactor = (float)_maxClientSize / (float)Math.Max( _viewPortArea.Width, _viewPortArea.Height );

			var h = AreaChanged;
			if( h != null )
				h( this, EventArgs.Empty );
		}

		/// <summary>
		/// Draws all the Squares of this instance of <see cref="ViewPort "/> in the current view port area.
		/// </summary>
		/// <param name="graphic">Graphic's instance used.</param>
		internal void Draw( Graphics graphic )
		{
			Debug.Assert( _floor.Area.Contains( _viewPortArea ) );
			Matrix origin = graphic.Transform;
			graphic.ResetTransform();
			graphic.ScaleTransform( _clientScaleFactor, _clientScaleFactor );
			Matrix local = graphic.Transform;

			// Render each Square of the Floor.
			foreach( var renderInfo in _floor.GetOverlappedSquares( _viewPortArea ) )
			{
				graphic.TranslateTransform( renderInfo.HorizontalOffset, renderInfo.VerticalOffset );
				renderInfo.Square.Draw( graphic, renderInfo.RectangleSource, _clientScaleFactor );
				graphic.Transform = local;
			}

			graphic.Transform = origin;
		}
	}
}
