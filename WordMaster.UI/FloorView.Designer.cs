using System.Drawing;

namespace WordMaster.UI
{
    partial class FloorView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        private void FloorView_Paint( object sender, System.Windows.Forms.PaintEventArgs e )
        {
            Graphics graphic = this.CreateGraphics( );
            Pen holdablePen = new Pen( Color.Beige );
            Pen unholdblePen = new Pen( Color.Gray );
            Pen teleportToPen = new Pen( Color.LightGreen );
            Pen playerPen = new Pen( Color.LightBlue );

            graphic.DrawRectangle( playerPen, 2, 2, 50, 50 );
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FloorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Name = "FloorView";
            this.Size = new System.Drawing.Size(300, 300);
            this.Paint += new System.Windows.Forms.PaintEventHandler( this.FloorView_Paint );
            this.ResumeLayout(false);

        }

        #endregion

    }
}
