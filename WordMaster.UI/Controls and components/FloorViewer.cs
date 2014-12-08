using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WordMaster.Gameplay;
using WordMaster.Rendering;

namespace WordMaster.UI
{
	public class FloorViewer : Control
	{
        ViewPort _viewPort;

		/// <summary>
		/// Initializes a new instance of <see cref="FloorViewer"/> class.
		/// </summary>
		public FloorViewer()
		{
			DoubleBuffered = true; // Graphical parameter (inherited)
			InitializeComponent();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="gameContext"></param>
		internal void Initialize( GameContext gameContext )
		{
			_viewPort = new ViewPort( new FloorRender( gameContext.Game.Character, gameContext.Game.Character.Floor ), 1 ); // ViewPort used to display the Floor
			_viewPort.AreaChanged += _viewPort_AreaChanged; // Force the application to (re)draw the ViewPort
		}

		/// <summary>
		/// Gets the current ViewPort used in this instance of <see cref="FloorViewer"/> class.
		/// </summary>
		public ViewPort ViewPort
		{
			get { return _viewPort; }
		}

		/// <summary>
		/// Force the application the redraw and object.
		/// </summary>
		/// <param name="sender">Caller object.</param>
		/// <param name="e">Event to handle.</param>
        void _viewPort_AreaChanged( object sender, EventArgs e )
        {
            Invalidate();
        }

		/// <summary>
		/// Reset the client's size.
		/// </summary>
		/// <param name="e">Event to handle.</param>
        protected override void OnResize( EventArgs e )
		{
			if( _viewPort != null ) _viewPort.SetClientSize( ClientSize );
            base.OnResize( e );
        }

		/// <summary>
		/// Move the ViewPort to the position.
		/// </summary>
		/// <param name="x">Horizontal's coordinate of the position.</param>
		/// <param name="y">Vertical's coordinate of the position.</param>
        public void ScrollTo( int x, int y )
        {
            if( _viewPort != null ) _viewPort.MoveCoordinates( x, y );
        }

        protected override void OnPaint( PaintEventArgs e )
        {
            if( _viewPort == null || this.IsInDesignMode() )
            {
                e.Graphics.FillRectangle( Brushes.Azure, e.ClipRectangle );
            }
            else
            {
				_viewPort.SetClientSize( ClientSize );
                _viewPort.Draw( e.Graphics );
            }
            base.OnPaint( e );
        }

		private void InitializeComponent()
		{
			this.SuspendLayout();
			this.ResumeLayout(false);
		}
	}
}
