namespace WordMaster.UI
{
    partial class Ingame
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Gameview = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Decriptionlbl = new System.Windows.Forms.Label();
            this.Levellbl = new System.Windows.Forms.Label();
            this.Lifelbl = new System.Windows.Forms.Label();
            this.Namelbl = new System.Windows.Forms.Label();
            this.Profilpicturebox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Wordslbl = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Respondlaunchbtn = new System.Windows.Forms.Button();
            this.mapbtn = new System.Windows.Forms.Button();
            this.Lastsavepointbtn = new System.Windows.Forms.Button();
            this.Savenquitbtn = new System.Windows.Forms.Button();
            this.WDversionlbl = new System.Windows.Forms.Label();
            this.Autouselbl = new System.Windows.Forms.Label();
            this.difficultylbl = new System.Windows.Forms.Label();
            this.Complementarylbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Gameview)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Profilpicturebox)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Gameview
            // 
            this.Gameview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Gameview.Location = new System.Drawing.Point(12, 12);
            this.Gameview.Name = "Gameview";
            this.Gameview.Size = new System.Drawing.Size(491, 451);
            this.Gameview.TabIndex = 0;
            this.Gameview.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.Decriptionlbl);
            this.panel1.Controls.Add(this.Levellbl);
            this.panel1.Controls.Add(this.Lifelbl);
            this.panel1.Controls.Add(this.Namelbl);
            this.panel1.Controls.Add(this.Profilpicturebox);
            this.panel1.Location = new System.Drawing.Point(509, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 302);
            this.panel1.TabIndex = 1;
            // 
            // Decriptionlbl
            // 
            this.Decriptionlbl.AutoSize = true;
            this.Decriptionlbl.Location = new System.Drawing.Point(7, 74);
            this.Decriptionlbl.Name = "Decriptionlbl";
            this.Decriptionlbl.Size = new System.Drawing.Size(63, 13);
            this.Decriptionlbl.TabIndex = 4;
            this.Decriptionlbl.Text = "Description:";
            // 
            // Levellbl
            // 
            this.Levellbl.AutoSize = true;
            this.Levellbl.Location = new System.Drawing.Point(76, 39);
            this.Levellbl.Name = "Levellbl";
            this.Levellbl.Size = new System.Drawing.Size(36, 13);
            this.Levellbl.TabIndex = 3;
            this.Levellbl.Text = "Level:";
            this.Levellbl.Click += new System.EventHandler(this.label3_Click);
            // 
            // Lifelbl
            // 
            this.Lifelbl.AutoSize = true;
            this.Lifelbl.Location = new System.Drawing.Point(76, 26);
            this.Lifelbl.Name = "Lifelbl";
            this.Lifelbl.Size = new System.Drawing.Size(27, 13);
            this.Lifelbl.TabIndex = 2;
            this.Lifelbl.Text = "Life:";
            // 
            // Namelbl
            // 
            this.Namelbl.AutoSize = true;
            this.Namelbl.Location = new System.Drawing.Point(76, 13);
            this.Namelbl.Name = "Namelbl";
            this.Namelbl.Size = new System.Drawing.Size(32, 13);
            this.Namelbl.TabIndex = 1;
            this.Namelbl.Text = "Nom:";
            // 
            // Profilpicturebox
            // 
            this.Profilpicturebox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Profilpicturebox.Location = new System.Drawing.Point(10, 9);
            this.Profilpicturebox.Name = "Profilpicturebox";
            this.Profilpicturebox.Size = new System.Drawing.Size(56, 62);
            this.Profilpicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Profilpicturebox.TabIndex = 0;
            this.Profilpicturebox.TabStop = false;
            this.Profilpicturebox.Click += new System.EventHandler(this.Profilpicturebox_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.Wordslbl);
            this.panel2.Location = new System.Drawing.Point(702, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(188, 302);
            this.panel2.TabIndex = 2;
            // 
            // Wordslbl
            // 
            this.Wordslbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Wordslbl.AutoSize = true;
            this.Wordslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wordslbl.Location = new System.Drawing.Point(56, 9);
            this.Wordslbl.Name = "Wordslbl";
            this.Wordslbl.Size = new System.Drawing.Size(74, 25);
            this.Wordslbl.TabIndex = 0;
            this.Wordslbl.Text = "Words";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(508, 329);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(382, 20);
            this.textBox1.TabIndex = 3;
            // 
            // Respondlaunchbtn
            // 
            this.Respondlaunchbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Respondlaunchbtn.Location = new System.Drawing.Point(508, 361);
            this.Respondlaunchbtn.Name = "Respondlaunchbtn";
            this.Respondlaunchbtn.Size = new System.Drawing.Size(188, 48);
            this.Respondlaunchbtn.TabIndex = 4;
            this.Respondlaunchbtn.Text = "Respond/launch";
            this.Respondlaunchbtn.UseVisualStyleBackColor = true;
            // 
            // mapbtn
            // 
            this.mapbtn.Location = new System.Drawing.Point(702, 361);
            this.mapbtn.Name = "mapbtn";
            this.mapbtn.Size = new System.Drawing.Size(188, 48);
            this.mapbtn.TabIndex = 5;
            this.mapbtn.Text = "Look to the map";
            this.mapbtn.UseVisualStyleBackColor = true;
            // 
            // Lastsavepointbtn
            // 
            this.Lastsavepointbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lastsavepointbtn.Location = new System.Drawing.Point(508, 415);
            this.Lastsavepointbtn.Name = "Lastsavepointbtn";
            this.Lastsavepointbtn.Size = new System.Drawing.Size(188, 48);
            this.Lastsavepointbtn.TabIndex = 6;
            this.Lastsavepointbtn.Text = "Return to last save point";
            this.Lastsavepointbtn.UseVisualStyleBackColor = true;
            // 
            // Savenquitbtn
            // 
            this.Savenquitbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Savenquitbtn.Location = new System.Drawing.Point(702, 415);
            this.Savenquitbtn.Name = "Savenquitbtn";
            this.Savenquitbtn.Size = new System.Drawing.Size(188, 48);
            this.Savenquitbtn.TabIndex = 7;
            this.Savenquitbtn.Text = "Save and quit";
            this.Savenquitbtn.UseVisualStyleBackColor = true;
            // 
            // WDversionlbl
            // 
            this.WDversionlbl.AutoSize = true;
            this.WDversionlbl.Location = new System.Drawing.Point(12, 466);
            this.WDversionlbl.Name = "WDversionlbl";
            this.WDversionlbl.Size = new System.Drawing.Size(94, 13);
            this.WDversionlbl.TabIndex = 5;
            this.WDversionlbl.Text = "Word Master vX.X";
            // 
            // Autouselbl
            // 
            this.Autouselbl.AutoSize = true;
            this.Autouselbl.Location = new System.Drawing.Point(266, 466);
            this.Autouselbl.Name = "Autouselbl";
            this.Autouselbl.Size = new System.Drawing.Size(84, 13);
            this.Autouselbl.TabIndex = 8;
            this.Autouselbl.Text = "Auto use potion:";
            // 
            // difficultylbl
            // 
            this.difficultylbl.AutoSize = true;
            this.difficultylbl.Location = new System.Drawing.Point(149, 466);
            this.difficultylbl.Name = "difficultylbl";
            this.difficultylbl.Size = new System.Drawing.Size(75, 13);
            this.difficultylbl.TabIndex = 9;
            this.difficultylbl.Text = "Difficulty level:";
            // 
            // Complementarylbl
            // 
            this.Complementarylbl.AutoSize = true;
            this.Complementarylbl.Location = new System.Drawing.Point(387, 466);
            this.Complementarylbl.Name = "Complementarylbl";
            this.Complementarylbl.Size = new System.Drawing.Size(116, 13);
            this.Complementarylbl.TabIndex = 10;
            this.Complementarylbl.Text = "Favorite chocolate bar:";
            // 
            // Ingame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 487);
            this.Controls.Add(this.Complementarylbl);
            this.Controls.Add(this.difficultylbl);
            this.Controls.Add(this.Autouselbl);
            this.Controls.Add(this.WDversionlbl);
            this.Controls.Add(this.Savenquitbtn);
            this.Controls.Add(this.Lastsavepointbtn);
            this.Controls.Add(this.mapbtn);
            this.Controls.Add(this.Respondlaunchbtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Gameview);
            this.Name = "Ingame";
            this.RightToLeftLayout = true;
            this.Text = "Word Master";
            this.Load += new System.EventHandler(this.Ingame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Gameview)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Profilpicturebox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Gameview;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Decriptionlbl;
        private System.Windows.Forms.Label Levellbl;
        private System.Windows.Forms.Label Lifelbl;
        private System.Windows.Forms.Label Namelbl;
        private System.Windows.Forms.PictureBox Profilpicturebox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Wordslbl;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Respondlaunchbtn;
        private System.Windows.Forms.Button mapbtn;
        private System.Windows.Forms.Button Lastsavepointbtn;
        private System.Windows.Forms.Button Savenquitbtn;
        private System.Windows.Forms.Label WDversionlbl;
        private System.Windows.Forms.Label Autouselbl;
        private System.Windows.Forms.Label difficultylbl;
        private System.Windows.Forms.Label Complementarylbl;
    }
}