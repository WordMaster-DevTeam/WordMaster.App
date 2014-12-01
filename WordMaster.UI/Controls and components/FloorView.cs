using System;
using System.Drawing;
using System.Windows.Forms;
using WordMaster.Library;

namespace WordMaster.UI
{
	public class FloorView : Control
	{
		readonly Floor _floor;
        readonly ViewPort _viewPort;

		/// <summary>
		/// Initializes a new instance of <see cref="ViewPortOnly"/> class.
		/// </summary>
        public FloorView()
        {
            DoubleBuffered = true; // Graphical parameter (inherited)
            _floor = null; // Floor to display
            _viewPort = new ViewPort( _floor, 1 ); // ViewPort used to display the Floor
            _viewPort.AreaChanged += _viewPort_AreaChanged; // Call the event AreaChanged, that force the application to (re)draw the ViewPort
        }

		/// <summary>
		/// Get the current ViewPort used in this instance of <see cref="FloorView"/> class.
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
            _viewPort.SetClientSize( ClientSize );
            base.OnResize( e );
        }

		/// <summary>
		/// Move the ViewPort to the position.
		/// </summary>
		/// <param name="x">Horizontal's coordinate of the position.</param>
		/// <param name="y">Vertical's coordinate of the position.</param>
        public void ScrollTo( int x, int y )
        {
            _viewPort.MoveCoordinates( x, y );
        }

        protected override void OnPaint( PaintEventArgs e )
        {
            if( _viewPort == null || this.IsInDesignMode() )
            {
                e.Graphics.FillRectangle( Brushes.Yellow, e.ClipRectangle );
            }
            else
            {
                _viewPort.Draw( e.Graphics );
            }
            base.OnPaint( e );
        }

		private void InitializeComponent()
		{
			this.SuspendLayout();
			this.ResumeLayout(false);
		}

		//public FloorView()
		//{
		//	InitializeComponent();
		//}

		//public FloorView( IContainer container )
		//{
		//	container.Add( this );

		//	InitializeComponent();
		//}
	}
}
